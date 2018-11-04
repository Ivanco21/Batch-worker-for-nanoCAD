using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace BatchWorker
{
    class PathManyFiles
    {
        private List<string> allDwg = new List<string>();
        private List<string> notReadFiles = new List<string>();
        private bool setPathAllFiles;

        public PathManyFiles(string path)
        {
            setPathAllFiles = PathFolder(path);
        }

        public event EventHandler<UserEventArgsPathAll> sendAllPathFromClass;

        public void DoEventSendAllPathesFromClass()
        {
            if (sendAllPathFromClass != null)
                sendAllPathFromClass(this, new UserEventArgsPathAll(allDwg, setPathAllFiles));
        }

        public bool PathFolder(string path)
        {
            string[] allFilesToConvert = Directory.GetFiles(path, "*.dwg", SearchOption.AllDirectories);
            CheckPath CheckAllFiles = new CheckPath();
            for (int i = 0, j = 0; i < allFilesToConvert.Length; i++, j++)
            {
                if (CheckAllFiles.CheckAccessFile(allFilesToConvert[i]) && CheckAllFiles.CheckReadOnlyFile(allFilesToConvert[i]))
                {
                    // MessageBox.Show(allFilesToConvert[i]);
                    allDwg.Add(allFilesToConvert[i]);
                }
                else
                {
                    notReadFiles.Add(allFilesToConvert[i]);
                }
            }

            if (allDwg.Count == 0 & notReadFiles.Count == 0)
            {
                MessageBox.Show("нет доступных файлов для обработки");
                return false;
            }
            else if (allDwg.Count == 0 & notReadFiles.Count != 0)
            {
                string badFiles = String.Join(",", notReadFiles.Select(s => s.ToString()).ToArray());
                MessageBox.Show("Файлы:" + badFiles + " - недоступны для записи либо открыты в другой программе");
                return false;
            }
            else if (allDwg.Count != 0 & notReadFiles.Count != 0)
            {
                string badFiles = String.Join(",", notReadFiles.Select(s => s.ToString()).ToArray());
                MessageBox.Show("Файлы:" + badFiles + " - будут пропущены т.к. доступны только для чтения,либо открыты в другой программе");
                return true;
            }
            else//allDwg.Length != 0 & notReadFiles.Length == 0
            {
                return true;
            }
        }
    }

    class CheckPath
    {
        public bool CheckReadOnlyFile(string _path)// проверка не стоит ли "только для чтения"
        {
            FileInfo info = new FileInfo(_path);
            bool readFl = info.IsReadOnly;
            if (readFl == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckAccessFile(string _path)// проверка на доступность, не открыт ли другим приложением
        {
            try
            {
                using (FileStream fs = File.Open(_path, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    fs.Close();
                }
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }
    }
}
