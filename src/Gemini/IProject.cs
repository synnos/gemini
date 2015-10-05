namespace Gemini
{
    public interface IProject
    {
        string Name { get; set; }
        string FileName { get; }
        bool Save(string filename);
    }
}