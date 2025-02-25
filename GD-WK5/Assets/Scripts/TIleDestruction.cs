using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestruction : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  // Reference to the Tilemap
    [SerializeField] private TileBase emptyTile; // Tile to replace with (empty space)
    [SerializeField] private TileBase ironOre;
    [SerializeField] private TileBase goldOre;


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
        if (tileAtPosition != null)
        {

            // Determine resource type
            if (tileAtPosition == ironOre)
            {
                Debug.Log("mine iron ore");
                PlayerManager.Instance.AddResource("Iron", 1);
            }
            else if (tileAtPosition == goldOre)
            {
                Debug.Log("mine gold ore");
                PlayerManager.Instance.AddResource("Gold", 1);
            }

            tilemap.SetTile(cellPos, null);  // Replace with empty tile
            Debug.Log("Tile removed from map.");
        }
    }
}
