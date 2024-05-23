using System;
using cakeslice;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action<CellView> Clicked;
    [SerializeField] private Outline _outline;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _outline.eraseRenderer = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _outline.eraseRenderer = true;
    }

    private void OnMouseDown() => Clicked?.Invoke(this);
}