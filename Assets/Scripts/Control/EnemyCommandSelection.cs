using System;
using UnityEngine;

public class EnemyCommandSelection : AbstractCommandSelection
{

    public override void MakeSelection()
    {
        foreach (SlotState slotState in base.SlotStates)
        {
            slotState.Random();
        }
        base.CommitSlots();
    }
}
