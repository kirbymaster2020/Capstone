using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string _itemType = "Arrow"; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddArrow();
                Destroy(gameObject); // Remove the item from the scene
            }
        }
    }
}