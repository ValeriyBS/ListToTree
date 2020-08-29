using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace ProblemSolution
{
    public static class CreateTreeFromList
    {
        public static IList<Node> Execute(IEnumerable<Node> flatStructure)
        {
            var root = new List<Node>();
            var args = (0, false);

            foreach (var node in flatStructure.OrderBy(n => n.ParentId))
                if (node.ParentId is null)
                    root.Add(node);
                else
                {
                    args.Item2 = false;
                    AddChildToRootParents(node, root, ref args);
                }

            return root;
        }

        private static void AddChildToRootParents(Node child, IEnumerable<Node> rootNodes, ref (int executionCounter, bool cancelationToken) recursionArgs)
        {
            recursionArgs.executionCounter ++;

            if (rootNodes is null) return;

                foreach (var node in rootNodes)
                if (child.ParentId == node.Id)
                {
                    if (node.Children is null)
                    {
                        node.Children = new List<Node> {child};
                    }
                    else
                    {
                        var children = node.Children.ToList();
                        children.Add(child);
                        node.Children = children;
                    }

                    recursionArgs.cancelationToken = true;
                    return ;
                }
                else if (!recursionArgs.cancelationToken)
                {
                    AddChildToRootParents(child, node.Children, ref recursionArgs);
                }
        }
    }
}