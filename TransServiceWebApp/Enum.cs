using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.Models;

namespace TransServiceWebApp.Enum
{
    public enum UserType
    {
        EmployeeDriver = 1,
        EmployeeForwarder = 3,
        EmployeeServiceMan = 2,
        Client = 5,
        EmployeeOffice = 4

    }
}