﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerBehaviour : MonoBehaviour
{
    public float movementSpeed;
    public int numberOfNeutrals;
    public int numberOfEnemies;

    public GameObject[] neutralFish;
    public GameObject[] enemyFish;

    public int numberOfActiveLoops;
    public Transform[] movementLoopOne;
    public Transform[] movementLoopTwo;
    public Transform[] movementLoopThree;
    public Transform[] movementLoopFour;

    GameObject[] activeFish;
    int nextEnteryPosition = 0;

    IEnumerator Start()
    {
        activeFish = new GameObject[numberOfNeutrals];

        for (int i = 0; i < numberOfNeutrals; i++)
        {
            yield return new WaitForSeconds(Random.Range(2.5f, 8.0f));

            int fishType = Random.Range(0, neutralFish.Length);
            int route = Random.Range(1, numberOfActiveLoops);

            GameObject neutralFishClone = (GameObject)Instantiate(neutralFish[fishType], transform.position, Quaternion.identity);
            switch (route)
            {
                case 1:
                    neutralFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopOne;
                    break;
                case 2:
                    neutralFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopTwo;
                    break;
                case 3:
                    neutralFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopThree;
                    break;
                case 4:
                    neutralFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopFour;
                    break;
                default:
                    Debug.Log("The int route was to great or null - NeutralFish");
                    break;
            }
            neutralFishClone.GetComponent<BackupFishMovement>().patrolSpeed = movementSpeed;

            Debug.Log("next entry position: ActiveFish[" + nextEnteryPosition + "]");
            if (activeFish.Length != 0)
            {
                activeFish[nextEnteryPosition] = neutralFishClone;
                nextEnteryPosition++;
            }
            else
            {
                activeFish[0] = neutralFishClone;
                nextEnteryPosition++;
            }

            Debug.Log("spawed one Fish");
        }

        for (int i = 0; i < numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(Random.Range(2.5f, 8.0f));

            int enemytype = Random.Range(0, enemyFish.Length);
            int route = Random.Range(1, numberOfActiveLoops);

            GameObject enemyFishClone = (GameObject)Instantiate(enemyFish[enemytype], transform.position, Quaternion.identity);
            switch (route)
            {
                case 1:
                    enemyFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopOne;
                    break;
                case 2:
                    enemyFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopTwo;
                    break;
                case 3:
                    enemyFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopThree;
                    break;
                case 4:
                    enemyFishClone.GetComponent<BackupFishMovement>().waypoints = movementLoopFour;
                    break;
                default:
                    Debug.Log("The int route was to great or null - EnemyFish");
                    break;
            }
            enemyFishClone.GetComponent<BackupFishMovement>().patrolSpeed = movementSpeed;

            Debug.Log("spawed one Enemy");
        }
    }

    void Update()
    {

    }
}
