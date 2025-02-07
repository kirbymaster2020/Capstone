using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public Rigidbody2D rb;
    public Vector2 direction = Vector2.right;
    public float lifespan = 2;
    public float speed;

    //Called before first frame update
    void Start()
    {
        rb.velocity = direction * speed;
        Destroy(gameObject, lifespan);
        
    }




}
