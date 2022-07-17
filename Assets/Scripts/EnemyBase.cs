using UnityEngine;

public class EnemyBase : Entity
{
    [SerializeField] Enemy Enemy;
    DiceRoller roller;

    [SerializeField] float RollFrequency = 0.01f;
    [SerializeField] float rollCooldown = 0.25f;
    float t;

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
