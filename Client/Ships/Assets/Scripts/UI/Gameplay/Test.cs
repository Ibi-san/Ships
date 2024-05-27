using System;
using UnityEngine;
    public class Test : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                PlayerSettings.Instance.PlayerStats.HubShips[4].SetDamage(5);
                PlayerSettings.Instance.PlayerStats.HubShips[4].SetMaxHealth(5);
                PlayerSettings.Instance.PlayerStats.HubShips[4].SetSpeed(5);
                GameManager.Instance.ShipsHubUI.UpdateShipUI(PlayerSettings.Instance.PlayerStats.HubShips[4]);
            }
        }
    }