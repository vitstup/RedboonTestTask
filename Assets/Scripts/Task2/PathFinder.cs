using System.Collections.Generic;
using UnityEngine;

public class PathFinder : IPathFinder
{
    public IEnumerable<Vector2> GetPath(Vector2 start, Vector2 end, IEnumerable<Edge> edges)
    {
        // ������� ������ ��������������� �� ������ �����
        List<Rectangle> rectangles = new List<Rectangle>();
        foreach (var edge in edges)
        {
            rectangles.Add(edge.First);
            rectangles.Add(edge.Second);
        }

        // ������� ���� � ������� ��������� A*
        var path = AStarPathFinder.FindPath(start, end, rectangles);

        // ���������� ����
        return path;
    }
}