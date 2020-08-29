using System.Collections.Generic;
using System.Linq;

namespace ProblemSolution
{
    public static class CreateTreeFromList
    {
        public static IList<Node> Execute(IEnumerable<Node> flatStructure)
        {
            var root = new List<Node>();
            foreach (var node in flatStructure.OrderBy(n => n.ParentId))
                if (node.ParentId is null)
                    root.Add(node);
                else
                    AddChildToRootParents(node, root);

            return root;
        }

        private static void AddChildToRootParents(Node child, IEnumerable<Node> rootNodes)
        {
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

                    return;
                }
                else
                {
                    AddChildToRootParents(child, node.Children);
                }
        }
    }
}