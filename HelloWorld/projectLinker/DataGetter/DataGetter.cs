using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projectLinker.DataGetter
{
    public class DataGetter
    {
        /*
         * select 
	p.name as projectName,
	p.description as projectDescription,
	date_created as dateCreated,
	com.description as communityName,
	worker.name as contractorName,
	s.description as Status,
	dbo.calcProjectPrice(f.id) as amount,
	[dbo].[calcPriorityForOrgsanisation](p.ID) as priority
from project p
	inner join category c on c.id = p.category_id
	left join funding f on f.id = p.funding_id
	inner join status s on s.id = p.status_id
	inner join community com on com.id= p.community_id
	left join contractor worker on worker.id = p.contractor_id
order by priority desc
;
         * */
        private static readonly string getProjectsForOrganisation = "select p.id as id,p.name as projectName,p.description as projectDescription,date_created as dateCreated,com.description as communityName,worker.name as contractorName,s.description as Status,dbo.calcProjectPrice(f.id) as amount,[dbo].[calcPriorityForOrgsanisation] (p.ID) as priority from project p inner join category c on c.id = p.category_id left join funding f on f.id = p.funding_id inner join status s on s.id = p.status_id inner join community com on com.id= p.community_id left join contractor worker on worker.id = p.contractor_id order by priority desc;";
        public static List<Models.Project> ProjectsForOrganisation(Guid organisationId)
        {
            List<Models.Project> toReturn = new List<Models.Project>();
            using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["projectLinker.Properties.Settings.hackathon_devConnectionString"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = getProjectsForOrganisation;
                SqlDataAdapter dat = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dat.Fill(ds);
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    toReturn.Add(
                            new Models.Project()
                            {
                                ProjectID = dr["id"].ToString(),
                                ProjectName = dr["projectName"].ToString(),
                                ProjectDescription = dr["projectDescription"].ToString(),
                                dateCreated = (DateTime)dr["dateCreated"],
                                CommunityDescription = dr["communityName"].ToString(),
                                ContractorName = dr["contractorName"].ToString(),
                                Status = dr["Status"].ToString(),
                                projectAmount = (decimal)dr["amount"],
                                projectPriority = (int)dr["priority"]
                            }
                        );
                }

            }
            return toReturn;
        }
    }
}