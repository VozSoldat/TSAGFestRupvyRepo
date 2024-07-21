using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 5f;
    private int currentWaypointIndex = 0;
    private bool isAtRestaurant = false;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        if (!isAtRestaurant)
        {
            MoveTowardsWaypoint();
        }
    }

    void MoveTowardsWaypoint()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject); // Menghilangkan mobil setelah mencapai waypoint terakhir
            }
            else if (currentWaypointIndex == 1) // Asumsi waypoint kedua adalah restoran
            {
                StartCoroutine(StopAtRestaurant(3f)); // Berhenti selama 3 detik di restoran
            }
        }
    }

    IEnumerator StopAtRestaurant(float waitTime)
    {
        isAtRestaurant = true;
        yield return new WaitForSeconds(waitTime);
        isAtRestaurant = false;
    }
}
