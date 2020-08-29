using System;
using System.Collections.Generic;

namespace ProblemSolution
{
    public class Node : IEquatable<Node>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public IEnumerable<Node> Children { get; set; }

        //Compares only Node's properties without the children!
        public bool Equals(Node other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            //var childrenEqual = this.Children.Count() == other.Children.Count();
            //var childrenEqual1 = this.Children.Except(other.Children).Any();
            //var childrenEqual2 = other.Children.Except(this.Children).Any();
            return Id == other.Id && Name == other.Name && ParentId == other.ParentId;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, ParentId);
        }

        public static bool operator ==(Node left, Node right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Node left, Node right)
        {
            return !Equals(left, right);
        }
    }
}