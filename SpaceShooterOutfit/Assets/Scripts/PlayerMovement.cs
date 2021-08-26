using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private float thrust;
    [SerializeField] private float minCameraFov;
    [SerializeField] private float maxCameraFov;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        move();
        rotate();
    }

    private void rotate()
    {
        rb.AddTorque(transform.up * Input.GetAxis("Horizontal") * torque);
        rb.AddTorque(transform.right * Input.GetAxis("Vertical") * torque);
    }

    private void move()
    {
        Camera.main.fieldOfView = (Input.GetAxis("Thrust") > 0) ? minCameraFov : maxCameraFov;

        rb.AddForce(transform.forward * Input.GetAxis("Thrust") * thrust);
    }
}
