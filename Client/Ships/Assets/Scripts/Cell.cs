using UnityEngine;

public class Cell
{
    public bool HasShip { get; private set; }
    public bool IsHit { get; private set; }
    public Vector2Int Coordinates { get; private set; }

    public Cell(Vector2Int coordinates)
    {
        Coordinates = coordinates;
    }

    public void Hit() => IsHit = true;

    public void SetShip() => HasShip = true;
}
