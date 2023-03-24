using System;
using System.Reflection.Metadata.Ecma335;

class Graph
{
	private Dictionary<Node, List<Node>> graph;
	private int noOfNodes;

	public Graph()
	{
		this.graph = new Dictionary<Node, List<Node>>();
		this.noOfNodes = 0;
	}

	public List<Node> getNeighbors(Node n)
	{
		return this.graph[n];
	}
	public Node getStartNode()
	{
		foreach(Node node in this.graph.Keys)
		{
			if(node.getNodeType() == 'K')
			{
				return node;
			}
		}
		return this.graph.Keys.First();
	}
	public void addNode(Node n, List<Node> neighbors)
	{
		this.graph.Add(n, neighbors);
		this.noOfNodes++;
	}
	public void addNeighbor(Node n, Node neighbor)
	{
		this.graph[n].Add(neighbor);
	}
	public int getTreasureCount()
	{
		int treasureCount = 0;
		foreach(Node node in this.graph.Keys)
		{
			if(node.getNodeType() == 'T')
			{
				treasureCount++;
			}
		}
		return treasureCount;
	}
	
}
