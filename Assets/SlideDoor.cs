using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    public GameObject[] buttons; // The array of buttons to activate
    public LayerMask objectMask; // The layer mask used to detect objects on the buttons

    private bool[] buttonStates; // The array of button states (true if a button is activated, false otherwise)
    private Vector3 initialPosition; // The initial position of the door
    private bool doorOpen = false; // Whether the door is open or not

    void Start()
    {
        buttonStates = new bool[buttons.Length]; // Initialize the button states array
        initialPosition = transform.position; // Get the initial position of the door
    }

    void Update()
    {
        int count = 0; // The number of activated buttons

        foreach (GameObject button in buttons)
        {
            if (button.GetComponent<ButtonEpic>().ObjectOnButton) // Check if a button is activated
            {
                buttonStates[count] = true; // Set the corresponding button state to true
            }
            else
            {
                buttonStates[count] = false; // Set the corresponding button state to false
            }

            count++;
        }

        if (buttonStates[0] && buttonStates[1] && buttonStates[2]) // Check if all three buttons are activated
        {
            if (!doorOpen) // Check if the door is not already open
            {
                transform.position += new Vector3(0, 5, 0); // Move the door up by 5 units
                doorOpen = true; // Set the doorOpen variable to true
            }
        }
        else
        {
            if (doorOpen) // Check if the door is open
            {
                transform.position = initialPosition; // Move the door back to its initial position
                doorOpen = false; // Set the doorOpen variable to false
            }
        }
    }
}
