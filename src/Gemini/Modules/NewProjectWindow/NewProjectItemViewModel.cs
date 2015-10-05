using System.Windows.Media;

namespace Gemini
{
    public class NewProjectItemViewModel
    {
        private readonly IProjectType _projectType;

        public NewProjectItemViewModel(IProjectType projectType)
        {
            _projectType = projectType;
        }
        public string ProjectType { get { return _projectType.ProjectType; } }
        public Geometry PathData { get { return _projectType.PathData; } }
        public Brush PathColor { get { return _projectType.PathColor; } }
        public string DefaultName { get { return _projectType.DefaultProjectName; } }

        public IProject GenerateNew(string projectName, string path)
        {
            return _projectType.GenerateNew(projectName, path);
        }
    }
}