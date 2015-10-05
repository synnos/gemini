using Gemini.Framework.Commands;

namespace Gemini.Modules.Shell.Commands
{
    [CommandDefinition]
    public class NewFileCommandListDefinition : CommandDefinition
    {
        public const string CommandName = "File.NewFile";

        public override string Name
        {
            get { return CommandName; }
        }

        public override string Text
        {
            get { return "Project..."; }
        }

        public override string ToolTip
        {
            get { return "Create new project"; }
        }
    }
}