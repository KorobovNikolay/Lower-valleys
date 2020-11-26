using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{
    /// <summary>
    /// Ребро
    /// </summary>
    /// <typeparam name="T">Тип имени вершин</typeparam>
    public class Edge<T>
    {
        /// <summary>
        /// Связанная вершина
        /// </summary>
        public Vertex<T> ConnectedVertex;

        /// <summary>
        /// Вес ребра
        /// </summary>
        public int Weight;

        /// <summary>
        /// Создать ребро
        /// </summary>
        /// <param name="connectedVertex">Связанная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public Edge(Vertex<T> connectedVertex, int weight)
        {
            ConnectedVertex = connectedVertex;
            Weight = weight;
        }
    }
}
