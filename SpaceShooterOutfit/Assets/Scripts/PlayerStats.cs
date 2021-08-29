using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    private bool hasShield;
    public int MaxAmmo;
    private int ammo;

    [Space(10)]
    [SerializeField] private GameObject shield;
    
    [Header("UI")]
    [SerializeField] private Slider healthBar;
    [SerializeField] private AmmoContainer ammoContainer;

    [Header("Audio")]
    private AudioSource audioSource;
    [SerializeField] private AudioClip healSfx;
    [SerializeField] private AudioClip shieldSfx;
    [SerializeField] private AudioClip breakShieldSfx;
    [SerializeField] private AudioClip rechargeSfx;
    
    [Header("Particles")]
    [SerializeField] private GameObject smokeThin1;
    [SerializeField] private GameObject smokeThin2;
    [SerializeField] private GameObject smokeThick1;
    [SerializeField] private GameObject smokeThick2;

    protected override void Awake()
    {
        base.Awake();
        healthBar.maxValue = maxHitPoints;
        healthBar.value = maxHitPoints;
        hasShield = shield.activeSelf;
        ammo = MaxAmmo;
        audioSource = GetComponent<AudioSource>();
    }

    public override void TakeDamage(int amount)
    {
        if (hasShield) SetShield(false);
        else
        {
            hitPoints -= amount;
            healthBar.value = hitPoints;

            setParticles();

            if (hitPoints <= 0)
            {
                GameManager.Instance.IncreaseScore(score);
                GameManager.Instance.GameOver();
                Destroy(gameObject);
            }
        }
    }

    public void Heal(int amount)
    {
        hitPoints = Mathf.Min(hitPoints + amount, maxHitPoints);
        healthBar.value = hitPoints;
        setParticles();
        playSfx(healSfx);
    }

    public void SetShield(bool value)
    {
        hasShield = value;
        shield.SetActive(value);
        playSfx((value) ? shieldSfx : breakShieldSfx);
    }

    public void AddAmmo(int amount)
    {
        ammo = Mathf.Min(ammo + amount, MaxAmmo);
        ammoContainer.AddAmmo(amount);
        playSfx(rechargeSfx);
    }

    public void RemoveAmmo()
    {
        ammo--;
        ammoContainer.RemoveAmmo();
    }

    public bool HasAmmo()
    {
        return ammo > 0;
    }

    private void playSfx(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void setParticles()
    {
        smokeThin1.SetActive(hitPoints < .8 * maxHitPoints);
        smokeThin2.SetActive(hitPoints < .6 * maxHitPoints);
        smokeThick1.SetActive(hitPoints < .4 * maxHitPoints);
        smokeThick2.SetActive(hitPoints < .2 * maxHitPoints);
    }
}
