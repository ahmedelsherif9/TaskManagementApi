using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Data;
using TaskManagement.Helper;

namespace TaskManagement.DTOs
{
    public class TaskDto : IMapFrom<Data.Task>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Data.Task , TaskDto>().ReverseMap();
        }
    }

    public class TaskModel : IMapFrom<Data.Task>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Data.Task, TaskModel>().ReverseMap();
        }
    }
}
