using UnityEngine;

public class Goop : MonoBehaviour
{
    public float launchForce = 5f; // The amount of force applied to the object when it is launched
    public GameObject groundGoopPrefab; // The prefab for the ground goop that should be spawned when the goop object collides with the ground layer

    private Rigidbody rb;
    private SphereCollider sphereCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
        rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Spawn ground goop at y = 0 and destroy this goop object
            Vector3 position = transform.position;
            position.y = 0f;
            Instantiate(groundGoopPrefab, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
