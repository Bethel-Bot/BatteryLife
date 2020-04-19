using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthRanged : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    public bool alive = true;
    public Animator anim;
    public ParticleSystem boom;
    float dropChance;

    public GameObject player;
    public GameObject AutoPew;
    public GameObject Heal;
    public GameObject Gun;
    void Start()
    {
        alive = true;
        currentHealth = maxHealth;

    }

    public void TakeDamage(int Damage)
    {
        FindObjectOfType<AudioManager>().Play("Hit");

        currentHealth -= Damage;

        anim.SetTrigger("Hurt");
        if (!alive)
        {
            return;
        }
        if (currentHealth <= 0)
        {
            boom.Play();
            Die();
        }
    }
    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Die");
        dropChance = Random.Range(1, 10);

        if (dropChance >= 9)
        {
            Instantiate(AutoPew, transform.position, transform.rotation);
        }
        if (dropChance < 2)
        {
            Instantiate(Heal, transform.position, transform.rotation);
        }

        currentHealth = 0;
        alive = false;


        player.GetComponent<Movement>().Kills += 1;

        GetComponentInChildren<TrailRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<EnemyFollow>().enabled = false;
        GetComponentInChildren<ShootPlayer>().enabled = false;
        GetComponentInChildren<ShootPlayer>().StopAllCoroutines();
        Gun.SetActive(false);
        

    }
}
