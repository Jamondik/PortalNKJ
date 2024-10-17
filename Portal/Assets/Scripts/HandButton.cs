using System.Collections;
using UnityEngine;

public class HandButton : MonoBehaviour
{
    [SerializeField] private Animator handButtonAnimator;
    [SerializeField] private AnimationClip handButtonAnimationClip;
    [SerializeField] private int pressingTime;

    [HideInInspector] public bool IsPressed;

    private Transform mainCameraTransform;

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Physics.Raycast(mainCameraTransform.position, mainCameraTransform.forward, out hit);

            if (hit.transform.CompareTag("HandButton"))
            {
                StartCoroutine(ButtonAnimator());
            }
        }
    }

    private IEnumerator ButtonAnimator()
    {
        IsPressed = true;
        handButtonAnimator.SetBool("isPressed", true);

        yield return new WaitForSeconds(handButtonAnimationClip.averageDuration);
        handButtonAnimator.SetBool("isPressed", false);

        yield return new WaitForSeconds(pressingTime);
        IsPressed = false;
    }
}
