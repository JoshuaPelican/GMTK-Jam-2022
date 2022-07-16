using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public int NumberOfDice = 1;

    public Mesh Mesh;
}
