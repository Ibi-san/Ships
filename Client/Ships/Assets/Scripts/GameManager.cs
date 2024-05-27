using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState { get; private set; }

    private int _currentRound = 0;

    [SerializeField] private Ship _oneCellShip;
    [SerializeField] private Ship _twoCellShip;
    [SerializeField] private Ship _threeCellShip;
    [SerializeField] private Ship _fourCellShip;
    
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
                _currentRound++;
                PlayerSettings.Instance.PlayerStats = _currentRound switch
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

    private static void InitShips(int shipAmount, Ship shipStat)
    {
        for (int i = 0; i < shipAmount; i++)
        {
            shipStat.SetID(i);
            PlayerSettings.Instance.PlayerStats.AddShipToHub(shipStat);
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
