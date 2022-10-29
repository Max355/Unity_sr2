using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
     [SerializeField] float moveSpeed = 1f;
    public Animator animator;
    Rigidbody2D myRigidbody;
    public int maxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt animation
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
       GetComponent<Collider2D>().enabled = false;
       this.enabled = false;//disable the enemy
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (moveSpeed, 0f);//move from right to left
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
       
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
       
    }

}
