namespace Itmo.ObjectOrientedProgramming.Lab4.FileManager.Services.ExecutableCommands.ExecuteMode;

public interface IMode
{
    void Connect(ref string? path, string? newPath);
    void Disconnect(ref string? path);
    void Copy(string? path, string sourcePath, string destinationPath);
    void Delete(string? path, string filePath);
    void Move(string? path, string sourcePath, string destinationPath);
    void Show(string? path, string showPath);
    void Rename(string? path, string namePath, string newName);
    void TreeGoTo(ref string? path, string? newPath);
    void TreeList(string? path, string requestDepth, int initialDepth, int startTraversalDepth);
}