using System.Collections;
using System.Collections.Generic;
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

    public void CreateTiles(HashSet<Node> openList, HashSet<Node> closedList, Vector3Int start, Vector3Int goal, Stack<Vector3Int> path = null)
    {
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
