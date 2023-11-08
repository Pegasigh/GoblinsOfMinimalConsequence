using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public enum TileType { START, END, PATH, BUILDING, WATER}

public class Astar : MonoBehaviour
{
    private int clickTimes = 0;

    private TileType tileType;

    [SerializeField]
    private Tilemap tilemap;

    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    private RuleTile water;

    [SerializeField]
    private RuleTile grass;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask layerMask;

    private Vector3Int startPos, goalPos;

    private HashSet<Node> openList;
    private HashSet<Node> closedList;
    private List<Vector3Int> waterTiles = new List<Vector3Int>();
    private Node current;
    private Dictionary<Vector3Int, Node> allNodes = new Dictionary<Vector3Int, Node>();


    void Update()
    {
        //checking mouse click to set start and goal Pos
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);

            if (hit.collider != null)
            {
                Vector3 mouseWorldPos = cam.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int clickPos = tilemap.WorldToCell(mouseWorldPos);
                //function to set start and goal positions
                ChangeTile(clickPos);
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //run visual Alg
            Algorithm();
        }

    }

    private void Initialize()
    {
        current = GetNode(startPos);

        openList = new HashSet<Node>();

        closedList = new HashSet<Node>();

        //Adding starting node to the open list
        openList.Add(current);
    }

    private void Algorithm()
    {
        if (current == null)
            Initialize();

        List<Node> neighbours = FindNeighbours(current.Position);

        ExamineNeighbours(neighbours, current);

        UpdateCurrentTile(ref current);

        AstarDebugger.MyInstance.CreateTiles(openList, closedList, startPos, goalPos);
    }

    private List<Node> FindNeighbours(Vector3Int parentPos)
    {
        List<Node> neighbours = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector3Int neighborPos = new Vector3Int(parentPos.x - x, parentPos.y - y, parentPos.z);

                if (y != 0 || x != 0)
                {
                    //TODO figure out a way to make sure tiles are actually existing so we can see debug visuals
                    if (neighborPos != startPos) //&& !waterTiles.Contains(neighborPos) && tilemap.GetTile(neighborPos))
                    {
                        Node neighbor = GetNode(neighborPos);
                        neighbours.Add(neighbor);
                    }

                }
            }
        }
        return neighbours;
    }

    //TODO avoid already added Nodes
    private void ExamineNeighbours(List<Node> neighbours, Node current)
    {
        for (int i = 0; i < neighbours.Count; i++)
        {
            openList.Add(neighbours[i]);

            int gScore = DetermineGScore(neighbours[i].Position, current.Position);

            CalcValues(current, neighbours[i], 0);
        }
    }

    private void CalcValues(Node parent, Node neighbor, int cost)
    {
        neighbor.Parent = parent;

        neighbor.G = parent.G + cost;

        neighbor.H = (Mathf.Abs(neighbor.Position.x - goalPos.x) + Mathf.Abs(neighbor.Position.y - goalPos.y) * 10);
        
        neighbor.f = neighbor.G + neighbor.H;
    }

    private int DetermineGScore(Vector3Int neighbour, Vector3Int current)
    {
        int gScore = 0;

        int x = current.x -neighbour.x;
        int y = current.y -neighbour.y;

        if (Mathf.Abs(x-y) % 2 == 1)
        {
            gScore = 10;
        }
        else
        {
            gScore = 14;
        }

        return gScore;
    }

    private void UpdateCurrentTile(ref Node current)
    {
        openList.Remove(current);

        closedList.Add(current);
    }

    //creating Nodes if not in the list
    private Node GetNode(Vector3Int pos)
    {
        if (allNodes.ContainsKey(pos))
        {
            return allNodes[pos];
        }
        else
        {
            Node node = new Node(pos);
            allNodes.Add(pos, node);
            return node;
        }
    }

    //function to set start and goal positions
    private void ChangeTile(Vector3Int clickPos)
    {
       if (clickTimes == 0)
        {
            startPos = clickPos;
            clickTimes = 1;
        }
       if (clickTimes == 1)
        { 
            goalPos = clickPos;
        }
    }

}
