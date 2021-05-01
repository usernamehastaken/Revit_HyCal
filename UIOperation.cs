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
    public class UIOperation
    {
        public static ConnectorSet GetConnectorSet(Document document, ElementId elementId)
        {
            //from the elementid to get all the connectors
            Element element = document.GetElement(elementId);
            //temporary group is out of consider
            switch (element.Category.Name)
            {
                case "风管":
                    Duct duct = element as Duct;
                    return duct.ConnectorManager.Connectors;
                //case "风管管件":
                //    familyInstance = element as FamilyInstance;
                //    return familyInstance.MEPModel.ConnectorManager.Connectors;
                //case "风管末端":
                //    familyInstance = element as FamilyInstance;
                //    return familyInstance.MEPModel.ConnectorManager.Connectors;
                //case "风管附件":
                //    familyInstance = element as FamilyInstance;
                //    return familyInstance.MEPModel.ConnectorManager.Connectors;
                default:
                    FamilyInstance familyInstance = element as FamilyInstance;
                    return familyInstance.MEPModel.ConnectorManager.Connectors;
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
                //if the elementids contain the group elements , 
                //elementids kick off the group elements and union the groupelementids
                IList<ElementId> groupElementIds = new List<ElementId>();
                foreach (ElementId id in elementIds)
                {
                    Group group = document.GetElement(id) as Group;
                    if (group != null) { groupElementIds.Add(id); }
                }//get the groupids
                if (groupElementIds.Count > 0)
                {
                    elementIds = elementIds.Except(groupElementIds).ToList<ElementId>();
                    foreach (ElementId id in groupElementIds)
                    {
                        Group group = document.GetElement(id) as Group;
                        elementIds = elementIds.Union(group.GetMemberIds()).ToList<ElementId>();//causion getmenberids contains elements of not solid elementid
                    }
                }
                TaskDialog.Show("Prompt", "Please Select the Origin of Selection Before!(No Group Element)");

                //pick up the original elementid of the pipeline
                ElementId elementId_origin = null;
                do
                {
                    elementId_origin = uIDocument.Selection.PickObject(ObjectType.Element).ElementId;

                } while ((document.GetElement(elementId_origin) as Group) != null);
                
                elementIds.Add(elementId_origin);
                return elementIds;
            }
            catch
            {
                throw new Exception("HVAC Hydraulic Calculation App Quit");
            }
        }
        public static ElementId GetAnotherIDAtConnector(ElementId ownerID,Connector connector)
        {
            ElementId id = null;
            if (connector.IsConnected)
            {
                foreach(Connector c in connector.AllRefs)
                {
                    if (c.Owner.Id != ownerID) { id = c.Owner.Id; }
                }
                return id;
            }
            else
            {
                return id;
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
