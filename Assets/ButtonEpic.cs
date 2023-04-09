using UnityEngine;

public class ButtonEpic : MonoBehaviour
{
    public LayerMask objectMask; // The layer mask used to detect objects on the button
    public float buttonPressDepth = 0.1f; // The distance the button will move down when activated

    private Vector3 initialPosition; // The initial position of the button
    private bool objectOnButton = false; // Whether an object is on the button or not
    private bool buttonPressed = false; // Whether the button is currently being pressed or not

    public bool ObjectOnButton // Property to get the objectOnButton variable
    {
        get { return objectOnButton; }
    }

    void Start()
    {
        initialPosition = transform.position; // Get the initial position of the button
    }

    void Update()
    {
        if (buttonPressed) // Check if the button is currently being pressed
        {
            return; // If so, do nothing and wait for the button to be released
        }

        if (objectOnButton) // Check if an object is on the button
        {
            transform.position -= new Vector3(0, buttonPressDepth, 0); // Move the button down by the buttonPressDepth distance
            buttonPressed = true; // Set the buttonPressed variable to true
        }
        else
        {
            transform.position = initialPosition; // Move the button back to its initial position
            buttonPressed = false; // Set the buttonPressed variable to false
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!buttonPressed && (objectMask.value & 1 << other.gameObject.layer) != 0) // Check if the other object is in the specified layer mask, and the button is not currently being pressed
        {
            objectOnButton = true; // Set the objectOnButton variable to true
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (objectOnButton && (objectMask.value & 1 << other.gameObject.layer) != 0) // Check if the other object is in the specified layer mask, and an object is currently on the button
        {
            objectOnButton = false; // Set the objectOnButton variable to false
            buttonPressed = false; // Set the buttonPressed variable to false
        }
    }
}
