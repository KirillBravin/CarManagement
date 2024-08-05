using CarManagement.Core.Interface;
using CarManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagement.Core.Services
{
    public class StaffService: IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private List<Staff> allStaff = new List<Staff>();

        public StaffService (IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        public void AddStaff(Staff staff)
        {
           _staffRepository.AddStaff(staff);
        }

        public List<Staff> GetStaff()
        {
            return _staffRepository.GetStaff();
        }

        public Staff GetStaffById(int staffId)
        {
            Staff staff = new Staff();
            foreach (Staff s in allStaff)
            {
                if (s.Id == staffId)
                {
                    staff = s;
                    break;
                }
            }
            return staff;
        }
    }
}
