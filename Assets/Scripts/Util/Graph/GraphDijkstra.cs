using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NikolayKorobov
{
    public static class GraphDijkstraExtension
    {
        // Информация о посещенной вершине
        private class VertexInfo<T>
        {
            public int Price { get; set; }
            public Vertex<T> Vertex { get; set; }
            public Vertex<T> PreviousVertex { get; set; }

            public VertexInfo(Vertex<T> vertex, Vertex<T> previous, int price)
            {
                Vertex = vertex;
                PreviousVertex = previous;
                Price = price;
            }
        }

        /// <summary>
        /// Поиск крочайшего пути, метод Dijkstra
        /// </summary>
        /// <typeparam name="T">Тип имени вершин</typeparam>
        /// <param name="graph">Граф</param>
        /// <param name="start">Стартовая вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <returns>Граф созданный из пути от одной точки к другой</returns>
        public static Graph<T> Dijkstra<T>(this Graph<T> graph, T start, T finish)
        {
            var startVertex = graph.FindVertex(start);
            var finishVertex = graph.FindVertex(finish);

            // Если вершины отсутсвуют в пути
            if (startVertex == null || finishVertex == null)
                return null;

            var notVisitedVertex = graph.Vertices;
            var infoVertex = new Dictionary<Vertex<T>, VertexInfo<T>>();

            infoVertex[startVertex] = new VertexInfo<T>(finishVertex, null, 0);

            while (true)
            {
                Vertex<T> toOpenVertex = null;
                int bestPrice = int.MaxValue;

                // Поолучить информацию о вершине
                foreach (var v in notVisitedVertex)
                {
                    if (infoVertex.ContainsKey(v) && infoVertex[v].Price < bestPrice)
                    {
                        toOpenVertex = v;
                        bestPrice = infoVertex[v].Price;
                    }
                }

                // Если пути нет
                if (toOpenVertex == null) return null;

                // Если путь завершен
                if (toOpenVertex == finishVertex) break;

                // Проитись по ребрам вершины и выбрать вершину с минимальным весом
                foreach (var e in toOpenVertex.GetEdges())
                {
                    var currentPrice = infoVertex[toOpenVertex].Price + e.Weight;
                    var nextVertex = e.ConnectedVertex;

                    if (!infoVertex.ContainsKey(nextVertex) || infoVertex[nextVertex].Price > currentPrice)
                        infoVertex[nextVertex] = new VertexInfo<T>(nextVertex, toOpenVertex, currentPrice);
                }

                notVisitedVertex.Remove(toOpenVertex);
            }

            // Заполнить путь от стартовой вершины до конченоц
            var result = new List<Vertex<T>>();

            while (finishVertex != null)
            {
                result.Add(finishVertex);
                finishVertex = infoVertex[finishVertex].PreviousVertex;
            }

            result.Reverse();

            return new Graph<T>(result);
        }
    }
}
