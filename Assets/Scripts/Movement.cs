﻿using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public PlayerData playerData = new PlayerData();
    public Camera camera;

    [SerializeField] private GameObject MovementCheckerFront;
    [SerializeField] private GameObject MovementCheckerBack;
    [SerializeField] private GameObject MovementCheckerRight;
    [SerializeField] private GameObject MovementCheckerLeft;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject Model;
    private void Start()
    {
        playerData = this.gameObject.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    private void Update()
    {
        animator.SetInteger("Walk", 0);
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (MovementCheckerFront.GetComponent<AllowMovementChecker>().getCanMove())
            {
                move(new Vector3(0,0,speed));
                playerData.addScore(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (this.transform.position.z <= -10)
            {
                return;
            }

            if (MovementCheckerBack.GetComponent<AllowMovementChecker>().getCanMove())
            {
                move(new Vector3(0, 0, -speed));
                playerData.removeScore(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (this.transform.position.x <= -10)
            {
                return;
            }

            if (MovementCheckerLeft.GetComponent<AllowMovementChecker>().getCanMove())
            {
                move(new Vector3(-speed, 0, 0));
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (this.transform.position.x >= 10)
            {
                return;
            }

            if (MovementCheckerRight.GetComponent<AllowMovementChecker>().getCanMove())
            {
                move(new Vector3(speed, 0, 0));
            }
        }
    }

    public void move(Vector3 dir)
    {
        transform.position = transform.position + dir;
        animator.SetInteger("Walk", 1);
    }
}