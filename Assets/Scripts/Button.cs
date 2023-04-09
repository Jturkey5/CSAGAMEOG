using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject doorObject;
    public LayerMask objectMask;

    private bool objectOnButton = false;

    private SlidingDoor doorToOpen;

    void Start()
    {
        doorToOpen = doorObject.GetComponent<SlidingDoor>();
    }

    void Update()
    {
        if (objectOnButton)
        {
            doorToOpen.OpenDoor();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((objectMask.value & 1 << other.gameObject.layer) != 0) // Check if the other object is in the specified layer mask
        {
            objectOnButton = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if ((objectMask.value & 1 << other.gameObject.layer) != 0) // Check if the other object is in the specified layer mask
        {
            objectOnButton = false;
            doorToOpen.CloseDoor();
        }
    }

    public bool ObjectOnButton // Property to get the objectOnButton variable
    {
        get { return objectOnButton; }
    }
}
