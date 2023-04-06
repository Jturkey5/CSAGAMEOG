using UnityEngine;

public class GroundGoop : MonoBehaviour
{
    public float jumpForce = 01f; // The force with which the object will be propelled upwards

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            rb.AddForce(jumpVector, ForceMode.Impulse);
        }
    }
}
