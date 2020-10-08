using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class DriverService
    {
        public List<DriverViewModel> GetAll()
        {
            var model = new DriverDao().GetAll();
            var result = new List<DriverViewModel>();
            foreach (var item in model)
            {
                result.Add(new DriverViewModel()
                {
                    Id = item.IdEmployee,
                    Name = item.FirstName + " " + item.LastName + "/" + item.IndentyficatorEmployee,
                });
            }
            return result;
        }
    }
}