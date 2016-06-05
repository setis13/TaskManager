using AutoMapper;
using TaskManager.Common.Extension;
using TaskManager.Data.Entities;
using TaskManager.Logic.Dtos;

namespace TaskManager.Logic.Mappings {
    public class BllMappingProfile : Profile {
        protected override void Configure() {
            CreateMap<Task, TaskDto>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
            CreateMap<Comment, CommentDto>().IgnoreAllNonExisting().ReverseMap().IgnoreAllNonExisting();
        }
    }
}