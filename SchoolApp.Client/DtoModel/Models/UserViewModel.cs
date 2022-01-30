using SchoolApp.Infrastructure.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Client.DtoModel.Models;
public class UserViewModel : Entity
{
    public string? email { get; set; }
    public virtual RoleViewModel? role { get; set; }
    public virtual PersonViewModel? person { get; set; }
}
