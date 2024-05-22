using System.Collections.Generic;
using Colyseus;
using UnityEngine;

public class MultiplayerManager : ColyseusManager<MultiplayerManager>
{
    #region Server

    private const string GameRoomName = "state_handler";

    private ColyseusRoom<State> _room;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        InitializeClient();
        Connect();
    }

    private async void Connect()
    {
        Dictionary<string, object> data = new()
        {
            {"login", PlayerSettings.Instance.Login},
            {"fraction", (int)PlayerSettings.Instance.Fraction},
            {"clan", (int)PlayerSettings.Instance.Clan}
        };
        _room = await client.JoinOrCreate<State>(GameRoomName, data);
        _room.OnStateChange += OnChange;
    }

    private void OnChange(State state, bool isFirstState)
    {
        if (isFirstState == false) return;
        _room.OnStateChange -= OnChange;

        state.players.ForEach((key, player) =>
        {
            if (key == _room.SessionId)
                CreatePlayer(player);
            else
                CreateEnemy(key, player);
        });
        
        _room.State.players.OnAdd += CreateEnemy;
        _room.State.players.OnRemove += RemoveEnemy;
    }


    protected override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        LeaveRoom();
    }

    public void LeaveRoom() => _room?.Leave();

    #endregion

    #region Player

    private void CreatePlayer(Player player)
    {
        print("Player created!");
    }

    #endregion


    #region Enemy

    [SerializeField] private Enemy _enemyPrefab;

    private void CreateEnemy(string key, Player player)
    {
        print("Enemy created!");
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemy.Init(player.f, player.c);
    }
    
    private void RemoveEnemy(string key, Player value)
    {
        
    }

    #endregion
}