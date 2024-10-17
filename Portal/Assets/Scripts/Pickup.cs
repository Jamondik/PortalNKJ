using System.Runtime.CompilerServices;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private Transform pickupedObjectPosition;
    [SerializeField] private float impulseCoefficent;

    private bool isObjectPickuped;
    private Transform pickupedObjectTransform;

    private void Update()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (hit.transform.GetComponent<PickupableObject>() != null)
            {
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                rb.isKinematic = true;

                float distance = Vector3.Distance(transform.position, hit.transform.position);

                pickupedObjectPosition.localPosition = new Vector3(0, 0, distance);

                pickupedObjectTransform = hit.transform;
                isObjectPickuped = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && isObjectPickuped)
        {
            isObjectPickuped = false;
            hit.rigidbody.isKinematic = false;
            hit.rigidbody.AddForce(transform.forward * impulseCoefficent, ForceMode.Impulse);
        }

        if (isObjectPickuped)
        {
            pickupedObjectTransform.position = pickupedObjectPosition.position;
        }
    }
}
