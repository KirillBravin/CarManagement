using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarManagement.Core.Models;

namespace CarManagement.Core.Interface
{
    public interface IStaffRepository
    {
        void AddStaff(Staff staff);
        List<Staff> GetStaff();
        Staff GetStaffById(int staffId);
    }
}
