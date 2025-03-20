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
    public float bowCooldown = 0.5f;
    private float shootTimer;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip arrowFireSound;
    [SerializeField] private float fireSoundVolume = 1f;

    // Add reference to inventory
    [SerializeField] private Inventory inventory;

    void Update()
    {
        shootTimer -= Time.deltaTime;
        HandleAiming();

        if (Input.GetButtonDown("Shoot") && shootTimer <= 0)
        {
            // Only shoot if we have arrows
            if (inventory != null && inventory.ArrowCount > 0)
            {
                Shoot();
            }
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
        shootTimer = bowCooldown;

        if (arrowFireSound != null)
        {
            AudioSource.PlayClipAtPoint(arrowFireSound, transform.position, fireSoundVolume);
        }

        // Deduct arrow from inventory
        if (inventory != null)
        {
            inventory.UseArrow();
        }
    }
}