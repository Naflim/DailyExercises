﻿// <copyright file="Graph.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#pragma warning disable

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DailyExercises.Utils;

namespace HW.CAB.Helper.PipeNetwork
{
    /// <summary>
    /// 图节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGraphNode<T>
    {
        /// <summary>
        /// 获取此节点相连的其他节点
        /// </summary>
        /// <returns>相连的其他节点</returns>
        T[] GetNextNodes();
    }

    /// <summary>
    /// 图结构存储容器
    /// </summary>
    /// <typeparam name="T">存储的元素类型</typeparam>
    public class Graph<T>
        : IEnumerable<T>
        where T : class, IGraphNode<T>
    {
        /// <summary>
        /// 连接关系表
        /// </summary>
        private Dictionary<T, List<T>> connectivity;

        /// <summary>
        /// 线程安全的连接关系表
        /// </summary>
        /// <remarks>用作异步存储</remarks>
        private ConcurrentDictionary<T, List<T>> connectivityAsync;

        public Graph(T origin)
        {
            Origin = origin;
        }

        /// <summary>
        /// 源节点
        /// </summary>
        public T Origin { get; set; }

        /// <summary>
        /// 开始检索图
        /// </summary>
        public void StartRetrieval()
        {
            connectivity = new Dictionary<T, List<T>>();
            AddNextNode(Origin);
        }

        /// <summary>
        /// 以异步形式检索图结构
        /// </summary>
        /// <returns>异步操作</returns>
        /// <remarks>
        /// BFS,检索分支时将新分支分配给线程池安排检索
        /// </remarks>
        public Task StartRetrievalAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                connectivityAsync = new ConcurrentDictionary<T, List<T>>();
                CountdownEvent countdown = new CountdownEvent(1);
                ThreadPool.GetMaxThreads(out int works, out int coms);

                //ShellUtils.Inst.Info($"当前任务数{countdown.CurrentCount}");
                ThreadPool.QueueUserWorkItem(AddNextNodeAsync,
                                             new Tuple<T, CountdownEvent>(Origin,
                                                 countdown));
                countdown.Wait(180000);
                connectivity = new Dictionary<T, List<T>>(connectivityAsync);
            },
                                         TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// 获取此节点的相邻节点
        /// </summary>
        /// <param name="node">查询节点</param>
        /// <returns>相邻节点</returns>
        public T[] GetConnectivity(T node)
        {
            if (connectivity.ContainsKey(node))
            {
                return connectivity[node].ToArray();
            }

            return new T[0];
        }

        /// <summary>
        /// 图中是否包含此节点
        /// </summary>
        /// <param name="node">节点</param>
        /// <returns>结果</returns>
        public bool Contains(T node)
        {
            return connectivity.ContainsKey(node);
        }

        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="node">节点</param>
        public void AddNode(T node)
        {
            var relationNodes = node.GetNextNodes();
            foreach (var relationNode in relationNodes)
            {
                if (connectivity.ContainsKey(relationNode) && !connectivity[relationNode].Contains(relationNode))
                {
                    connectivity[relationNode].Add(node);
                }
            }

            connectivity[node] = new List<T>(relationNodes);
        }

        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="node">节点</param>
        public void RemoveNode(T node)
        {
            var relationNodes = node.GetNextNodes();
            foreach (var relationNode in relationNodes)
            {
                if (connectivity.ContainsKey(relationNode))
                {
                    connectivity[relationNode].Remove(node);
                }
            }

            connectivity.Remove(node);
        }

        /// <summary>
        /// 替换节点
        /// </summary>
        /// <param name="oldNode">就节点</param>
        /// <param name="newNode">新节点</param>
        public void ReplaceNode(T oldNode, T newNode)
        {
            RemoveNode(oldNode);
            AddNode(newNode);
        }

        /// <summary>
        /// DFS获取两点间全部路径
        /// </summary>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        /// <param name="filter">过滤器</param>
        /// <returns>全部路径</returns>
        /// <exception cref="ArgumentException">目标点不在图内</exception>
        public List<List<T>> GetAllPathsByDfs(T start, T end, Func<T[], T, bool> filter = null)
        {
            if (!connectivity.ContainsKey(start))
            {
                throw new ArgumentException("起点不在图中", nameof(start));
            }

            if (!connectivity.ContainsKey(end))
            {
                throw new ArgumentException("终点不在图中", nameof(end));
            }

            return GetAllPathsByDfs(new List<T> { start }, start, end, filter);
        }

        /// <summary>
        /// BFS获取两点间全部路径
        /// </summary>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        /// <param name="filter">过滤器</param>
        /// <returns>全部路径</returns>
        /// <exception cref="ArgumentException">目标点不在图内</exception>
        public List<List<T>> GetAllPathsByBfs(T start, T end, Func<T[], T, bool> filter = null)
        {
            if (!connectivity.ContainsKey(start))
            {
                throw new ArgumentException("起点不在图中", nameof(start));
            }

            if (!connectivity.ContainsKey(end))
            {
                throw new ArgumentException("终点不在图中", nameof(end));
            }

            List<List<T>> result = new List<List<T>>();
            List<HashSet<T>> paths = new List<HashSet<T>>();
            HashSet<T> head = new HashSet<T>();
            head.Add(start);
            paths.Add(head);
            while (paths.Count > 0)
            {
                var cache = paths.ToArray();
                paths.Clear();

                foreach (var item in cache)
                {
                    T node = item.Last();
                    if (node.Equals(end))
                    {
                        result.Add(item.ToList());
                        continue;
                    }

                    foreach (var next in GetConnectivity(node))
                    {
                        if (!item.Contains(next) && (filter?.Invoke(item.ToArray(), next) ?? true))
                        {
                            HashSet<T> newPath = new HashSet<T>(item);
                            newPath.Add(next);
                            paths.Add(newPath);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// BFS获取两点间最少连接数路径
        /// </summary>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        /// <param name="filter">过滤器</param>
        /// <returns>最少连接数路径</returns>
        /// <exception cref="ArgumentException">目标点不在图内</exception>
        public List<T> GetShortestPathByBfs(T start, T end, Func<T[], T, bool> filter = null)
        {
            if (!connectivity.ContainsKey(start))
            {
                throw new ArgumentException("起点不在图中", nameof(start));
            }

            if (!connectivity.ContainsKey(end))
            {
                throw new ArgumentException("终点不在图中", nameof(end));
            }

            HashSet<T> accessed = new HashSet<T>();
            List<LinkedList<T>> paths = new List<LinkedList<T>>();
            LinkedList<T> head = new LinkedList<T>();
            head.AddLast(start);
            paths.Add(head);
            while (paths.Count > 0)
            {
                var cache = paths.ToArray();
                paths.Clear();

                foreach (var item in cache)
                {
                    T node = item.Last.Value;
                    accessed.Add(node);
                    if (node.Equals(end))
                    {
                        return item.ToList();
                    }

                    foreach (var next in GetConnectivity(node))
                    {
                        if (!accessed.Contains(next) && (filter?.Invoke(item.ToArray(), next) ?? true))
                        {
                            LinkedList<T> newPath = new LinkedList<T>(item);
                            newPath.AddLast(next);
                            paths.Add(newPath);
                        }
                    }
                }
            }

            return new List<T>();
        }

        /// <summary>
        /// 迪杰斯特拉算法
        /// </summary>
        /// <param name="start">起点</param>
        /// <param name="end">终点</param>
        /// <param name="weight">权值</param>
        /// <param name="filter">过滤器</param>
        /// <returns>权值总和最低路径</returns>
        /// <remarks>
        /// Dijkstra算法的实现
        /// 权值不可出现负数
        /// </remarks>
        public List<T> Dijkstra(T start, T end, Func<T, T, double> weight, Func<T, bool> filter = null)
        {
            Dictionary<T, Tuple<double, T, bool>> dic = new Dictionary<T, Tuple<double, T, bool>>();
            foreach (var item in connectivity)
            {
                dic[item.Key] = new Tuple<double, T, bool>(double.MaxValue, null, false);
            }

            dic[start] = new Tuple<double, T, bool>(0, null, true);
            T pointer = start;
            var accessed = new HashSet<T>();

            int count = 0;
            while (!pointer.Equals(end))
            {
                pointer = Dijkstra(dic, accessed, pointer, end, weight, filter);

                if (dic[pointer].Item1 == double.MaxValue && dic[pointer].Item2 == null)
                    return new List<T>();
            }

            List<T> result = new List<T>();
            while (!pointer.Equals(start))
            {
                result.Add(pointer);
                pointer = dic[pointer].Item2;
            }

            result.Add(start);
            result.Reverse();
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return connectivity.Keys.GetEnumerator();
        }

        private void AddNextNode(T node)
        {
            if (connectivity.ContainsKey(node))
            {
                return;
            }

            var nextNodes = node.GetNextNodes();
            connectivity[node] = new List<T>(nextNodes);
            foreach (var item in nextNodes)
            {
                AddNextNode(item);
            }
        }

        private void AddNextNodeAsync(object state)
        {
            try
            {
                if (!(state is Tuple<T, CountdownEvent> date))
                {
                    return;
                }

                var node = date.Item1;
                var countdown = date.Item2;
                connectivityAsync[node] = new List<T>(node.GetNextNodes());
                var nextNodes = connectivityAsync[node].Where(n => !connectivityAsync.ContainsKey(n)).ToArray();

                if (nextNodes.Length == 0)
                {
                    countdown.Signal();

                    //ShellUtils.Inst.Info($"当前任务数{countdown.CurrentCount}");
                    return;
                }

                for (int i = 1; i < nextNodes.Length; i++)
                {
                    countdown.TryAddCount();

                    //ShellUtils.Inst.Info($"当前任务数{countdown.CurrentCount}");
                    ThreadPool.QueueUserWorkItem(AddNextNodeAsync,
                                                 new Tuple<T, CountdownEvent>(nextNodes[i], countdown));
                }

                AddNextNodeAsync(new Tuple<T, CountdownEvent>(nextNodes[0], countdown));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private List<List<T>> GetAllPathsByDfs(List<T> prefix, T start, T end, Func<T[], T, bool> filter = null)
        {
            List<List<T>> result = new List<List<T>>();

            foreach (var next in GetConnectivity(start))
            {
                if (!prefix.Contains(next))
                {
                    if (next.Equals(end))
                    {
                        List<T> path = new List<T>(prefix);
                        path.Add(next);
                        result.Add(path);
                    }
                    else if (filter?.Invoke(prefix.ToArray(), next) ?? true)
                    {
                        List<T> path = new List<T>(prefix);
                        path.Add(next);
                        result.AddRange(GetAllPathsByDfs(path, next, end, filter));
                    }
                }
            }

            return result;
        }

        private void Dijkstra(Dictionary<T, Tuple<double, T, bool>> dic,
                      HashSet<T> accessed,
                      T target,
                      Func<T, T, double> weight,
                      Func<T, bool> filter = null)
        {
            var markItem = dic.Where(i => !i.Value.Item3).MinItem(v => v.Value.Item1);
            dic[markItem.Key] = new Tuple<double, T, bool>(markItem.Value.Item1, markItem.Value.Item2, true);
            if (markItem.Key.Equals(target))
            {
                return;
            }

            var nextNodes = GetConnectivity(markItem.Key)
                .Where(next => !accessed.Contains(next) && (filter?.Invoke(next) ?? true));

            foreach (var next in nextNodes)
            {
                var nextItem = dic[next];
                var thisWeight = markItem.Value.Item1 + weight(markItem.Value.Item2, next);
                if (thisWeight < nextItem.Item1)
                {
                    dic[next] = new Tuple<double, T, bool>(thisWeight, markItem.Key, false);
                }
            }

            accessed.Add(markItem.Key);
            Dijkstra(dic, accessed, target, weight, filter);
        }

        private T Dijkstra(Dictionary<T, Tuple<double, T, bool>> dic,
                              HashSet<T> accessed,
                              T pointer,
                              T target,
                              Func<T, T, double> weight,
                              Func<T, bool> filter = null)
        {
            var nextNodes = GetConnectivity(pointer)
                .Where(next => !accessed.Contains(next) && (filter?.Invoke(next) ?? true));

            foreach (var next in nextNodes)
            {
                var nextItem = dic[next];
                var thisWeight = dic[pointer].Item1 + weight(pointer, next);
                if (thisWeight < nextItem.Item1)
                {
                    dic[next] = new Tuple<double, T, bool>(thisWeight, pointer, false);
                }
            }

            accessed.Add(pointer);

            var markItem = dic.Where(i => !i.Value.Item3).MinItem(v => v.Value.Item1);
            dic[markItem.Key] = new Tuple<double, T, bool>(markItem.Value.Item1, markItem.Value.Item2, true);

            return markItem.Key;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}