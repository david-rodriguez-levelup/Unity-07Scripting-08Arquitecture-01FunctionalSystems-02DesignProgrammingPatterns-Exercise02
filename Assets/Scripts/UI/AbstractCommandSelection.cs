using System;
using UnityEngine;

public abstract class AbstractCommandSelection : MonoBehaviour
{

    public event Action<ICommand[]> OnSelectionDone;

    [SerializeField] private CommandConfigList commandConfigList;
    [SerializeField] private GameObject commandReceiver;

    protected SlotState[] SlotStates { get; private set; }

    private void Awake()
    {
        SlotStates = GetComponentsInChildren<SlotState>();
        foreach (SlotState slotState in SlotStates)
        {
            slotState.SetAvailableCommands(commandConfigList);
        }

        OnAwake();
    }

    protected virtual void OnAwake()
    {
        // Overrided in subclasses if needed.
    }

    public void ResetSlots()
    {
        foreach (SlotState slotState in SlotStates)
        {
            slotState.Reset();
        }
    }

    public abstract void MakeSelection();

    protected void CommitSlots()
    {
        ICommand[] commands = CommandFactory.CreateCommands(SlotStates, commandReceiver);
        OnSelectionDone?.Invoke(commands);
    }

}
