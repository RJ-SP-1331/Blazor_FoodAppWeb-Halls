using Blazor_FoodAppWeb.Data;
using System.Collections.Generic;

namespace Blazor_FoodAppWeb.IService
{
    public interface IAdminService
    {
        void SaveOrUpdate(Admin admin);
        Admin GetAdmin(string adminId);
        List<Admin> GetAdmins();
        string Delete(string adminId);
    }
}
