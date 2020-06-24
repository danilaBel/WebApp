using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ISmsSender
    {
        public Task SendSmsAsync(string number, string message);
    }
}
