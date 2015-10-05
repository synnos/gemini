using System;

namespace Gemini
{
    public interface IProjectManager
    {
        IProject CurrentProject { get; set; }

        event EventHandler CurrentProjectChanged;
    }
}
