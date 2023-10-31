using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathColoring : MonoBehaviour
{
    public Transform target;
    private TileSystem tileSystem;
    private List<Vector2Int> pathwayPoints;

    private void Start()
    {
        tileSystem = GameObject.FindWithTag("NavigationMap").GetComponent<TileSystem>();
        CalculatePathway();
        ColorPathway();
    }

    private void CalculatePathway()
    {
        pathwayPoints = new List<Vector2Int>();

        Vector2Int startPos = new Vector2Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y));
        Vector2Int targetPos = new Vector2Int(Mathf.FloorToInt(target.position.x), Mathf.FloorToInt(target.position.y));

        // Implement your pathfinding algorithm here to calculate the pathway
        // For demonstration, we'll just add a simple linear interpolation example
        Vector2Int currentPos = startPos;

        while (currentPos != targetPos)
        {
            pathwayPoints.Add(currentPos);

            int deltaX = Mathf.Clamp(targetPos.x - currentPos.x, -1, 1);
            int deltaY = Mathf.Clamp(targetPos.y - currentPos.y, -1, 1);

            currentPos.x += deltaX;
            currentPos.y += deltaY;
        }

        pathwayPoints.Add(targetPos);
    }

    private void ColorPathway()
    {
        foreach (Vector2Int tilePos in pathwayPoints)
        {
            tileSystem.ColorTile(tilePos, Color.yellow);
        }
    }
}
