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
        Vector3 toPos = target.position + (target.rotation * offset);
        Vector3 curPos = Vector3.Lerp(transform.position, toPos, movementSpeed * Time.deltaTime);
        transform.position = curPos;

        Quaternion toRot = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion curRot = Quaternion.Slerp(transform.rotation, toRot, rotationSpeed * Time.deltaTime);
        transform.rotation = curRot;
    }
}
