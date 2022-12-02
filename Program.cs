using DailyExercises;
using System;

public class GraphMutiplyTable
{
    /**
     * vName-->顶点名称
     * firstEdge-->顶点边链表的头结点
     */
    public class Vertex
    {
        public String vName;
        public Edge firstEdge;

        public Vertex() { }
        public Vertex(String name)
        {
            this.vName = name;
        }
    }

    /**
     * iVex-->边的其中一个顶点A
     * iLink-->边中顶点A的边链表的指针
     * jVex-->边的另一个顶点B
     * jLink-->边中顶点B的边链表的指针
     */
    public class Edge
    {
        public int iVex;
        public Edge iLink;
        public int jVex;
        public Edge jLink;

        public Edge() { }
        public Edge(int iVex, int jVex)
        {
            this.iVex = iVex;
            this.jVex = jVex;
        }
    }

    public class GraphEdge
    {
        public String vex;
        public String otherVex;

        public GraphEdge(String vexName, String otherVexName)
        {
            this.vex = vexName;
            this.otherVex = otherVexName;
        }
    }

    public List<Vertex> vertexArr;

    public void init(String[] vexArr, List<GraphEdge> edgeList)
    {
        initVexArr(vexArr);
        initEdge(edgeList);
    }

    public void initVexArr(String[] vexArr)
    {
        vertexArr = new List<Vertex>(vexArr.Length);
        for (int i = 0; i < vexArr.Length; i++)
        {
            Vertex vertex = new Vertex(vexArr[i]);
            vertexArr.Add(vertex);
        }
    }

    public void initEdge(List<GraphEdge> edgeList)
    {
        for (int i = 0; i < edgeList.Count; i++)
        {
            GraphEdge graphEdge = edgeList[i];
            if (contains(graphEdge.vex) && contains(graphEdge.otherVex))
            {
                //获取顶点的下标
                int vIndex = getVexIndex(graphEdge.vex);
                int oIndex = getVexIndex(graphEdge.otherVex);
                //获取顶点
                Vertex vertex = vertexArr[vIndex];
                Vertex oVertex = vertexArr[oIndex];
                //构造两个顶点的边
                Edge edge = new Edge(vIndex, oIndex);
                //头插法插入vertex的边
                if (vertex.firstEdge == null)
                {
                    vertex.firstEdge = edge;
                }
                else
                {
                    Edge vexNextEdge = vertex.firstEdge;
                    edge.iLink = vexNextEdge;
                    vertex.firstEdge = edge;
                }
                //头插法插入oVertex的边
                if (oVertex.firstEdge == null)
                {
                    oVertex.firstEdge = edge;
                }
                else
                {
                    Edge oVexNextEdge = oVertex.firstEdge;
                    edge.jLink = oVexNextEdge;
                    oVertex.firstEdge = edge;
                }


            }
        }
    }

    public bool contains(String vName)
    {
        foreach (Vertex vertex in vertexArr)
        {
            if (vertex.vName.Equals(vName))
                return true;
        }
        return false;
    }

    public int getVexIndex(String vName)
    {
        for (int i = 0; i < vertexArr.Count; i++)
        {
            if (vertexArr[i].vName.Equals(vName))
                return i;
        }
        return -1;
    }

    public void print()
    {
        foreach (Vertex vertex in vertexArr)
        {
            Console.WriteLine("顶点 " + vertex.vName + " 的所有边: ");
            int vIndex = getVexIndex(vertex.vName);
            Edge cursor = vertex.firstEdge;
            while (cursor != null)
            {
                Console.WriteLine(cursor.iVex + "---" + cursor.jVex + " ||");
                if (cursor.iVex == vIndex)
                {
                    cursor = cursor.iLink;
                }
                else
                {
                    cursor = cursor.jLink;
                }
            }

            Console.WriteLine();
        }
    }

    //删除边
    /**
     * 删除边的整体思路
     * 1.找到边上的两个顶点A和B
     * 2.分别遍历AB的边链表，直到找到要删除的边S
     * 3.分别将边S及边S的前驱边PS的数据存储起来,这里A的要删除的边为cursor，前驱边为preCursor,B的要删除的边为oCursor,前驱边为oPreCursor
     * 4.调整链表结构
     * @param graphEdge
     */
    public void remove(GraphEdge graphEdge)
    {
        String vName = graphEdge.vex;
        String oName = graphEdge.otherVex;
        int vIndex = getVexIndex(vName);
        int oIndex = getVexIndex(oName);
        //处理边的第一个顶点A
        Vertex vertex = vertexArr[vIndex];
        Edge cursor = vertex.firstEdge;
        //指针的前驱
        Edge preCursor = null;

        while (cursor != null)
        {
            if (cursor.iVex == oIndex || cursor.jVex == oIndex)
            {
                //通过遍历顶点A的所有边，找到边的前驱指针
                break;
            }
            preCursor = cursor;
            if (cursor.iVex == vIndex)
            {
                cursor = cursor.iLink;
            }
            else
            {
                cursor = cursor.jLink;
            }
        }

        //处理边的第二个顶点B
        Vertex oVertex = vertexArr[oIndex];
        Edge oCursor = oVertex.firstEdge;
        //指针的前驱
        Edge oPreCursor = null;

        while (oCursor != null)
        {
            if (oCursor.iVex == vIndex || oCursor.jVex == vIndex)
            {
                //通过遍历顶点B的所有边，找到边的前驱指针
                break;
            }
            oPreCursor = oCursor;
            if (oCursor.iVex == oIndex)
            {
                oCursor = oCursor.iLink;
            }
            else
            {
                oCursor = oCursor.jLink;
            }
        }

        if (preCursor != null)
        {
            if (preCursor.iVex == vIndex && cursor.iVex == vIndex)
            {
                preCursor.iLink = cursor.iLink;
            }
            else if (preCursor.iVex == vIndex && cursor.jVex == vIndex)
            {
                preCursor.iLink = cursor.jLink;
            }
            else if (preCursor.jVex == oIndex && cursor.iVex == vIndex)
            {
                preCursor.jLink = cursor.iLink;
            }
            else
            {
                preCursor.jLink = cursor.jLink;
            }
        }
        else
        {
            if (cursor.iVex == vIndex)
            {
                vertex.firstEdge = cursor.iLink;
            }
            else
            {
                vertex.firstEdge = cursor.jLink;
            }
        }

        if (oPreCursor != null)
        {
            if (oPreCursor.iVex == oIndex && oCursor.iVex == oIndex)
            {
                oPreCursor.iLink = oCursor.iLink;
            }
            else if (oPreCursor.iVex == oIndex && oCursor.jVex == oIndex)
            {
                oPreCursor.iLink = oCursor.jLink;
            }
            else if (oPreCursor.jVex == oIndex && oCursor.iVex == oIndex)
            {
                oPreCursor.jLink = oCursor.iLink;
            }
            else
            {
                oPreCursor.jLink = oCursor.jLink;
            }
        }
        else
        {
            if (oCursor.iVex == oIndex)
            {
                oVertex.firstEdge = oCursor.iLink;
            }
            else
            {
                oVertex.firstEdge = oCursor.jLink;
            }
        }


    }

    public static void Main(String[] args)
    {
        var val = ArrangeBall.MinOperations("001011");

        for (int i = 0; i<val.Length; i++) Console.WriteLine(val[i]);

        Console.Read();


        return;
        GraphMutiplyTable graph = new GraphMutiplyTable();
        String[] vexArr = { "V0", "V1", "V2", "V3" };
        GraphEdge edge = new GraphEdge("V0", "V1");
        GraphEdge edge1 = new GraphEdge("V0", "V2");
        GraphEdge edge2 = new GraphEdge("V0", "V3");
        GraphEdge edge3 = new GraphEdge("V1", "V2");
        GraphEdge edge4 = new GraphEdge("V2", "V3");

        List<GraphEdge> edgeList = new List<GraphEdge>();
        edgeList.Add(edge);
        edgeList.Add(edge1);
        edgeList.Add(edge2);
        edgeList.Add(edge3);
        edgeList.Add(edge4);

        graph.init(vexArr, edgeList);
        graph.remove(edge3);
        graph.print();
    }
}