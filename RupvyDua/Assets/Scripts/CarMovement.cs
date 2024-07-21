using UnityEngine;
using UnityEngine.Tilemaps;

public class CarMovement : MonoBehaviour
{
    public float speed = 2f;
    private bool isStopped = false;
    private float stopDuration = 2f;
    private float stopTimer = 0f;

    public TileBase roadTile;
    private Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (isStopped)
        {
            stopTimer += Time.deltaTime;
            if (stopTimer >= stopDuration)
            {
                isStopped = false;
                stopTimer = 0f;
            }
            return;
        }

        MoveTowardsWaypoint();
    }

    public void SetWaypoints(Vector3[] newWaypoints)
    {
        waypoints = new Transform[newWaypoints.Length];
        for (int i = 0; i < newWaypoints.Length; i++)
        {
            GameObject waypointObject = new GameObject("Waypoint");
            waypointObject.transform.position = newWaypoints[i];
            waypoints[i] = waypointObject.transform;
        }
        currentWaypointIndex = 0;
    }

    private void MoveTowardsWaypoint()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            isStopped = true;
        }
    }
}
