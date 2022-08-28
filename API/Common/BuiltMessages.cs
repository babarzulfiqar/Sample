using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common
{
    public static class BuiltMessages
    {
        public static string BuiltMessage(Exception e, int eventtype)
        {
            if (e.InnerException != null)
            {
                if (!string.IsNullOrWhiteSpace(e.InnerException.Message))
                {
                    if (e.InnerException is SqlException ex)
                    {
                        if (ex.Number == 2627 || ex.Number == 2601 || ex.Message.ToLower().Contains("duplicate key"))
                        {
                            return ConstantProps.DuplicateDataText;
                        }
                    }
                    if (e.InnerException.Message.ToLower().Contains("duplicate key "))
                    {
                        return ConstantProps.DuplicateDataText;
                    }

                    if (e.InnerException.InnerException != null)
                        if (!string.IsNullOrWhiteSpace(e.InnerException.InnerException.Message))
                        {
                            return eventtype.ToString() + " >> " + e.InnerException.InnerException.Message + " >> " + e.Message + ", " + e.InnerException.InnerException.Message;
                        }
                }
                return eventtype.ToString() + " >> " + e.Message + ", " + e.InnerException.Message;
            }
            else
            {
                return eventtype.ToString() + " >> " + e.Message;
            }
        }

    }
}
