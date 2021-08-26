using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Damage;
    public int HitPoints;

    public void TakeDamage(int damage)
    {
        HitPoints -= damage;

        if (HitPoints <= 0) Destroy(gameObject);
    }
}
