using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public Transform LaunchPoint;
    public GameObject arrowPrefab;
    private Vector2 AimDirection = Vector2.right;



    // Update is called once per frame
    void Update()
    {
        HandleAiming();

        if (Input.GetButtonDown("Shoot"))
        {
        Shoot();
            
        }
    }

    private void HandleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            AimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }

    public void Shoot()
    {
       Arrow arrow = Instantiate(arrowPrefab, LaunchPoint.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.direction = AimDirection;
    }
}

