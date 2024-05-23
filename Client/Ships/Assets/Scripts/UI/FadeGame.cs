using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeGame : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _transitionTime;

    [SerializeField] private TextMeshProUGUI _loadingText;
    [SerializeField] private string[] _waitTexts = { "Ожидание оппонента...", "Ожидание оппонента.", "Ожидание оппонента.." };

    [SerializeField] private Score _score;
    private Coroutine waitCoroutine; 

    private void Start()
    {
        _loadingText.DOFade(1, _transitionTime);
        waitCoroutine = StartCoroutine(WaitForEnemy());
        MultiplayerManager.Instance.EnemyJoined += StopWaiting;
    }

    private void StopWaiting()
    {
        StopCoroutine(waitCoroutine);
        _loadingText.DOKill();
        _loadingText.DOFade(0, _transitionTime / 2).OnComplete(() =>
        {
            _fadePanel.DOFillAmount(0, _transitionTime);
            gameObject.SetActive(false);
        });
        InitScore();
    }

    private void InitScore()
    {
        var player = PlayerSettings.Instance;
        var enemy = Enemy.Instance;
        _score.Init(player.Login, enemy.Login, player.Clan, enemy.Clan);
    }

    private IEnumerator WaitForEnemy()
    {
        int index = 0;
        while (true)
        {
            _loadingText.text = _waitTexts[index];
            index = (index + 1) % _waitTexts.Length;
            yield return new WaitForSeconds(1);
        }
    }
}
