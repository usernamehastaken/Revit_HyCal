using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.ApplicationServices;
using Revit_FunExtension;

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uIApplication = commandData.Application;
            UIDocument uIDocument = commandData.Application.ActiveUIDocument;
            Document document = uIDocument.Document;

            ////IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
            //Reference reference = uIDocument.Selection.PickObject(ObjectType.Element);
            //Element element = document.GetElement(reference.ElementId);
            //ParameterSet parameterSet = element.Parameters;
            ////parameterSet.
            //Parameter parameter= element.get_Parameter(BuiltInParameter.RBS_CALCULATED_SIZE);
            //string str = uIApplication.Application.SharedParametersFilename;

            //TaskDialog.Show("1", str);
            //Transaction transaction = new Transaction(document);
            //transaction.Start("asdf");
            //document.Application.OpenSharedParameterFile().Groups.Create("asdf");
            //transaction.Commit();

            SetNewParameterToInstanceWall(uIApplication, document.Application.OpenSharedParameterFile());


            return Result.Succeeded;
        }

        public static bool SetNewParameterToInstanceWall(UIApplication app, DefinitionFile myDefinitionFile)
        {
            // create a new group in the shared parameters file
            DefinitionGroups myGroups = myDefinitionFile.Groups;
            DefinitionGroup myGroup = myGroups.Create("nnf");

            // create an instance definition in definition group MyParameters
            ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions("Instance_ProductDate", ParameterType.Text);
            // Don't let the user modify the value, only the API
            option.UserModifiable = false;
            // Set tooltip
            option.Description = "Wall product date";
            Definition myDefinition_ProductDate = myGroup.Definitions.Create(option);

            // create a category set and insert category of wall to it
            CategorySet myCategories = app.Application.Create.NewCategorySet();
            // use BuiltInCategory to get category of wall
            Category myCategory = Category.GetCategory(app.ActiveUIDocument.Document, BuiltInCategory.OST_Walls);


            myCategories.Insert(myCategory);

            //Create an instance of InstanceBinding
            InstanceBinding instanceBinding = app.Application.Create.NewInstanceBinding(myCategories);

            // Get the BingdingMap of current document.
            BindingMap bindingMap = app.ActiveUIDocument.Document.ParameterBindings;

            // Bind the definitions to the document
            bool instanceBindOK = bindingMap.Insert(myDefinition_ProductDate,
                                            instanceBinding, BuiltInParameterGroup.PG_TEXT);
            return instanceBindOK;
        }
    }
}
