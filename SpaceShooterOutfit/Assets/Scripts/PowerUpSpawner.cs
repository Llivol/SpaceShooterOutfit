using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject powerUpHealth;
    [SerializeField] private GameObject powerUpRecharge;
    [SerializeField] private GameObject powerUpShield;

    [Header("Amount")]
    [SerializeField] private int amountHealth;
    [SerializeField] private int amountRecharge;
    [SerializeField] private int amountShield;

    [Space(10)]
    [SerializeField] private float maxDistance;
    [SerializeField] private float offset;

    private void Start()
    {
        for (int i = 0; i < amountHealth; i++)
        {
            var healthUpPowerUp = Instantiate(powerUpHealth, Random.insideUnitSphere * maxDistance + Random.insideUnitSphere * offset, Random.rotation);
            healthUpPowerUp.transform.SetParent(transform);
        }

        for (int i = 0; i < amountRecharge; i++)
        {
            var rechargePowerUp = Instantiate(powerUpRecharge, Random.insideUnitSphere * maxDistance + Random.insideUnitSphere * offset, Random.rotation);
            rechargePowerUp.transform.SetParent(transform);
        }

        for (int i = 0; i < amountShield; i++)
        {
            var shieldPowerUp = Instantiate(powerUpShield, Random.insideUnitSphere * maxDistance + Random.insideUnitSphere * offset, Random.rotation);
            shieldPowerUp.transform.SetParent(transform);
        }
    }
}
