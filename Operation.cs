using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Mechanical;

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
    }
}
