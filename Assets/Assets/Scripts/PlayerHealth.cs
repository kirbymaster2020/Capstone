using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameObject + " Has been slain.");

        // Load the GameOver scene - either by name or index
        SceneManager.LoadScene("GameOver");
        // Alternative: SceneManager.LoadScene(4); // Using the index from your build settings

        // Destroy the player object after loading the scene
        Destroy(gameObject);
    }
}