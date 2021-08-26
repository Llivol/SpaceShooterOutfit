using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + (target.rotation * offset);
        Vector3 currentPosition = Vector3.Lerp(transform.position, desiredPosition, movementSpeed * Time.deltaTime);
        transform.position = currentPosition;

        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion currentRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = currentRotation;
    }
}
