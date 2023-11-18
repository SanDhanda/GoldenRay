using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float startTimeBtweenSpawns;
    float timeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawns = startTimeBtweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PhotonNetwork.IsMasterClient || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }
        if(timeBetweenSpawns <= 0)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            PhotonNetwork.Instantiate(enemy.name, spawnPosition, Quaternion.identity);
            timeBetweenSpawns = startTimeBtweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
