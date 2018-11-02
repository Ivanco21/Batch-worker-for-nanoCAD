using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DgnLineTypesRemove
{
    class UserEventArgsPathAll : EventArgs
    {
        public readonly List<string> allPathes;
        public readonly bool setAllPathes;

        public UserEventArgsPathAll(List<string> allPt, bool setPt)
        {
            allPathes = allPt;
            setAllPathes = setPt;
        }
    }
}
