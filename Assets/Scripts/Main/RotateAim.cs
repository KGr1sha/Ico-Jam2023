using UnityEngine;

public class RotateAim : MonoBehaviour
{
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private float _pistolAngle;

    private Camera _worldCamera;

    private void Start()
    {
        _worldCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 mousePosition = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, Mathf.Abs(aimDirection.x)) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -_pistolAngle, _pistolAngle);
        _aimTransform.eulerAngles = new Vector3(0, _aimTransform.eulerAngles.y, angle);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 worldPosition = _worldCamera.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0f;
        return worldPosition;
    }
}
