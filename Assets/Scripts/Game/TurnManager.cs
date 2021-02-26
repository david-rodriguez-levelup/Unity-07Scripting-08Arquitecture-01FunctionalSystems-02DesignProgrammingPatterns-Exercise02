using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{

    [SerializeField] PlayerCommandSelection playerCommandSelection;
    [SerializeField] EnemyCommandSelection enemyCommandSelection;

    private List<ICommand> playerCommands = new List<ICommand>();
    private List<ICommand> enemyCommands = new List<ICommand>();

    private void Start()
    {
        NewTurn();
    }

    private void OnEnable()
    {
        playerCommandSelection.OnSelectionDone += AddPlayerCommands;
        enemyCommandSelection.OnSelectionDone += AddEnemyCommands;
    }

    private void OnDisable()
    {
        playerCommandSelection.OnSelectionDone -= AddPlayerCommands;
        enemyCommandSelection.OnSelectionDone -= AddEnemyCommands;
    }

    private void NewTurn()
    {
        Debug.Log("NEW TURN:");
        Debug.Log("1) SELECTION:");

        playerCommands.Clear();
        playerCommandSelection.ResetSlots();
        enemyCommands.Clear();
        enemyCommandSelection.ResetSlots();

        // Better with a callback?
        playerCommandSelection.MakeSelection();
        // ... and wait for event playerCommandSelection.OnSelectionDone!
    }


    private void AddPlayerCommands(ICommand[] commands)
    {
        Debug.Log("Player commands:");
        foreach (ICommand command in commands)
        {
            Debug.Log($"\tCommand {(command != null ? command.ToString() : "EMPTY")} added to player's commands.");
            playerCommands.Add(command);
        }

        // Better with a callback?
        enemyCommandSelection.MakeSelection();
        // ... and wait for event enemyCommandSelection.OnSelectionDone!
    }

    private void AddEnemyCommands(ICommand[] commands)
    {
        Debug.Log("Enemy commands:");
        foreach (ICommand command in commands)
        {
            Debug.Log($"\tCommand {command} added to enemy's commands.");
            enemyCommands.Add(command);
        }

        // Now we can resolve the turn!
        ResolveTurn();
    }

    private void ResolveTurn()
    {
        Debug.Log("2) RESOLVE:");
        for (int i = 0; i < playerCommands.Count; i++)
        {
            Debug.Log($"Slot {i}:");
            ICommand playerCommand = playerCommands[i];
            if (playerCommand != null)
            {
                playerCommands[i].Execute();
            }
            else
            {
                Debug.Log("\tPlayer does NOTHING!");
            }
            enemyCommands[i].Execute();
        }

        Debug.Log("______________________________________________________________\n\n");

        // Invoke new turn after X seconds...
        Invoke(nameof(NewTurn), 5f);
    }

}
