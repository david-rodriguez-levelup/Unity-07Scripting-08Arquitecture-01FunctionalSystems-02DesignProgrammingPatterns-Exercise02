using UnityEngine;

public class SlotState : MonoBehaviour
{
    private const int EMPTY = -1;
   
    [SerializeField] Sprite emptyIcon;

    public bool Locked { get; set; } = false;

    private IChangeSlotIconAction changeSlotIconAction;

    private CommandConfigList availableCommands;
    private int currentIndex = EMPTY;

    private void Awake()
    {
        changeSlotIconAction = GetComponentInChildren<IChangeSlotIconAction>();
    }

    public void SetAvailableCommands(CommandConfigList commandConfigList)
    {
        availableCommands = commandConfigList;
    }

    private void Start()
    {
        Reset();
    }

    public CommandConfig Current => currentIndex != EMPTY ? availableCommands.Get(currentIndex) : null;

    public void Next()
    {
        currentIndex = (currentIndex + 1) % availableCommands.Length;
        UpdateIcon();
    }

    public void Random()
    {
        currentIndex = UnityEngine.Random.Range(0, availableCommands.Length);
        UpdateIcon();
    }

    public void Reset()
    {
        Locked = false;
        currentIndex = EMPTY;
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (currentIndex == EMPTY)
        {
            changeSlotIconAction.Perform(emptyIcon);
        } 
        else
        {
            changeSlotIconAction.Perform(Current.Icon);
        }        
    }

}
