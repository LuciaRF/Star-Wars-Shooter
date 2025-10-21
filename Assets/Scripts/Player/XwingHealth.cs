using UnityEngine;
using UnityEngine.UI;

public class XwingHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;
    [SerializeField] float damageBullet;

    [SerializeField] private Image lifeBar;
    [SerializeField] private ParticleSystem bigExplosion, 
                                            smallExplosion;
    
    [SerializeField] GameManager gameManager;

    private void Awake()
    {
        currentHealth = maxHealth;
        lifeBar.fillAmount = 1;
        bigExplosion.Stop();
        smallExplosion.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
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
        gameManager.GameOver();
        bigExplosion.Play();
        Camera.main.transform.SetParent(null);
        Destroy(gameObject, 1.8f);
        
    }
}
