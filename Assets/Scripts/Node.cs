using System.Collections;
using UnityEngine;


public class Node
{
    public int G { get; set; } = int.MaxValue;
    //public int H { get; set; }
    public int F { get; set; } = int.MaxValue;
    public Node Parent { get; set; }
    public Vector3Int Position { get; set; }

    public Node(Vector3Int position)
    {
        this.Position = position;
    }
}