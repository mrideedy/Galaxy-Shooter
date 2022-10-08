using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPreFab;
    [SerializeField]
    
    private GameObject[] powerups;
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }
    IEnumerator EnemySpawnRoutine ()
    {
    while (true)
    {
        Instantiate(enemyShipPreFab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
        yield return new WaitForSeconds (4.0f);
        
    }
       
}
    IEnumerator PowerupSpawnRoutine ()
    {
        while (true)
        {
            int randowmPowerup = Random.Range(0,3);
            Instantiate(powerups[randowmPowerup], new Vector3(Random.Range(-8f, 8f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds (8.0f);
        }
    }
}
