using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
    [SerializeField] private GameObject waypointPrefab;
    [SerializeField] private float maxDistance;
    [SerializeField] private int amount;
    
    private void Awake()
    {
        for (int i = 0; i < amount; i++)
        {
            var newWaypoint = Instantiate(waypointPrefab, Random.insideUnitSphere * maxDistance, Quaternion.identity);
            newWaypoint.transform.SetParent(transform);
        }
    }
}
