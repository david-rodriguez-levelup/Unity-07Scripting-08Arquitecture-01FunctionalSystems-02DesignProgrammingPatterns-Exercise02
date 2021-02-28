using UnityEngine;

public class EnemyHealingAction : MonoBehaviour, ICommandAction
{
    private const string ID = "HEALING";

    public string Id => ID;

    public void Perform()
    {
        Debug.Log($"\t{name} performs ACTION {ID}!");
    }
}
