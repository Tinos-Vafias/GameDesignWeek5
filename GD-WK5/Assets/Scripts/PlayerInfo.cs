using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance { get; private set; }

    private float horizontal;
    private float speed = 8f;
    public int health = 5; // ✅ Health is still managed here

    public float jetpackForce = 11f;
    public float maxFlyTime = 1.5f; // ✅ This will now be updated by JetpackManager
    private float flyTimeRemaining;

    private bool isGrounded;
    public Transform groundCheck; // Empty object to check ground
    public LayerMask groundLayer; // Layer mask for ground detection
    private float killzone = -5f;

    public int damage;

    [SerializeField] private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flyTimeRemaining = maxFlyTime;
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(1);  // Lose 1 health each press (for testing)
        }

        // Jetpack logic (Handled by JetpackManager for upgrades)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (flyTimeRemaining > 0)
            {
                flyTimeRemaining -= Time.deltaTime;
            }
        }
        else if (isGrounded)
        {
            flyTimeRemaining = maxFlyTime;
        }

        // Kill zone kills player
        if (transform.position.y < killzone)
        {
            health -= 5;

            if (health <= 0) SceneManager.LoadScene("ShopScene");

        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Current Health: " + health);

        if (health <= 0)
        {
            SceneManager.LoadScene("ShopScene");
        }
    }



    private void FixedUpdate()
    {
        // Movement logic
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);

        // Jetpack logic (Still uses `maxFlyTime`, but upgrades handled externally)
        if (Input.GetKey(KeyCode.UpArrow) && flyTimeRemaining > 0)
        {
            rb.AddForce(Vector2.up * jetpackForce, ForceMode2D.Force);
        }
    }


}