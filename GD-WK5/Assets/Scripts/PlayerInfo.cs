using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{

    private float horizontal;
    private float speed = 8f;
    public int health = 5;
    public int damage = 1;
    
    public float jetpackForce = 11f;
    public float maxFlyTime = 1.5f;
    private float flyTimeRemaining;
    
    [SerializeField] private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flyTimeRemaining = maxFlyTime;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);  // Lose 1 health each press
        }
        
        
        // jetpack logic
        if (Input.GetKey(KeyCode.UpArrow)) {
            // Decrement the remaining fly time
            if (flyTimeRemaining > 0) {
                flyTimeRemaining -= Time.deltaTime;
            }
        }
        else {
            flyTimeRemaining = maxFlyTime;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Current Health: " + health);

        if (health <= 0) SceneManager.LoadScene("ShopScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyAttack enemyAttack = collision.gameObject.GetComponent<enemyAttack>();
            TakeDamage(enemyAttack.damage);
        }
    }

    private void FixedUpdate()
    {
        // Movement logic
        rb.linearVelocity = new Vector3(horizontal * speed, rb.linearVelocity.y);
        
        // Jetpack logic
        if (Input.GetKey(KeyCode.UpArrow) && flyTimeRemaining > 0)
        {
            rb.AddForce(Vector2.up * jetpackForce, ForceMode2D.Force);
        }
    }

    public void UpgradeDamage()
    {
        damage++;
        Debug.Log("Damage Upgraded: " + damage);
    }
    
    public void UpgradeJetpack()
    {
        maxFlyTime += .5f;
        Debug.Log("Flight time upgraded " + damage);
    }
}
