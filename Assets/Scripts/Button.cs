using UnityEngine;

public class Button : MonoBehaviour
{
    public SlidingDoor doorToOpen;
    public LayerMask objectMask;

    private bool objectOnButton = false;

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
}
