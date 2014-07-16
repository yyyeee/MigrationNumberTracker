using System.Collections.Generic;
using JetBrains.Application.DataContext;
using JetBrains.ReSharper.Feature.Services.Generate.Actions;
using JetBrains.ReSharper.Feature.Services.LiveTemplates.Settings;
using JetBrains.ReSharper.LiveTemplates.FileTemplates;
using JetBrains.ReSharper.LiveTemplates.Templates;

namespace MigrationNumberTracker.ResharperPlugin
{
    [GenerateProvider]
    public class GenerateMigrationItemProvider : IGenerateActionProvider
    {
        public IEnumerable<IGenerateActionWorkflow> CreateWorkflow(IDataContext dataContext)
        {
            var template = new Template(
                "MigrationShortcut",
                "MigrationDescription",
                "MigrationText",
                true,
                true,
                false,//it is visible with true also, what does this mean ???
                TemplateApplicability.File);
            yield return new GenerateMigrationActionWorkflow(template);
        }
    }

    public class GenerateMigrationActionWorkflow : GenerateFileActionWorkflow
    {
        public GenerateMigrationActionWorkflow(Template template) : base(template, 100)
        {
        }
    }
}