using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace udfFunctions
{
    public class EmbeddedFunctions
    {
        private static string priorityForOrganisation = "select sum(priority_score) from priority_calculation inner join priority_definition pd on pd.id = priority_calculation.priority_id where project_id = @projectid;";
        [SqlFunction(DataAccess = DataAccessKind.Read)]
        public static int calcPriorityForOrgsanisation(Guid projectGuid)
        {
            int toReturn = 0;
            using(SqlConnection conn = new SqlConnection("context connection = true"))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = priorityForOrganisation;
                cmd.Parameters.AddWithValue("@projectid", projectGuid);
                object returned = cmd.ExecuteScalar();
                if (returned != null)
                    toReturn = (int)returned;
            }
            return toReturn;
        }
    }
}
