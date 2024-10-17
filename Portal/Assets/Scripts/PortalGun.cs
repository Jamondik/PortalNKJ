using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.ProBuilder.Shapes;

public class PortalGun : MonoBehaviour
{
    [SerializeField] private GameObject bluePortalPrefab;
    [SerializeField] private GameObject redPortalPrefab;
    [SerializeField] private float portalDisplacement;
    [SerializeField] private MainCamera mainCameraScript;
    [SerializeField] private Animator portalGunAnimator;
    [SerializeField] private AnimationClip shootAnimationClip;
    [SerializeField] private Vector3 portalScale;
    [SerializeField] private GameObject installedBluePortal;
    [SerializeField] private GameObject installedRedPortal;

    private bool isBluePortalInstalled = false;
    private bool isRedPortalInstalled = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit);
            
            Vector3 intersectionPosition = hit.point;

            Vector3 intersectionPositionInLocal = hit.transform.position - hit.point;

            StartCoroutine(PortalGunAnimationer());

            if (hit.collider.GetComponent<WallInfo>().IsPortalSuitable)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject bluePortalStoper = installedBluePortal.transform.Find("Stoper").gameObject;
                    GameObject bluePortalUnactiveQuad = installedBluePortal.transform.Find("UnactiveQuad").gameObject;

                    PortalShooter(isRedPortalInstalled, hit, installedBluePortal, bluePortalStoper, bluePortalUnactiveQuad);
                    isBluePortalInstalled = true;
                }
                else if (Input.GetMouseButtonDown(1))
                {
                    GameObject redPortalStoper = installedRedPortal.transform.Find("Stoper").gameObject;
                    GameObject redPortalUnactiveQuad = installedRedPortal.transform.Find("UnactiveQuad").gameObject;

                    PortalShooter(isBluePortalInstalled, hit, installedRedPortal, redPortalStoper, redPortalUnactiveQuad);
                    isRedPortalInstalled = true;
                }              
            }
        }
    }

    private void PortalShooter(bool isPortalPlaced, RaycastHit hit, GameObject installedPortal, GameObject installedPortalStopper, GameObject installedPortalUnactiveQuad)
    {
        PortalRenderer portalRenderer = installedPortal.GetComponentInChildren<PortalRenderer>();
        Portal portal = installedPortal.GetComponent<Portal>();
        portal._renderer = portalRenderer;
        portal._wallColliders[0] = hit.collider;

        installedPortal.transform.position = hit.point + hit.normal * portalDisplacement / 2;
        installedPortal.transform.rotation = Quaternion.LookRotation(-hit.normal);
      
        if (!isPortalPlaced)
        {
            installedPortalStopper.SetActive(true);
        }
        else
        {
            installedPortalStopper.SetActive(false);
            installedPortalUnactiveQuad.SetActive(false);
        }
        
    }

    private IEnumerator PortalGunAnimationer()
    {
        portalGunAnimator.SetBool("Shooting", true);
        yield return new WaitForSeconds(shootAnimationClip.averageDuration);
        portalGunAnimator.SetBool("Shooting", false);
    }
}
