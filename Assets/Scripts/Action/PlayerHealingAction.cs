using UnityEngine;

public class PlayerHealingAction : MonoBehaviour, ICommandAction
{
    private const string ID = "HEALING";

    public string Id => ID;

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
    }
}
