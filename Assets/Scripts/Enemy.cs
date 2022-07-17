using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    [Header("Enemy Settings")]
    public int MaxHealth;
    public int NumberOfAttackDice;
    public float Difficulty = 1;

    [Header("Enemy Visuals")]
    public Mesh Mesh;
}
