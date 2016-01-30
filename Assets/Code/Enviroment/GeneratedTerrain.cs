using UnityEngine;
using System.Collections;

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
        }

        public Node(Vector3 position)
        {
            m_position = position;
        }
    }

    private class ControlNode : Node
    {
        private bool m_active;

        private Node m_above, m_right;

        public bool Active
        {
            get { return m_active; }
        }

        public Node Above
        {
            get { return m_above; }
        }

        public Node Right
        {
            get { return m_right; }
        }

        public ControlNode(Vector3 position, bool active, float squareSize) : base(position)
        {
            m_active = active;
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

        public ControlNode BottomRight
        {
            get { return m_bottomRight; }
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

        _generateMesh();
    }

    private void _generateMesh()
    {
        
    }

    private void _generateAreaMesh()
    {
        
    }
}
