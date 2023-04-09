using UnityEngine;

public class TerrainBuilder : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject cubePrefab;
    public LayerMask buildMask;
    public float maxBuildDistance = 10f;
    public KeyCode buildKey = KeyCode.B;

    private bool canBuild = false; // Add this variable to control building permission

    void Update()
    {
        if (Input.GetKeyDown(buildKey)) // Check if the player can build before processing the build key
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxBuildDistance, buildMask))
            {
                Vector3 spawnPosition = hit.point + hit.normal * 0.5f;
                spawnPosition = new Vector3(Mathf.Round(spawnPosition.x), Mathf.Round(spawnPosition.y), Mathf.Round(spawnPosition.z));
                Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            }
        }
    }

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
