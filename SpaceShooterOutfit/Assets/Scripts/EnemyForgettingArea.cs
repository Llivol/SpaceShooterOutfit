using UnityEngine;

public class EnemyForgettingArea : MonoBehaviour
{
    [SerializeField] private EnemyMovement parentEnemy;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parentEnemy.StopChasing();
        }
    }
}
