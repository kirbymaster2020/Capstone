using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int ArrowCount { get; private set; }
    public UnityEvent OnArrowCollected; // For UI/audio updates

    private void Start()
    {
        // Initialize with 5 arrows
        ArrowCount = 5;
        OnArrowCollected.Invoke(); // Update UI at game start
    }

    public void AddArrow()
    {
        ArrowCount++;
        OnArrowCollected.Invoke(); // Update UI after pickup
        Debug.Log($"Arrows: {ArrowCount}");
    }

    // Returns true if an arrow was successfully used
    public bool UseArrow()
    {
        if (ArrowCount > 0)
        {
            ArrowCount--;
            OnArrowCollected.Invoke(); // Update UI after use
            Debug.Log($"Arrows: {ArrowCount}");
            return true;
        }
        return false;
    }
}