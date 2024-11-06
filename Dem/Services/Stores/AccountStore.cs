using Dem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dem.Services.Stores
{
    public class AccountStore
    {
        public event Action CurrentEmployeeChanged;

        private Employee _currentEmployee;

        public Employee CurrentEmployee 
        { 
            get => _currentEmployee;
            set
            {
                _currentEmployee = value;
                CurrentEmployeeChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentEmployee != null;


        public void Logout()
        {
            CurrentEmployee = null;
        }
    }
}
