using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding
{
    class WeigthedBFSearch
    {
        class theNode
        {
            public int name; //the index of the node within the nodes[]
            public int distanceFromS = -1;//The default value functions equivalently to infinity
            public int path;//allows us to construct the path backwards when the algorithm is finished
            public List<vertex> adjacentNodes = new List<vertex>();//a list of all nodes adjacent to node with each corrisponding weight
        }

        class vertex
        {
            public theNode node;//the adjacent node
            public int weight;//the weight of the vertex 

            public vertex(theNode x, int y)
            {
                node = x;
                weight = y;
            }
        }

        static void BreadthFirst(theNode[] nodes, theNode s, theNode d)
        {
            Queue<theNode> q = new Queue<theNode>();

            s.distanceFromS = 0;

            q.Enqueue(s);

            while (q.Count > 0)//ensures that we stop the dequeue once we are considering nodes further away than the current distance we are considering
            {
                theNode i = q.Dequeue();
       
                foreach (vertex j in i.adjacentNodes)
                {
                     
                    if (j.node.distanceFromS == -1 || j.node.distanceFromS>i.distanceFromS+j.weight)//if the node has not yet been processed OR if the distance is greater than what the current processing would result in
                    {
                        j.node.distanceFromS = i.distanceFromS + j.weight;
                        j.node.path = i.name;
                        q.Enqueue(j.node);
                    }

                }
            }
        
            Console.WriteLine("The distance to d is" + " " + d.distanceFromS);
            Console.WriteLine("The path starts at node" + " " + s.name);

            Stack<theNode> tempStack = new Stack<theNode>();//Here we simulate recursion with a stack
            theNode check = d;
            int pathLength = d.distanceFromS;
            while (check!=s)//we add to the stack until we reach our starting point 
            {
                tempStack.Push(check);
                check = nodes[check.path];
            }

            while (tempStack.Count > 0)
            {
                Console.WriteLine("Followed by node" + " " + tempStack.Pop().name);
            }

           
        }

        static void Main()
        {
            theNode[] nodes = new theNode[5];
            for (int i = 0; i < 5; i++)
            {
                nodes[i] = new theNode();
                nodes[i].name = i;
            }

            nodes[0].adjacentNodes.Add(new vertex(nodes[0], 0));
            nodes[0].adjacentNodes.Add(new vertex(nodes[1], 10));
            nodes[0].adjacentNodes.Add(new vertex(nodes[3], 5));
            nodes[1].adjacentNodes.Add(new vertex(nodes[1], 0));
            nodes[1].adjacentNodes.Add(new vertex(nodes[2], 3));
            nodes[2].adjacentNodes.Add(new vertex(nodes[2], 0));
            nodes[2].adjacentNodes.Add(new vertex(nodes[4], 4));
            nodes[3].adjacentNodes.Add(new vertex(nodes[3], 0));
            nodes[3].adjacentNodes.Add(new vertex(nodes[1], 1));
            nodes[3].adjacentNodes.Add(new vertex(nodes[4], 20));
            nodes[4].adjacentNodes.Add(new vertex(nodes[4], 0));

            theNode s = nodes[0];//Setting the start

            theNode d = nodes[4];//setting the destination 

            BreadthFirst(nodes, s, d);
        }
    }
}
