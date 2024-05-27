using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class ShipsHubUI : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private ShipUIArea shipUIAreaPrefab;

    private List<ShipUIArea> _shipsUI = new(); 
    public void Init()
    {
        foreach (var ship in PlayerSettings.Instance.PlayerStats.HubShips)
        {
            var shipUI = Instantiate(shipUIAreaPrefab, _content.transform);
            shipUI.Init(ship);
            _shipsUI.Add(shipUI);
        }
    }

    public void UpdateShipUI(Ship ship)
    {
        _shipsUI.Single(shipUI => shipUI.ID == ship.ID).UpdateStats(ship);
    }
}