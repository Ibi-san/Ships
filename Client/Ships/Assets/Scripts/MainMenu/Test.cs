using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        print(PlayerSettings.Instance.Login);
        print(PlayerSettings.Instance.Fraction);
        print(PlayerSettings.Instance.Clan);
    }
}
