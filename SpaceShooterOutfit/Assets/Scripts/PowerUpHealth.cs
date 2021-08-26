using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    [SerializeField] private int healingAmount;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.parent.gameObject.GetComponent<PlayerStats>().Heal(healingAmount);
            Destroy(gameObject);
        }
    }
}
