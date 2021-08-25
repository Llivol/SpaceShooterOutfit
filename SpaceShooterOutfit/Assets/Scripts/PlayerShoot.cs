using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform[] shootPoints;
    [SerializeField] private float cooldown;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot()) shoot();
    }

    private bool canShoot()
    {
        return true;
    }

    private void shoot()
    {
        foreach (Transform shootPoint in shootPoints)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            bullet.transform.parent = shootPoint;
        }
    }
}
