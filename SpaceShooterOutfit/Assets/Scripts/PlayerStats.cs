using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    [SerializeField] private Slider healthBar;

    protected override void Awake()
    {
        base.Awake();
        healthBar.maxValue = maxHitPoints;
        healthBar.value = maxHitPoints;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        healthBar.value = maxHitPoints;
    }
}
