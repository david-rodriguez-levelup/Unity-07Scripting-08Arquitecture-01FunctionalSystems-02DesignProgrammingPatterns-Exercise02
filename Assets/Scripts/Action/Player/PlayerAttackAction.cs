using UnityEngine;

public class PlayerAttackAction : MonoBehaviour, ICommandAction
{
    private const string ID = "ATTACK";

    public string Id => ID;

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
    }
}
