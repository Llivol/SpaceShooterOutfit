using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
