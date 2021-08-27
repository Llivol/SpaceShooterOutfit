using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float torque;
    [SerializeField] private float thrust;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waypointOffset;
    [SerializeField] private float saeftyDistance;
    private Rigidbody rb;
    private int curPoint = 0;
    private bool isChasing = false;
    private Transform target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isChasing)
        {
            target = waypoints[curPoint];
            if (Vector3.Distance(target.position, transform.position) < waypointOffset) selectNextWaypoint();
        }

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
        if (isChasing && Vector3.Distance(target.position, transform.position) < saeftyDistance) return;
        
        rb.AddForce(transform.forward * thrust);
    }

    private void selectNextWaypoint()
    {
        curPoint++;
        if (curPoint >= waypoints.Length) curPoint = 0;

        target = waypoints[curPoint];
    }

    public void StartChasing(Transform chaseTarget)
    {
        isChasing = true;
        target = chaseTarget;
    }
    public void StopChasing()
    {
        isChasing = false;
    }
}
