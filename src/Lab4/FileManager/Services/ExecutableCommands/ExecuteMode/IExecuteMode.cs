namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

public interface IExecuteMode
{
    void Copy(string sourcePath, string destinationPath);
    void Delete(string path);
    void Move(string sourcePath, string destinationPath);
    bool Exists(string path);
    string Show(string path);
    void Rename(string oldName, string newName);
}