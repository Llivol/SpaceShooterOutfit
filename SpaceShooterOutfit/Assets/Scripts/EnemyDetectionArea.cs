using UnityEngine;

public class EnemyDetectionArea : MonoBehaviour
{
    [SerializeField] private Transform parentEnemy;
    private EnemyMovement movement;
    private EnemyShoot shoot;

    private void Awake()
    {
        movement = parentEnemy.GetComponent<EnemyMovement>();
        shoot = parentEnemy.GetComponent<EnemyShoot>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movement.StartChasing(other.gameObject.transform);
            shoot.SetIsShooting(true);
        }
    }
}
