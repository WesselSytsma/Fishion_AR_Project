using UnityEngine;
using System.Collections;

public class SpawnerBehaviour : MonoBehaviour {
    public GameObject SpawnPoint;
    public GameObject FishPreFab;

    int NumberOfFish = 0;
    Vector3 FishSpawnPoint;

    void Start () {
        FishSpawnPoint = SpawnPoint.transform.position;

        for (int i = 0; i < 10; i++)
        {
            NumberOfFish++;
            SpawnNewFish();
        }
	}
	
	void Update () {
        if (NumberOfFish < 10)
        {
            SpawnNewFish();
        }
	    
	}

    public void SpawnNewFish()
    {
        GameObject Fish = (GameObject)Instantiate(FishPreFab, FishSpawnPoint, Quaternion.identity);
    }
}
