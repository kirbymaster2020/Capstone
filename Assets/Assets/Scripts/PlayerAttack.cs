using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool isAttacking = false;

    public EnemyHealth enemyHealth;

    private float attackTime = 0.5f;
    private float timer = 0.0f;


    public int damage = 2;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
            Debug.Log("Attack button clicked.");

        }

        if (isAttacking == true)
        {
            timer += Time.deltaTime;
            if (timer >= attackTime) 
            { 
            timer = 0.0f;
            isAttacking = false;
            attackArea.SetActive(isAttacking);
            Debug.Log("Attack Deactivated.");
            }
            
        }

      

    }

    private void Attack()
    {
        isAttacking = true;
        attackArea.SetActive(isAttacking);
        Debug.Log("Attack Activated.");

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        //enemyHealth.takeDamage(damage);
    //        //Debug.Log(collision.gameObject.tag + " Has taken " + damage + " damage from " + gameObject + "'s attack.");





    //    }

    //}
}
