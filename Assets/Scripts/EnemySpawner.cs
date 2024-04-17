using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private TimedSpawner timedSpawner;
    private float spawnWait = 10f;
    private bool upgraded1 = true;
    private bool upgraded2 = true;
    private bool upgraded3 = true;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnWait = 7f;
        upgraded1 = true;
        upgraded2 = true;
        upgraded3 = true;
        timedSpawner = GetComponent<TimedSpawner>();
        if(this.gameObject.tag == "FirstSpawner")
        {
            StartCoroutine(SpawnerController(spawnWait));
        }
        
    }

    private void OnEnable()
    {
        timedSpawner = GetComponent<TimedSpawner>();
        timedSpawner.CanSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Points == 30 && upgraded1)
        {
            timedSpawner.CanSpawn = true;
            timedSpawner.MinFrequency = 5;
            timedSpawner.MaxFrequency = 5;
            //spawnWait = 10f;
            //StartCoroutine (SpawnerController(spawnWait));
            upgraded1 = false;
        }

        if(GameManager.Instance.Points == 100 && upgraded2)
        {
            timedSpawner.CanSpawn = true;
            timedSpawner.MinFrequency = 4.5f;
            timedSpawner.MaxFrequency = 4.5f;
            //spawnWait = 20f;
            //StartCoroutine(SpawnerController(spawnWait));
            upgraded2 = false;
        }

        if(GameManager.Instance.Points == 300 && upgraded3)
        {
            timedSpawner.CanSpawn = true;
            timedSpawner.MinFrequency = 4;
            timedSpawner.MaxFrequency = 4;
            //spawnWait = 25f;
            //timedSpawner.CanSpawn = true;
            upgraded3 = false;
        }

        if(GameManager.Instance.Points == 1000)
        {
            timedSpawner.MinFrequency = 2;
            timedSpawner.MaxFrequency = 2;
        }
    }

    IEnumerator SpawnerController(float spawnWait)
    {
        timedSpawner.CanSpawn = true;
        WaitForSeconds wait = new WaitForSeconds(spawnWait);
        yield return wait;
        timedSpawner.CanSpawn = false;
        StopCoroutine(SpawnerController(spawnWait));
    }
}
