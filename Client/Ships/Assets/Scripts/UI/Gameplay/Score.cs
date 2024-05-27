using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Image _playerFlag;
    [SerializeField] private Image _enemyFlag;

    [SerializeField] private List<Sprite> _flags = new();

    private string _playerName;
    private string _enemyName;

    private int _enemyWins;
    private int _playerWins;

    public void Init(string playerName, string enemyName, Clan playerClan, Clan enemyClan)
    {
        _playerFlag.sprite = _flags[(int)playerClan];
        _enemyFlag.sprite = _flags[(int)enemyClan];
        _playerName = playerName;
        _enemyName = enemyName;

        UpdateText();
    }

    public void PlayerWin()
    {
        _playerWins++;
        UpdateText();
    }

    public void EnemyWin()
    {
        _enemyWins++;
        UpdateText();
    }

    private void UpdateText()
    {
        _scoreText.text = $"Раунд {GameManager.Instance.CurrentRound}\n{_playerName} <sprite name=\"Swords\"> {_enemyName}\n{_playerWins} : {_enemyWins}";
    }
}
