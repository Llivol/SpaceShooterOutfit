using UnityEngine;

public class EnemyForgettingArea : MonoBehaviour
{
    [SerializeField] private Transform parentEnemy;
    private EnemyMovement movement;
    private EnemyShoot shoot;

    private void Awake()
    {
        movement = parentEnemy.GetComponent<EnemyMovement>();
        shoot = parentEnemy.GetComponent<EnemyShoot>();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            movement.StopChasing();
            shoot.SetIsShooting(false);
        }
    }
}
