using UnityEngine;

public class ItemPickerUpper : MonoBehaviour
{
    public Camera playerCamera;
    public float pickupRange = 2f;
    public LayerMask pickupMask;
    public float distanceOffset = 0.5f;
    public int heldItemLayer; // Add this variable to store the "HeldItem" layer index

    private GameObject heldItem;
    private Collider heldItemCollider;
    private int originalLayer; // Add this variable to store the original layer of the held item

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
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
            {
                Vector3 newPosition = hit.point + hit.normal * distanceOffset;
                heldItem.transform.position = newPosition;
            }
        }
    }

    void PickupItem()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange, pickupMask))
        {
            heldItem = hit.collider.gameObject;
            heldItemCollider = heldItem.GetComponent<Collider>();
            heldItem.GetComponent<Rigidbody>().isKinematic = true;
            heldItem.transform.SetParent(playerCamera.transform);

            if (heldItemCollider != null)
            {
                heldItemCollider.enabled = false;
            }

            originalLayer = heldItem.layer; // Store the original layer
            heldItem.layer = heldItemLayer; // Set the held item's layer to "HeldItem"
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
