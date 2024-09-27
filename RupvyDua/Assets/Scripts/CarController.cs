using UnityEngine;

public class CarController : MonoBehaviour
{
    private Vector3 destination;
    private float speed = 5f;

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination, step);

        if (Vector3.Distance(transform.position, destination) < 0.001f)
        {
            Destroy(gameObject); // Destroy the car when it reaches the destination
        }
    }
}
