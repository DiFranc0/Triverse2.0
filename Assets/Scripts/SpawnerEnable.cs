using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnable : MonoBehaviour
{
    public GameObject[] enemySpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Points == 100)
        {
            enemySpawner[0].SetActive(true);
        }

        if (GameManager.Instance.Points == 300)
        {
            enemySpawner[1].SetActive(true);
        }
    }
}
