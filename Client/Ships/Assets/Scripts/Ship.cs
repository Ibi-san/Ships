using UnityEngine;

[CreateAssetMenu (fileName = "Ship", menuName = "Ships/Ship")]
public class Ship : ScriptableObject
{
    [field: SerializeField] public int Size { get; private set; }
    [field: SerializeField] public int Speed { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }

    public Ship(int size, int speed, int damage, int maxHealth)
    {
        Size = size;
        Speed = speed;
        Damage = damage;
        MaxHealth = maxHealth;
    }
}