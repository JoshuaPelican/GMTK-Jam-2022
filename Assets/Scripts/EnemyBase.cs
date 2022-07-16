using UnityEngine;

public class EnemyBase : Entity
{
    [SerializeField] Enemy Enemy;

    private void Awake()
    {
        SetTarget(GameObject.FindWithTag("Player").GetComponent<Player>());
    }

    protected override void Die()
    {
        Debug.Log("Enemy " + name + " has Died!");
    }
}
