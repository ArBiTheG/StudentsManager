using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Application.Common.Services
{
    public record NotificationMessage(string title,string body, DateTime DateTime);
}
