using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// trying to generate tiles around the player
// the tiles are squares, so we probably have to check multiples of 10 or something like that for positions to generate tiles

public class TileGeneration : MonoBehaviour
{
    public Tile tile;
    public float tilePlacementRange;
    public Tilemap tilemap;
    private GameObject Player;
    private Vector3Int Position;
    void Start()
    {
        // create an initial tile when the game starts
        // Tile tile = Tile.CreateInstance<Tile>();
        Player = GameObject.Find("Player");
    }

    // use the Update() method to place new tiles around the player
    // then delete them if they are too far away
    void Update()
    {
        Vector3 playerPosition = Player.transform.position;
        Position = convertToVector3Int(playerPosition);
        if (!checkForTiles(playerPosition))
        {
            tilemap.SetTile(Position, tile);
        }
    }
    
    // check if there are tiles within a range of the player
    private bool checkForTiles(Vector3 position)
    {
        // check a sphere around the player for existing tiles
        Collider[] hitColliders = Physics.OverlapSphere(position, tilePlacementRange);
        foreach (var hitCollider in hitColliders)
        {
            // if some collider is a tile, return true
            if (hitCollider.GetType() == tile.GetType())
            {
                return true;
            }
        }
        return false;
    }

    // don't know how to make FloorToInt work, so I am doing it manually
    public static Vector3Int convertToVector3Int(Vector3 v)
    {
        Vector3Int vector3Int = new Vector3Int();
        vector3Int.x = Mathf.RoundToInt(v.x);
        vector3Int.y = Mathf.RoundToInt(v.y);
        vector3Int.z = Mathf.RoundToInt(v.z);

        return vector3Int;
    }
}
