using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Teigha.DatabaseServices;
using HostMgdApp = HostMgd.ApplicationServices;
using Teigha.Runtime;
using HostMgd.ApplicationServices;
using Multicad.AplicationServices;

using mcObj = Multicad.DatabaseServices;


namespace BatchWorker
{
    class SPDSdestroyer
    {
        public void DestroySPDSobjects(List<string> allDwgPath, bool isSaveDWG)
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

                // spexplodeall разрушает все СПДС объекты
                McContext.ExecuteCommand("spexplodeall");
                System.Windows.Forms.SendKeys.SendWait("{ENTER}");// окно подтверждения 

                // чтобы пользователь мог просмотреть изменения какие сделала команда
                // если isSaveDWG == true чертежи закрываются с сохранением 

                if (isSaveDWG)
                {
                    mcObj.McDocument mcDocItem = mcObj.McDocument.ActiveDocument;

                    try
                    {
                        mcDocItem.Save();
                        mcDocItem.Close();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
