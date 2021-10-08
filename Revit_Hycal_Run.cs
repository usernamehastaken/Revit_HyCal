﻿using System;
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
using Autodesk.Revit.DB.Mechanical;
using System.Threading;
using System.Windows.Forms;

namespace Revit_HyCal
{
    [Transaction(TransactionMode.Manual)]
    class Revit_Hycal_Run : IExternalCommand 
    {
        //作为程序入口
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //test
            UIOperation.uIDocument = commandData.Application.ActiveUIDocument;
            UIOperation.document = UIOperation.uIDocument.Document;
            Test.test(commandData,ref message, elements);
            return Result.Succeeded;
            //test

        }


    }
}