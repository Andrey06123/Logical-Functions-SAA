using LogicalLibrary.DataStructures;
using LogicalLibrary.Functions;

namespace Logic_SAA
{
    public class Function
    {
        public string? Name { get; private set; }
        public List<string> Parameters { get; }
        public BinaryTree<string> SolutionTree { get; }

        public Function(string input) 
        {
            Define define = new Define(input);
            Name = define.GetName();
        }
    }
}
