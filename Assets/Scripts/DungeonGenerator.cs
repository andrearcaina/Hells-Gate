using System.Collections;
using System.Collections.Generic;
using System.Linq; // this is needed for the ElementAt function on line 60
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    /*  NOTABLE CODE COMMENTS
        what does serialize field do?
        it makes the variable show up in the inspector
        this is useful for debugging
        what does protected do?
        it makes the variable only accessible to this class and its children
        this is useful for inheritance 
    */
    
    [SerializeField]
    protected Vector2Int startPosition = new Vector2Int(0, 0);

    [SerializeField]
    private int iterations = 10;
    
    [SerializeField]
    public int walkLength = 10;
    
    [SerializeField]
    public bool randomIterations = true;

    // this is the function that will run the procedural generation
    // this function is public so that it can be called from the inspector
    public void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        foreach (Vector2Int position in floorPositions)
        {
            // print the floor positions
            // this is to test that the random walk is working
            Debug.Log(position);
        }
    }

    // this is the function that will generate the random walk using the procedural generation script
    // this function is protected so that it can be used by the child classes
    protected HashSet<Vector2Int> RunRandomWalk()
    {
        Vector2Int currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        
        for (int i = 0; i < iterations; i++)
        {
            // get a random walk
            HashSet<Vector2Int> path = ProceduralGeneration.RandomWalk(currentPosition, walkLength);

            // add the walk to the floor positions
            floorPositions.UnionWith(path);

            if (randomIterations)
            {
                // set the current position to the end of the walk
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }
}
