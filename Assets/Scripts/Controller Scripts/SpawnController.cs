using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject[] hostilePrefabs;
    public Transform[] spawnPoints;

    GameController gameCon;

    void Start()
    {
        gameCon = FindObjectOfType<GameController>();
        StartCoroutine(spawnLoop());
    }

    IEnumerator spawnLoop()
    {
        while(true)
        {
            int H = (int) Random.Range(0, hostilePrefabs.Length);
            int S = (int) Random.Range(0, spawnPoints.Length);
            
            Instantiate(hostilePrefabs[H], spawnPoints[S].position, Quaternion.identity);
            gameCon.updateHostiles();

            yield return new WaitForSeconds(4f);
        }
    }
}
