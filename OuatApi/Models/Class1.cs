using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OuatApi.Models
{
    public class Class1
    {

        public class Rootobject
        {
            public string name { get; set; }
            public Qnalist[] qnaList { get; set; }
            public string[] urls { get; set; }
            public object[] files { get; set; }
        }

        public class Qnalist
        {
            public int id { get; set; }
            public string answer { get; set; }
            public string source { get; set; }
            public string[] questions { get; set; }
            public Metadata[] metadata { get; set; }
        }

        public class Metadata
        {
            public string name { get; set; }
            public string value { get; set; }
        }

    }
}