using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    [Header("References")]
    [SerializeField] DiceRoller DiceRollerPrefab;
    [SerializeField] protected Transform RollerPoint;

    [SerializeField] protected FloatVariable health;
    protected Entity target;
    [SerializeField] protected FloatVariable Streak;

    private void Start()
    {
        GameManager.Instance.OnGameState.AddListener(StartTurn);

        Initialize();
    }

    public abstract void Initialize();

    protected abstract void StartTurn(GameState gameState);

    public void SetTarget(Entity entity)
    {
        target = entity;
    }

    public DiceRoller UseAttack(int numDice)
    {
        DiceRoller newRoller = Instantiate(DiceRollerPrefab, RollerPoint);
        newRoller.Initialize(numDice, Streak);
        newRoller.OnRollerFinished.AddListener(Attack);
        return newRoller;
    }

    public virtual void TakeDamage(int damage)
    {
        health.Value -= damage;

        if(health.Value <= 0)
        {
            //Die
            Die();
        }
    }

    public virtual void Attack(int value)
    {
        if (!target)
        {
            Debug.LogError(name + " has No Target!");
            return;
        }

        target.TakeDamage(value);

        EndTurn();
    }

    protected abstract void Die();

    protected abstract void EndTurn();
}
