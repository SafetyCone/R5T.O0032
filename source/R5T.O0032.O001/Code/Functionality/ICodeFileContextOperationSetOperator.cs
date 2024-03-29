using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis.CSharp.Syntax;

using R5T.L0073.F001;
using R5T.L0073.T001;
using R5T.L0073.T003;
using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0093.T000;
using R5T.L0096.T000;
using R5T.T0132;
using R5T.T0221;


namespace R5T.O0032.O001
{
    [FunctionalityMarker]
    public partial interface ICodeFileContextOperationSetOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public O0031.O001.ICodeFileContextOperationSetOperator _ForUnspecifiedContextTypes => O0031.O001.CodeFileContextOperationSetOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IEnumerable<Func<TCodeFileContext, Task>> Generate_DocumentationFile<TCodeFileContext>(
            (IsSet<IHasFilePath>, IsSet<IHasNamespaceName>) propertiesRequired,
            out IChecked<IFileExists> checkedDocumentationFileExists,
            string projectDescription)
            where TCodeFileContext : IHasFilePath, IHasNamespaceName
        {
            checkedDocumentationFileExists = Checked.Check<IFileExists>();

            return Instances.EnumerableOperator.From(
                Instances.CodeFileContextOperations.In_CompilationFileContext<TCodeFileContext>(
                    out _,
                    Instances.CompilationUnitContextOperations.Set_CompilationUnit_ToNewEmpty,
                    Instances.CompilationUnitContextOperations.Add_UsingNamespace<CompilationFileContext>(
                        Instances.NamespaceNames.System,
                        out _
                    ),
                    Instances.CompilationUnitContextOperations.In_NamespaceDeclarationContext<CompilationFileContext>(
                        out _,
                        Instances.NamespaceDeclarationContextOperations.Set_NamespaceDeclaration_ToNewEmpty<L0073.T003.N001.NamespaceDeclarationContext>(
                            out _
                        ),
                        Instances.NamespaceDeclarationContextOperations.In_ClassDeclarationContext<L0073.T003.N001.NamespaceDeclarationContext>(
                            out _,
                            Instances.ClassDeclarationContextOperations.Set_ClassDeclaration_New<ClassDeclarationContext>(
                                Instances.ClassNames._Strings.Documentation,
                                out var classDeclarationSet
                            ),
                            Instances.ClassDeclarationContextOperations.Modify_Modifiers<ClassDeclarationContext>(
                                classDeclarationSet,
                                _ =>
                                {
                                    var modifiersDescriptor = new ModifiersDescriptor
                                    {
                                        Accessibility = MemberAccessibilityLevel.Public,
                                        Is_Static = true,
                                    };

                                    var output = Instances.ModifiersOperator.Get_ModifiersTokenList(modifiersDescriptor);
                                    return output;
                                }
                            ),
                            Instances.DocumentationCommentContextOperations.In_DocumentationCommentContext<ClassDeclarationContext, ClassDeclarationSyntax>(
                                out _,
                                Instances.DocumentationCommentContextOperations.Set_DocumentationComment_New<DocumentationCommentContext<ClassDeclarationSyntax>>(
                                    out _
                                ),
                                Instances.DocumentationCommentContextOperations.Add_SummaryElement<DocumentationCommentContext<ClassDeclarationSyntax>>(
                                    projectDescription
                                ),
                                Instances.DocumentationCommentContextOperations.Append_DocumentationComment_ToPrimarySyntaxNode<DocumentationCommentContext<ClassDeclarationSyntax>, ClassDeclarationSyntax>()
                            ),
                            Instances.ClassDeclarationContextOperations.Add_ClassDeclaration_ToNamespaceDeclaration
                        ),
                        Instances.NamespaceDeclarationContextOperations.Add_NamespaceDeclaration_ToCompilationUnit
                    ),
                    Instances.CompilationUnitContextOperations.Write_CompilationUnit_ToFilePath<CompilationFileContext>(
                        out _
                    )
                )
            );
        }

        public IEnumerable<Func<TCodeFileContext, Task>> Generate_InstancesFile<TCodeFileContext>(
            (IsSet<IHasFilePath>, IsSet<IHasNamespaceName>) propertiesRequired,
            out IChecked<IFileExists> checkedInstancesFileExists)
            where TCodeFileContext : IHasFilePath, IHasNamespaceName
        {
            checkedInstancesFileExists = Checked.Check<IFileExists>();

            return Instances.EnumerableOperator.From(
                Instances.CodeFileContextOperations.In_CompilationFileContext<TCodeFileContext>(
                    out _,
                    Instances.CompilationUnitContextOperations.Set_CompilationUnit_ToNewEmpty,
                    Instances.CompilationUnitContextOperations.Add_UsingNamespace<CompilationFileContext>(
                        Instances.NamespaceNames.System,
                        out _
                    ),
                    Instances.CompilationUnitContextOperations.In_NamespaceDeclarationContext<CompilationFileContext>(
                        out _,
                        Instances.NamespaceDeclarationContextOperations.Set_NamespaceDeclaration_ToNewEmpty<L0073.T003.N001.NamespaceDeclarationContext>(
                            out _
                        ),
                        Instances.NamespaceDeclarationContextOperations.In_ClassDeclarationContext<L0073.T003.N001.NamespaceDeclarationContext>(
                            out _,
                            Instances.ClassDeclarationContextOperations.Set_ClassDeclaration_New<ClassDeclarationContext>(
                                Instances.ClassNames._Strings.Instances,
                                out var classDeclarationSet
                            ),
                            Instances.ClassDeclarationContextOperations.Modify_Modifiers<ClassDeclarationContext>(
                                classDeclarationSet,
                                _ =>
                                {
                                    var modifiersDescriptor = new ModifiersDescriptor
                                    {
                                        Accessibility = MemberAccessibilityLevel.Public,
                                        Is_Static = true,
                                    };

                                    var output = Instances.ModifiersOperator.Get_ModifiersTokenList(modifiersDescriptor);
                                    return output;
                                }
                            ),
                            Instances.ClassDeclarationContextOperations.Add_ClassDeclaration_ToNamespaceDeclaration
                        ),
                        Instances.NamespaceDeclarationContextOperations.Add_NamespaceDeclaration_ToCompilationUnit
                    ),
                    Instances.CompilationUnitContextOperations.Write_CompilationUnit_ToFilePath<CompilationFileContext>(
                        out _
                    )
                )
            );
        }

        public IEnumerable<Func<TCodeFileContext, Task>> Generate_ProgramFile<TCodeFileContext>(
            string namespaceName)
            where TCodeFileContext : IHasFilePath, IWithCompilationUnit
        {
            return this._ForUnspecifiedContextTypes.Generate_ProgramFile<TCodeFileContext,
                NamespaceDeclarationContext,
                ClassDeclarationContext,
                MethodDeclarationContext,
                StatementContext>
                (namespaceName);
        }
    }
}
