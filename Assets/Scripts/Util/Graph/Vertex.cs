using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{

    /// <summary>
    /// Вершина
    /// </summary>
    /// <typeparam name="T">Тип вершины</typeparam>
    public class Vertex<T>
    {
        /// <summary>
        /// Имя вершины
        /// </summary>
        public T Name { get; private set; }

        private List<Edge<T>> _edges = new List<Edge<T>>();

        /// <summary>
        /// Создать вершину
        /// </summary>
        /// <param name="name">Имя вершины</param>
        public Vertex(T name)
        {
            Name = name;
        }

        /// <summary>
        /// Добавить ребро вершине
        /// </summary>
        /// <param name="connectedVertex">Связанная вершина</param>
        /// <param name="weight">Вес ребра</param>
        public void AddEdge(Vertex<T> connectedVertex, int weight)
        {
            if (weight < 0)
                throw new ArgumentException("Вес ребра не может быть отрицательным");

            if (FindEdge(connectedVertex) == null)
                _edges.Add(new Edge<T>(connectedVertex, weight));
        }

        /// <summary>
        /// Поиск ребра
        /// </summary>
        /// <param name="connectedVertex">Связанная вершина</param>
        /// <returns>Если ребро пресутсвует то вернуть его</returns>
        public Edge<T> FindEdge(Vertex<T> connectedVertex)
        {
            return _edges.Find(e => e.ConnectedVertex.Equals(connectedVertex));
        }

        /// <summary>
        /// Получить все ребра
        /// </summary>
        /// <returns>Ребра</returns>
        public List<Edge<T>> GetEdges()
        {
            return _edges;
        }

        public override string ToString()
        {
            return $"Name: {Name} Edges count: {_edges.Count}";
        }
    }
}
