using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static PlayerSettings Instance { get; private set; }

    public PlayerStats PlayerStats;

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

    public void SetLogin(string login) => Login = login;

    public void SetFraction(Fraction fraction) => Fraction = fraction;
    
    public void SetClan(Clan clan) => Clan = clan;

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}

public enum Fraction
{
    Pirate,
    Corsair
}

public enum Clan
{
    BlackLagoon,
    FunnyRoger,
    British,
    Spanish
}