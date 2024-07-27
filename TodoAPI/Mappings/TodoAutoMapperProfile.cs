using AutoMapper;
using TodoAPI.Todo;

namespace TodoAPI.Mappings
{

    public class TodoAutoMapperProfile : Profile
    {
        public TodoAutoMapperProfile() {

            CreateMap<TodoPostDTO,TodoModel>().ReverseMap();
            CreateMap<TodoPutDTO,TodoModel>().ReverseMap();
        
        }
    }
}
