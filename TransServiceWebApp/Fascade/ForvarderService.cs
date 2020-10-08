using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class ForvarderService
    {
        internal void ValidateAcceptOrder(AcceptOrderViewModel model)
        {


        }

        public void AcceptOrder(AcceptOrderViewModel viewModel)
        {
            var orderDao = new OrderDao();
            var model = orderDao.GetOrder(viewModel.OrderId);
            model.IdEmployee = viewModel.DriverId;
            model.IdVehicle = viewModel.VehicleId;
            model.IdStatus = 2;
            orderDao.Update(model);

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

        internal void ValidateAcceptCargo(AcceptCargoViewModel model)
        {
          
        }


        public void PassCargo(AcceptCargoViewModel viewModel)
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

        public void PassCargo(PassCargoViewModel viewModel)
        {
            var orderDao = new OrderDao();
            var model = orderDao.GetOrder(viewModel.OrderId);
            model.DataIssuseCargo = viewModel.DateIssusing;
            model.LastNameAccepting = viewModel.PersonAccepting;
            model.NumberPZ = viewModel.NumberPZ;
            model.DescriptionIssusingCargo = viewModel.Descirption;
            model.IdStatus = 4;
            orderDao.Update(model);

        }

        internal void ValidatePassCargo(PassCargoViewModel model)
        {
            
        }
    }
}