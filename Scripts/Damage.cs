using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public int dmg;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
            collision.gameObject.GetComponent<EnemyFollow>().dazeTime = collision.gameObject.GetComponent<EnemyFollow>().StartdazeTime;
            gameObject.SetActive(false);





        }
        else if (collision.gameObject.tag == "EnemyRanged")
        {
            collision.gameObject.GetComponent<EnemyHealthRanged>().TakeDamage(dmg);
            collision.gameObject.GetComponent<EnemyFollow>().dazeTime = collision.gameObject.GetComponent<EnemyFollow>().StartdazeTime;
            gameObject.SetActive(false);





        }
    }
}
