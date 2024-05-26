using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeMenu : MonoBehaviour
{
    [SerializeField] private Image _fadePanel;
    [SerializeField] private float _transitionTime;
    public void LoadGameplay()
    {
        GameManager.Instance.UpdateState(GameState.StartRound);
        _fadePanel.DOFillAmount(1, _transitionTime).SetEase(Ease.OutCubic).OnComplete(() =>
            SceneManager.LoadScene(sceneBuildIndex: 1));
    }
}
