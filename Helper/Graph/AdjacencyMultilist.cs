// <copyright file="AdjacencyMultilist.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace HW.CAB.Helper.PipeNetwork
{
    /// <summary>
    /// 图中的顶点
    /// </summary>
    /// <typeparam name="Te">边类型</typeparam>
    public interface IGrapVertex<Te>
    {
        /// <summary>
        /// 获取顶点连接的边
        /// </summary>
        /// <returns>边</returns>
        List<Te> GetEdges();
    }

    /// <summary>
    /// 图中的边
    /// </summary>
    /// <typeparam name="Tv">点类型</typeparam>
    public interface IGrapEdge<Tv>
    {
        /// <summary>
        /// 获取边上的两个顶点
        /// </summary>
        /// <returns>顶点</returns>
        List<Tv> GetVertexs();
    }

    /// <summary>
    /// 邻接多重表
    /// </summary>
    /// <typeparam name="Tv">顶点</typeparam>
    /// <typeparam name="Te">边</typeparam>
    /// <remarks>
    /// 允许出现单顶点边
    /// 顶点与边类型需重写好Equals方法
    /// </remarks>
    public class AdjacencyMultilist<Tv, Te>
        where Tv : IGrapVertex<Te>
        where Te : IGrapEdge<Tv>
    {
        private readonly List<VertexNode<Tv, Te>> list;

        private readonly List<Tv> vertexs;

        private readonly List<Te> edges;

        private readonly Dictionary<Te, Tuple<int, int>> edgeMap;

        public AdjacencyMultilist(IEnumerable<Tv> vertexs, IEnumerable<Te> edges)
        {
            this.vertexs = vertexs.ToList();
            this.edges = edges.ToList();
            list = this.vertexs.Select(v => new VertexNode<Tv, Te>(v)).ToList();
            edgeMap = new Dictionary<Te, Tuple<int, int>>();

            InitEdgeNode();
        }

        /// <summary>
        /// 邻接多重表
        /// </summary>
        public VertexNode<Tv, Te>[] Table => list.ToArray();

        /// <summary>
        /// 储存的所有顶点
        /// </summary>
        public Tv[] Vertexs => vertexs.ToArray();

        /// <summary>
        /// 储存的所有边
        /// </summary>
        public Te[] Edges => edges.ToArray();

        /// <summary>
        /// 顶点是否存在于表中
        /// </summary>
        /// <param name="vertex">顶点</param>
        /// <returns>结果</returns>
        public bool ContainsVertex(Tv vertex)
        {
            foreach (var item in list)
            {
                if (item.Vertex.Equals(vertex))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 顶点于表中的索引
        /// </summary>
        /// <param name="vertex">顶点</param>
        /// <returns>索引</returns>
        public int VertexIndexOf(Tv vertex)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Vertex.Equals(vertex))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 边的顶点于表中的位置
        /// </summary>
        /// <param name="edge">边</param>
        /// <returns>索引</returns>
        public Tuple<int, int> EdgeIndexOf(Te edge)
        {
            if (edgeMap.ContainsKey(edge))
            {
                return edgeMap[edge];
            }

            return new Tuple<int, int>(-1, -1);
        }

        /// <summary>
        /// 删除边
        /// </summary>
        /// <param name="edge">边</param>
        public void RemoveEdge(Te edge)
        {
            if (edges.Contains(edge))
            {
                edges.Remove(edge);
                edgeMap.Remove(edge);
            }
            else
            {
                return;
            }

            var vertexs = edge.GetVertexs();

            //获取顶点的下标
            int vIndex = -1, oIndex = -1;

            for (int i = 0; i < vertexs.Count; i++)
            {
                if (i == 0)
                {
                    vIndex = VertexIndexOf(vertexs[i]);
                }
                else if (i == 1)
                {
                    oIndex = VertexIndexOf(vertexs[i]);
                }
                else
                {
                    break;
                }
            }

            if (vIndex != -1)
            {
                //顶点A指针的前驱
                EdgeNode<Tv, Te> preCursor = null;
                var vertex = list[vIndex];
                var cursor = vertex.FirstEdge;

                while (cursor != null)
                {
                    //通过遍历顶点A的所有边，找到边的前驱指针
                    if (cursor.Edge.Equals(edge))
                    {
                        break;
                    }

                    preCursor = cursor;

                    if (cursor.Vex == vIndex)
                    {
                        cursor = cursor.Link;
                    }
                    else
                    {
                        cursor = cursor.JLink;
                    }
                }

                if (cursor != null)
                {
                    if (preCursor != null)
                    {
                        if ((preCursor.Vex == vIndex) && (cursor.Vex == vIndex))
                        {
                            preCursor.Link = cursor.Link;
                        }
                        else if ((preCursor.Vex == vIndex) && (cursor.JVex == vIndex))
                        {
                            preCursor.Link = cursor.JLink;
                        }
                        else if ((preCursor.JVex == vIndex) && (cursor.Vex == vIndex))
                        {
                            preCursor.JLink = cursor.Link;
                        }
                        else
                        {
                            preCursor.JLink = cursor.JLink;
                        }
                    }
                    else
                    {
                        if (cursor.Vex == vIndex)
                        {
                            vertex.FirstEdge = cursor.Link;
                        }
                        else
                        {
                            vertex.FirstEdge = cursor.JLink;
                        }
                    }
                }
            }

            if (oIndex != -1)
            {
                //顶点B指针的前驱
                EdgeNode<Tv, Te> preCursor = null;
                var vertex = list[oIndex];
                var cursor = vertex.FirstEdge;

                while (cursor != null)
                {
                    //通过遍历顶点A的所有边，找到边的前驱指针
                    if (cursor.Edge.Equals(edge))
                    {
                        break;
                    }

                    preCursor = cursor;

                    if (cursor.Vex == oIndex)
                    {
                        cursor = cursor.Link;
                    }
                    else
                    {
                        cursor = cursor.JLink;
                    }
                }

                if (cursor != null)
                {
                    if (preCursor != null)
                    {
                        if ((preCursor.Vex == oIndex) && (cursor.Vex == oIndex))
                        {
                            preCursor.Link = cursor.Link;
                        }
                        else if ((preCursor.Vex == oIndex) && (cursor.JVex == oIndex))
                        {
                            preCursor.Link = cursor.JLink;
                        }
                        else if ((preCursor.JVex == oIndex) && (cursor.Vex == oIndex))
                        {
                            preCursor.JLink = cursor.Link;
                        }
                        else
                        {
                            preCursor.JLink = cursor.JLink;
                        }
                    }
                    else
                    {
                        if (cursor.Vex == oIndex)
                        {
                            vertex.FirstEdge = cursor.Link;
                        }
                        else
                        {
                            vertex.FirstEdge = cursor.JLink;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 替换边
        /// </summary>
        /// <param name="original">原边</param>
        /// <param name="newEdge">新边</param>
        public void ReplaceEdge(Te original, Te newEdge)
        {
            var index = edges.IndexOf(original);
            if (index == -1)
            {
                return;
            }

            edges[index] = newEdge;
            edgeMap.Remove(original);

            var vertexs = original.GetVertexs();

            foreach (var vertex in vertexs)
            {
                var i = VertexIndexOf(vertex);
                if (i != -1)
                {
                    var cursor = list[i].FirstEdge;

                    while (cursor != null)
                    {
                        //通过遍历顶点A的所有边，找到边的前驱指针
                        if (cursor.Edge.Equals(original))
                        {
                            cursor.Edge = newEdge;
                            edgeMap[newEdge] = new Tuple<int, int>(cursor.Vex, cursor.JVex);
                            break;
                        }

                        if (cursor.Vex == i)
                        {
                            cursor = cursor.Link;
                        }
                        else
                        {
                            cursor = cursor.JLink;
                        }
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// 删除顶点
        /// </summary>
        /// <param name="vertex">顶点</param>
        public void RemoveVertex(Tv vertex)
        {
            int vIndex = VertexIndexOf(vertex);
            if (vIndex == -1)
            {
                return;
            }

            var cursor = list[vIndex].FirstEdge;
            while (cursor != null)
            {
                if (cursor.Vex == vIndex)
                {
                    cursor.Vex = -1;
                    edgeMap[cursor.Edge] = new Tuple<int, int>(-1, cursor.JVex);
                    cursor = cursor.Link;
                }
                else
                {
                    cursor.JVex = -1;
                    edgeMap[cursor.Edge] = new Tuple<int, int>(cursor.Vex, -1);
                    cursor = cursor.JLink;
                }
            }

            vertexs.Remove(vertex);
            list.RemoveAt(vIndex);
        }

        /// <summary>
        /// 获取边相邻的边
        /// </summary>
        /// <param name="edge">参照边</param>
        /// <returns>相邻边</returns>
        public List<Te> GetAdjacentEdge(Te edge)
        {
            List<Te> result = new List<Te>();
            if (!edgeMap.ContainsKey(edge))
            {
                return result;
            }

            var indexs = edgeMap[edge];
            var cursor = indexs.Item1 < 0 ? null : list[indexs.Item1].FirstEdge;

            while (cursor != null)
            {
                if (!cursor.Edge.Equals(edge))
                {
                    result.Add(cursor.Edge);
                }

                if (cursor.Vex == indexs.Item1)
                {
                    cursor = cursor.Link;
                }
                else
                {
                    cursor = cursor.JLink;
                }
            }

            cursor = indexs.Item2 < 0 ? null : list[indexs.Item2].FirstEdge;

            while (cursor != null)
            {
                if (!cursor.Edge.Equals(edge))
                {
                    result.Add(cursor.Edge);
                }

                if (cursor.Vex == indexs.Item2)
                {
                    cursor = cursor.Link;
                }
                else
                {
                    cursor = cursor.JLink;
                }
            }

            return result;
        }

        /// <summary>
        /// 获取顶点相邻的点
        /// </summary>
        /// <param name="vertex">参照点</param>
        /// <returns>相邻点</returns>
        public List<Tv> GetAdjacentVertex(Tv vertex)
        {
            List<Tv> result = new List<Tv>();

            int index = VertexIndexOf(vertex);
            if (index == -1)
            {
                return result;
            }

            var cursor = list[index].FirstEdge;

            while (cursor != null)
            {
                if (cursor.Vex == index)
                {
                    if (cursor.JVex != -1)
                    {
                        result.Add(list[cursor.JVex].Vertex);
                    }

                    cursor = cursor.Link;
                }
                else
                {
                    if (cursor.Vex != -1)
                    {
                        result.Add(list[cursor.Vex].Vertex);
                    }

                    cursor = cursor.JLink;
                }
            }

            return result;
        }

        /// <summary>
        /// 获取顶点相邻的边
        /// </summary>
        /// <param name="vertex">参照点</param>
        /// <returns></returns>
        public List<Te> GetEdges(Tv vertex)
        {
            List<Te> result = new List<Te>();

            int index = VertexIndexOf(vertex);
            if (index == -1)
            {
                return result;
            }

            var cursor = list[index].FirstEdge;

            while (cursor != null)
            {
                if (cursor.Vex == index)
                {
                    result.Add(cursor.Edge);
                    cursor = cursor.Link;
                }
                else
                {
                    result.Add(cursor.Edge);
                    cursor = cursor.JLink;
                }
            }

            return result;
        }

        /// <summary>
        /// 通过查表获取边相邻顶点
        /// </summary>
        /// <param name="edge">边</param>
        /// <returns>顶点</returns>
        public List<Tv> GetVertexs(Te edge)
        {
            List<Tv> result = new List<Tv>();
            if (!edgeMap.ContainsKey(edge))
            {
                return result;
            }

            var indexs = edgeMap[edge];

            if (indexs.Item1 >= 0)
            {
                result.Add(list[indexs.Item1].Vertex);
            }

            if (indexs.Item2 >= 0)
            {
                result.Add(list[indexs.Item2].Vertex);
            }

            return result;
        }

        /// <summary>
        /// 获取边相邻的顶点与边
        /// </summary>
        /// <param name="edge">边</param>
        /// <returns>相邻的顶点与边</returns>
        public Dictionary<Tv, List<Te>> GetConnectors(Te edge)
        {
            Dictionary<Tv, List<Te>> result = new Dictionary<Tv, List<Te>>();
            if (!edgeMap.ContainsKey(edge))
            {
                return result;
            }

            var indexs = edgeMap[edge];
            EdgeNode<Tv, Te> cursor = null;
            List<Te> addList = null;
            if (indexs.Item1 >= 0)
            {
                cursor = list[indexs.Item1].FirstEdge;
                addList = result[list[indexs.Item1].Vertex] = new List<Te>();
            }

            while (cursor != null)
            {
                if (!cursor.Edge.Equals(edge))
                {
                    addList.Add(cursor.Edge);
                }

                if (cursor.Vex == indexs.Item1)
                {
                    cursor = cursor.Link;
                }
                else
                {
                    cursor = cursor.JLink;
                }
            }

            if (indexs.Item2 >= 0)
            {
                cursor = list[indexs.Item2].FirstEdge;
                addList = result[list[indexs.Item2].Vertex] = new List<Te>();
            }

            while (cursor != null)
            {
                if (!cursor.Edge.Equals(edge))
                {
                    addList.Add(cursor.Edge);
                }

                if (cursor.Vex == indexs.Item2)
                {
                    cursor = cursor.Link;
                }
                else
                {
                    cursor = cursor.JLink;
                }
            }

            return result;
        }

        /// <summary>
        /// 初始化边节点
        /// </summary>
        private void InitEdgeNode()
        {
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var edgeVertexs = edge.GetVertexs();

                bool hasVertex = false;
                foreach (var v in edgeVertexs)
                {
                    if (ContainsVertex(v))
                    {
                        hasVertex = true;
                        break;
                    }
                }

                if (hasVertex)
                {
                    //获取顶点的下标
                    int vIndex = -1, oIndex = -1;

                    for (int j = 0; j < edgeVertexs.Count; j++)
                    {
                        if (j == 0)
                        {
                            vIndex = VertexIndexOf(edgeVertexs[j]);
                        }
                        else if (j == 1)
                        {
                            oIndex = VertexIndexOf(edgeVertexs[j]);
                        }
                        else
                        {
                            break;
                        }
                    }

                    edgeMap[edge] = new Tuple<int, int>(vIndex, oIndex);

                    EdgeNode<Tv, Te> edgeNode = new EdgeNode<Tv, Te>(edge, vIndex, oIndex);

                    if (vIndex != -1)
                    {
                        var vertex = list[vIndex];
                        if (vertex.FirstEdge == null)
                        {
                            vertex.FirstEdge = edgeNode;
                        }
                        else
                        {
                            var nextEdge = vertex.FirstEdge;
                            edgeNode.Link = nextEdge;
                            vertex.FirstEdge = edgeNode;
                        }
                    }

                    if (oIndex != -1)
                    {
                        var vertex = list[oIndex];
                        if (vertex.FirstEdge == null)
                        {
                            vertex.FirstEdge = edgeNode;
                        }
                        else
                        {
                            var nextEdge = vertex.FirstEdge;
                            edgeNode.JLink = nextEdge;
                            vertex.FirstEdge = edgeNode;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// 边表结点
    /// </summary>
    public class EdgeNode<Tv, Te>
        where Tv : IGrapVertex<Te>
        where Te : IGrapEdge<Tv>
    {
        public EdgeNode(Te edge, int iVex, int jVex)
        {
            Edge = edge;
            Vex = iVex;
            JVex = jVex;
        }

        /// <summary>
        /// 边储存数据
        /// </summary>
        public Te Edge { get; set; }

        /// <summary>
        /// 边起点索引
        /// </summary>
        public int Vex { get; set; }

        /// <summary>
        /// 边起点所连接的下一条边结点
        /// </summary>
        public EdgeNode<Tv, Te> Link { get; set; }

        /// <summary>
        /// 边终点索引
        /// </summary>
        public int JVex { get; set; }

        /// <summary>
        /// 边终点所连接的下一条边结点
        /// </summary>
        public EdgeNode<Tv, Te> JLink { get; set; }
    }

    /// <summary>
    /// 顶点表结点
    /// </summary>
    public class VertexNode<Tv, Te>
        where Tv : IGrapVertex<Te>
        where Te : IGrapEdge<Tv>
    {
        public VertexNode(Tv vertex)
        {
            Vertex = vertex;
        }

        /// <summary>
        /// 顶点储存的数据
        /// </summary>
        public Tv Vertex { get; set; }

        /// <summary>
        /// 指向的第一个顶点
        /// </summary>
        public EdgeNode<Tv, Te> FirstEdge { get; set; }
    }
}