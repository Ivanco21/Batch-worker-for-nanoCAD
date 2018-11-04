using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Teigha.DatabaseServices;
using HostMgdApp = HostMgd.ApplicationServices;
using Teigha.Runtime;
using HostMgd.ApplicationServices;

using mcObj = Multicad.DatabaseServices;


namespace BatchWorker
{
    class DgnDelete  
    {
        string dgnLsDictName = "ACAD_DGNLINESTYLECOMP";// this distionary has been deleted
        public void DgnDeleting(List<string> allDwgPath)
        {
            HostMgdApp.Application ncadMgpApp = Marshal.GetActiveObject("nanocad.Application") as HostMgdApp.Application;
            foreach (string oneDwg in allDwgPath)
            {

                HostMgdApp.Document docMgb;
                try
                {
                    docMgb = HostMgdApp.Application.DocumentManager.Open(oneDwg, false);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    return;
                }

                Database db = docMgb.Database;

                ObjectIdCollection objIdColl = new ObjectIdCollection();
                bool dgnSt;
                using (Transaction tr = db.TransactionManager.StartTransaction())
                {
                    var nod = (DBDictionary)tr.GetObject(db.NamedObjectsDictionaryId, OpenMode.ForRead);
                    if ((ObjectId)nod[dgnLsDictName] != ObjectId.Null)
                    {
                        dgnSt = true;
                        DBDictionary dgnLsDict = (DBDictionary)tr.GetObject((ObjectId)nod[dgnLsDictName], OpenMode.ForWrite);
                        dgnLsDict.Erase();
                        //dgnLsDict.Remove(dgnLsDictName);
                        tr.Commit();
                    }
                    else
                    {
                        dgnSt = false;
                        tr.Commit();
                    }
                }
                // был ли словарь 
                if (dgnSt == false)
                {
                    docMgb.Dispose();
                    mcObj.McDocument mcDocClose = mcObj.McDocument.ActiveDocument;
                    mcDocClose.Close();
                    continue;
                }
                docMgb.Database.Save();
                docMgb.Dispose();

                mcObj.McDocument mcDoc = mcObj.McDocument.ActiveDocument;
                mcDoc.Save();
                mcDoc.Close();

                HostMgdApp.Document docMgbItem = HostMgdApp.Application.DocumentManager.Open(oneDwg, false);
                Database dbItem = docMgbItem.Database;

                ObjectIdCollection objIdCollItem = new ObjectIdCollection();
                using (Transaction trItem = dbItem.TransactionManager.StartTransaction())
                {
                    LinetypeTable LnTb;
                    LnTb = trItem.GetObject(dbItem.LinetypeTableId, OpenMode.ForRead) as LinetypeTable;

                    foreach (ObjectId oneObjId in LnTb)
                    {
                        objIdCollItem.Add(oneObjId);
                    }
                    dbItem.Purge(objIdCollItem);
                    trItem.Commit();
                }
                dbItem.Purge(objIdCollItem);

                using (Transaction t = dbItem.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId ltypeId in objIdCollItem)
                    {
                        DBObject ltype = t.GetObject(ltypeId, OpenMode.ForWrite);
                        ltype.Erase();
                    }
                    t.Commit();
                }
                dbItem.ReclaimMemoryFromErasedObjects(objIdCollItem);
                docMgbItem.Database.Save();
                docMgbItem.Dispose();

                mcObj.McDocument mcDocItem = mcObj.McDocument.ActiveDocument;
                mcDocItem.Save();
                mcDocItem.Close();

            }

        }

    }
}
