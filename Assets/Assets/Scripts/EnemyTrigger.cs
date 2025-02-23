using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemyHealth enemyHealth;

    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            Debug.Log(gameObject + " hit by " + collision.gameObject.tag + " for " + damage + " damage.");
            enemyHealth.takeDamage(damage);
          

        }

    }
}
