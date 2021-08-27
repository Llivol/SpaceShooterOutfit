using UnityEngine;

public class Laser : MonoBehaviour
{
    private Stats laserStats;
    private GameObject shooter;
    [SerializeField] protected GameObject hitPrefab;

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
            var hit = Instantiate(hitPrefab, transform.position, transform.rotation);
            hit.transform.SetParent(transform.parent);
            Destroy(gameObject);
        }
    }
}
