using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject player;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

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
