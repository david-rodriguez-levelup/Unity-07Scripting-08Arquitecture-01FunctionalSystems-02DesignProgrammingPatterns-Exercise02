using UnityEngine;

public class PlayerDefenseAction : MonoBehaviour, ICommandAction
{
    private const string ID = "DEFENSE";

    public string Id => ID;

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
    }
}
