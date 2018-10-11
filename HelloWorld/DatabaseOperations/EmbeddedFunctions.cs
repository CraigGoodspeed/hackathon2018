using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
    private static readonly string priorityForOrganisation = "select sum(score) from (select sum(priority_value) as score from project inner join category on category.id = project.category_id where project.id = @projectid union all select sum(priority_score) score from priority_calculation inner join priority_definition pd on pd.id = priority_calculation.priority_id where project_id = @projectid) as a;";
    private static readonly string createFinancialTree = "createFinancialTree";
    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static SqlInt32 calcPriorityForOrgsanisation(SqlGuid projectGuid)
    {
        if (projectGuid.IsNull)
            return 0;
        int toReturn = 0;
        using (SqlConnection conn = new SqlConnection("context connection = true"))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = priorityForOrganisation;
            cmd.Parameters.AddWithValue("@projectid", projectGuid);
            object returned = cmd.ExecuteScalar();
            if (!returned.Equals(DBNull.Value))
                toReturn = (int)returned;
        }
        return toReturn;
    }

    [SqlFunction(DataAccess = DataAccessKind.Read)]
    public static SqlDecimal calcProjectPrice(SqlGuid projectGuid)
    {
        if (projectGuid.IsNull)
            return 0;
        decimal toReturn = 0;
        using (SqlConnection conn = new SqlConnection("context connection = true"))
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = createFinancialTree;
            cmd.Parameters.AddWithValue("@top_id", projectGuid);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dat.Fill(ds);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                string id = dr["id"].ToString();
                if (isLeaf(id,ds))
                {
                    toReturn += (decimal)dr["amount"];
                }
            }
        }
        return toReturn;
    }
    private static bool isLeaf(string id, DataSet ds)
    {
        foreach(DataRow dr in ds.Tables[0].Rows)
        {
            if (id.Equals(dr["pid"].ToString()))
                return false;
        }
        return true;
    }
}
