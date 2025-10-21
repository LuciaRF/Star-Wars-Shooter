using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    
    [SerializeField] private float damageBullet;
    
    [SerializeField] private Image lifeBar;

    [SerializeField] private ParticleSystem smallExplosion,
                                            bigExplosion;


    private void Awake()
    {
        smallExplosion.Stop();
        bigExplosion.Stop();
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            smallExplosion.Play();
            currentHealth -= damageBullet;
            lifeBar.fillAmount = currentHealth / maxHealth;
            Destroy(other.gameObject);

            if (currentHealth <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        bigExplosion.Play();
        Destroy(gameObject, 1f);
    }
}
