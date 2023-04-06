using UnityEngine;

public class TerrainBuilder : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject cubePrefab;
    public LayerMask buildMask;
    public float maxBuildDistance = 10f;
    public KeyCode buildKey = KeyCode.B;

    void Update()
    {
        if (Input.GetKeyDown(buildKey))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxBuildDistance, buildMask))
            {
                Vector3 spawnPosition = hit.point + hit.normal * 0.5f; // Add half the size of the cube to place it on the surface
                spawnPosition = new Vector3(Mathf.Round(spawnPosition.x), Mathf.Round(spawnPosition.y), Mathf.Round(spawnPosition.z)); // Round position values to create a grid-like placement
                Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
