using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class MunicipalNetworkForm : Form
    {
        private MunicipalGraph graph;
        private MunicipalWeightedGraph weightedGraph;

        public MunicipalNetworkForm()
        {
            InitializeComponent();
            BuildNetworks();
            LoadLocations();

            rtbResults.ReadOnly = true;
            cmbStartLocation.DropDownStyle =
                ComboBoxStyle.DropDownList;
        }

        private void BuildNetworks()
        {
            graph = new MunicipalGraph();
            weightedGraph = new MunicipalWeightedGraph();

            // Demo connections for BFS and DFS
            graph.AddConnection("Durban", "Pinetown");
            graph.AddConnection("Durban", "Umhlanga");
            graph.AddConnection("Pinetown", "PMB");
            graph.AddConnection("Pinetown", "Umhlanga");
            graph.AddConnection("Umhlanga", "Ballito");
            graph.AddConnection("PMB", "Ballito");

            // Weighted connections for Prim's Algorithm
            weightedGraph.AddConnection("Durban", "Pinetown", 4);
            weightedGraph.AddConnection("Durban", "Umhlanga", 6);
            weightedGraph.AddConnection("Pinetown", "PMB", 8);
            weightedGraph.AddConnection("Pinetown", "Umhlanga", 3);
            weightedGraph.AddConnection("Umhlanga", "Ballito", 5);
            weightedGraph.AddConnection("PMB", "Ballito", 10);
        }

        private void LoadLocations()
        {
            cmbStartLocation.Items.Clear();

            cmbStartLocation.Items.AddRange(new object[]
            {
                "Durban",
                "Pinetown",
                "Umhlanga",
                "PMB",
                "Ballito"
            });

            cmbStartLocation.SelectedIndex = 0;
        }

        private void btnBFS_Click(object sender, EventArgs e)
        {
            string start =
                cmbStartLocation.SelectedItem.ToString();

            List<string> result =
                graph.BreadthFirstSearch(start);

            rtbResults.Text =
                "BREADTH-FIRST SEARCH (BFS)\n\n" +
                "Starting Location: " + start + "\n\n" +
                "Traversal Order:\n" +
                string.Join(" -> ", result);
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            string start =
                cmbStartLocation.SelectedItem.ToString();

            List<string> result =
                graph.DepthFirstSearch(start);

            rtbResults.Text =
                "DEPTH-FIRST SEARCH (DFS)\n\n" +
                "Starting Location: " + start + "\n\n" +
                "Traversal Order:\n" +
                string.Join(" -> ", result);
        }

        private void btnMST_Click(object sender, EventArgs e)
        {
            string start =
                cmbStartLocation.SelectedItem.ToString();

            int totalCost;

            List<string> result =
                weightedGraph.PrimMST(start, out totalCost);

            rtbResults.Text =
                "MINIMUM SPANNING TREE\n" +
                "Prim's Algorithm\n\n" +
                "Starting Location: " + start + "\n\n" +
                string.Join("\n", result) +
                "\n\nTotal Connection Cost: " + totalCost;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        
    }
}


