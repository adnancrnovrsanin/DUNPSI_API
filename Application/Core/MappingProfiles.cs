using System.Globalization;
using AutoMapper;
using Domain;
using Domain.ModelsDTOs;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateMap<Source, Destination>();
            CreateMap<AppUser, AppUser>();
            CreateMap<SoftwareProject, SoftwareProject>();
            CreateMap<SoftwareCompany, SoftwareCompany>();
            CreateMap<Team, Team>();
            CreateMap<ProjectManager, ProjectManager>();
            CreateMap<ProductManager, ProductManager>();
            CreateMap<Developer, Developer>();
            CreateMap<Message, Message>();
            CreateMap<Rating, Rating>();
            CreateMap<Requirement, Requirement>();

            CreateMap<Developer, DeveloperDto>();
            CreateMap<ProjectManager, ProjectManagerDto>()
                .ForMember(d => d.CurrentTeamId, o => o.MapFrom(s => s.ManagedTeams.FirstOrDefault(t => t.Project.Finished == false).Id));
            CreateMap<ProductManager, ProductManagerDto>();
            CreateMap<Team, TeamDto>()
                .ForMember(t => t.ProjectId, o => o.MapFrom(s => s.Project.Id))
                .ForMember(t => t.Developers, o => o.MapFrom(s => s.AssignedDevelopers.Select(d => d.Developer)));
            CreateMap<SoftwareProject, SoftwareProjectDto>()
                .ForMember(p => p.DueDate, o => o.MapFrom(s => s.DueDate.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture)));
        }
    }
}