using System.Collections;
using UnityEngine;


public class Node
{
    public float G { get; set; } = float.PositiveInfinity;
    //public int H { get; set; }
    public float F { get; set; } = float.PositiveInfinity;
    public Node Parent { get; set; }
    public Vector3Int Position { get; set; }

    public Node(Vector3Int position)
    {
        this.Position = position;
    }
}