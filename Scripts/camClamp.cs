using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camClamp : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x,-2.55f, 1.77f),
            Mathf.Clamp(target.position.y, 6.58f, -5.11f),
            transform.position.z);
    }
}
