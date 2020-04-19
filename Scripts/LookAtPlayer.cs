using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public GameObject entityplayer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.position - transform.position;

        difference.Normalize();

        //Find Angle
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //Actual Rotation
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        //Angle Flip Specifications
        if (rotationZ < -90 || rotationZ > 90)
        {

            //Flip
            if (player.transform.eulerAngles.y == 0)
            {

                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);

            }

            else if (player.transform.eulerAngles.y == 0)
            {

                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);


            }




        }
    }
}