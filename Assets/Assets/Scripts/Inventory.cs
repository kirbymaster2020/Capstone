using UnityEngine;
using UnityEngine.Events;
using TMPro; // Add this for TextMeshPro functionality

public class Inventory : MonoBehaviour
{
    public int ArrowCount { get; private set; }
    public UnityEvent OnArrowCollected; // For UI/audio updates

    // Reference to the ArrowAmountText
    [SerializeField] private TextMeshProUGUI arrowAmountText;

    private void Start()
    {
        // Initialize with 5 arrows
        ArrowCount = 05;
        UpdateArrowUI(); // Update UI at game start
    }

    public void AddArrow()
    {
        ArrowCount++;
        UpdateArrowUI(); // Update UI after pickup
        Debug.Log($"Arrows: {ArrowCount}");
    }

    // Returns true if an arrow was successfully used
    public bool UseArrow()
    {
        if (ArrowCount > 0)
        {
            ArrowCount--;
            UpdateArrowUI(); // Update UI after use
            Debug.Log($"Arrows: {ArrowCount}");
            return true;
        }
        return false;
    }

    // Method to update the arrow count UI
    private void UpdateArrowUI()
    {
        if (arrowAmountText != null)
        {
            arrowAmountText.text = ArrowCount.ToString(); // Update the text with the current arrow count
        }
    }
}
