using UnityEngine;

public class CubeButton : MonoBehaviour
{
    [SerializeField] private Animator buttonAnimator;

    [HideInInspector] public bool IsPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            IsPressed = true;
            buttonAnimator.SetBool("isPressed", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            IsPressed = false;
            buttonAnimator.SetBool("isPressed", false);
        }
    }
}
