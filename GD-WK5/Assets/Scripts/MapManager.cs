using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int width = 60;
    [SerializeField] private int height = 50;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase dirtTile;
    [SerializeField] private TileBase stoneTile;
    [SerializeField] private TileBase[] mineralTiles;

    [SerializeField] private float noiseScale = 5f; // Now used for clustering!
    [SerializeField] private float mineralThreshold = 0.01f; // Controls how much mineral spawns

    [SerializeField] private int minClusters = 3;
    [SerializeField] private int maxClusters = 6;
    [SerializeField] private int minClusterSize = 5;
    [SerializeField] private int maxClusterSize = 15;

    private void Start()
    {
        GenerateMap();
    }

    private void GenerateMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Base layer (stone and dirt)
                TileBase tile = (y < height - 3) ? stoneTile : dirtTile;
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }

        GenerateMinerals();
    }

    private void GenerateMinerals()
    {
        foreach (TileBase mineralTile in mineralTiles)
        {
            GenerateMineralCluster(mineralTile);
        }
    }

    private void GenerateMineralCluster(TileBase mineralTile)
    {
        int numClusters = Random.Range(minClusters, maxClusters);

        for (int i = 0; i < numClusters; i++)
        {
            int startX = Random.Range(0, width);
            int startY = Random.Range(0, height - 3); // Keep minerals underground

            int clusterSize = Random.Range(minClusterSize, maxClusterSize);
            GenerateCluster(startX, startY, clusterSize, mineralTile);
        }
    }

    private void GenerateCluster(int startX, int startY, int clusterSize, TileBase mineralTile)
    {
        for (int i = 0; i < clusterSize; i++)
        {
            // Use Perlin noise for natural clustering
            float noiseValue = Mathf.PerlinNoise((startX + i) / noiseScale, (startY + i) / noiseScale);

            if (noiseValue > mineralThreshold) // Only place minerals if above the threshold
            {
                int offsetX = Random.Range(-2, 3);
                int offsetY = Random.Range(-2, 3);

                int x = Mathf.Clamp(startX + offsetX, 0, width - 1);
                int y = Mathf.Clamp(startY + offsetY, 0, height - 1);

                if (tilemap.GetTile(new Vector3Int(x, y, 0)) == stoneTile) // Only replace stone
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), mineralTile);
                }
            }
        }
    }
}
