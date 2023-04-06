using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    public GameObject door;
    public float closeSpeed = 2f;
    public float closedYPosition = 0f; // Set this to the desired Y position when the door is closed

    private bool playerEntered = false;
    private Vector3 closedPosition;

    private void Start()
    {
        closedPosition = new Vector3(door.transform.position.x, closedYPosition, door.transform.position.z);
    }

    private void Update()
    {
        if (playerEntered)
        {
            door.transform.position = Vector3.Lerp(door.transform.position, closedPosition, Time.deltaTime * closeSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
        }
    }
}
