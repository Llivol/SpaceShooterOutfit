using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoints;
    [SerializeField] private float cooldown;
    private float timeToShoot = 0;
    private bool isShooting;
    
    private void Update()
    {
        if (canShoot()) shoot();

        if (timeToShoot > 0) timeToShoot -= Time.deltaTime;
    }

    private bool canShoot()
    {        
        return isShooting && timeToShoot <= 0;
    }

    private void shoot()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.transform.SetParent(transform.parent);
            bullet.GetComponent<Laser>().SetShooter(gameObject);
        }

        timeToShoot = cooldown;
    }

    public void SetIsShooting(bool value)
    {
        isShooting = value;
    }
}
