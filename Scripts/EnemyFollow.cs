using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    private bool isWalking;
    public float AgroRange;

   public Transform target;
   

    public float coolDown = 1;
    public float coolDownTimer;

    public float dazeTime;
    public float StartdazeTime;
    void Start()
    {          //Find Player
       
    }
    void Update()
    {




        if (dazeTime <= 0)
        {
            speed = 1f;
        }
        else
        {
            speed = 0;
            dazeTime -= Time.deltaTime;
        }

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;

        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;

        }


        float distToPlayer = Vector2.Distance(transform.position, target.position);
        //Move To Player
        if (distToPlayer < AgroRange)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        

    }

    //Do Damage
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && coolDownTimer == 0)
        {
          collision.GetComponent<Health>().TakeDamage(2);
            coolDownTimer = coolDown;
        }

       
    }

}
