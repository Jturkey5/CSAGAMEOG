using UnityEngine;

public class ItemPickerUpper : MonoBehaviour
{
    public Camera playerCamera;
    public float pickupRange = 3f; // Increase the pickup range
    public float pickupRadius = 0.5f; // Add this variable to define the radius of the sphere used for picking up items
    public LayerMask pickupMask;
    public float distanceOffset = 0.5f;
    public int heldItemLayer;
    public float heldItemDistance = 2f;

    private GameObject heldItem;
    private Collider heldItemCollider;
    private int originalLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (heldItem == null)
            {
                PickupItem();
            }
            else
            {
                DropItem();
            }
        }

        if (heldItem != null)
        {
            Vector3 newPosition = playerCamera.transform.position + playerCamera.transform.forward * heldItemDistance;
            heldItem.transform.position = newPosition;
        }
    }

    void PickupItem()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, pickupRadius, transform.forward, out hit, pickupRange, pickupMask))
        {
            heldItem = hit.collider.gameObject;
            heldItemCollider = heldItem.GetComponent<Collider>();
            heldItem.GetComponent<Rigidbody>().isKinematic = true;
            heldItem.transform.SetParent(playerCamera.transform);

            if (heldItemCollider != null)
            {
                heldItemCollider.enabled = false;
            }

            originalLayer = heldItem.layer;
            heldItem.layer = heldItemLayer;
        }
    }

    void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            heldItem.transform.SetParent(null);

            if (heldItemCollider != null)
            {
                heldItemCollider.enabled = true;
            }

            heldItem.layer = originalLayer; // Restore the original layer

            heldItem = null;
            heldItemCollider = null;
        }
    }
}
