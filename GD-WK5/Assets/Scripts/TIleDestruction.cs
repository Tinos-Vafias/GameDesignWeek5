using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestruction : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Tilemap tilemap;  // Reference to the Tilemap
    [SerializeField] private TileBase emptyTile; // Tile to replace with (empty space)
    [SerializeField] private TileBase ironOre;
    [SerializeField] private TileBase goldOre;


    void Update()
    {
        // Check if the player input
        if (Input.GetMouseButtonDown(0))  // Left mouse button
        {
            mineTile();
        }
    }

    void mineTile()
    {
        // Convert mouse position to world position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(worldPos);  // Convert world position to tile cell position
        Vector3Int playerTilePosition = tilemap.WorldToCell(player.position);

        // Get the tile at the position
        TileBase tileAtPosition = tilemap.GetTile(cellPos);

        // If there's a tile, destroy it
        if (Mathf.Abs(cellPos.x - playerTilePosition.x) <= 1 &&
            Mathf.Abs(cellPos.y - playerTilePosition.y) <= 1)
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

            tilemap.SetTile(cellPos, null);  // Replace with empty tile
            Debug.Log("Tile removed from map.");
        }
    }
}
