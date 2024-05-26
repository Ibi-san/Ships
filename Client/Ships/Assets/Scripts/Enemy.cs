using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }
    
    public PlayerStats EnemyStats;
    public string Login { get; private set; }
    public Fraction Fraction { get; private set; }
    public Clan Clan { get; private set; }
    
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Init(int fraction, int clan, string login)
    {
        Login = login;
        Fraction = (Fraction)fraction;
        Clan = (Clan)clan;
    }
}