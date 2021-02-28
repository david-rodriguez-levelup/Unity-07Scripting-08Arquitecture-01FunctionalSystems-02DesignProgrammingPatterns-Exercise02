using System;
using UnityEngine;

public class EnemySlotsControl : AbstractSlotsControl
{

    public override void MakeSelection()
    {
        foreach (SlotState slotState in base.SlotStates)
        {
            slotState.Random(allowEmptyAction: false);
        }
        base.SubmitSlots();
    }
}
