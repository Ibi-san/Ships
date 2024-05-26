using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarHide : MonoBehaviour
{
    [SerializeField] private Image _handleImage;
    [SerializeField] private float _hideTime;
    [SerializeField] private Color _normalColor;
    
    public void TriggerScroll()
    {
        StopAllCoroutines();
        _handleImage.color = _normalColor;
        StartCoroutine(Hide());
    }

    private IEnumerator Hide()
    {
        while (_handleImage.color.a != 0)
        {
            var currentColor = _handleImage.color;
            currentColor.a -= 0.01f;
            _handleImage.color = currentColor;
            yield return new WaitForEndOfFrame();
        }
    }
}
