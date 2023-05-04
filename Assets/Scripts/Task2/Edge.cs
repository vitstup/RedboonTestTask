using UnityEngine;

[System.Serializable]
public struct Edge
{
    public Rectangle First;
    public Rectangle Second;
    public Vector3 Start;
    public Vector3 End;

    public Edge(Rectangle first, Rectangle second, Vector3 start, Vector3 end)
    {
        First = first;
        Second = second;
        Start = start;
        End = end;
    }
}