using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 direction = Vector2.down;
    public EnemyHealth enemyHealth;
    public float lifespan = 2;
    public float speed;
    public int damage = 2;

    //Called before first frame update
    void Start()
    {
        rb.velocity = direction * speed;
        RotateArrow();
        Destroy(gameObject, lifespan);
        
    }

    private void RotateArrow()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Arrow Hit.");
            Destroy(gameObject);
           // EnemyHealth.takeDamage(damage);

        }

    }


}
