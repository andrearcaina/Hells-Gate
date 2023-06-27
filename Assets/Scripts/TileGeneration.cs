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
        // None of this works since tiles in tilemaps don't have a type (I think)
        // Instead, we should be trying to look at the point in the tile map to see if they contain something,
        // then checking the points in the camera area to see if the points match, which will tell us if there is something there
        // I think then we can put tiles/take them away if they are a certain offset of the camera view
        // You can translate cellspace in a tilemap to worldspace using tilemap.CellToWorld()
        // You can translate worldspace to screen space (camera view) with Camera.main.WorldToScreenPoint()
        // Compare the points in this area somehow with the camera view.

        
        // check a sphere around the player for existing tiles
        Collider[] hitColliders = Physics.OverlapSphere(position, tilePlacementRange);
        foreach (var hitCollider in hitColliders)
        {
            print(hitCollider.name);
            // if some collider is a tile, return true
            if (hitCollider.GetType() == tile.GetType())
            {
                print(hitCollider.name);
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
