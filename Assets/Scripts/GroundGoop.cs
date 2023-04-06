using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGoop : MonoBehaviour
{
    public float jumpForce = 180f;
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 force = new Vector3(0, jumpForce, 0);
                rb.AddForce(force, ForceMode.VelocityChange);
            }
        }
    }
}
