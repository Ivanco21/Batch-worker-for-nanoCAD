using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Teigha.DatabaseServices;
using HostMgdApp = HostMgd.ApplicationServices;
using Teigha.Runtime;

namespace DgnLineTypesRemove
{
    public class ShowApp
    {
        [CommandMethod("gptComplexDGNPurge")]
        public void StartMainApp()
        {
            MainForm MainForm = new MainForm();
            HostMgdApp.Application.ShowModelessDialog(MainForm);
        }
    }
}
