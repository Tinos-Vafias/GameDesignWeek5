using UnityEngine;
using UnityEngine.Tilemaps;

public class Digging : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  // Reference to the Tilemap
    [SerializeField] private TileBase emptyTile; // Tile to replace with (empty space)
    [SerializeField] private TileBase ironOre;
    [SerializeField] private TileBase goldOre;

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
        if (!gameObject.activeSelf)
            return;

        // Get the hurtbox's own collider
        Collider2D col = GetComponent<Collider2D>();
        if (col == null)
            return;

        // Get the world bounds of the hurtbox
        Bounds bounds = col.bounds;

        // Convert the bounds' minimum and maximum points to tilemap cell coordinates.
        Vector3Int bottomLeftCell = tilemap.WorldToCell(bounds.min);
        Vector3Int topRightCell = tilemap.WorldToCell(bounds.max);

        // Iterate through all cells in the bounds
        for (int x = bottomLeftCell.x; x <= topRightCell.x; x++)
        {
            for (int y = bottomLeftCell.y; y <= topRightCell.y; y++)
            {
                Vector3Int cellPos = new Vector3Int(x, y, 0);
                TileBase tileAtPosition = tilemap.GetTile(cellPos);

                // If a tile exists at this cell, remove it.
                if (tileAtPosition != null)
                {
                    // Determine resource type
                    if (tileAtPosition == ironOre)
                    {
                        Debug.Log("mine iron ore");
                        PlayerManager.Instance.AddCoins(5);
                    }
                    else if (tileAtPosition == goldOre)
                    {
                        Debug.Log("mine gold ore");
                        PlayerManager.Instance.AddCoins(10);
                    }
                    tilemap.SetTile(cellPos, null);
                    // Optionally, add logic here to increase gold/iron.
                }
            }
        }
    }
    
    
}
