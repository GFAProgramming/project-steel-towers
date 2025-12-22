using System.Collections.Generic;
using Godot;
using JetBrains.Annotations;
using SteelTowers.Toggles;

namespace SteelTowers.Utilities;

public static class NodeUtilities
{
	[CanBeNull]
	public static Node FindNodeByTypeOrNull<T>(Node root)
	{
		Queue<Node> unprocessedNodes = [];
		unprocessedNodes.Enqueue(root);
		
		while (unprocessedNodes.Count > 0)
		{
			Node currentNode = unprocessedNodes.Dequeue();
			if (DebugToggles.LogFindNodeByType)
			{
				GD.Print($"Processing node {currentNode.GetPath()}");
			}

			if (currentNode is T)
			{
				return currentNode;
			}
			
			foreach (Node childNode in currentNode.GetChildren())
			{
				unprocessedNodes.Enqueue(childNode);
			}
		}

		return null;
	}

	public static Node FindNodeByType<T>(Node root)
	{
		Node? node = FindNodeByTypeOrNull<T>(root);

		if (node is null)
		{
			GD.PrintErr($"No node of type {typeof(T).Name} was found relative to node {root.GetPath()}");
		}

		return node;
	}
}
