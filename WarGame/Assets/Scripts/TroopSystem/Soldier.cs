using UnityEngine;

public class Soldier : Troop
{
    public override int Attack()
    {
        return SortAttackValue();
    }

    private int SortAttackValue()
    {
        return Random.Range(1, 6);
    }
}
