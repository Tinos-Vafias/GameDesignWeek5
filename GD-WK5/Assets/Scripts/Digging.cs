using UnityEngine;
using UnityEngine.Tilemaps;

public class Digging : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  // Reference to the Tilemap
    [SerializeField] private TileBase emptyTile; // Tile to replace with (empty space)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only proceed if this hurtbox is active.
        if (!gameObject.activeSelf)
            return;
        
        // Here you can optionally check that the collision is with your Tilemap object,
        // for example by checking collision.gameObject.CompareTag("Tilemap") if you set a tag.
        // For this example, we assume any collision should trigger tile destruction.

        // Use the hurtbox's position as the collision point.
        Vector3 collisionPoint = transform.position;
        Vector3Int cellPos = tilemap.WorldToCell(collisionPoint);
        TileBase tileAtPosition = tilemap.GetTile(cellPos);

        // If there's a tile at that cell, remove it.
        if (tileAtPosition != null)
        {
            tilemap.SetTile(cellPos, null);
            // Optionally, you could add logic here to increase gold/iron.
        }
    }
}
