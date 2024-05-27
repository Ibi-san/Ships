using UnityEngine;

[CreateAssetMenu (fileName = "Ship", menuName = "Ships/Ship")]
public class Ship : ScriptableObject
{
    [field: SerializeField] public int Size { get; private set; }
    [field: SerializeField] public int Speed { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int MaxHealth { get; private set; }

    public int ID { get; private set; } = 0;

    public Ship(int size, int speed, int damage, int maxHealth)
    {
        Size = size;
        Speed = speed;
        Damage = damage;
        MaxHealth = maxHealth;
    }

    public void SetDamage(int amount) => Damage = amount;

    public void SetMaxHealth(int amount) => MaxHealth = amount;

    public void SetSpeed(int amount) => Speed = amount;

    public void SetID(int id) => ID = id;
}