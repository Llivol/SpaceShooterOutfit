using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoints;
    [SerializeField] private float cooldown;
    private PlayerStats stats;
    private float timeToShoot = 0;

    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Fire") == 1 && canShoot()) shoot();
        if (timeToShoot > 0) timeToShoot -= Time.deltaTime;
    }

    private bool canShoot()
    {
        return Time.timeScale > 0 && stats.HasAmmo() && timeToShoot <= 0;
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
        timeToShoot = cooldown;
    }
}
