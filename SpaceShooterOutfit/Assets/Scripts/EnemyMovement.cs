using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private float thrust;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float offset;
    private Rigidbody rb;
    private int curPoint = 0;
    private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        target = waypoints[curPoint];
        if (Vector3.Distance(target.position, transform.position) < offset) selectNextWaypoint();
        
        move();
        rotate();
    }

    private void rotate()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        Quaternion rotation = targetRotation * Quaternion.Inverse(rb.rotation);
        rb.AddTorque(rotation.x / Time.fixedDeltaTime, rotation.y / Time.fixedDeltaTime, rotation.z / Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void move()
    {
        rb.AddForce(transform.forward * thrust);
    }

    private void selectNextWaypoint()
    {
        curPoint++;
        if (curPoint >= waypoints.Length) curPoint = 0;

        target = waypoints[curPoint];
    }
}
