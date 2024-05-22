using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Action<CellView> Clicked;
    [SerializeField] private Material _water;
    [SerializeField] private Material _selectedWater;

    [SerializeField] private MeshRenderer _waterMesh;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _waterMesh.material = _selectedWater;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _waterMesh.material = _water;
    }

    private void OnMouseDown() => Clicked?.Invoke(this);
}