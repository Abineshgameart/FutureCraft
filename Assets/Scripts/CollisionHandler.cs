using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CollisionHandler : MonoBehaviour
{

    public Transform correctPosition; // The correct target position on the assembled model
    public float snapThreshold = 1f; // Distance threshold for snapping
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool isCollidingWithCorrectPart = false;
    public MeshRenderer correctPositionRenderer;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        grabInteractable.selectExited.AddListener(OnRelease);
        //correctPositionRenderer = correctPosition.GetComponent<MeshRenderer>();
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (isCollidingWithCorrectPart && Vector3.Distance(transform.position, correctPosition.position) < snapThreshold)
        {
            SnapToCorrectPosition();
        }
    }

    void SnapToCorrectPosition()
    {
        transform.position = correctPosition.position;
        transform.rotation = correctPosition.rotation;
        rb.isKinematic = true; // Prevent further movement
        grabInteractable.enabled = false; // Disable XRGrabInteractable
        if (correctPositionRenderer != null)
        {
            correctPositionRenderer.enabled = false; // Hide only the mesh renderer
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == correctPosition)
        {
            isCollidingWithCorrectPart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == correctPosition)
        {
            isCollidingWithCorrectPart = false;
        }
    }
}
