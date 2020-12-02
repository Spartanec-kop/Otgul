using Otgul.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otgul.Services.Interfaces
{
    public interface IReportService
    {
        string CreateWordReportForUser(User user);
        string CreateExcelReportForUser(User user);
    }
}
