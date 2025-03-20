using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField] private string _itemType = "Arrow";
    [SerializeField] private AudioClip _pickupSound;
    [SerializeField] private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                // Play sound before destroying
                if (_pickupSound != null && _audioSource != null)
                {
                    _audioSource.PlayOneShot(_pickupSound);
                }

                inventory.AddArrow();

                // Delay destruction until sound finishes
                Destroy(gameObject, _pickupSound != null ? _pickupSound.length : 0);
            }
        }
    }
}