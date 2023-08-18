using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.SoftwareProjects.DTOs
{
    public class RequirementsRequestParams
    {
        public Guid ProjectId { get; set; }
        public string Status { get; set; }
    }
}