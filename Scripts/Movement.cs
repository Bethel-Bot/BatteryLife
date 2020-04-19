using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;


    public GameObject BulletPrefab;
    GameObject BulletPrefabClone;
    //SlashForce
    public float BulletForce = 1;

    //WhereToSlash
    public Transform firePoint;
    //CoolDown
    public float coolDown = 1;
    public float coolDownTimer;

    public bool canAuto;


    public int Kills;


    


       









    //Movement Variables
    public float speed;

    private Vector2 moveVelocity;






    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DoT());
    }




    void Update()
    {
        if (Kills >= 100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;

        }
        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;

        }
        if (Input.GetButtonDown("Fire1") && canAuto)
        {
            StartCoroutine(disableAuto());
            InvokeRepeating("Attack", 0f, 1f/10f);
        }
        if (canAuto == false)
        {
            CancelInvoke("Attack");
        }

            if (Input.GetButtonDown("Fire1") && coolDownTimer == 0)
        {
            Attack();

        }
        //Movement
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(RegenRoutine());
            speed = 0f;
        }

        if (Input.GetButtonUp("Jump"))
        {
            StopCoroutine(RegenRoutine());
            speed = 1.5f;
        }










    }



    void FixedUpdate()
    {
        //Movement Positioning
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);


    }
    public void Attack()
    {
        //Attacking and destroying clone
        BulletPrefabClone = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = BulletPrefabClone.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * BulletForce, ForceMode2D.Impulse);

        


        Destroy(BulletPrefabClone, .2f);
        coolDownTimer = coolDown;
    }
    private IEnumerator RegenRoutine()
    {
        yield return new WaitForSeconds(1);

        GetComponent<Health>().Regen(4);

      
            
    }
    private IEnumerator DoT()
    {
        yield return new WaitForSeconds(2);

        GetComponent<Health>().TakeDamage(5);

        StartCoroutine(DoT());
    }
    private IEnumerator disableAuto()
    {
        yield return new WaitForSeconds(5);

        Debug.Log("done");
        canAuto = false;


    }
}
