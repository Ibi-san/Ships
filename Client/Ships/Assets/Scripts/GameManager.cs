using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    public int CurrentRound { get; private set; } = 3;

    [SerializeField] private Ship _oneCellShip;
    [SerializeField] private Ship _twoCellShip;
    [SerializeField] private Ship _threeCellShip;
    [SerializeField] private Ship _fourCellShip;

    public ShipsHubUI ShipsHubUI;

    private int _shipID = 0;
    
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

    public void UpdateState(GameState state)
    {
        CurrentState = state;

        switch (state)
        {
            case GameState.StartRound:
                CurrentRound++;
                PlayerSettings.Instance.PlayerStats = CurrentRound switch
                {
                    1 => new PlayerStats(1, 0, 0, 0),
                    2 => new PlayerStats(2, 1, 0, 0),
                    3 => new PlayerStats(3, 2, 1, 0),
                    4 => new PlayerStats(4, 3, 2, 1),
                    _ => PlayerSettings.Instance.PlayerStats
                };
                
                InitShips(PlayerSettings.Instance.PlayerStats.SmallShipsAmount, _oneCellShip);
                InitShips(PlayerSettings.Instance.PlayerStats.MediumShipsAmount, _twoCellShip);
                InitShips(PlayerSettings.Instance.PlayerStats.LargeShipsAmount, _threeCellShip);
                InitShips(PlayerSettings.Instance.PlayerStats.FlotillaAmount, _fourCellShip);
                ShipsHubUI.Init();
                break;
            
            case GameState.Battle:
                break;
            case GameState.Victory:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void InitShips(int shipAmount, Ship ship)
    {
        for (int i = 0; i < shipAmount; i++)
        {
            ship.SetID(_shipID);
            _shipID++;
            PlayerSettings.Instance.PlayerStats.AddShipToHub(ship);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}

public enum GameState
{
    StartRound,
    Battle,
    Victory,
    Lose
}
