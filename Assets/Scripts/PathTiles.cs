using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class PathTiles : MonoBehaviour
{
    public int width;
    public int height;


    void Start()
    {
        //floor position so we don't have to be so specific when placing in editor (here as well as in other script just in case something isn't floored right in play mode)

        transform.position = new Vector3(Mathf.Floor(transform.position.x), Mathf.Floor(transform.position.y), transform.position.z);


        //tell navigation map which tiles are occupied

        TileSystem navigationMap = GameObject.FindWithTag("NavigationMap").GetComponent<TileSystem>();

        for (int x = (int)transform.position.x; x < (int)transform.position.x + width; x++)
        {
            for (int y = (int)transform.position.y; y < (int)transform.position.y + height; y++)
            {
                navigationMap.OccupyTile(new Vector2Int(x, y));
            }
        }
    }

    private void OnDestroy()
    {
        //tell navigation map which tiles to free up

        TileSystem navigationMap = GameObject.FindWithTag("NavigationMap").GetComponent<TileSystem>();

        for (int x = (int)transform.position.x; x < (int)transform.position.x + width; x++)
        {
            for (int y = (int)transform.position.y; y < (int)transform.position.y + height; y++)
            {
                navigationMap.VacateTile(new Vector2Int(x, y));
            }
        }
    }

    private void OnDrawGizmos()
    {
        // draw "hitbox"

        Vector3 size = new Vector3(width, height);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(new Vector3(Mathf.Floor(transform.position.x), Mathf.Floor(transform.position.y)) + size * 0.5f, size);
    }
}
