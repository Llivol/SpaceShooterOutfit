using UnityEngine;

public class EnemyDetectionArea : MonoBehaviour
{
    [SerializeField] private EnemyMovement parentEnemy;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parentEnemy.StartChasing(other.gameObject.transform);
        }
    }
}
