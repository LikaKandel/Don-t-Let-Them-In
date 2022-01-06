using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float startSpeed;
    [HideInInspector]public float _speed;
    public float startHealth = 0;
    private float health;
    [SerializeField] private float healthNeeded;
    [SerializeField] private int enemyReward;
    [SerializeField] private Image healthBar;

    private bool turned;

    public bool dead { get; set; }
    private void Start()
    {
        health = startHealth;turned = false;
    }
    public void TakeDamage(float amount)
    {
        
        health += amount;
        healthBar.fillAmount = health / healthNeeded;
        if (health >= healthNeeded)
        {
            Die();
        }
    }

    public void Slow(float slowAmount)
    {
        _speed = startSpeed * (1f - slowAmount);
    }
    void Die()
    {
        dead = true;
        _speed = 7;
        PlayerStats.Money += enemyReward;
        if (!turned)
        {
            transform.Rotate(new Vector3(0f, 180f, 0f), Space.World);
            turned = true;
        }
        
    }
   
}
