using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 1;


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
            Destroy(gameObject);
            Debug.Log(gameObject + " Has been slain.");

        }

    }

}
