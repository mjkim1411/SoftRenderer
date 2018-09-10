using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    private Vector3 _cubeSize;
    [SerializeField]
    private Vector2 _uvOffset;
    [SerializeField]
    private Vector3 _uvSize;

    private void Start()
    {
        MeshFilter filter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        Vector3[] vertices;
        int[] indices;
        Vector2[] uvs;
        CreateCube(_cubeSize, _uvOffset, _uvSize, out vertices, out indices, out uvs);
        m.vertices = vertices;
        m.triangles = indices;
        m.uv = uvs;
        m.RecalculateNormals();
        filter.mesh = mesh;
    }

    private void CreateCube(Vector3 cubeSize, Vector2 uvOffset, Vector3 uvSize, out Vector3[] vertices, out int[] indices, out Vector2[] uvs)
    {
        vertices = new Vector3[]
        {
            // Front
            new Vector3(-cubeSize.x, -cubeSize.y, 0f),
            new Vector3(-cubeSize.x, cubeSize.y, 0f),
            new Vector3(cubeSize.x, cubeSize.y, 0f),
            new Vector3(cubeSize.x, -cubeSize.y, 0f),

            // Top
            new Vector3(-cubeSize.x, cubeSize.y, 0f),
            new Vector3(-cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(cubeSize.x, cubeSize.y, 0f),

            // Back
            new Vector3(-cubeSize.x, -cubeSize.y, cubeSize.z),
            new Vector3(-cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(cubeSize.x, -cubeSize.y, cubeSize.z),

            // Left
            new Vector3(-cubeSize.x, -cubeSize.y, cubeSize.z),
            new Vector3(-cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(-cubeSize.x, cubeSize.y, 0f),
            new Vector3(-cubeSize.x, -cubeSize.y, 0f),

            // Right
            new Vector3(cubeSize.x, -cubeSize.y, 0f),
            new Vector3(cubeSize.x, cubeSize.y, 0f),
            new Vector3(cubeSize.x, cubeSize.y, cubeSize.z),
            new Vector3(cubeSize.x, -cubeSize.y, cubeSize.z),

            // Bottom
            new Vector3(-cubeSize.x, -cubeSize.y, cubeSize.z),
            new Vector3(-cubeSize.x, -cubeSize.y, 0f),
            new Vector3(cubeSize.x, -cubeSize.y, 0f),
            new Vector3(cubeSize.x, -cubeSize.y, cubeSize.z)
        };

        indices = new int[]
        {
            // Front
            0, 1, 2,
            0, 2, 3,

            // Top
            4, 5, 6,
            4, 6, 7,

            // Back
            8, 10, 9,
            8, 11, 10,

            // Left
            12, 13, 14,
            12, 14, 15,

            // Right
            16, 17, 18,
            16, 18, 19,

            // Bottom
            20, 21, 22,
            20, 22, 23
        };

        uvs = new Vector2[]
        {
            // Front
            new Vector2(uvOffset.x + uvSize.z, uvOffset.y),
            new Vector2(uvOffset.x + uvSize.z, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.z + uvSize.x, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.z + uvSize.x, uvOffset.y),

            // Top
            new Vector2(uvOffset.x + uvSize.z, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.z, uvOffset.y + uvSize.y * 2f),
            new Vector2(uvOffset.x + uvSize.z + uvSize.x, uvOffset.y + uvSize.y * 2f),
            new Vector2(uvOffset.x + uvSize.z + uvSize.x, uvOffset.y + uvSize.y),

            // Back
            new Vector2(uvOffset.x + uvSize.x + uvSize.z * 2f, uvOffset.y),
            new Vector2(uvOffset.x + uvSize.x + uvSize.z * 2f, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.x * 2f + uvSize.z * 2f, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.x * 2f + uvSize.z * 2f, uvOffset.y),

            // Left
            new Vector2(uvOffset.x + uvSize.x + uvSize.z, uvOffset.y),
            new Vector2(uvOffset.x + uvSize.x + uvSize.z, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.x + uvSize.z * 2f, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.x + uvSize.z * 2f, uvOffset.y),

            // Right
            new Vector2(uvOffset.x, uvOffset.y),
            new Vector2(uvOffset.x, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.z, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.z, uvOffset.y),

            // Bottom
            new Vector2(uvOffset.x + uvSize.x + uvSize.z, uvOffset.y + uvSize.y),
            new Vector2(uvOffset.x + uvSize.x + uvSize.z, uvOffset.y + uvSize.y + uvSize.z),
            new Vector2(uvOffset.x + uvSize.x * 2f + uvSize.z, uvOffset.y + uvSize.y + uvSize.z),
            new Vector2(uvOffset.x + uvSize.x * 2f + uvSize.z, uvOffset.y + uvSize.y)
        };
    }
}
