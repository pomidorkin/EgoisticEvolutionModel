using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltruistController : MonoBehaviour
{
    [SerializeField] GameObject altruistSlimePrefab;
    [SerializeField] PositionManager positionManager;
    [SerializeField] ChartController chartController;
    public List<AltruistSlime> altruistSlimes;
    private bool allHunted = false;
    private bool allAte = false;
    private bool allTriedReproduce = false;
    private bool allSlimesReachedPosition = false;
    private int coffers = 0;
    public int newSlimesAmount = 0;

    [SerializeField] private int numberOfIterations = 20;
    private int iterationIndex = 0;

    public delegate void HuntAction();
    public event HuntAction HuntCommand;

    public delegate void EatAction();
    public event EatAction EatCommand;

    public delegate void ResetAction();
    public event ResetAction ResetCommand;

    public delegate void TryReproduceAction();
    public event TryReproduceAction TryReproduceCommand;

    public delegate void AllReachedPositionAction();
    public event AllReachedPositionAction AllReachedPositionCommand;

    private void Start()
    {
        SendHuntCommand();
    }

    public void CheckIfAllHunted()
    {
        allHunted = true;
        foreach (AltruistSlime slime in altruistSlimes)
        {
            if (!slime.hasHunted)
            {
                allHunted = false;
            }
        }
        if (allHunted)
        {
            Debug.Log("Sending an eat command");
            EatCommand();
        }
    }

    public void CheckIfAllHaveEaten()
    {
        allAte = true;
        foreach (AltruistSlime slime in altruistSlimes)
        {
            if (!slime.hasEaten)
            {
                allAte = false;
            }
        }
        if (allAte)
        {
            TryReproduceCommand();
        }
    }

    public bool CheckIfAllReachedPosition(bool isGoingForHumt)
    {
        allSlimesReachedPosition = true;
        foreach (AltruistSlime slime in altruistSlimes)
        {
            if (!slime.positionReached)
            {
                allSlimesReachedPosition = false;
            }
        }
        if (allSlimesReachedPosition && isGoingForHumt)
        {
            AllReachedPositionCommand();
        }

        return allSlimesReachedPosition;
    }

    public void ResetAllReachedPosition()
    {
        allSlimesReachedPosition = false;
    }

    public void CheckIfAllHaveReproduced()
    {
        allTriedReproduce = true;
        foreach (AltruistSlime slime in altruistSlimes)
        {
            if (!slime.triedReproduce)
            {
                allTriedReproduce = false;
            }
        }
        Debug.Log("allTriedReproduce: " + allTriedReproduce + ", (iterationIndex < numberOfIterations): " + (iterationIndex < numberOfIterations));
        // Interation end
        if (allTriedReproduce && (iterationIndex < numberOfIterations))
        {
            chartController.AddDataToChart(altruistSlimes.Count);
            allAte = false;
            allHunted = false;
            allTriedReproduce = false;
            SpawnNewSlime();
            ResetCommand();
            SendHuntCommand();
        }

    }

    public void IncreaseSpawningAmount()
    {
        newSlimesAmount += 1;
    }

    private void SpawnNewSlime()
    {
        if (newSlimesAmount > 0)
        {
            for (int i = 0; i < newSlimesAmount; i++)
            {
                Instantiate(altruistSlimePrefab, positionManager.GetRandomSpawnPosition(), Quaternion.identity);
            }
            newSlimesAmount = 0;
        }
    }

    public int GetCoffersAmount()
    {
        return coffers;
    }

    public void AddToCoffers(int amount)
    {
        coffers += amount;
    }

    public bool TakeFromCoffers(int amount)
    {
        if ((coffers - amount) >= 0)
        {
            coffers -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SendHuntCommand()
    {
        iterationIndex += 1;
        Debug.Log("iterationIndex: " + iterationIndex);
        HuntCommand();
    }

    public PositionManager GetPositionManager()
    {
        return positionManager;
    }
}
