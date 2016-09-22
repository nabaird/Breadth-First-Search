using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding
{
    class Program
    {
        class theNode
        {
            public int name; //the index of the node within the nodes[]
            public bool known = false;
            public int distanceFromS = -1;//The default value functions equivalently to infinity
            public int path;//allows us to construct the path backwards when the algorithm is finished
            public List<theNode> adjacentNodes = new List<theNode>();//a list of all nodes adjacent to node
        }

        static void BreadthFirst(theNode[] nodes, theNode s, theNode d)
        {
            Queue<theNode> q = new Queue<theNode>();

            s.distanceFromS = 0;

            q.Enqueue(s);

            for (int currDist = 0; currDist < nodes.Length; currDist++)//the immediate distance we are checking in the breadth-first search
            {
                while (q.Count > 0 && q.Peek().distanceFromS == currDist)//ensures that we stop the dequeue once we are considering nodes further away than the current distance we are considering
                {
                    theNode i = q.Dequeue();
                    if (i.known == false && i.distanceFromS == currDist)
                    {
                        i.known = true;
                        foreach (theNode j in i.adjacentNodes)
                        {

                            if (j.distanceFromS == -1)
                            {
                                j.distanceFromS = currDist + 1;//here we gaurantee we will check this node in the next pass 
                                j.path = i.name;
                                q.Enqueue(j);
                            }

                        }
                    }
                }
            }

            Console.WriteLine("The distance to d is" + " " + d.distanceFromS);
            Console.WriteLine("The path starts at node" + " " + s.name);

            Stack<theNode> tempStack = new Stack<theNode>();//Here we simulate recursion with a stack
            theNode check = d;
            int p = 0;
            int pathLength = d.distanceFromS;
            while (p < pathLength)
            {
                tempStack.Push(check);
                check = nodes[check.path];
                p++;
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

            nodes[0].adjacentNodes.Add(nodes[0]);
            nodes[0].adjacentNodes.Add(nodes[1]);
            nodes[0].adjacentNodes.Add(nodes[3]);
            nodes[1].adjacentNodes.Add(nodes[1]);
            nodes[1].adjacentNodes.Add(nodes[2]);
            nodes[2].adjacentNodes.Add(nodes[2]);
            nodes[2].adjacentNodes.Add(nodes[4]);
            nodes[3].adjacentNodes.Add(nodes[3]);
            nodes[3].adjacentNodes.Add(nodes[1]);
            nodes[3].adjacentNodes.Add(nodes[4]);
            nodes[4].adjacentNodes.Add(nodes[4]);

            theNode s = nodes[0];//Setting the start

            theNode d = nodes[4];//setting the destination 

            BreadthFirst(nodes, s, d);
        }
    }
}
