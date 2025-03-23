using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolV3 : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] private Transform[] patrolPoints;    // Array of patrol points in the scene
    [SerializeField] private float moveSpeed = 2f;        // Speed of enemy movement
    [SerializeField] private float waitTime = 1f;         // Time to wait at each patrol point

    private int currentPointIndex;                       // Current patrol point target
    private float waitTimer;                             // Timer for waiting at points
    private bool isWaiting;                              // Is enemy currently waiting
    private SpriteRenderer spriteRenderer;               // Reference to sprite renderer for flipping

    void Start()
    {
        // Initialize components and settings
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentPointIndex = 0;
        waitTimer = 0f;
        isWaiting = false;

        // Start at the first patrol point
        transform.position = patrolPoints[0].position;
    }

    void Update()
    {
        // If waiting at a point
        if (isWaiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                isWaiting = false;
                MoveToNextPoint();
            }
            return;
        }

        // Move towards current patrol point
        Vector2 targetPosition = patrolPoints[currentPointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position,
            targetPosition, moveSpeed * Time.deltaTime);

        // Flip sprite based on movement direction
        if (targetPosition.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (targetPosition.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }

        // Check if reached the patrol point
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartWaiting();
        }
    }

    private void MoveToNextPoint()
    {
        // Move to next point in array, loop back to start if at end
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }

    private void StartWaiting()
    {
        isWaiting = true;
        waitTimer = waitTime;
    }

    // Draw patrol points in editor for visualization
    void OnDrawGizmos()
    {
        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                if (patrolPoints[i] != null)
                {
                    Gizmos.DrawSphere(patrolPoints[i].position, 0.1f);

                    // Draw lines between points
                    if (i > 0 && patrolPoints[i - 1] != null)
                    {
                        Gizmos.DrawLine(patrolPoints[i - 1].position, patrolPoints[i].position);
                    }
                }
            }
            // Draw line from last to first point
            if (patrolPoints.Length > 1 && patrolPoints[0] != null &&
                patrolPoints[patrolPoints.Length - 1] != null)
            {
                Gizmos.DrawLine(patrolPoints[patrolPoints.Length - 1].position,
                    patrolPoints[0].position);
            }
        }
    }
}

