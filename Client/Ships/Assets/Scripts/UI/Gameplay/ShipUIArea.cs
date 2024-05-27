using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipUIArea : MonoBehaviour
{
    [SerializeField] private Transform _shipSize;
    [SerializeField] private GameObject _cellImagePrefab;
    [SerializeField] private Image _shipIcon;
    [SerializeField] private TextMeshProUGUI _shipStatsText;

    [SerializeField] private Sprite _oneCell;
    [SerializeField] private Sprite _twoCell;
    [SerializeField] private Sprite _threeCell;
    [SerializeField] private Sprite _fourCell;
    
    public int ID { get; private set; }
    public void Init(Ship ship)
    {
        ID = ship.ID;
        SetShipVisual(ship);
        UpdateStats(ship);
    }

    public void UpdateStats(Ship ship) => _shipStatsText.text = $"Размер: {ship.Size}\nСкорость: {ship.Speed}\nУрон: {ship.Damage}\nЗдоровье: {ship.MaxHealth}\n";

    private void SetShipVisual(Ship ship)
    {
        switch (ship.Size)
        {
            case 1:
                CreateCell(1);
                _shipIcon.sprite = _oneCell;
                break;
            case 2:
                CreateCell(2);
                _shipIcon.sprite = _twoCell;
                break;
            case 3:
                CreateCell(3);
                _shipIcon.sprite = _threeCell;
                break;
            case 4:
                CreateCell(4);
                _shipIcon.sprite = _fourCell;
                break;
        }
    }

    private void CreateCell(int cellAmount)
    {
        Vector3 cellPosition = Vector3.zero;
        for (int i = 0; i < cellAmount; i++)
        {
            var cell = Instantiate(_cellImagePrefab, _shipSize);
            cell.transform.localPosition = cellPosition;
            cellPosition.x -= 40;
        }
    }
}