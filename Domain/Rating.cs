using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Rating
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ProjectManagerId { get; set; }
        public Guid DeveloperId { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public DateTime DateTimeRated { get; set; } = DateTime.UtcNow;
        public SoftwareProject Project { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public Developer Developer { get; set; }
    }
}