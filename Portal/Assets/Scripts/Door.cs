using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private HandButton linkedHandButton;
    [SerializeField] private CubeButton linkedCubeButton;
    [SerializeField] private bool isCubeButtonLinked;
    [SerializeField] private bool isHandButtonLinked;

    private void Update()
    {
        if (isCubeButtonLinked)
        {
            doorAnimator.SetBool("IsOpened", linkedCubeButton.IsPressed);
        }
        else if (isHandButtonLinked)
        {
            doorAnimator.SetBool("IsOpened", linkedHandButton.IsPressed);
        }
    }
}
