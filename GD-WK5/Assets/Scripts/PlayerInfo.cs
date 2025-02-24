using System;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    public int health = 5;
    public int damage = 5;
    
    
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");


    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(horizontal * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyAttack enemyAttack = collision.gameObject.GetComponent<enemyAttack>();
            health -= enemyAttack.damage;
            Debug.Log("Current Health: " + health);
        }
    }
}
