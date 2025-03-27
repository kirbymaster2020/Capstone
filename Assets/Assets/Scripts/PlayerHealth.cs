using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line for scene management

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float deathSoundVolume = 1f;

    [Header("UI References")] // New Header for UI references
    public GameObject HeartImage1; // Reference for first heart UI
    public GameObject HeartImage2; // Reference for second heart UI
    public GameObject HeartImage3; // Reference for third heart UI


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        UpdateHeartsUI();  // Ensure hearts are shown at the start
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int amount)
    {
        health -= amount;
        UpdateHeartsUI();  // Update hearts every time damage is taken

        if (health <= 0)
        {
            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position, deathSoundVolume);
            }

            // Go to GameOver scene when health reaches 0
            SceneManager.LoadScene("GameOver");  // Ensure your GameOver scene is named "GameOver"
            Debug.Log(gameObject + " Has been slain.");
        }
    }

    // Function to update the UI based on the current health
    void UpdateHeartsUI()
    {
        // Update hearts based on the player's health
        HeartImage1.SetActive(health >= 1); // Show HeartImage1 if health is 1 or more
        HeartImage2.SetActive(health >= 2); // Show HeartImage2 if health is 2 or more
        HeartImage3.SetActive(health >= 3); // Show HeartImage3 if health is 3 or more
    }
}
