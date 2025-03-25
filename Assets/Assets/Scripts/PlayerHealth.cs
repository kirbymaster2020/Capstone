using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float deathSoundVolume = 1f;


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

            if (deathSound != null)
            {
                AudioSource.PlayClipAtPoint(deathSound, transform.position, deathSoundVolume);
            }

            Destroy(gameObject);
            Debug.Log(gameObject + " Has been slain.");


        }

    }

}