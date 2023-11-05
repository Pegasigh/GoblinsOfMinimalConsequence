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

    public void CreateTiles(HashSet<Node> openList, Vector3Int start, Vector3Int goal)
    {
        foreach(Node node in openList)
        {
            ColourTile(node.Position, openColour);
        }

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
