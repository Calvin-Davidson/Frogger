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
        if (Direction == direction.left)
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);            
        }

        if (Direction == direction.right)
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }
}
