using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AstarDebugger : MonoBehaviour
{
    private static AstarDebugger instance;

    public static AstarDebugger MyInstance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<AstarDebugger>();

            return instance;
        }
    }

    [SerializeField]
    private Astar goblinToTrack;

    [SerializeField]
    private Grid grid;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile tile;

    [SerializeField]
    private Color openColour, closedColour, pathColour, currentColour, startColour, goalColour;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GameObject debugTextPrefab;

    private List<GameObject> debugObjects = new List<GameObject>();

    private void Update()
    {
        //checking the "I" Key to only update debug visual when pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            Stack<Vector3Int> path = goblinToTrack.AStarAlgorithm(goblinToTrack.getStartPos(), goblinToTrack.getGoalPos(), out var openSet, out var closedSet);
            CreateTiles(openSet, closedSet, goblinToTrack.getStartPos(), goblinToTrack.getGoalPos(), path);
        }

    }

    public void CreateTiles(HashSet<Node> openList, HashSet<Node> closedList, Vector3Int start, Vector3Int goal, Stack<Vector3Int> path = null)
    {
        //destroy all old tiles
        tilemap.ClearAllTiles();

        foreach(Node node in openList)
        {
            ColourTile(node.Position, openColour);
        }
        
        foreach(Node node in closedList)
        {
            ColourTile(node.Position, closedColour);
        }

        //colouring the path
        if(path != null)
        {
            foreach(Vector3Int pos in path)
            {
                if(pos != start && pos != goal)
                {
                    ColourTile(pos, pathColour);
                }
            }
        }
        //colouring start and end pos after colouring everything else
        ColourTile(start, startColour);
        ColourTile(goal, goalColour);
    }

    //colours the tiles for visual only at the moment
    public void ColourTile(Vector3Int pos, Color colour) 
    {
        tilemap.SetTile(pos, tile);
        tilemap.SetTileFlags(pos, TileFlags.None);
        tilemap.SetColor(pos, colour);
    }
}
