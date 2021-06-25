using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            spawnNewEnemy();
        }
    }

    void spawnNewEnemy(){
        int randomNumber = Mathf.RoundToInt(UnityEngine.Random.Range( 0, transform.childCount));
        GameObject go = Instantiate(enemyPrefab, transform.GetChild(randomNumber).transform.position, Quaternion.identity);
        go.transform.GetComponent<EnemyMovement>().wavepointIndex = randomNumber;
    }

}
