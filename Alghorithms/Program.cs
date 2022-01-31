using System;

namespace Alghorithms {
 
    class Program
    {
        private static void GetMatrix(Graph graph)
        {
            var matrix = graph.GetMatrix();
            Console.Write("№");
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(" | " + (i + 1) + " | ");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(" | " + matrix[i, j] + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------");
        }

        private static void GetVertex(Graph graph,Vertex vertex)
        {
            Console.Write(vertex.Number + ": ");
            foreach (var v in graph.GetVertexLists(vertex))
            {
                Console.Write(v.Number + ", ");
            }
            Console.WriteLine();
        }

        private static void GetWave(Graph graph, Vertex vertex,Vertex vertex1)
        {
            Console.Write("From vertex "+vertex.Number + " to vertex "+vertex1.Number+": ");
            foreach (var v in graph.Wave(vertex, vertex1))
            {
                Console.Write(v.Number + ", ");
            }
            Console.WriteLine();
        }

        private static void GetDFS(Graph graph, Vertex vertex, Vertex vertex1)
        {
            foreach (var v in graph.DFS(vertex, vertex1))
            {
                Console.Write(v.Number + ", ");
            }
            Console.WriteLine();
        }

        static void Main()
        {
            var graph = new Graph();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);
            graph.AddEdge(v6, v5);
            graph.AddEdge(v5, v6);

            GetMatrix(graph);

            GetVertex(graph, v1);
            GetVertex(graph, v2);
            GetVertex(graph, v3);
            GetVertex(graph, v4);
            GetVertex(graph, v5);
            GetVertex(graph, v6);
            GetVertex(graph, v7);


            GetWave(graph, v1, v5);
            GetWave(graph, v2, v4);

            GetDFS(graph, v1, v5);
            GetDFS(graph, v2, v4);

            Console.ReadLine();
        }
    }
}