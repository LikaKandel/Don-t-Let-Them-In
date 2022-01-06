using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNodes : MonoBehaviour
{
    [SerializeField] private GameObject[] leftSpawnPos;
    [SerializeField] private GameObject[] rightSpawnPos;
    [SerializeField] private GameObject nodePrefab;
    [SerializeField] private int timesSpawnStart;
    public static int timesSpawn;

    private void Start()
    {
        timesSpawn = timesSpawnStart;

        leftSpawnPos.Shuffle(5);
        rightSpawnPos.Shuffle(5);
        for (int i = 0; i < 2; i++)
        {
            Instantiate(nodePrefab, leftSpawnPos[i].transform.position, transform.rotation * Quaternion.Euler(-90f,0f, 0f));
            Instantiate(nodePrefab, rightSpawnPos[i].transform.position, transform.rotation * Quaternion.Euler(-90f, 0f, 0f));
        }
    }

}
