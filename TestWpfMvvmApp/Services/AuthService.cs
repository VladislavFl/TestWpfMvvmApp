using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpfMvvmApp.Services
{
    public class AuthService
    {
        public event Action? OnUserAuthenticated;

        private bool _isAuthenticated;

        public bool IsAuthenticated
        {
            get => _isAuthenticated;
            set
            {
                if (_isAuthenticated != value)
                {
                    _isAuthenticated = value;
                    OnUserAuthenticated?.Invoke();
                }
            }
        }
    }
}
