using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    public int MaxAmmo;
    private bool hasShield;
    [SerializeField] private GameObject shield;
    [SerializeField] private Slider healthBar;

    protected override void Awake()
    {
        base.Awake();
        healthBar.maxValue = maxHitPoints;
        healthBar.value = maxHitPoints;
        hasShield = shield.activeSelf;
    }

    public override void TakeDamage(int amount)
    {
        if (hasShield) SetShield(false);
        else
        {
            base.TakeDamage(amount);
            healthBar.value = hitPoints;
        }

    }

    public void Heal(int amount)
    {
        hitPoints = Mathf.Min(hitPoints + amount, maxHitPoints);
        healthBar.value = hitPoints;
    }

    public void SetShield(bool value)
    {
        hasShield = value;
        shield.SetActive(value);
    }
}
