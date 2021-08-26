using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private float thrust;
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
        rb.AddForce(transform.forward * Input.GetAxis("Thrust") * thrust);
    }
}
