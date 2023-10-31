using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSystem : MonoBehaviour
{
    Tilemap NavigationMap;
    public Tile Occupied;

    private void Awake()
    {
        NavigationMap = GetComponent<Tilemap>();
    }

    public void OccupyTile (Vector2Int tilePos)
    {
        NavigationMap.SetTile((Vector3Int)tilePos, Occupied);
    }

    public void VacateTile (Vector2Int tilePos)
    {
        NavigationMap.SetTile((Vector3Int)tilePos, null);
    }

    public IEnumerable<Vector2Int> GetEdges (Vector2Int nodePos)
    {
        //checking for adjacent free tiles

        if(NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.right)) == null)
        {
            yield return nodePos + Vector2Int.right;
        }

        if (NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.left)) == null)
        {
            yield return nodePos + Vector2Int.left;
        }

        if (NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.up)) == null)
        {
            yield return nodePos + Vector2Int.up;
        }

        if (NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.down)) == null)
        {
            yield return nodePos + Vector2Int.down;
        }


        //checking for diagonal free tiles

        //bl
        if(NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.left)) == null && 
            NavigationMap.GetTile ((Vector3Int)(nodePos + Vector2Int.down)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.left + Vector2Int.down)) == null)
        {
            yield return nodePos + Vector2Int.left + Vector2Int.down;
        }

        //tl
        if (NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.left)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.up)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.left + Vector2Int.up)) == null)
        {
            yield return nodePos + Vector2Int.left + Vector2Int.up;
        }

        //br
        if (NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.right)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.down)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.right + Vector2Int.down)) == null)
        {
            yield return nodePos + Vector2Int.right + Vector2Int.down;
        }

        //tr
        if (NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.right)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.up)) == null &&
            NavigationMap.GetTile((Vector3Int)(nodePos + Vector2Int.right + Vector2Int.up)) == null)
        {
            yield return nodePos + Vector2Int.right + Vector2Int.up;
        }
    }

  


    private void OnDrawGizmos()
    {
        //if(NavigationMap == null)
        //{
        //    Awake();
        //}

        //Vector2Int pos = new Vector2Int(0, 0);
        //foreach(Vector2Int edgeNode in GetEdges(pos))
        //{
        //    Gizmos.DrawLine((pos + new Vector2(0.5f, 0.5f)), (edgeNode + new Vector2(0.5f, 0.5f)));
        //}


    }
}
