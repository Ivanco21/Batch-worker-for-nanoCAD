using System;

using HostMgdApp = HostMgd.ApplicationServices;
using Multicad.Runtime;

namespace BatchWorker
{
    public class ShowApp
    {
        [CommandMethod("BatchWorker", CommandFlags.NoCheck | CommandFlags.NoPrefix)]
        public void StartMainApp()
        {
            MainForm MainForm = new MainForm();
            HostMgdApp.Application.ShowModelessDialog(MainForm);
        }
    }
}
