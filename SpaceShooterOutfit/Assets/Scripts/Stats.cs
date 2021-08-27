using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Damage;
    [SerializeField] protected int maxHitPoints;
    [SerializeField] protected int score;
    protected int hitPoints;

    protected virtual void Awake()
    {
        hitPoints = maxHitPoints;
    }

    public virtual void TakeDamage(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0) 
        {
            GameManager.Instance.IncreaseScore(score);
            Destroy(gameObject);
        }
    }
}
