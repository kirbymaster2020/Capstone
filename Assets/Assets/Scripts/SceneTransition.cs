using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad = "Ending";
    public Color outlineColor = Color.green;
    public float lineWidth = 0.15f; // Increased line width for a bolder outline

    private LineRenderer lineRenderer;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        // Get the BoxCollider2D component
        boxCollider = GetComponent<BoxCollider2D>();

        // Add a LineRenderer component if it doesn't exist
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Configure the LineRenderer for a bolder look
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.positionCount = 5; // 5 points to close the rectangle
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = outlineColor;
        lineRenderer.endColor = outlineColor;

        // Set the line renderer to appear in front of other objects
        lineRenderer.sortingOrder = 10;

        // Draw the rectangle outline
        DrawColliderOutline();
    }

    private void DrawColliderOutline()
    {
        if (boxCollider != null && lineRenderer != null)
        {
            // Calculate the box's four corners in world space
            Vector2 size = boxCollider.size;
            Vector2 offset = boxCollider.offset;

            // Calculate half extents
            float halfWidth = size.x * transform.lossyScale.x / 2f;
            float halfHeight = size.y * transform.lossyScale.y / 2f;

            // Calculate center position
            Vector3 center = transform.position + new Vector3(offset.x, offset.y, 0);

            // Make the outline slightly larger than the collider for better visibility
            halfWidth += lineWidth * 0.5f;
            halfHeight += lineWidth * 0.5f;

            // Set the points for the LineRenderer (5 points to close the loop)
            // Move slightly forward in Z to avoid Z-fighting
            float zOffset = -0.1f;
            lineRenderer.SetPosition(0, center + new Vector3(-halfWidth, -halfHeight, zOffset));
            lineRenderer.SetPosition(1, center + new Vector3(halfWidth, -halfHeight, zOffset));
            lineRenderer.SetPosition(2, center + new Vector3(halfWidth, halfHeight, zOffset));
            lineRenderer.SetPosition(3, center + new Vector3(-halfWidth, halfHeight, zOffset));
            lineRenderer.SetPosition(4, center + new Vector3(-halfWidth, -halfHeight, zOffset)); // Back to start to close the loop
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger entered by: " + collision.gameObject.name);

        // Check if the object entering the trigger is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Loading scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Keep the OnDrawGizmos for editor visualization with bolder lines
    private void OnDrawGizmos()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider != null)
        {
            Gizmos.color = outlineColor;
            Vector3 center = transform.position + new Vector3(boxCollider.offset.x, boxCollider.offset.y, 0);
            Vector3 size = new Vector3(
                boxCollider.size.x * transform.lossyScale.x,
                boxCollider.size.y * transform.lossyScale.y,
                0.1f
            );
            Gizmos.DrawWireCube(center, size);

            // Draw a second slightly larger cube for bolder look
            Gizmos.DrawWireCube(center, size * 1.05f);
        }
    }
}