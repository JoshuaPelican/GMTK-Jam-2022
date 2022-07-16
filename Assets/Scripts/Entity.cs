using UnityEngine;
using UnityEngine.Events;

public abstract class Entity : MonoBehaviour
{
    [Header("References")]
    [SerializeField] DiceRoller DiceRollerPrefab;
    [SerializeField] protected Transform RollerPoint;

    protected int health;
    protected Entity target;

    [SerializeField] UnityEvent OnAttackEnded;

    public void SetTarget(Entity entity)
    {
        target = entity;
    }

    public void UseAttack(int numDice, Transform rollerPoint)
    {
        DiceRoller newRoller = Instantiate(DiceRollerPrefab, rollerPoint);
        newRoller.SetNumberOfDice(numDice);
        newRoller.OnRollerFinished.AddListener(Attack);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            //Die
            Die();
        }
    }

    void Attack(int value)
    {
        if (!target)
        {
            Debug.LogError(name + " has No Target!");
            return;
        }

        target.TakeDamage(value);

        OnAttackEnded?.Invoke();
    }

    protected abstract void Die();

}
