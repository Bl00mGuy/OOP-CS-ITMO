using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

public class LocalMode : IMode
{
    public void Connect(ref string? path, string? newPath)
    {
        path = newPath;
    }

    public void Disconnect(ref string? path)
    {
        path = string.Empty;
        Environment.Exit(0);
    }

    public void Copy(string? path, string sourcePath, string destinationPath)
    {
        if (path is null) return;
        string fullPath = Path.Combine(sourcePath, path);
        File.Copy(sourcePath, destinationPath);
        if (File.Exists(sourcePath))
        {
            string fileName = Path.GetFileNameWithoutExtension(destinationPath);
            string fileExtension = Path.GetExtension(destinationPath);

            if (File.Exists(destinationPath))
            {
                for (int i = 1; ; i++)
                {
                    string newName = $"{fileName}_({i}){fileExtension}";
                    string newFileDestinationPath = Path.Combine(Path.GetDirectoryName(destinationPath) ?? string.Empty, newName);

                    if (!File.Exists(newFileDestinationPath))
                    {
                        File.Copy(fullPath, newFileDestinationPath);
                    }
                }
            }
            else
            {
                File.Copy(fullPath, destinationPath);
            }

            Console.WriteLine($"Copied file from {sourcePath} to {destinationPath}");
        }
        else
        {
            Console.WriteLine($"File not found: {sourcePath}");
        }
    }

    public void Delete(string? path, string filePath)
    {
        if (path is null) return;
        string fullPath = Path.Combine(filePath, path);
        if (File.Exists(filePath))
        {
            File.Delete(fullPath);
            Console.WriteLine($"Deleted file: {filePath}");
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}");
        }
    }

    public void Move(string? path, string sourcePath, string destinationPath)
    {
        if (path is null) return;
        string fullPath = Path.Combine(sourcePath, path);
        if (File.Exists(sourcePath))
        {
            File.Move(fullPath, destinationPath);
            Console.WriteLine($"Moved file from {sourcePath} to {destinationPath}");
        }
        else
        {
            Console.WriteLine($"File not found: {sourcePath}");
        }
    }

    public void Show(string? path, string showPath)
    {
        if (path is null) return;
        string fullPath = Path.Combine(showPath, path);
        if (File.Exists(showPath))
        {
            string content = File.ReadAllText(fullPath);
            Console.WriteLine($"#-----{Path.GetFileNameWithoutExtension(showPath)} CONTENT:-----#");
            Console.WriteLine(content);
            Console.WriteLine("#---------------#");
        }
        else
        {
            Console.WriteLine($"File not found: {showPath}");
        }
    }

    public void Rename(string? path, string namePath, string newName)
    {
        if (path is null) return;
        string fullPath = Path.Combine(namePath, path);
        if (File.Exists(namePath))
        {
            File.Move(fullPath, newName);
            Console.WriteLine($"Renamed file from {namePath} to {newName}");
        }
        else
        {
            Console.WriteLine($"File not found: {namePath}");
        }
    }

    public void TreeGoTo(ref string? path, string? newPath)
    {
        path = newPath;
    }

    public void TreeList(string? path, string requestDepth, int initialDepth, int startTraversalDepth)
    {
        if (path is null) return;

        TreeTraversal(path, int.TryParse(requestDepth, out int depth) ? depth : initialDepth, startTraversalDepth);
    }

    private void TreeTraversal(string root, int maxDepth, int currentDepth = 0, bool isLast = true)
    {
        if (currentDepth > maxDepth) return;

        string indent = new string(' ', currentDepth * 4);
        string prefix = isLast ? "└─" : "├─";
        Console.WriteLine($"{indent}{prefix}[{Path.GetFileName(root)}]");

        string[] directories = Directory.GetDirectories(root);

        for (int i = 0; i < directories.Length; i++)
        {
            bool isSubLast = i == directories.Length - 1;
            TreeTraversal(directories[i], maxDepth, currentDepth + 1, isSubLast);
        }

        string subfolderIndent = $"{indent}{(isLast ? "    " : "│   ")}";
        string[] files = Directory.GetFiles(root);

        for (int i = 0; i < files.Length; i++)
        {
            Console.WriteLine($"{subfolderIndent}│  {Path.GetFileName(files[i])}");
        }
    }
}