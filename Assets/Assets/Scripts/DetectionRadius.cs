using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionRadius : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;           // Speed of enemy movement
    [SerializeField] private float detectionRadius = 5f;     // Radius to detect player
    [SerializeField] private float minDistance = 0.5f;       // Minimum distance to keep from player

    [Header("References")]
    [SerializeField] private Transform player;              // Reference to player transform
    private SpriteRenderer spriteRenderer;                  // For flipping sprite

    private bool isFollowing = false;                       // Tracking if enemy is following

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Try to find player if not assigned
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                player = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (player == null) return; // No player to follow

        // Calculate distance to player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Check if player is within detection radius
        if (distanceToPlayer <= detectionRadius)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
            // Only follow if not too close
            if (distanceToPlayer > minDistance)
            {
                // Move towards player
                    transform.position = Vector2.MoveTowards(
                    transform.position,
                    player.position,
                    moveSpeed * Time.deltaTime
                );

                // Flip sprite based on player position
                if (player.position.x > transform.position.x)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
            }
        }

        // Stop following if player moves out of radius (with some buffer)
        if (distanceToPlayer > detectionRadius * 1.2f)
        {
            isFollowing = false;
        }
    }

    // Visualize detection radius in editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        if (isFollowing && player != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}