using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hardy
{
    public class SaveData
    {
        public string FileName;
        public bool IsModified;
        public bool IsNew;


        public SaveData()
        {
            FileName = String.Empty;
            IsModified = false;
            IsNew = true;
        }
        public SaveData(string fileName, bool isModified)
        {
            FileName = fileName;
            IsModified = isModified;
        }
    }
}
