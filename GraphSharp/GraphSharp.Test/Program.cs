using System;
using GraphSharpLib;

namespace GraphSharp.Test
{

    public class Entity{
        public string Title { get; private set; }
        public decimal Amount { get; private set; }

        public static Entity Create(string title, decimal amount)
        {
            return new Entity{
                Title = title,
                Amount = amount
            };            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var graph = new Graph<Entity>();
            
            var first = Entity.Create("first", 2.34m);
            var second = Entity.Create("second", 3.4m);
            var third = Entity.Create("third", 77.28m);
            var forth = Entity.Create("forth", 66.11m);

            graph.AddEdge(first, second);
            graph.AddEdge(first, third);
            graph.AddEdge(second, forth);
            graph.AddEdge(forth, first);

            graph.DfsTraverse(second, vertex => Console.WriteLine($"{vertex.Title} - {vertex.Amount}"));
            
            // var graph = new AcyclicDirectedGraph<int>();
            // graph.AddEdge(1, 2);
            // graph.AddEdge(2, 3);
            // graph.AddEdge(2, 5);
            // graph.AddEdge(3, 4);
            // graph.AddEdge(5, 8);
            // graph.AddEdge(4, 6);
            // graph.AddEdge(4, 7);
            // graph.AddEdge(4, 5);
            // graph.AddEdge(5, 6);
            // graph.DfsTraverse(2, vertex => Console.WriteLine(vertex));
            Console.ReadLine();
        }
    }
}
