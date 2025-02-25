using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestruction : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  // Reference to the Tilemap
    [SerializeField] private TileBase emptyTile; // Tile to replace with (empty space)

    void Update()
    {
        // Check if the player input
        if (Input.GetMouseButtonDown(0))  // Left mouse button
        {
            DestroyTileAtMousePosition();
        }
    }

    void DestroyTileAtMousePosition()
    {
        // Convert mouse position to world position
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPos = tilemap.WorldToCell(worldPos);  // Convert world position to tile cell position

        // Get the tile at the position
        TileBase tileAtPosition = tilemap.GetTile(cellPos);

        // If there's a tile, destroy it
        // TODO: add gold and iron increase
        if (tileAtPosition != null)
        {
            tilemap.SetTile(cellPos, null);  // Replace with empty tile
        }
    }
}
