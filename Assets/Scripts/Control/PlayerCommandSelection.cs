using UnityEngine;

public class PlayerCommandSelection : AbstractCommandSelection
{

    [SerializeField] private GameObject okButton;
    private IInputSensor[] okInputSensors;

    private bool locked = true; // Starts locked by default!

    protected override void OnAwake()
    {
        okInputSensors = okButton.GetComponents<IInputSensor>();
    }

    private void OnEnable()
    {
        foreach (IInputSensor okButtonSensor in okInputSensors)
        {
            okButtonSensor.OnPressed += OnOkButtonPressed;
        }
    }

    private void OnDisable()
    {
        foreach (IInputSensor okButtonSensor in okInputSensors)
        {
            okButtonSensor.OnPressed -= OnOkButtonPressed;
        }
    }

    public override void MakeSelection()
    {
        locked = false;
        SetSlotsLockedValue(false);
        // Wait for user selection and okButtonSensor.OnPressed!
    }

    private void OnOkButtonPressed()
    {
        if (!locked)
        {
            locked = true;
            SetSlotsLockedValue(true);
            base.CommitSlots();
        }
    }

    private void SetSlotsLockedValue(bool value)
    {
        foreach (SlotState slotState in base.SlotStates)
        {
            slotState.Locked = value;
        }
    }

}
