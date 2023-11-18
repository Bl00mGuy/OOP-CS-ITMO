using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

public class LocalModeCommandsExecution : IExecuteMode
{
    public void Copy(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);
    }

    public void Delete(string path)
    {
        File.Delete(path);
    }

    public void Move(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);
    }

    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public string Show(string path)
    {
        return File.ReadAllText(path);
    }

    public void Rename(string oldName, string newName)
    {
        File.Move(oldName, newName);
    }
}