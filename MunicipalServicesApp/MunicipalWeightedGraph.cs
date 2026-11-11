using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServicesApp
{
    public class MunicipalWeightedGraph
    {
        // Each location has a list of connected locations
        // and their connection costs.
        private readonly Dictionary<string, List<Edge>> adjacencyList =
            new Dictionary<string, List<Edge>>(
                StringComparer.OrdinalIgnoreCase);

        public class Edge
        {
            public string Destination { get; set; }
            public int Weight { get; set; }
        }

        // Add a location to the graph
        public void AddLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return;

            location = location.Trim();

            if (!adjacencyList.ContainsKey(location))
            {
                adjacencyList[location] = new List<Edge>();
            }
        }

        // Add a two-way weighted connection
        public void AddConnection(
            string location1,
            string location2,
            int weight)
        {
            if (string.IsNullOrWhiteSpace(location1) ||
                string.IsNullOrWhiteSpace(location2))
            {
                throw new ArgumentException(
                    "Both locations must be provided.");
            }

            location1 = location1.Trim();
            location2 = location2.Trim();

            if (weight <= 0)
            {
                throw new ArgumentException(
                    "Connection weight must be greater than zero.");
            }

            if (string.Equals(
                location1,
                location2,
                StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "A location cannot connect to itself.");
            }

            AddLocation(location1);
            AddLocation(location2);

            // Avoid duplicate connections
            AddOrUpdateEdge(location1, location2, weight);
            AddOrUpdateEdge(location2, location1, weight);
        }

        private void AddOrUpdateEdge(
            string from,
            string to,
            int weight)
        {
            Edge existing = adjacencyList[from]
                .FirstOrDefault(e =>
                    string.Equals(
                        e.Destination,
                        to,
                        StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {
                existing.Weight = weight;
            }
            else
            {
                adjacencyList[from].Add(new Edge
                {
                    Destination = to,
                    Weight = weight
                });
            }
        }

        // Prim's Minimum Spanning Tree Algorithm
        public List<string> PrimMST(
            string startLocation,
            out int totalWeight)
        {
            totalWeight = 0;

            List<string> mstConnections =
                new List<string>();

            if (string.IsNullOrWhiteSpace(startLocation))
                return mstConnections;

            startLocation = startLocation.Trim();

            if (!adjacencyList.ContainsKey(startLocation))
                return mstConnections;

            HashSet<string> visited =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            visited.Add(startLocation);

            while (visited.Count < adjacencyList.Count)
            {
                string bestFrom = null;
                string bestTo = null;
                int minimumWeight = int.MaxValue;

                // Find the cheapest edge connecting
                // a visited location to an unvisited one.
                foreach (string location in visited)
                {
                    foreach (Edge edge in adjacencyList[location])
                    {
                        if (!visited.Contains(edge.Destination) &&
                            edge.Weight < minimumWeight)
                        {
                            minimumWeight = edge.Weight;
                            bestFrom = location;
                            bestTo = edge.Destination;
                        }
                    }
                }

                // No remaining reachable locations
                if (bestTo == null)
                    break;

                visited.Add(bestTo);

                mstConnections.Add(
                    bestFrom + " -> " +
                    bestTo + " (Cost: " +
                    minimumWeight + ")");

                totalWeight += minimumWeight;
            }

            return mstConnections;
        }

        public int LocationCount
        {
            get { return adjacencyList.Count; }
        }
    }
}
