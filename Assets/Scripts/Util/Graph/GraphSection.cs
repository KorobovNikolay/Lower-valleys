using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{
    public static class GraphSectionExtension
    {
        /// <summary>
        /// Получить отрезок вершин графа
        /// </summary>
        /// <typeparam name="T">Тип имени вершин</typeparam>
        /// <param name="graph">Граф</param>
        /// <param name="names">Имя вершин из которох сформировать отрезок</param>
        /// <returns>Граф</returns>
        public static Graph<T> Section<T>(this Graph<T> graph, List<T> names)
        {
            var vertices = new List<Vertex<T>>();

            foreach (var v in graph.Vertices)
                if (names.Contains(v.Name))
                    vertices.Add(v);

            return new Graph<T>(vertices);
        }    
    }
}
