using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float doorSpeed = 1f;
    public float doorHeight = 5f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    void Start()
    {
        closedPosition = transform.position;
        openPosition = new Vector3(transform.position.x, transform.position.y + doorHeight, transform.position.z);
    }

    void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, doorSpeed * Time.deltaTime);
            if (transform.position == openPosition)
            {
                isOpening = false;
            }
        }

        if (isClosing)
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, doorSpeed * Time.deltaTime);
            if (transform.position == closedPosition)
            {
                isClosing = false;
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    public void CloseDoor()
    {
        isClosing = true;
        isOpening = false;
    }
}
