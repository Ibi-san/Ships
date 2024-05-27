using System;
using System.Collections.Generic;

public class PlayerStats
{
    public int SmallShipsAmount { get; private set; }
    public int MediumShipsAmount { get; private set; }
    public int LargeShipsAmount { get; private set; }
    public int FlotillaAmount { get; private set; }

    private List<Ship> BattleShips = new();
    public List<Ship> HubShips = new();

    public PlayerStats(int smallShipsAmount, int mediumShipsAmount, int largeShipsAmount, int flotillaAmount)
    {
        SmallShipsAmount = smallShipsAmount;
        MediumShipsAmount = mediumShipsAmount;
        LargeShipsAmount = largeShipsAmount;
        FlotillaAmount = flotillaAmount;
    }

    public void AddShipToBattle(Ship ship) => BattleShips.Add(ship);
    public void RemoveShip(Ship ship) => BattleShips.Remove(ship);
    public void ClearBattleShips() => BattleShips.Clear();
    public void AddShipToHub(Ship ship) => HubShips.Add(ship);
    
}