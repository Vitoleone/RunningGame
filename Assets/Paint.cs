using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Paint : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    Color[] colors;


    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
        gameObject.AddComponent<MeshCollider>();
        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        colors = new Color[vertices.Length];
    }
    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform.gameObject.tag == "Wall")
            {
               
                // create new colors array where the colors will be created.


                colors[hit.triangleIndex] = Color.red;
                
               


                // assign the array of colors to the Mesh.
                mesh.colors = colors;
            }
        }

    }
    void CreateShape()
    {
        //vertices = new Vector3[]
        //{
        //    //new Vector3(0,0,0),
        //    //new Vector3(0,0,1),
        //    //new Vector3(1,0,0),
        //    //new Vector3(1,0,1),
        //    //new Vector3(2,0,0),
        //    //new Vector3(2,0,1),

        //};
        vertices = CreateVertices(20);
        triangles = CreateTriangles(20);
        //triangles = new int[]
        //{
        //    0,1,2,
        //    1,3,2,
        //    2,3,4,
        //    3,5,4,
        //};
    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

    }

    Vector3[] CreateVertices(int quantity)
    {
        int x = 0;
        int y = 0;
        int z = 0;
        Vector3[] vertices;
        vertices = new Vector3[quantity * 3];

        for (int i = 0; i < quantity * 3; i++)
        {
            if (i == 0)
            {
                vertices[i] = new Vector3(x, y, z);
            }
            else if (i % 2 != 0)
            {
                z++;
                vertices[i] = new Vector3(x, y, z);
            }
            else
            {
                x++;
                z--;
                vertices[i] = new Vector3(x, y, z);
            }
        }
        return vertices;
    }
    int[] CreateTriangles(int quantity)
    {
        int first = -1;
        int second = 1;
        int third = 0;
        int[] triangles;
        triangles = new int[quantity * 6];

        int counter = 0;
        for (int i = 0; i < quantity * 6; i++)
        {
            if (counter == 0)
            {
                first++;
                triangles[i] = first;
                counter++;
            }
            else if (counter == 1)
            {
                if (i % 2 != 0)
                {
                    triangles[i] = second;

                }
                else
                {
                    second += 2;
                    triangles[i] = second;

                }
                counter++;
            }
            else if (counter == 2)
            {
                if (i % 2 != 0)
                {

                    triangles[i] = third;
                }
                else
                {
                    third += 2;
                    triangles[i] = third;
                }
                counter = 0;
            }

        }
        return triangles;
    }

}