using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FPProjectStudentSuccessBSA.Data
{
    public class SQLConnectionConfig
    {
        public string Value { get; }
        public SQLConnectionConfig(string value)
        {
            Value = value;
        }
    }
}
