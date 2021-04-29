using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI.Selection;

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    public class Operation
    {
        public static ConnectorSet GetConnectorSet(Document document, ElementId elementId)
        {
            //from the elementid to get all the connectors
            Element element = document.GetElement(elementId);
            //is Group
            Group group = element as Group;
            if (group is null)
            {
                //category only in ['duct','family instance']
                Duct duct = element as Duct;
                if (duct is null)
                {
                    FamilyInstance familyInstance = element as FamilyInstance;
                    if (familyInstance is null)
                    {
                        throw new Exception("选择的图元未有连接键或非机械图元！");
                    }
                    return familyInstance.MEPModel.ConnectorManager.Connectors;
                }
                else
                {
                    return duct.ConnectorManager.Connectors;
                }
            }
            else
            {
                IList<ElementId> elementIds = group.GetMemberIds();
                IList<Connector> connectors = new List<Connector>();
                foreach (var v in elementIds)
                {
                    foreach (Connector connector in GetConnectorSet(document, v))
                    {
                        connectors.Add(connector);
                    }
                }
                return connectors as ConnectorSet;
            }

        }
        public static IList<ElementId> SelectPipeline(UIDocument uIDocument,Document document)
        {
            //!!!Causion last one is element_origin
            List<ElementId> elementIds = new List<ElementId>();
            try
            {
                //pickup all the elementids of the pipeline
                IList<Reference> references = uIDocument.Selection.PickObjects(ObjectType.Element);
                foreach (Reference reff in references)
                {
                    elementIds.Add(reff.ElementId);
                }
                TaskDialog.Show("Prompt", "Please Select the Origin of Selection Before!");
                
                //pick up the original elementid of the pipeline
                ElementId elementId_origin = uIDocument.Selection.PickObject(ObjectType.Element).ElementId;

                //if the elementids contain the group elements , 
                //elementids kick off the group elements and union the groupelementids
                IList<ElementId> groupElementIds = new List<ElementId>();
                foreach (ElementId id in elementIds)
                {
                    Group group = document.GetElement(id) as Group;
                    if (group != null) { groupElementIds.Add(id); }
                }
                if (groupElementIds.Count > 0)
                {
                    elementIds = elementIds.Except(groupElementIds).ToList<ElementId>();
                    foreach (ElementId id in groupElementIds)
                    {
                        Group group = document.GetElement(id) as Group;
                        elementIds = elementIds.Union(group.GetMemberIds()).ToList<ElementId>();//causion getmenberids contains elements of not solid elementid
                    }
                }
                elementIds.Add(elementId_origin);
                return elementIds;
            }
            catch
            {
                throw new Exception("HVAC Hydraulic Calculation App Quit");
            }
        }

    }

    public class MassSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            return true;
        }

        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
}
