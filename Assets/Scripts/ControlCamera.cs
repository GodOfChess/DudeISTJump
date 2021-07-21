using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Transform playerpos;

    public void Update()
    {
        if (playerpos.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, playerpos.position.y, transform.position.z);
        }
    }
}
