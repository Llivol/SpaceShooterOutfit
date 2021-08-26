using UnityEngine;

public class PowerUpShield : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.parent.gameObject.GetComponent<PlayerStats>().SetShield(true);
            Destroy(gameObject);
        }
    }
}
