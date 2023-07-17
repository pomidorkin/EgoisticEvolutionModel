using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] Transform forestPosition;
    [SerializeField] Transform homePosition;
    [SerializeField] Transform spawnPosition;
    private float walkRadius = 1f;
    private float yPos = 3.09f;

    public Vector3 GetRandomForestPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += forestPosition.position;
        randomDirection.y = yPos;
        return randomDirection;
    }

    public Vector3 GetRandomHomePosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += homePosition.position;
        randomDirection.y = yPos;
        return randomDirection;
    }

    public Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += spawnPosition.position;
        randomDirection.y = yPos;
        return randomDirection;
    }
}
