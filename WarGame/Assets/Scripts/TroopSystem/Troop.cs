using UnityEngine;

public class Troop : MonoBehaviour
{
    [SerializeField]
    private GameDefines.TroopType _troopType;

    [SerializeField]
    private Color _color;

    [SerializeField]
    private int _owner;

    public void SetOwner(int owner)
    {
        _owner = owner;
    }

    public int GetOwner()
    {
        return _owner;
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public Color GetColor()
    {
        return _color;
    }

    public virtual int  Attack()
    {
        return 0;
    }

}
