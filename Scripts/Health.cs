using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public bool alive = true;

    public HealthBarScript healthbar;
    public Animator anim;


    void Start()
    {
        alive = true;
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int Damage)
    {

        FindObjectOfType<AudioManager>().Play("Hit");
        anim.SetTrigger("Hurt");
       

        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
        currentHealth -= Damage;
        healthbar.SetHealth(currentHealth);
        if (!alive)
        {
            return;
        }
        if (currentHealth <= 0)
        {
            Die();
        }


    }

    public void Regen(int regen)
    {
        
        currentHealth += regen;
        healthbar.SetHealth(currentHealth);
        if (!alive)
        {
            return;
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Die");
        currentHealth = 0;
        alive = false;
        gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    
}
