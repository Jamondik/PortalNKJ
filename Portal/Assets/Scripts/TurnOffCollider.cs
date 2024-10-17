using Unity.VisualScripting;
using UnityEngine;

public class TurnOffCollider : MonoBehaviour
{
    [SerializeField] public Collider SettedWallColider;
    [SerializeField] private TurnOffCollider other;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SettedWallColider.enabled = false;
            this.other.SettedWallColider.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SettedWallColider.enabled = true;
            this.other.SettedWallColider.enabled = true;
        }
    }
}
