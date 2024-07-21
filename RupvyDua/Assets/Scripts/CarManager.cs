using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] spawnPoints;
    public Transform[] destinationPoints;

    private float spawnInterval = 5f;

    void Start()
    {
        StartCoroutine(SpawnCars());
    }

    IEnumerator SpawnCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Randomly select a spawn point and a destination point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Transform destinationPoint = destinationPoints[Random.Range(0, destinationPoints.Length)];

            GameObject car = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);
            CarController carController = car.GetComponent<CarController>();
            carController.SetDestination(destinationPoint.position);
        }
    }
}
