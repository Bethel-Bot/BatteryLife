using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanAuto : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Movement>().canAuto = true;
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Pickup");




        }
    }
}
