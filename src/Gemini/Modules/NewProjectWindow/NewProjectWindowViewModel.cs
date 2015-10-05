using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using Gemini.Framework;
using Gemini.Framework.Services;
using Xceed.Wpf.Toolkit;

namespace Gemini
{
    [Export(typeof(NewProjectWindowViewModel))]
    public class NewProjectWindowViewModel : WindowBase
    {
        private IProjectManager _projectManager;
        private NewProjectItemViewModel _selectedProjectType;
        private string _projectName;
        private string _path;

        [ImportingConstructor]
        public NewProjectWindowViewModel([ImportMany] IProjectType[] projectTypes, [Import]IProjectManager projectManager)
        {
            _projectManager = projectManager;
            ProjectTypes = new ObservableCollection<NewProjectItemViewModel>();
            foreach (var projectType in projectTypes)
            {
                ProjectTypes.Add(new NewProjectItemViewModel(projectType));
            }

            SelectedProjectType = ProjectTypes.FirstOrDefault();
        }

        public NewProjectItemViewModel SelectedProjectType
        {
            get { return _selectedProjectType; }
            set
            {
                if (Equals(value, _selectedProjectType)) return;

                NewProjectItemViewModel previouslySelectedProject = _selectedProjectType;

                _selectedProjectType = value;
                NotifyOfPropertyChange(() => SelectedProjectType);

                if (_selectedProjectType != null)
                {
                    if (previouslySelectedProject != null && ProjectName == previouslySelectedProject.DefaultName)
                    {
                        ProjectName = _selectedProjectType.DefaultName;
                    }
                    else if (previouslySelectedProject == null)
                    {
                        ProjectName = _selectedProjectType.DefaultName;
                    }
                }

                NotifyOfPropertyChange(() => CanCreate);
            }
        }

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (value == _projectName) return;
                _projectName = value;
                NotifyOfPropertyChange(() => ProjectName);
                NotifyOfPropertyChange(() => CanCreate);
            }
        }

        public string Path
        {
            get { return _path; }
            set
            {
                if (value == _path) return;
                _path = value;
                NotifyOfPropertyChange(() => Path);
                NotifyOfPropertyChange(() => CanCreate);
            }
        }

        public string Title { get { return "New Project"; } }

        public ObservableCollection<NewProjectItemViewModel> ProjectTypes
        {
            get;
            private set;
        }

        public bool CanCreate
        {
            get
            {
                return !string.IsNullOrEmpty(ProjectName) && !string.IsNullOrEmpty(Path) && SelectedProjectType != null;
            }
        }

        public void Create()
        {
            _projectManager.CurrentProject = SelectedProjectType.GenerateNew(ProjectName, Path);
            TryClose();
        }
    }
}
