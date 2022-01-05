using System;
using System.Threading.Tasks;

using R5T.D0078;
using R5T.D0079;
using R5T.T0111;

using Instances = R5T.T0111.X0001.Instances;


namespace System
{
    public static class ILibraryGeneratorExtensions
    {
        public static async Task GenerateBasicTypesLibrary(this ILibraryGenerator _,
            string libraryName,
            string libraryDescription,
            string repositoryDirectoryPath,
            IVisualStudioProjectFileOperator visualStudioProjectFileOperator,
            IVisualStudioSolutionFileOperator visualStudioSolutionFileOperator)
        {
            // Solution.
            var solutionDirectoryPath = Instances.SolutionPathsOperator.GetSourceSolutionDirectoryPath(repositoryDirectoryPath);

            var solutionName = Instances.LibraryNameOperator.GetSolutionName(libraryName);
            var solutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName(solutionName);
            var solutionFilePath = Instances.PathOperator.GetFilePath(solutionDirectoryPath, solutionFileName);

            var constructionSolutionName = Instances.SolutionNameOperator.GetConstructionSolutionName(solutionName);
            var constructionSolutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName(constructionSolutionName);
            var constructionSolutionFilePath = Instances.PathOperator.GetFilePath(solutionDirectoryPath, constructionSolutionFileName);

            var basicTypesProjectFileSpecification = Instances.ProjectOperator.GetBasicTypesProjectFileSpecification(
                libraryName,
                libraryDescription,
                solutionDirectoryPath);

            var basicConstructionProjectFileSpecification = Instances.ProjectOperator.GetBasicConstructionProjectFileSpecification(
                libraryName,
                libraryDescription,
                solutionDirectoryPath,
                basicTypesProjectFileSpecification.FilePath);

            // Create types solution.
            await Instances.SolutionGenerator.CreateSolution(
                solutionFilePath,
                visualStudioSolutionFileOperator,
                async (solutionFileContext) =>
                {
                    // Create the types project (basic types, no
                    // * Project Plan
                    // * Documentation
                    // * /Code/Classes directory.
                    await Instances.ProjectGenerator.CreateBasicTypesLibraryProject(
                        solutionFileContext,
                        basicTypesProjectFileSpecification,
                        visualStudioProjectFileOperator,
                        visualStudioSolutionFileOperator);
                });

            // Create construction solution.
            await Instances.SolutionGenerator.CreateSolution(
                constructionSolutionFilePath,
                visualStudioSolutionFileOperator,
                async (constructionSolutionFileContext) =>
                {
                    await Instances.ProjectGenerator.CreateBasicConstructionConsoleProject(
                        constructionSolutionFileContext,
                        basicConstructionProjectFileSpecification,
                        visualStudioProjectFileOperator,
                        visualStudioSolutionFileOperator);
                });
        }
    }
}
