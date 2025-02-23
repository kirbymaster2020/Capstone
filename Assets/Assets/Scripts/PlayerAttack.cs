using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
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
        if (collision.gameObject.tag == "Enemy")
        {
            //enemyHealth.takeDamage(damage);
            //Debug.Log(collision.gameObject.tag + " Has taken " + damage + " damage from " + gameObject + "'s attack.");





        }

    }
}
