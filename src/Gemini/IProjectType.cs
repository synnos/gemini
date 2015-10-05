using System.Windows.Media;
using System.Windows.Shapes;

namespace Gemini
{
    public interface IProjectType
    {
        string ProjectType { get; }
        string DefaultProjectName { get; }
        Geometry PathData { get; }
        Brush PathColor { get; }
        IProject GenerateNew(string projectName, string filePath);
    }
}