using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private int amount;
    [SerializeField] private float maxDistance;
    [SerializeField] private float offset;

    private void Awake()
    {
        int asteroidsCount = asteroidPrefabs.Length;
        for (int i = 0; i < amount; i++)
        {
            GameObject asteroidPrefab = asteroidPrefabs[Random.Range(0, asteroidsCount - 1)];
            var newAsteroid = Instantiate(asteroidPrefab, Random.insideUnitSphere * maxDistance + Random.insideUnitSphere * offset, Random.rotation);
            newAsteroid.transform.SetParent(transform);
        }
    }
}
