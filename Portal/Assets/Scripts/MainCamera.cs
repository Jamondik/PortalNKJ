using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] public Portal[] _portals;

    [SerializeField] private Camera _myCamera;

    private void OnPreRender()
    {
        for (int i = 0; i < _portals.Length; i++)
        {
            if (_portals[i] != null)
            {
                _portals[i].Render(_myCamera);
            }
        }
    }
}