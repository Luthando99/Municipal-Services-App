using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public class IssueAVLTree
    {
        private class Node
        {
            public Issue Data;
            public Node Left;
            public Node Right;
            public int Height = 1;

            public Node(Issue issue)
            {
                Data = issue;
            }
        }

        private Node root;

        private int Height(Node node)
        {
            return node == null ? 0 : node.Height;
        }

        private int Balance(Node node)
        {
            return node == null ? 0 :
                Height(node.Left) - Height(node.Right);
        }

        private void UpdateHeight(Node node)
        {
            node.Height = 1 + Math.Max(
                Height(node.Left),
                Height(node.Right)
            );
        }

        // Right rotation
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node subtree = x.Right;

            x.Right = y;
            y.Left = subtree;

            UpdateHeight(y);
            UpdateHeight(x);

            return x;
        }

        // Left rotation
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node subtree = y.Left;

            y.Left = x;
            x.Right = subtree;

            UpdateHeight(x);
            UpdateHeight(y);

            return y;
        }

        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            root = InsertNode(root, issue);
        }

        private Node InsertNode(Node node, Issue issue)
        {
            if (node == null)
                return new Node(issue);

            int comparison = string.Compare(
                issue.TrackingID,
                node.Data.TrackingID,
                StringComparison.OrdinalIgnoreCase
            );

            if (comparison < 0)
                node.Left = InsertNode(node.Left, issue);
            else if (comparison > 0)
                node.Right = InsertNode(node.Right, issue);
            else
            {
                node.Data = issue;
                return node;
            }

            UpdateHeight(node);

            int balance = Balance(node);

            // Left-Left case
            if (balance > 1 && Balance(node.Left) >= 0)
                return RotateRight(node);

            // Left-Right case
            if (balance > 1 && Balance(node.Left) < 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            // Right-Right case
            if (balance < -1 && Balance(node.Right) <= 0)
                return RotateLeft(node);

            // Right-Left case
            if (balance < -1 && Balance(node.Right) > 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

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
                    return current.Data;

                current = comparison < 0
                    ? current.Left
                    : current.Right;
            }

            return null;
        }
    }
}

