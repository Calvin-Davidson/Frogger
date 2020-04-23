using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    private float speed = 15;
    public enum direction
    {
        right,
        left
    }

    public direction Direction;
    private void Update()
    {
        if (Direction == direction.right)
        {
            if ((transform.position.x >= 100 || transform.position.x <= -100))
            {
                Destroy(this.gameObject);
            }
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);            
        }

        if (Direction == direction.left)
        {
            if ((transform.position.x >= 100 || transform.position.x <= -100))
            {
                Destroy(this.gameObject);
            }
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }
}
