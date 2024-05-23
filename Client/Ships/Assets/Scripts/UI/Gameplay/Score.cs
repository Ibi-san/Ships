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

    public void Init(string playerName, string enemyName, Clan playerClan, Clan enemyClan)
    {
        _playerFlag.sprite = _flags[(int)playerClan];
        _enemyFlag.sprite = _flags[(int)enemyClan];

        _scoreText.text = $"Раунд 1\n{playerName} <sprite name=\"Swords\"> {enemyName}\n0 : 0";
    }
}
