using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance; // Singleton for easy access


    private float horizontal;   


    [SerializeField] private Rigidbody2D rb;

    private int coins;

    private Animator animator;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    public Transform groundCheck; // Empty object to check ground
    public LayerMask groundLayer; // Layer mask for ground detection

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Animation
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");


        // Animation
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (horizontal != 0)
            spriteRenderer.flipX = (horizontal < 0);

        // Running animation
        animator.SetBool("isRunning", horizontal != 0);

        // Falling
        animator.SetBool("isFalling", rb.linearVelocity.y < 0);

        // jetpack logic
        if (Input.GetKey(KeyCode.UpArrow)) {
            animator.SetTrigger("Jump");
        }


    }   

    









    // Necessary getters & setters
    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public int GetCoins()
    {
        return coins;
    }

    public bool SpendCoins(int amount)
    {
    if (coins >= amount)
        {
            coins -= amount;
            return true;
        }
        return false;
    }


}
