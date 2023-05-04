using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathFinder
{
    private class Node
    {
        public Vector2 Position;    // Позиция узла
        public float Cost;          // Стоимость пути до узла
        public float Heuristic;     // Оценка эвристикой до цели
        public Node Parent;         // Родительский узел
    }

    private static readonly Vector2[] DIRECTIONS =
    {
        new Vector2(0, 1),
        new Vector2(0, -1),
        new Vector2(1, 0),
        new Vector2(-1, 0)
    };

    public static List<Vector2> FindPath(Vector2 start, Vector2 end, List<Rectangle> rectangles)
    {
        var openSet = new List<Node>();
        var closedSet = new List<Node>();

        var startNode = new Node
        {
            Position = start,
            Cost = 0,
            Heuristic = CalculateHeuristic(start, end),
            Parent = null
        };

        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            var currentNode = GetLowestCostNode(openSet);

            if (currentNode.Position == end)
            {
                return ConstructPath(currentNode);
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            foreach (var neighbor in GetNeighbors(currentNode, rectangles))
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }

                var newCost = currentNode.Cost + CalculateDistance(currentNode, neighbor);

                if (newCost < neighbor.Cost || !openSet.Contains(neighbor))
                {
                    neighbor.Cost = newCost;
                    neighbor.Heuristic = CalculateHeuristic(neighbor.Position, end);
                    neighbor.Parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        // Если путь не найден
        return new List<Vector2>();
    }

    private static float CalculateHeuristic(Vector2 start, Vector2 end)
    {
        return Vector2.Distance(start, end);
    }

    private static float CalculateDistance(Node a, Node b)
    {
        return Vector2.Distance(a.Position, b.Position);
    }

    private static List<Node> GetNeighbors(Node node, List<Rectangle> rectangles)
    {
        var neighbors = new List<Node>();

        foreach (var direction in DIRECTIONS)
        {
            var neighborPosition = node.Position + direction;

            if (IsPositionValid(neighborPosition, rectangles))
            {
                var neighborNode = new Node
                {
                    Position = neighborPosition,
                    Cost = 0,
                    Heuristic = 0,
                    Parent = null
                };

                neighbors.Add(neighborNode);
            }
        }

        return neighbors;
    }

    private static bool IsPositionValid(Vector2 position, List<Rectangle> rectangles)
    {
        foreach (var rectangle in rectangles)
        {
            if (position.x >= rectangle.Min.x && position.x <= rectangle.Max.x &&
                position.y >= rectangle.Min.y && position.y <= rectangle.Max.y)
            {
                return false;
            }
        }

        return true;
    }

    private static Node GetLowestCostNode(List<Node> nodes)
    {
        Node lowestCostNode = nodes[0];

        foreach (var node in nodes)
        {
            if (node.Cost + node.Heuristic < lowestCostNode.Cost + lowestCostNode.Heuristic)
            {
                lowestCostNode = node;
            }
        }

        return lowestCostNode;
    }
    private static List<Vector2> ConstructPath(Node endNode)
    {
        var path = new List<Vector2>();
        var currentNode = endNode;
        while (currentNode.Parent != null)
        {
            path.Add(currentNode.Position);
            currentNode = currentNode.Parent;
        }
        path.Reverse();
        return path;
    }
}
