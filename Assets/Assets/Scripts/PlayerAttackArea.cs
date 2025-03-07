using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{

    private int damage = 3;

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            health.takeDamage(damage);
        }

    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
