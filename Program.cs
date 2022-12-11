using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

class Program
{
    public static Tree<string> OrganizeRank = new Tree<string>();
    public static Stack<string> bosses = new Stack<string>();

    public static void AddEmployee(int index)
    {
        int num = Convert.ToInt32(Console.ReadLine());
        if(num > 0)
        {
            string name = Console.ReadLine();
            OrganizeRank.AddChild(index, name);
            index++;
            AddEmployee(index);
            num--;

            for(int i = 0; i < num; i++)
            {
                string nameNext = Console.ReadLine();
                OrganizeRank.AddSibling(index, nameNext);
                index++;
                AddEmployee(index);
            }
        }
    }

    public static void SearchBoss(string search)
    {
        int index = 0;
        for (int i = 0; i < OrganizeRank.GetLength(); i++)
        {
            if(OrganizeRank.Get(i) == search)
            {
                index = i;
                break;
            }
        }

        TreeNode<string> nodeSearch = OrganizeRank.GetTreeNodeChild(index);
        while (nodeSearch.Parent() != null)
        {
            string temp = nodeSearch.Parent().GetValue();
            bosses.Push(temp);
            nodeSearch = nodeSearch.Parent();
        }
    }

    public static void PrintOutput()
    {
        for (int i = bosses.GetLength()-1; i >= 0; i--)
        {
            Console.WriteLine(bosses.Get(i));
        }
    }

    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        OrganizeRank.AddChild(-1, name);
        AddEmployee(0);

        string searchName = Console.ReadLine();
        SearchBoss(searchName);
        PrintOutput();
    }
}