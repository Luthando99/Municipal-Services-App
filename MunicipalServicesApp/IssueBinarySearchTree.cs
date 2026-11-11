using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public class IssueBinarySearchTree
    {
        // Each node stores one municipal service request.
        private class Node
        {
            public Issue Data;
            public Node Left;
            public Node Right;

            public Node(Issue issue)
            {
                Data = issue;
            }
        }

        // The first node in the tree.
        private Node root;

        // Add a request to the tree.
        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            root = InsertNode(root, issue);
        }

        private Node InsertNode(Node current, Issue issue)
        {
            if (current == null)
            {
                return new Node(issue);
            }

            int comparison = string.Compare(
                issue.TrackingID,
                current.Data.TrackingID,
                StringComparison.OrdinalIgnoreCase
            );

            if (comparison < 0)
            {
                current.Left = InsertNode(current.Left, issue);
            }
            else if (comparison > 0)
            {
                current.Right = InsertNode(current.Right, issue);
            }
            else
            {
                // Replace an existing request with the same ID.
                current.Data = issue;
            }

            return current;
        }

        // Search for a request using its Tracking ID.
        public Issue Search(string trackingID)
        {
            if (string.IsNullOrWhiteSpace(trackingID))
                return null;

            Node current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    trackingID.Trim(),
                    current.Data.TrackingID,
                    StringComparison.OrdinalIgnoreCase
                );

                if (comparison == 0)
                {
                    return current.Data;
                }

                if (comparison < 0)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            return null;
        }
    }
}
