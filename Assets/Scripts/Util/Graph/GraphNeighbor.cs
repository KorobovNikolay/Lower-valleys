using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{
    public static class GraphNeighborExtension
    {
        /// <summary>
        /// Создать граф из сосдних вершин
        /// </summary>
        /// <typeparam name="T">Тип имени вершин</typeparam>
        /// <param name="graph">Текуший граф</param>
        /// <param name="point">Точка старта</param>
        /// <param name="depth">Глубина</param>
        /// <returns></returns>
        public static Graph<T> Neighbor<T>(this Graph<T> graph, T point, int depth)
        {
            var result = new List<Vertex<T>>();
            var points = new List<Vertex<T>>();
            var startVertex = graph.FindVertex(point);

            if (startVertex is null)
                throw new ArgumentNullException("Стартовая вершина отсутствует в графе");

            points.Add(startVertex);

            for (int i = 0; i < depth; i++)
            {

                var edges = new List<Vertex<T>>();

                foreach (var p in points)
                {
                    foreach (var v in p.GetEdges())
                    {
                        if (!result.Contains(v.ConnectedVertex))
                        {
                            if (!v.ConnectedVertex.Equals(startVertex))
                            {
                                result.Add(v.ConnectedVertex);
                                edges.Add(v.ConnectedVertex);
                            }
                        }
                    }
                }

                points = edges;
            }

            return new Graph<T>(result);
        }
    }
}
