using UnityEngine;

public class ProceduralTerrain : MonoBehaviour
{
    public Camera playerCamera;
    public LayerMask buildMask;
    public float maxBuildDistance = 10f;
    public KeyCode buildKey = KeyCode.B;

    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uvs;
    private int vertexCount;

    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        vertices = new Vector3[0];
        triangles = new int[0];
        uvs = new Vector2[0];
        vertexCount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(buildKey))
        {
            RaycastHit hit;
            Ray ray = playerCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, maxBuildDistance, buildMask))
            {
                Vector3 newVertex = hit.point;
                AddVertex(newVertex);
            }
        }
    }
    void AddVertex(Vector3 newVertex)
{
    System.Array.Resize(ref vertices, vertexCount + 1);
    System.Array.Resize(ref uvs, vertexCount + 1);
    vertices[vertexCount] = newVertex;
    uvs[vertexCount] = new Vector2(newVertex.x, newVertex.z);

    if (vertexCount >= 2)
    {
        CreateTriangle();
    }

    vertexCount++;

    mesh.vertices = vertices;
    mesh.triangles = triangles;
    mesh.uv = uvs;
    mesh.RecalculateNormals();
}

void CreateTriangle()
{
    System.Array.Resize(ref triangles, triangles.Length + 3);

    triangles[triangles.Length - 3] = vertexCount - 2;
    triangles[triangles.Length - 2] = vertexCount - 1;
    triangles[triangles.Length - 1] = vertexCount;

}
}