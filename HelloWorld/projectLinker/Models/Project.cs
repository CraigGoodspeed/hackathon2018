using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectLinker.Models
{
    public class Project
    {
        /*
select 
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
         public string ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime dateCreated { get; set; }
        public string CommunityDescription { get; set; }
        public string ContractorName { get; set; }
        public string Status { get; set; }
        public decimal projectAmount { get; set; }
        public int projectPriority { get; set; }

    }
}