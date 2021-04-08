using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryRH
{
    interface IOperations
    {
        string ToJson();
        void FromJson(string json);
        string ToXML();
        void FromXML(string xml);

    }
}
