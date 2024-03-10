using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Vector3 _distanceFromObject;
    [SerializeField] private float _currentVelocity;

    private void FixedUpdate()
    {
                Vector3 positionToGo = _object.transform.position + _distanceFromObject;
                Vector3 smoothPosition = Vector3.Lerp(transform.position, positionToGo, 0.05F);
                transform.position = Vector3.Lerp(transform.position, smoothPosition, _currentVelocity * Time.deltaTime);
                transform.LookAt(_object.transform.position);
    }
}
