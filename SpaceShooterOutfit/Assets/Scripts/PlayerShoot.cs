using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoints;
    private PlayerStats stats;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot()) shoot();
    }

    private bool canShoot()
    {
        return Time.timeScale > 0 && stats.HasAmmo();
    }

    private void shoot()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.transform.SetParent(transform.parent);
            bullet.GetComponent<Laser>().SetShooter(gameObject);
        }
        stats.RemoveAmmo();
    }
}
