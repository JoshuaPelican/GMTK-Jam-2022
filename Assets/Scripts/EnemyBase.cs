using UnityEngine;

public class EnemyBase : Entity
{
    [SerializeField] Enemy Enemy;
    DiceRoller roller;

    [SerializeField] float RollFrequency = 0.01f;
    [SerializeField] float rollCooldown = 0.25f;
    float t;

    [SerializeField] private Transform damagePopup, heavyDmgPopup;

    private void Awake()
    {
        SetTarget(GameObject.FindWithTag("Player").GetComponent<Player>());
        Streak.Value = 1;
    }

    protected override void Initialize()
    {
        health.Value = Enemy.MaxHealth;
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
            float percentStreak = (0.5f / Streak.Value) * Enemy.Difficulty;
            float percentRandomRoll = Mathf.Clamp01(-(0.05f * Enemy.Difficulty) + 0.334f);

            if (roller.CurrentDiceValue > 3 && Random.value <= percentStreak) 
            {
                roller.StopCurrentDice();
                t = 0;
            }
            else if(Random.value <= percentRandomRoll)
            {
                roller.StopCurrentDice();
                t = 0;
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
        
        //find player equped weapon.numdice = int num dice
        //if(damage >= num dice * 5){HeavyDamageTextPopup}
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
