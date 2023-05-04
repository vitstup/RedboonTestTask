using System.Collections.Generic;
using UnityEngine;

public class TestPathFinder : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;
    public List<Edge> edges;

    private PathFinder pathFinder = new PathFinder();

    private void OnDrawGizmos()
    {
        // Отображаем ребра и прямоугольники
        foreach (var edge in edges)
        {
            Gizmos.DrawLine(edge.Start, edge.End);
            Gizmos.color = new Color(0, 0, 1, 0.1f);
            Gizmos.DrawCube((edge.First.Min + edge.First.Max) / 2, edge.First.Max - edge.First.Min);
            Gizmos.DrawCube((edge.Second.Min + edge.Second.Max) / 2, edge.Second.Max - edge.Second.Min);
        }

        // Находим путь
        var path = pathFinder.GetPath(start, end, edges);

        // Отображаем путь
        Gizmos.color = Color.green;
        Vector2 previos = start;
        foreach (var p in path)
        {
            Gizmos.DrawLine(previos, p);
            previos = p;
        }
    }

    public void GenerateRandomPath(int numEdges, float maxX, float maxY)
    {
        // Генерируем случайные точки начала и конца пути
        start = new Vector2(Random.Range(0f, maxX), Random.Range(0f, maxY));
        end = new Vector2(Random.Range(0f, maxX), Random.Range(0f, maxY));

        // Генерируем случайные ребра
        edges = new List<Edge>();
        for (int i = 0; i < numEdges; i++)
        {
            Vector2 firstMin = new Vector2(Random.Range(0f, maxX), Random.Range(0f, maxY));
            Vector2 firstMax = new Vector2(Random.Range(firstMin.x, maxX), Random.Range(firstMin.y, maxY));
            Rectangle firstRect = new Rectangle(firstMin, firstMax);

            Vector2 secondMin = new Vector2(Random.Range(0f, maxX), Random.Range(0f, maxY));
            Vector2 secondMax = new Vector2(Random.Range(secondMin.x, maxX), Random.Range(secondMin.y, maxY));
            Rectangle secondRect = new Rectangle(secondMin, secondMax);

            Vector3 start = new Vector3(Random.Range(firstMin.x, firstMax.x), Random.Range(firstMin.y, firstMax.y), 0f);
            Vector3 end = new Vector3(Random.Range(secondMin.x, secondMax.x), Random.Range(secondMin.y, secondMax.y), 0f);

            Edge edge = new Edge(firstRect, secondRect, start, end);
            edges.Add(edge);
        }
    }

    [ContextMenu("Generate")]
    public void Generate()
    {
        GenerateRandomPath(1,5,5);
    }
}