using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
   void Start()
    {
    MeshFilter mf = GetComponent<MeshFilter>();
        Mesh m = new Mesh();
        m.vertices = GetCubeVertices(new Vector3(5f, 5f, 5f));
        m.triangles = GetQuadTriangles(0, 6);
        m.uv = GetUVArray(new Vector2(0.0f, 0.75f), new Vector3(0.125f, 0.125f, 0.125f));
        m.RecalculateNormals();
        mf.mesh = m;
    }


    Vector3[] GetCubeVertices(Vector3 size)
    {
        List<Vector3> vertices = new List<Vector3>();


        // Top
        vertices.Add(new Vector3(-size.x, size.y, -size.z));
        vertices.Add(new Vector3(-size.x, size.y, size.z));
        vertices.Add(new Vector3(size.x, size.y, size.z));
        vertices.Add(new Vector3(size.x, size.y, -size.z));

        // Bottom
        vertices.Add(new Vector3(-size.x, -size.y, size.z));
        vertices.Add(new Vector3(-size.x, -size.y, -size.z));
        vertices.Add(new Vector3(size.x, -size.y, -size.z));
        vertices.Add(new Vector3(size.x, -size.y, size.z));

        // Front
        vertices.Add(new Vector3(-size.x, -size.y, -size.z));
        vertices.Add(new Vector3(-size.x, size.y, -size.z));
        vertices.Add(new Vector3(size.x, size.y, -size.z));
        vertices.Add(new Vector3(size.x, -size.y, -size.z));

        // Right
        vertices.Add(new Vector3(-size.x, -size.y, size.z));
        vertices.Add(new Vector3(-size.x, size.y, size.z));
        vertices.Add(new Vector3(-size.x, size.y, -size.z));
        vertices.Add(new Vector3(-size.x, -size.y, -size.z));

        // Left
        vertices.Add(new Vector3(size.x, -size.y, -size.z));
        vertices.Add(new Vector3(size.x, size.y, -size.z));
        vertices.Add(new Vector3(size.x, size.y, size.z));
        vertices.Add(new Vector3(size.x, -size.y, size.z));

        // Back
        vertices.Add(new Vector3(size.x, -size.y, size.z));
        vertices.Add(new Vector3(size.x, size.y, size.z));
        vertices.Add(new Vector3(-size.x, size.y, size.z));
        vertices.Add(new Vector3(-size.x, -size.y, size.z));

        return vertices.ToArray();
    }

    int[] GetQuadTriangles(int startIndex, int quadCount)
    {
        List<int> triangles = new List<int>();
        int m = 0;

        for (int i = 0; i < quadCount; i++)
        {
            m = startIndex + i * 4;

            triangles.Add(m);
            triangles.Add(m + 1);
            triangles.Add(m + 2);
            triangles.Add(m);
            triangles.Add(m + 2);
            triangles.Add(m + 3);
        }

        return triangles.ToArray();
    }

    Vector2[] GetUVArray(Vector2 origin, Vector3 uvSize)
    {
        List<Vector2> uvs = new List<Vector2>();

        Vector2[] top = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y)
        };

        Vector2[] bottom = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.z + uvSize.x * 2, origin.y + uvSize.y + uvSize.z),
            new Vector2(origin.x + uvSize.z + uvSize.x * 2, origin.y + uvSize.y)
        };

        Vector2[] front = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z, origin.y),
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y)
        };

        Vector2[] right = new Vector2[]
        {
            new Vector2(origin.x, origin.y),
            new Vector2(origin.x, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z, origin.y)
        };

        Vector2[] left = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y),
            new Vector2(origin.x + uvSize.z + uvSize.x, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x * 2, origin.y + uvSize.y),
            new Vector2(origin.x + uvSize.z + uvSize.x * 2, origin.y)
        };

        Vector2[] back = new Vector2[]
        {
            new Vector2(origin.x + uvSize.z + uvSize.x * 2, origin.y),
            new Vector2(origin.x + uvSize.z + uvSize.x * 2, origin.y + uvSize.y),
            new Vector2(origin.x + (uvSize.z + uvSize.x) * 2, origin.y + uvSize.y),
            new Vector2(origin.x + (uvSize.z + uvSize.x) * 2, origin.y)
        };
        uvs.AddRange(top);
        uvs.AddRange(bottom);
        uvs.AddRange(front);
        uvs.AddRange(right);
        uvs.AddRange(left);
        uvs.AddRange(back);

        return uvs.ToArray();
    }
}
