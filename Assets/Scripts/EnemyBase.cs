using UnityEngine;

public class EnemyBase : Entity
{
    [SerializeField] Enemy Enemy;
    DiceRoller roller;

    [SerializeField] float RollFrequency = 0.01f;
    [SerializeField] float rollCooldown = 0.25f;
    float t;

    [SerializeField] private Transform damagePopup;

    private void Awake()
    {
        SetTarget(GameObject.FindWithTag("Player").GetComponent<Player>());
    }

    protected override void Initialize()
    {
        health = Enemy.MaxHealth;
    }

    protected override void StartTurn(GameState gameState)
    {
        if (gameState != GameState.Enemy)
            return;

        roller = UseAttack(Enemy.NumberOfAttackDice);
    }

    private void FixedUpdate()
    {
        if (!roller)
            return;

        t += Time.deltaTime;

        if(Random.value <= RollFrequency && t >= rollCooldown)
        {
            float percentStreak = Mathf.Pow(Streak.Value / 10, 1 / Enemy.Difficulty);
            float percentRandomRoll = 0.25f / Enemy.Difficulty;

            if (roller.CurrentDiceValue > 3 && Random.value <= percentStreak) 
            {
                roller.StopCurrentDice();
                rollCooldown = 0;
            }
            else if(Random.value <= percentRandomRoll)
            {
                roller.StopCurrentDice();
                rollCooldown = 0;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (damagePopup != null)
        {
            DamageTextPopup(damage);
        }
    }

    public void DamageTextPopup(int damage)
    {
        Transform DamagePopupTransform = Instantiate(damagePopup, transform);
        DamagePopup _damagePopup = DamagePopupTransform.GetComponent<DamagePopup>();
        _damagePopup.Setup(damage);
    }

    protected override void Die()
    {
        Debug.Log("Enemy " + name + " has Died!");
        Destroy(gameObject);
        GameManager.Instance.ChangeGameState(GameState.Map);
    }

    protected override void EndTurn()
    {
        GameManager.Instance.ChangeGameState(GameState.Player);
    }
}
