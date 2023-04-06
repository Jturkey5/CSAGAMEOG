using UnityEngine;

public class BuildArea : MonoBehaviour
{
    public static bool canBuild = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canBuild = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canBuild = false;
        }
    }
}
