using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Stats laserStats;
    private GameObject shooter;

    private void Start()
    {
        laserStats = shooter.GetComponent<Stats>();
    }

    public void SetShooter(GameObject shooter)
    {
        this.shooter = shooter;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == shooter) return;
        if (collision.gameObject.tag == "Asteroids" || collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Stats>().TakeDamage(laserStats.Damage);
            Destroy(gameObject);
        }
    }
}
