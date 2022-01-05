using System;

using R5T.T0040;
using R5T.T0041;
using R5T.T0110;
using R5T.T0112;
using R5T.T0113;


namespace R5T.T0111.X0001
{
    public static class Instances
    {
        public static ILibraryNameOperator LibraryNameOperator { get; } = T0110.LibraryNameOperator.Instance;
        public static IPathOperator PathOperator { get; } = T0041.PathOperator.Instance;
        public static IProjectGenerator ProjectGenerator { get; } = T0113.ProjectGenerator.Instance;
        public static IProjectOperator ProjectOperator { get; } = T0113.ProjectOperator.Instance;
        public static ISolutionFileNameOperator SolutionFileNameOperator { get; } = T0040.SolutionFileNameOperator.Instance;
        public static ISolutionGenerator SolutionGenerator { get; } = T0113.SolutionGenerator.Instance;
        public static ISolutionNameOperator SolutionNameOperator { get; } = T0112.SolutionNameOperator.Instance;
        public static ISolutionPathsOperator SolutionPathsOperator { get; } = T0040.SolutionPathsOperator.Instance;
    }
}
