using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace projectLinker.Controllers
{
    public class ContractorController : ApiController
    {
        // GET: Contractor
        public IEnumerable<Models.Project> Get()
        {
            return DataGetter.DataGetter.ProjectsForContractor(new Guid());
        }
    }
}