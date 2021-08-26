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
        print(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemies" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Stats>().TakeDamage(stats.Damage);
        }
    }
}
