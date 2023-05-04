using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGeneration
{   
    // this is a list of all the directions that the random walk can go
    public static List<Vector2Int> randomDirections = new List<Vector2Int>
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, 0), //LEFT
    };
    // this is the path that the random walk will take
    public static HashSet<Vector2Int> path; 
    
    // this is the function that will generate the random walk
    public static void RandomWalk(Vector2Int startPosition, int walkLength)
    {
        // this is the path that the random walk will take
        path = new HashSet<Vector2Int>();

        path.Add(startPosition);

        Vector2Int currentPosition = startPosition;

        // this is the loop that will generate the random walk
        for (int i = 0; i < walkLength; i++)
        {
            // this is the new position that the random walk will go to
            Vector2Int newPosition = currentPosition + GetRandomDirections()[Random.Range(0, GetRandomDirections().Count)];

            // this will add the new position to the path
            path.Add(newPosition);
            
            // this will set the current position to the new position
            currentPosition = newPosition;
        }
    }

    // getter methods
    public static List<Vector2Int> GetRandomDirections()
    {
        return randomDirections;
    }

    public static HashSet<Vector2Int> GetPath()
    {
        return path;
    }
}