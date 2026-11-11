using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MunicipalServicesApp
{
    public class MunicipalGraph
    {
        // Adjacency list:
        // Each location stores its connected locations.
        private Dictionary<string, List<string>> adjacencyList =
            new Dictionary<string, List<string>>(
                StringComparer.OrdinalIgnoreCase);

        // Add a location to the graph.
        public void AddLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return;

            location = location.Trim();

            if (!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new List<string>();
            }
        }

        // Connect two locations.
        public void AddConnection(
            string location1,
            string location2)
        {
            if (string.IsNullOrWhiteSpace(location1) ||
                string.IsNullOrWhiteSpace(location2))
                return;

            location1 = location1.Trim();
            location2 = location2.Trim();

            AddLocation(location1);
            AddLocation(location2);

            // Avoid connecting a location to itself.
            if (string.Equals(
                location1,
                location2,
                StringComparison.OrdinalIgnoreCase))
                return;

            // Add both directions (undirected graph).
            if (!adjacencyList[location1].Exists(
                x => string.Equals(
                    x,
                    location2,
                    StringComparison.OrdinalIgnoreCase)))
            {
                adjacencyList[location1].Add(location2);
            }

            if (!adjacencyList[location2].Exists(
                x => string.Equals(
                    x,
                    location1,
                    StringComparison.OrdinalIgnoreCase)))
            {
                adjacencyList[location2].Add(location1);
            }
        }

        // Return all locations in the graph.
        public List<string> GetLocations()
        {
            return new List<string>(adjacencyList.Keys);
        }

        // Return locations connected to a given location.
        public List<string> GetConnections(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return new List<string>();

            location = location.Trim();

            if (adjacencyList.ContainsKey(location))
            {
                return new List<string>(
                    adjacencyList[location]);
            }

            return new List<string>();
        }


        public List<string> BreadthFirstSearch(string startLocation)
        {
            List<string> visitedOrder = new List<string>();

            if (string.IsNullOrWhiteSpace(startLocation) ||
                !adjacencyList.ContainsKey(startLocation.Trim()))
            {
                return visitedOrder;
            }

            Queue<string> queue = new Queue<string>();

            HashSet<string> visited =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            string start = startLocation.Trim();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();

                visitedOrder.Add(current);

                foreach (string neighbour in adjacencyList[current])
                {
                    if (visited.Add(neighbour))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return visitedOrder;
        }


        public List<string> DepthFirstSearch(string startLocation)
        {
            List<string> visitedOrder = new List<string>();

            if (string.IsNullOrWhiteSpace(startLocation) ||
                !adjacencyList.ContainsKey(startLocation.Trim()))
            {
                return visitedOrder;
            }

            Stack<string> stack = new Stack<string>();

            HashSet<string> visited =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            stack.Push(startLocation.Trim());

            while (stack.Count > 0)
            {
                string current = stack.Pop();

                if (!visited.Add(current))
                    continue;

                visitedOrder.Add(current);

                // Reverse order maintains the original neighbour order.
                List<string> neighbours =
                    new List<string>(adjacencyList[current]);

                neighbours.Reverse();

                foreach (string neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                    }
                }
            }

            return visitedOrder;
        }

    }
}
