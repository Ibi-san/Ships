using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HubExpand : MonoBehaviour
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private Vector2 _horisontalExpand;
    [SerializeField] private Vector2 _verticalExpand;
    [SerializeField] private Vector2 _positionHorisontal;
    [SerializeField] private Vector2 _positionVertical;
    [SerializeField] private float _transitionTime;
    
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private HubButton _relatedButton;
    [SerializeField] private CanvasGroup _crewElementsGroup;

    private Sequence _expandSequence;
    private void Start()
    {
        _expandSequence = DOTween.Sequence();
        _expandSequence.SetAutoKill(false);
        _expandSequence
            .AppendCallback(() => _backgroundImage.enabled = !_backgroundImage.enabled)
            .Append(_background.DOAnchorPos(_positionHorisontal, _transitionTime))
            .Join(_background.DOSizeDelta(_horisontalExpand, _transitionTime))
            .Append(_background.DOSizeDelta(_verticalExpand, _transitionTime))
            .Join(_background.DOAnchorPos(_positionVertical, _transitionTime))
            .Append(_crewElementsGroup.DOFade(1, _transitionTime / 2))
            .AppendCallback(() => _crewElementsGroup.blocksRaycasts = !_crewElementsGroup.blocksRaycasts);
        _expandSequence.Pause();
    }

    public void Expand()
    {
        _expandSequence.PlayForward();
    }

    public void Squeeze()
    {
        _expandSequence.PlayBackwards();
        _expandSequence.OnRewind(_relatedButton.ReturnButton);
    }
}
