using System;
using System.Collections.Generic;
using System.Linq;

namespace GravityTree
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());

            //// List of parents for given node.
            //var parents = new int[n+1];

            //Console.ReadLine().Split().Select((x, i) => parents[i + 2] = int.Parse(x)).ToArray();

            //var q = int.Parse(Console.ReadLine());

            //var queries = new List<KeyValuePair<int, int>>();

            //for (int i = 0; i < q; i++)
            //{
            //    var line = Console.ReadLine().Split();
            //    queries.Add(new KeyValuePair<int, int>(int.Parse(line[0]), int.Parse(line[1])));
            //}

            var n = 7;

            var parents = new int[] { 0, 0, 1, 1, 2, 2, 4, 5 };

            var q = 1;

            var queries = new List<KeyValuePair<int, int>>
            {
                new KeyValuePair<int, int>(7, 1),
                new KeyValuePair<int, int>(3, 2),
                new KeyValuePair<int, int>(6, 3),
                new KeyValuePair<int, int>(3, 1),
                new KeyValuePair<int, int>(6, 1)
            };

            // List of children for given node.
            var children = new List<int>[n + 1];

            for (int i = 2; i < n + 1; i++)
            {
                var parent = parents[i];

                children[parent] = children[parent] ?? new List<int>();

                children[parent].Add(i);
            }

            //Calculate shortest paths to all nodes, with priority for the v subtree.
            var distances = new int[n + 1, n + 1];

            foreach (var query in queries)
            {
                var u = query.Key;
                var v = query.Value;

                CalculateDistance(v, u, parents, children, distances);
                //long gravity = CalculateDistanceAndGravity(v, u, parents, children, distances);
                long gravity = CalculateGravity(v, u, children, distances);

                Console.WriteLine(gravity);
            }
        }

        private static long CalculateDistanceAndGravity(int v, int u, int[] parents, List<int>[] children, int[,] distances)
        {
            var visited = new HashSet<int>();

            var q = new Queue<int>();
            q.Enqueue(u);

            long gravity = 0;
            bool foundActivator = false;
            bool isInsideActivated = false;

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                visited.Add(current);

                var parentOfCurrent = parents[current];
                if (!visited.Contains(parentOfCurrent))
                {
                    distances[u, parentOfCurrent] = distances[u, current] + 1;
                    distances[parentOfCurrent, u] = distances[u, current] + 1;

                    if (parentOfCurrent == v)
                    {
                        isInsideActivated = true;
                        foundActivator = true;

                        foreach (var visitedNode in visited)
                        {
                            gravity += distances[u, visitedNode] * distances[u, visitedNode];
                        }

                        gravity += distances[u, parentOfCurrent] * distances[u, parentOfCurrent];
                    }

                    if (!isInsideActivated || current != v)
                    {
                        q.Enqueue(parentOfCurrent);
                    }
                }

                if (children[current] != null)
                {
                    children[current].ForEach(x =>
                    {
                        if (!visited.Contains(x))
                        {
                            if (x == v)
                            {
                                q.Dequeue();
                                foundActivator = true;
                            }

                            q.Enqueue(x);
                            distances[u, x] = distances[u, current] + 1;
                            distances[x, u] = distances[u, current] + 1;

                            if (foundActivator)
                            {
                                gravity += distances[u, x] * distances[u, x];
                            }
                        }
                    });
                }
            }

            return gravity;
        }

        private static void CalculateDistance(int v, int u, int[] parents, List<int>[] children, int[,] distances)
        {
            if (v == u)
            {
                return;
            }
            else if(distances[v, u] != 0)
            {
                return;
            }

            var visited = new HashSet<int>();

            var q = new Queue<int>();
            q.Enqueue(u);

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                if (current != v)
                {
                    if (current != 1)
                    {
                        var parentOfCurrent = parents[current];
                        if (!visited.Contains(parentOfCurrent))
                        {
                            q.Enqueue(parentOfCurrent);
                            distances[u, parentOfCurrent] = distances[u, current] + 1;
                            distances[parentOfCurrent, u] = distances[u, current] + 1;
                        }
                    }
                }
                else
                {
                    break;
                }

                if (children[current] != null)
                {
                    children[current].ForEach(x =>
                    {
                        if (!visited.Contains(x))
                        {
                            q.Enqueue(x);
                            distances[u, x] = distances[u, current] + 1;
                            distances[x, u] = distances[u, current] + 1;
                        }
                    });
                }

                visited.Add(current);
            }
        }

        private static long CalculateGravity(int v, int u, List<int>[] children, int[,] distances)
        {
            var q = new Queue<int>();

            q.Enqueue(v);

            long gravity = distances[v, u] * distances[v, u];

            while (q.Count > 0)
            {
                var current = q.Dequeue();

                //var distance = distances[current, u];

                //gravity +=  distance * distance;

                if (children[current] != null)
                {
                    children[current].ForEach(c =>
                    {
                        q.Enqueue(c);
                        var distance = 0;
                        if (u != c && distances[u, c] == 0)
                        {
                            distance = distances[u, current] + 1;
                            distances[u, c] = distance;
                            distances[c, u] = distance;
                        }
                        else if (distances[u, c] != 0)
                        {
                            distance = distances[u, c];
                        }

                        gravity += distance * distance;
                    });
                }
            }

            return gravity;
        }
    }
}
