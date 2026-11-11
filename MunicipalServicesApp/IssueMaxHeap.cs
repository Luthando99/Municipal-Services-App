using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public class IssueMaxHeap
    {
        private readonly List<Issue> heap =
            new List<Issue>();

        public int Count => heap.Count;

        public void Insert(Issue issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            heap.Add(issue);

            int index = heap.Count - 1;

            // Move the new item upwards when necessary.
            while (index > 0)
            {
                int parent = (index - 1) / 2;

                if (heap[parent].Priority >= heap[index].Priority)
                    break;

                Swap(parent, index);
                index = parent;
            }
        }

        public Issue Peek()
        {
            if (heap.Count == 0)
                return null;

            return heap[0];
        }

        public Issue ExtractMax()
        {
            if (heap.Count == 0)
                return null;

            Issue highest = heap[0];
            int last = heap.Count - 1;

            heap[0] = heap[last];
            heap.RemoveAt(last);

            int index = 0;

            while (true)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int largest = index;

                if (left < heap.Count &&
                    heap[left].Priority > heap[largest].Priority)
                {
                    largest = left;
                }

                if (right < heap.Count &&
                    heap[right].Priority > heap[largest].Priority)
                {
                    largest = right;
                }

                if (largest == index)
                    break;

                Swap(index, largest);
                index = largest;
            }

            return highest;
        }

        private void Swap(int first, int second)
        {
            Issue temp = heap[first];
            heap[first] = heap[second];
            heap[second] = temp;
        }
    }
}
