using UnityEngine;

public class PowerUpAmmo : MonoBehaviour
{
    [SerializeField] private int ammoAmount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.parent.gameObject.GetComponent<PlayerStats>().AddAmmo(ammoAmount);
            Destroy(gameObject);
        }
    }
}
