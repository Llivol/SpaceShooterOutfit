using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rotate();
    }

    private void rotate()
    {
        Vector3 rotation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 newForward = Vector3.RotateTowards(transform.forward, rotation, rotSpeed * Time.deltaTime, 0);
        rb.MoveRotation(Quaternion.LookRotation(newForward));
    }
}
