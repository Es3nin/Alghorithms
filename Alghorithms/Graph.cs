using System;


namespace Alghorithms
{
    class Graph
    {
        List<Vertex> V = new List<Vertex>();
        List<Edge> E = new List<Edge>();

        public void AddVertex(Vertex vertex)
        {
            V.Add(vertex);
        }
        
        public void AddEdge(Vertex from,Vertex to)
        {
            var edge = new Edge(from, to);
            E.Add(edge);
        }

        public int VertexCount=>V.Count;
        public int EdgeCount => E.Count;

        public int [,] GetMatrix()
        {
            var matrix = new int[V.Count,E.Count];

            foreach(var edge in E)
            {
                var row = edge.From.Number-1;
                var column = edge.To.Number-1;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        public List<Vertex> GetVertexLists(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach(var edge in E)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }

            return result; 
        }

        public List<Vertex> Wave(Vertex start,Vertex finish)
        {
            var list = new List<Vertex>
            {
                start
            };

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVertexLists(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }
            return list;
        }

        public List<Vertex> DFS(Vertex start, Vertex Finish)
        {
            var list = new List<Vertex>
            {
                start
            };

            if (GetVertexLists(start) != null)
            {
                foreach (var v in GetVertexLists(start))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                        start = v;
                    }
                }
                return;
            }
            else
            {
                for(int i = list.Count - 1; i >= 0; i--)
                {
                    if (!list.Contains(list[i]))
                    {
                        list.Add(list[i]);
                        start = list[i];
                    }
                    return;
                }
            }
            return list;
        }
    }
}
