using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

[RequireComponent(typeof(MeshFilter))]
public class GeneratedTerrain : Terrain
{
    private float m_boxSize = 1.0f;

    private TerrainData m_data;

    private class Node
    {
        private Vector3 m_position;
        private int m_vertexIndex = -1;

        public Vector3 Position
        {
            get { return m_position; }
        }

        public int VertexIndex
        {
            get { return m_vertexIndex; }
            set { m_vertexIndex = value; }
        }

        public Node(Vector3 position)
        {
            m_position = position;
        }
    }

    private class ControlNode : Node
    {
        private Node m_above, m_right;

        private Block m_data;

        public bool Active
        {
            get { return m_data.Value > 0; }
        }

        public Block Data
        {
            get { return m_data; }
        }

        public Node Above
        {
            get { return m_above; }
        }

        public Node Right
        {
            get { return m_right; }
        }

        public ControlNode(Vector3 position, Block data, float squareSize) : base(position)
        {
            m_data = data;
            m_above = new Node(position + Vector3.forward * squareSize * 0.5f);
            m_right = new Node(position + Vector3.right * squareSize * 0.5f);
        }
    }

    private class Square
    {
        private ControlNode m_topLeft, m_topRight, m_bottomLeft, m_bottomRight;

        public Node CenterTop
        {
            get { return m_topLeft.Right; }
        }

        public Node CenterRight
        {
            get { return m_bottomRight.Above; }
        }

        public Node CenterBottom
        {
            get { return m_bottomLeft.Right; }
        }

        public Node CenterLeft
        {
            get { return m_bottomLeft.Above; }
        }

        public ControlNode TopLeft
        {
            get { return m_topLeft; }
        }

        public ControlNode TopRight
        {
            get { return m_topRight; }
        }

        public ControlNode BottomLeft
        {
            get { return m_bottomLeft; }
        }

        public ControlNode BottomRight
        {
            get { return m_bottomRight; }
        }

        public int Congifuration
        {
            get
            {
                int configuration = 0;

                if (TopLeft.Active)
                    configuration += 8;
                if (TopRight.Active)
                    configuration += 4;
                if (BottomRight.Active)
                    configuration += 2;
                if (BottomLeft.Active)
                    configuration += 1;

                return configuration;
            }
        }

        public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomLeft, ControlNode bottomRight)
        {
            m_topLeft = topLeft;
            m_topRight = topRight;
            m_bottomLeft = bottomLeft;
            m_bottomRight = bottomRight;
        }
    }

    public override void Construct(TerrainData data)
    {
        m_data = data;

        _generateMesh(data);
    }

    private void _generateMesh(TerrainData data)
    {
        Vector3 startPosition = transform.position - new Vector3(m_data.Width, 0, m_data.Height) * m_boxSize * 0.5f;
        Vector3 step = new Vector3(m_boxSize, 0, m_boxSize);

        int width = data.Width;
        int height = data.Height;
        
        ControlNode[,] nodes = new ControlNode[width,height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 offset = startPosition + new Vector3(step.x * x, 0.0f, step.z * y);
                nodes[x, y] = new ControlNode(offset, data.GetBlock(new Point(x, y)), m_boxSize);
            }
        }

        LinkedList<Square> squares = new LinkedList<Square>();

        for (int y = 0; y < height - 1; y++)
        {
            for (int x = 0; x < width - 1; x++)
            {
                ControlNode bottomLeft = nodes[x, y];
                ControlNode bottomRight = nodes[x + 1, y];
                ControlNode topLeft = nodes[x, y + 1];
                ControlNode topRight = nodes[x + 1, y + 1];

                Square square = new Square(topLeft, topRight, bottomLeft, bottomRight);
                squares.AddLast(square);
            }
        }

        LinkedList<Vector3> verticies = new LinkedList<Vector3>();
        LinkedList<int> indicies = new LinkedList<int>();

        foreach (Square square in squares)
        {
            _buildSquare(square, verticies, indicies);
        } 

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        mesh.vertices = verticies.ToArray();
        mesh.triangles = indicies.ToArray();
        mesh.RecalculateNormals();
    }

    private void _buildSquare(Square square, LinkedList<Vector3> verticies, LinkedList<int> indicies)
    {
        switch (square.Congifuration)
        {
            case 0:
                break;

            //1 Point:
            case 1:
                _generateTriangles(verticies, indicies, square.BottomLeft, square.CenterLeft, square.CenterBottom);
                break;
            //case 2:
            //    _generateTriangles(verticies, indicies, square.CenterRight, square.BottomRight, square.CenterBottom);
            //    break;
            case 4:
                _generateTriangles(verticies, indicies, square.CenterTop, square.CenterRight, square.TopRight);
                break;
            //case 8:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.CenterTop, square.CenterLeft);
            //    break;

            ////2 Point:
            //case 3:
            //    _generateTriangles(verticies, indicies, square.CenterRight, square.BottomRight, square.BottomLeft, square.CenterLeft);
            //    break;
            //case 6:
            //    _generateTriangles(verticies, indicies, square.CenterTop, square.TopRight, square.BottomRight, square.CenterBottom);
            //    break;
            //case 9:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.CenterTop, square.CenterBottom, square.BottomLeft);
            //    break;
            //case 12:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.TopRight, square.CenterRight, square.CenterLeft);
            //    break;
            //case 5:
            //    _generateTriangles(verticies, indicies, square.CenterTop, square.TopRight, square.CenterRight, square.CenterBottom, square.BottomLeft, square.CenterLeft);
            //    break;
            //case 10:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.CenterTop, square.CenterRight, square.BottomRight, square.CenterBottom, square.CenterLeft);
            //    break;

            ////3 Point:
            //case 7:
            //    _generateTriangles(verticies, indicies, square.CenterTop, square.TopRight, square.BottomRight, square.BottomLeft, square.CenterLeft);
            //    break;
            //case 11:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.CenterTop, square.CenterRight, square.BottomRight, square.BottomLeft);
            //    break;
            //case 13:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.TopRight, square.CenterRight, square.CenterBottom, square.BottomLeft);
            //    break;
            //case 14:
            //    _generateTriangles(verticies, indicies, square.TopLeft, square.TopRight, square.BottomRight, square.CenterBottom, square.CenterLeft);
            //    break;

            //4 Point:
            case 15:
                _generateTriangles(verticies, indicies, square.BottomLeft, square.TopRight, square.TopLeft, square.BottomLeft);
                break;
        }
    }

    private void _generateTriangles(LinkedList<Vector3> verticies, LinkedList<int> indicies, params Node[] points)
    {
        //Have to make at least one tri
        Assert.IsTrue(points.Length >= 3);

        foreach (Node point in points)
        {
            if (point.VertexIndex == -1)
            {
                point.VertexIndex = verticies.Count;
                verticies.AddLast(point.Position);
            }
        }

        int i = 0;
        do
        {
            indicies.AddLast(points[0].VertexIndex);
            indicies.AddLast(points[i + 1].VertexIndex);
            indicies.AddLast(points[i + 2].VertexIndex);
            i++;
        } while (i < points.Length - 2);
    }
}
