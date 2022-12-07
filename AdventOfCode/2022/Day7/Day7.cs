namespace AdventOfCode._2022.Day7;

public class Day7
{
    private static int _sumOfSelectedSizes;

    public static void Part1()
    {
        var commands = File.ReadAllLines("2022/Day7/input.txt")[1..];
        var root = BuildTree(commands);

        TreeDfs(root);

        Console.WriteLine(_sumOfSelectedSizes);
    }

    private static Node BuildTree(IEnumerable<string> commands)
    {
        var root = new Node(null, "/", 0, false);
        var current = root;

        foreach (var command in commands)
        {
            var parts = command.Split(" ");

            switch (parts[0])
            {
                // ls
                case "$" when parts[1] == "ls":
                    continue;

                // cd
                case "$" when parts[1] == "cd":
                    current = parts[2] == ".."
                        ? current?.Parent
                        : current?.Children.Single(n => n.Name == parts[2]);
                    break;

                // folder
                case "dir":
                    var dir = new Node(current, parts[1], 0, false);
                    current?.Children.Add(dir);
                    break;

                // file
                default:
                    var file = new Node(current, parts[1], int.Parse(parts[0]), true);
                    current?.Children.Add(file);
                    break;
            }
        }

        return root;
    }

    private static int TreeDfs(Node root)
    {
        if (root.IsFile) return root.Size;

        foreach (var child in root.Children)
            root.Size += TreeDfs(child);

        if (root.Size <= 100000)
            _sumOfSelectedSizes += root.Size;

        return root.Size;
    }

    private class Node
    {
        public Node? Parent { get; set; }
        public ICollection<Node> Children { get; set; } = new List<Node>();

        public string Name { get; set; }
        public int Size { get; set; }
        public bool IsFile { get; set; }

        public Node(Node? parent, string name, int size, bool isFile)
        {
            Parent = parent;
            Name = name;
            Size = size;
            IsFile = isFile;
        }
    }
}