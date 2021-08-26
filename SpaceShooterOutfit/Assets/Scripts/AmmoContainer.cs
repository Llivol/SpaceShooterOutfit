using UnityEngine;

public class AmmoContainer : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        for (int i = 0; i < playerStats.MaxAmmo; i++)
        {
            var bullet = Instantiate(ammoPrefab);
            bullet.transform.SetParent(transform);
        }
    }

    public bool HasAmmo()
    {
        return transform.childCount > 0;
    }

    public void AddAmmo(int amount)
    {
        for (int i = 0; i < amount && transform.childCount < playerStats.MaxAmmo; i++)
        {
            var bullet = Instantiate(ammoPrefab);
            bullet.transform.SetParent(transform);
        }
    }

    public void RemoveAmmo()
    {
        Destroy(transform.GetChild(0).gameObject);
    }
}
