using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileType {START, END, PATH, BUILDING, WATER}

[RequireComponent(typeof(SeekAI))]
public class Astar : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;

    private Tilemap navigationMap;
    private SeekAI seekAI;
    private ArriveAI arriveAI;



    //ONLY HERE FOR TESTING
    [SerializeField]
    private LayerMask layerMask;



    private Stack<Vector3Int> path;
       
    private Vector3Int goalPos;



    private void Start()
    {
        /* TESTING REMOVE LATER*/
        Debug.Log("astar start");

        //setting navigation map to be one in scene
        navigationMap = GameObject.FindWithTag("NavigationMap").GetComponent<Tilemap>();

        //grabbing it's own SeekAI and ArriveAI
        seekAI = GetComponent<SeekAI>();
        arriveAI = GetComponent<ArriveAI>();

        //defaulting path to be empty
        path = new Stack<Vector3Int>();

        //setting camera

    }

    void Update()
    {
        ////checking mouse click to set start and goal Pos
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);

        //    if (hit.collider != null)
        //    {
        //        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        Vector3Int clickPos = tilemap.WorldToCell(mouseWorldPos);

        //        goalPos = clickPos;
        //        path = AStarAlgorithm(getStartPos(), goalPos);
        //    }
        //}

        //actually move the goblin
        moveActor();
    }

    private Stack<Vector3Int> AStarAlgorithm(Vector3Int startPos, Vector3Int goalPos)
    {
        return AStarAlgorithm(startPos, goalPos, out _, out _);
    }

    public Stack<Vector3Int> AStarAlgorithm(Vector3Int startPos, Vector3Int goalPos, out HashSet<Node> openSet, out HashSet<Node> closedSet)
    {
        Stack<Vector3Int> result = new Stack<Vector3Int>();
        Dictionary<Vector3Int, Node> nodes = new(); //all the temp info about the nodes this algorithm has looked at or is going to look at

        //defaulting closedSet to be empty
        closedSet = new HashSet<Node>();

        //adding first node to openset and dictionary
        openSet = new HashSet<Node>();
        Node startNode = GetNode(startPos, nodes);
        startNode.G = 0;
        openSet.Add(startNode);



        //only runs the algorithm if goalPos is an unoccupied tile
        if (!navigationMap.GetTile(goalPos))
        {
            //explores nodes until there are no more nodes left or end has been found
            while (openSet.Count != 0)
            {
                //find node with lowest F score
                Node current = openSet.First();
                foreach (Node node in openSet)
                {
                    if (current.F > node.F)
                    {
                        current = node;
                    }
                }

                //at end node, creates a path from start to end
                if (current.Position == goalPos)
                {
                    //construct a path
                    while (current.Position != startPos)
                    {
                        result.Push(current.Position);
                        current = current.Parent;

                        //iterations++;
                        //if (iterations > 1000)
                        //{ break; }
                    }

                    return result;
                }


                //ensuring dictionary stores the shortest route between nodes and adds edges to openSet
                foreach (Node neighbor in FindNeighbours(current.Position, nodes))
                {
                    //tentative g score will replace g score if better
                    float tentativeG = current.G + FindEuclideanDistance(current.Position, neighbor.Position);

                    if (tentativeG < neighbor.G)
                    {
                        neighbor.G = tentativeG;
                        neighbor.F = tentativeG + FindEuclideanDistance(goalPos, neighbor.Position);
                        neighbor.Parent = current;
                        openSet.Add(neighbor); //only adds if not already in set
                    }
                }

                //already explored this node, now adding it to closedSet and removing it from openSet
                closedSet.Add(current);
                openSet.Remove(current);
            }
        }
            
        //no path found, basically just have goblin stay where he is
        result.Push(startPos);
        return result;
    }

    private static Node GetNode(Vector3Int pos, Dictionary<Vector3Int, Node> nodes)
    {
        //generates a new node if node at pos doesn't exist
        if (nodes.TryGetValue(pos, out Node result))
        {
            return result;
        }
        else
        {
            result = new Node(pos);
            nodes.Add(pos, result);
            return result;
        }
    }

    private List<Node> FindNeighbours(Vector3Int parentPos, Dictionary<Vector3Int, Node> nodes) //this dictionary should only exist while the algorithm is running, it's one time use only (because we want the parent and weights to be reset when we generate a new path to a new location)
    {
        List<Node> neighbours = new List<Node>();
        Vector3Int neighborPos;
        

        /***************************************
            checking for adjacent free tiles
        ***************************************/

        neighborPos = parentPos + Vector3Int.right;
        if (!navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        neighborPos = parentPos + Vector3Int.left;
        if (!navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        neighborPos = parentPos + Vector3Int.up;
        if (!navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        neighborPos = parentPos + Vector3Int.down;
        if (!navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        /***************************************
            checking for diagonal free tiles
        ***************************************/

        //bottom left
        neighborPos = parentPos + Vector3Int.down + Vector3Int.left;
        if (!navigationMap.GetTile(parentPos + Vector3Int.left) &&
            !navigationMap.GetTile(parentPos + Vector3Int.down) &&
            !navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }                
        }

        //bottom right
        neighborPos = parentPos + Vector3Int.down + Vector3Int.right;
        if (!navigationMap.GetTile(parentPos + Vector3Int.right) &&
            !navigationMap.GetTile(parentPos + Vector3Int.down) &&
            !navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        //top left
        neighborPos = parentPos + Vector3Int.up + Vector3Int.left;
        if (!navigationMap.GetTile(parentPos + Vector3Int.left) &&
            !navigationMap.GetTile(parentPos + Vector3Int.up) &&
            !navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        //top right
        neighborPos = parentPos + Vector3Int.up + Vector3Int.right;
        if (!navigationMap.GetTile(parentPos + Vector3Int.right) &&
            !navigationMap.GetTile(parentPos + Vector3Int.up) &&
            !navigationMap.GetTile(neighborPos))
        {
            if (tilemap.GetTile(neighborPos))
            {
                Node neighbor = GetNode(neighborPos, nodes);
                neighbours.Add(neighbor);
            }
        }

        return neighbours;
    }


    private static float FindEuclideanDistance(Vector3Int posA, Vector3Int posB)
    {
        //converting to float vectors
        Vector3 posA_ = (Vector3)posA;
        Vector3 posB_ = (Vector3)posB;

        //pythagorium to find distance between the positions
        float result = Mathf.Sqrt(((posA_.x - posB_.x) * (posA_.x - posB_.x)) + ((posA_.y - posB_.y) * (posA_.y - posB_.y)));

        return result;
    }

    public Vector3Int getStartPos()
    {
        return new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
    }

    public Vector3Int getGoalPos()
    {
        return goalPos;
    }

    private void moveActor()
    {
        if(path.Count > 1)
        {
            //if at pos, remove it from path
            if (Vector3.Distance(transform.position, path.Peek() + new Vector3(0.5f, 0.5f, 0)) < 0.5f) //checks if it's close enough
            {
                path.Pop();
            }

            //seek to next pos in path
            seekAI.setTarget(path.Peek() + new Vector3(0.5f, 0.5f, 0));
            arriveAI.setTarget(path.Peek() + new Vector3(0.5f, 0.5f, 0));
        }
    }

    public void PathfindTo(Vector3 goalPos_)
    {
        goalPos = new Vector3Int((int)goalPos_.x, (int)goalPos_.y, (int)goalPos_.z);
        path = AStarAlgorithm(getStartPos(), goalPos); 
    }
}


