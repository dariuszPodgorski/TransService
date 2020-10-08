using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class CargoService
    {
        public List<TypeCargoViewModel> GetAllTypeCargo()
        {
            var model = new CargoDao().GetAllTypeCargo();
            var result = new List<TypeCargoViewModel>();
            foreach (var item in model)
            {
                result.Add(new TypeCargoViewModel()
                {
                    Id = item.IdTypeCargo,
                    Name = item.Name
                });
            }
            return result;
        }


        public void AcceptCargo(AcceptCargoViewModel viewModel)
        {
            var orderDao = new OrderDao();
            var model = orderDao.GetOrder(viewModel.OrderId);
            model.DateAcceptedCargo = viewModel.DateAccepting;
            model.LastNameIssusing = viewModel.PersonIssusing;
            model.NumerWZ = viewModel.NumberWZ;
            model.DescriptionAcceptedCargo = viewModel.Descirption;
           
            model.IdStatus = 3;
            orderDao.Update(model);

        }

        internal void ValidateAccpetCargo(AcceptCargoViewModel model)
        {

        }
    }
}