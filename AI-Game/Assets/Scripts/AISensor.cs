using UnityEngine;

public class AISensor : MonoBehaviour
{
    public float distance = 10f;
    public float angle = 30f;
    public float height = 1.0f;
    public Color meshColor = new Color(1f, 0f, 0f, 0.35f);

    private Mesh mesh;

    Mesh CreateWedgeMesh()
    {
        int segments = 10;
        int numTriangles = (segments * 4) + 2 + 2;
        Mesh newMesh = new Mesh();

        int numVertices = numTriangles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCentre = Vector3.zero;
        Vector3 bottomLeft = Quaternion.Euler(0f, -angle, 0f) * Vector3.forward * distance;
        Vector3 bottomRight = Quaternion.Euler(0f, angle, 0f) * Vector3.forward * distance;

        Vector3 topCentre = bottomCentre + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;
        Vector3 topRight = bottomRight + Vector3.up * height;

        int vert = 0;

        // Left side (facing outward to the left)
        vertices[vert++] = bottomCentre;
        vertices[vert++] = topLeft;
        vertices[vert++] = bottomLeft;

        vertices[vert++] = bottomCentre;
        vertices[vert++] = topCentre;
        vertices[vert++] = topLeft;

        // Right side (facing outward to the right)
        vertices[vert++] = bottomCentre;
        vertices[vert++] = bottomRight;
        vertices[vert++] = topRight;

        vertices[vert++] = bottomCentre;
        vertices[vert++] = topRight;
        vertices[vert++] = topCentre;


        float currentAngle = -angle;
        float deltaAngle = (angle * 2) / segments;
        for(int i = 0; i < segments; i++)
        {
            bottomCentre = Vector3.zero;
            bottomLeft = Quaternion.Euler(0f, currentAngle, 0f) * Vector3.forward * distance;
            bottomRight = Quaternion.Euler(0f, currentAngle + deltaAngle, 0f) * Vector3.forward * distance;

            topCentre = bottomCentre + Vector3.up * height;
            topLeft = bottomLeft + Vector3.up * height;
            topRight = bottomRight + Vector3.up * height;

            // Far side (facing outward away from origin)
            vertices[vert++] = bottomLeft;
            vertices[vert++] = topRight;
            vertices[vert++] = bottomRight;

            vertices[vert++] = bottomLeft;
            vertices[vert++] = topLeft;
            vertices[vert++] = topRight;

            // Top side (facing up)
            vertices[vert++] = topCentre;
            vertices[vert++] = topRight;
            vertices[vert++] = topLeft;

            // Bottom side (facing up so it's visible from above)
            vertices[vert++] = bottomCentre;
            vertices[vert++] = bottomLeft;
            vertices[vert++] = bottomRight;

            currentAngle += deltaAngle;
        }

        for (int i = 0; i < numVertices; ++i)
        {
            triangles[i] = i;
        }

        newMesh.vertices = vertices;
        newMesh.triangles = triangles;
        newMesh.RecalculateNormals();

        return newMesh;
    }

    private void OnValidate()
    {
        mesh = CreateWedgeMesh();
    }

    private void OnDrawGizmos()
    {
        if (mesh == null)
        {
            mesh = CreateWedgeMesh();
        }

        Gizmos.color = meshColor;
        Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
    }
}