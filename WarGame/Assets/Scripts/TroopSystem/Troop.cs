using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    [SerializeField]
    private GameDefines.TroopType _troopType;
    
    [SerializeField]
    private List<GameDefines.TroopType> _canAttackUnities = new List<GameDefines.TroopType>();
    
    [SerializeField]
    private List<GameDefines.TroopType> _advantageAttackUnities = new List<GameDefines.TroopType>();

    [SerializeField]
    private List<GameDefines.TroopType> _disadvantageAttackUnities = new List<GameDefines.TroopType>();

    [SerializeField]
    private List<GameDefines.TroopType> _normalAttackUnities = new List<GameDefines.TroopType>();

    [SerializeField]
    private Color _color;

    [SerializeField]
    private int _owner;

    private int[] _advantageDice = { 1,2,3,4,5,0 };
    private int[] _normalDice = { 1,2,3,4,5,6 };
    private int[] _disadvantageDice = { 1,2,3,4,0,0};

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

    public virtual void  Attack()
    {
     
    }

    public virtual int AttackNormal()
    {
        return _normalDice[Random.Range(0, _normalDice.Length - 1)];
    }

    public virtual int AttackAdvantage()
    {
        return _advantageDice[Random.Range(0, _advantageDice.Length - 1)];
    }

    public virtual int AttackDisadvantage()
    {
        return _disadvantageDice[Random.Range(0, _disadvantageDice.Length - 1)];
    }

}
