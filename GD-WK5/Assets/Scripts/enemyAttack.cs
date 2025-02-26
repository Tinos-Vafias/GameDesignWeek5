using System;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shovel"))
        {
            PlayerManager pi = player.GetComponent<PlayerManager>();
            health -= pi.damage;
            Debug.Log("ouch");
        }
    }
}
