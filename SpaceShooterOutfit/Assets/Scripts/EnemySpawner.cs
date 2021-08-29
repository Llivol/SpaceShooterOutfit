using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float maxDistance;
    [SerializeField] private float offset;
    
    private void Awake()
    {
        int enemiesCount = enemyPrefabs.Length;
        for (int i = 0; i < enemiesCount; i++)
        {
            GameObject enemyPrefab = enemyPrefabs[i];
            var newEnemy = Instantiate(enemyPrefab, Random.insideUnitSphere * maxDistance + Random.insideUnitSphere * offset, Random.rotation);
            newEnemy.transform.SetParent(transform);
        }
    }
}
