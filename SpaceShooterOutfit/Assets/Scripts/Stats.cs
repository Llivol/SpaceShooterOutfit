using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] protected GameObject explosionPrefab;

    [Header("Stats")]
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
        if (hitPoints <= 0) return;
        
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            GameManager.Instance.IncreaseScore(score);
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            explosion.transform.SetParent(transform.parent);
            Destroy(gameObject);
        }
    }
}
