using AutoMapper;
using SchoolApp.Client.DtoModel.Models;
using SchoolApp.Infrastructure.Models.Classes;

namespace PokerPlanningApp.DtoModel.Profiles;
public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Role, RoleViewModel>();
        CreateMap<RoleViewModel, Role>();
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();
        CreateMap<Person, PersonViewModel>();
        CreateMap<PersonViewModel, Person>();
    }
}
