﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerBehaviour : MonoBehaviour
{
    public Transform fishtankTracker;
    public float movementSpeed;
    public int numberOfNeutrals;
    public int numberOfEnemies;

    //public GameObject[] neutralFish;
    public GameObject[] enemyFish;
    public List<GameObject> neutralFish = new List<GameObject>();
    public FishTargetDisplay fishTargetDisplay;

    public int numberOfActiveLoops;
    public Transform[] movementLoopOne;
    public Transform[] movementLoopTwo;
    public Transform[] movementLoopThree;
    public Transform[] movementLoopFour;

    GameObject[] activeFish;
    int nextEnteryPosition = 0;

    private int counter = 0;

    IEnumerator Start()
    {
            //
        //activeFish = new GameObject[numberOfNeutrals];
        
            //spawn the given number of fish
        for (int i = 0; i < numberOfNeutrals; i++)
        {
            int fishType = Random.Range(0, neutralFish.Count);
            int route = Random.Range(1, numberOfActiveLoops);

                //spawn a fish of a random type on the location of the spawnpoint
            GameObject neutralFishClone = (GameObject)Instantiate(neutralFish[fishType], transform.position, transform.rotation);
                
                //choose a random movementloop of waypoints to follow and give it to the fish
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
            neutralFishClone.GetComponent<BackupFishMovement>().parentObject = fishtankTracker;

            Debug.Log("next entry position: ActiveFish[" + nextEnteryPosition + "]");
                //add the fish to an list of ative fish to be used in targetdisplay
            /*if (activeFish.Length != 0)
            {
                activeFish[nextEnteryPosition] = neutralFishClone;
                nextEnteryPosition++;
            }
            else
            {
                activeFish[0] = neutralFishClone;
                nextEnteryPosition++;
            }*/
            
                //build by zhifan new method to store the active neurtral fish in a array in targetdisplay
            neutralFish.Add(neutralFishClone);

            Debug.Log("spawed one Fish");

            counter = i;
            counter--;
            if (counter == numberOfNeutrals)
            {
                fishTargetDisplay.GetComponent<FishTargetDisplay>().PrefabsToString();
                fishTargetDisplay.GetComponent<FishTargetDisplay>().NextTarget();
                Debug.Log("fishSPAWWWWWNNNING");
            }
                //section ended

                //wait a random ammount of time to spawn the next fish
            yield return new WaitForSeconds(Random.Range(2.5f, 8.0f));
        }

            //same as spawing the neutral fish but without adding it to a list/array
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int enemytype = Random.Range(0, enemyFish.Length);
            int route = Random.Range(1, numberOfActiveLoops);

            GameObject enemyFishClone = (GameObject)Instantiate(enemyFish[enemytype], transform.position, transform.rotation);
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
            enemyFishClone.GetComponent<BackupFishMovement>().parentObject = fishtankTracker;

            yield return new WaitForSeconds(Random.Range(2.5f, 8.0f));

            Debug.Log("spawed one Enemy");
        }
    }
}
