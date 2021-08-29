using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Stats stats;

    private void Start()
    {
        stats = GetComponent<Stats>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Stats>()) collision.gameObject.GetComponent<Stats>().TakeDamage(stats.Damage);
        }
    }
}
