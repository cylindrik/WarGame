using UnityEngine;

public class Tank : Troop
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
