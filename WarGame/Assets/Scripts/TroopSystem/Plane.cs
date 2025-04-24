using UnityEngine;

public class Plane : Troop
{

    private int[] _planeDice = {0, 0, 0, 1, 2, 3};
    
    public override int Attack()
    {
        return SortAttackValue();
    }

    private int SortAttackValue()
    {
        return _planeDice[Random.Range(0, _planeDice.Length -1)];
    }
}
