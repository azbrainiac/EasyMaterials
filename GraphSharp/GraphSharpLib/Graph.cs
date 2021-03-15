using System;
using System.Collections.Generic;

namespace GraphSharpLib
{
    public class Graph<T>
    {
        private Dictionary<T, int> Vertices { get; }

        private List<List<T>> VerticesEdges { get; }
        private bool[] _visited;
        private Action<T> _visit;
        
        public Graph()
        {
            Vertices = new Dictionary<T, int>();
            VerticesEdges = new List<List<T>>();
        }

        public void AddEdge (T from, T to){
            if(!Vertices.TryGetValue(from, out var index)){                
                var edges = new List<T>{ to };
                Vertices.Add(from, Vertices.Count);
                VerticesEdges.Add(edges);
            }
            else{
                var edges = VerticesEdges[index];
                edges.Add(to);
            }
            
            if(!Vertices.TryGetValue(to, out index)){                
                var edges = new List<T>();
                Vertices.Add(to, Vertices.Count);
                VerticesEdges.Add(edges);
            }            
        }

        public IEnumerable<T> GetSorted(){
            int[] inDegree = new int[Vertices.Count];
            foreach(var v in Vertices){
                                
            }
            return null;
        }

        public void DfsTraverse(T source, Action<T> visit){
            _visited = new bool[Vertices.Count];
            _visit = visit;
            Traverse(source);
        }

        private void Traverse(T source){
            _visit(source);
            int index = Vertices[source]; 

            _visited[index] = true;

            foreach(var linked in VerticesEdges[index]){
                int vertexIndex = Vertices[linked];
                if(!_visited[vertexIndex]){
                    Traverse(linked);
                }
            }
        } 
    }
}
