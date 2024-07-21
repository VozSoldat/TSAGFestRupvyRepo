using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform spawnPoint;
    public Transform[] waypoints;
    public float spawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            GameObject car = Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
            CarMovement carMovement = car.GetComponent<CarMovement>();
            carMovement.waypoints = waypoints;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
