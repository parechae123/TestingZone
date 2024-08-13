using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid;
using UnityEngine;

namespace Tarodev_Pathfinding._Scripts {
    /// <summary>
    /// This algorithm is written for readability. Although it would be perfectly fine in 80% of games, please
    /// don't use this in an RTS without first applying some optimization mentioned in the video: https://youtu.be/i0x5fj4PqP4
    /// If you enjoyed the explanation, be sure to subscribe!
    ///
    /// Also, setting colors and text on each hex affects performance, so removing that will also improve it marginally.
    /// </summary>
    public static class Pathfinding {
        public static readonly Color PathColor = new Color(0.65f, 0.35f, 0.35f);
        public static readonly Color OpenColor = new Color(.4f, .6f, .4f);
        public static readonly Color ClosedColor = new Color(0.35f, 0.4f, 0.5f);
        
        public static List<NodeBase> FindPath(NodeBase startNode, NodeBase targetNode) {
            List<NodeBase> toSearch = new List<NodeBase>() { startNode };
            List<NodeBase> processed = new List<NodeBase>();
            GridManager.Instance._outPutNodes.Clear();

            while (toSearch.Any()) {
                NodeBase current = toSearch[0];
                foreach (NodeBase t in toSearch) 
                    if (t.F < current.F || t.F == current.F && t.H < current.H) current = t;

                processed.Add(current);
                toSearch.Remove(current);
                
                current.SetColor(ClosedColor);

                if (current == targetNode) {
                    NodeBase currentPathTile = targetNode;
                    List<NodeBase> path = new List<NodeBase>();
                    int count = 100;
                    while (currentPathTile != startNode) {
                        path.Add(currentPathTile);
                        currentPathTile = currentPathTile.Connection;
                        count--;
                        if (count < 0) throw new Exception();
                        Debug.Log("sdfsdf");
                    }

                    foreach (NodeBase tile in path) 
                    {
                        tile.SetColor(PathColor);
                        GridManager.Instance._outPutNodes.Add(tile);
                    }
                    
                    startNode.SetColor(PathColor);
                    Debug.Log(path.Count);
                    GridManager.Instance._outPutNodes.Add(startNode);
                    GridManager.Instance._outPutNodes.Reverse();
                    //GridManager.Instance._outPutNodes.RemoveAt(GridManager.Instance._outPutNodes.Count-1);
                    GridManager.Instance.ResetMoveTimers();
                    return path;
                }

                foreach (NodeBase neighbor in current.Neighbors.Where(t => t.Walkable && !processed.Contains(t))) {
                    bool inSearch = toSearch.Contains(neighbor);

                    float costToNeighbor = current.G + current.GetDistance(neighbor);

                    if (!inSearch || costToNeighbor < neighbor.G) {
                        neighbor.SetG(costToNeighbor);
                        neighbor.SetConnection(current);

                        if (!inSearch) {
                            neighbor.SetH(neighbor.GetDistance(targetNode));
                            toSearch.Add(neighbor);
                            neighbor.SetColor(OpenColor);
                        }
                    }
                }
            }
            return null;
        }
    }
}