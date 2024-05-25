using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HubButton : MonoBehaviour
{
    [SerializeField] private RectTransform _background;
    
    [SerializeField] private Image _buttonImage;
    [SerializeField] private TextMeshProUGUI _buttonText;
    [SerializeField] private float _transitionTime;
    [SerializeField] private Image _relatedBackground;
    [SerializeField] private HubExpand _relatedManageMenu;

    private Sequence _buttonSequence;

    private void Start()
    {
        _buttonSequence = DOTween.Sequence();
        _buttonSequence.SetAutoKill(false);
        _buttonSequence
            .Append(_background.DOScale(1.1f, _transitionTime))
            .Join(_buttonImage.DOFade(0, _transitionTime / 2))
            .Join(_buttonText.DOFade(0, _transitionTime / 2))
            .AppendCallback(() => _relatedBackground.enabled = !_relatedBackground.enabled);
        _buttonSequence.Pause();
    }

    public void PressButton()
    {
        _buttonSequence.PlayForward();
        _buttonSequence.OnComplete(_relatedManageMenu.Expand);
    }

    public void ReturnButton()
    {
        _buttonSequence.PlayBackwards();
    }
}
