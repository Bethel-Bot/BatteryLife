using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject BulletPrefab;
    GameObject BulletPrefabClone;
    //SlashForce
    public float BulletForce = 1;

    //WhereToSlash
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackPlayer());
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(2);


            Attack();

        StartCoroutine(AttackPlayer());

        
    }
    public void Attack()
    {
        //Attacking and destroying clone
        BulletPrefabClone = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = BulletPrefabClone.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * BulletForce, ForceMode2D.Impulse);




        Destroy(BulletPrefabClone, .6f);
        
    }
}
