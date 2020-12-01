using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{
    public static class GraphExcludeExtension
    {
        /// <summary>
        /// Исключить вершины из графа
        /// </summary>
        /// <typeparam name="T">Тип имени вершины</typeparam>
        /// <param name="graph">Граф</param>
        /// <param name="vertices">Векршины которые нужно исключить</param>
        /// <returns>Граф</returns>
        public static Graph<T> Exclude<T>(this Graph<T> graph, List<T> excludeVertices)
        {
            var vertices = graph.Vertices;

            foreach (var name in excludeVertices)
                vertices.Remove(graph.GetVertex(name));

            return new Graph<T>(vertices);
        }
    }
}
