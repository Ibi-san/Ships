using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Fraction Fraction { get; private set; }
    public Clan Clan { get; private set; }

    public void Init(int fraction, int clan)
    {
        Fraction = (Fraction)fraction;
        Clan = (Clan)clan;
    }
}