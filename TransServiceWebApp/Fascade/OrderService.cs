using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TransServiceWebApp.DAO;
using TransServiceWebApp.Infrastucture;
using TransServiceWebApp.Interface;
using TransServiceWebApp.Models;
using TransServiceWebApp.ViewModel;

namespace TransServiceWebApp.Fascade
{
    public class OrderService
    {

        /* 
         * 
         * WSZYSTKIE ZLECENIA
         * 
         */
        private List<ShowAllOrderViewModel> Map(List<AllOrder> allOrderList)
        {
            var result = new List<ShowAllOrderViewModel>();
            foreach (var orderAll in allOrderList)
            {
                var model = new ShowAllOrderViewModel();

                model.OrderId = orderAll.IdAllOrder;
                model.NameOrder = orderAll.NameOrder;
                model.CityReception = orderAll.CityReception;
                model.MaxDateReception = orderAll.MaxDateReception;
                model.CityDelivery = orderAll.CItyDelivery;
                model.DataMaxDelivery = orderAll.DataMaxDelivery;
                model.StatusName = orderAll.Status.Name;

                result.Add(model);
            }
            return result;
        }


        public List<ShowAllOrderViewModel> GetAllOrdersClient(int idLogin)
        {
            //1
            List<AllOrder> orderList = new OrderDao().GetClientOrders(idLogin);

            return Map(orderList);
        }




        /*
         * 
         * SZCEGÓŁY ZAMÓWIENIA 
         * 
         */

        public ShowDetailsOrderViewModel GetDetailsNewOrder(int orderId)
        {
            var model = new OrderDao().GetNewOrderDetails(orderId);

            var result = new ShowDetailsOrderViewModel()
            {

                OrderId = model.IdAllOrder,
                StatusName = model.Status.Name,
                TypeCargoName = model.TypeCargo.Name,
                NameCompanyReception = model.NameCompanyReception,
                CountryReception = model.CountryReception,
                PostCodeReception = model.PostCodeReception,
                CityReception = model.CityReception,
                StreetReception = model.StreetReception,
                NumberOfBuildingReception = model.NumberOfBuildingReception,
                PhoneReception = model.PhoneReception,
                EmailReception = model.EmailReception,
                MaxDateReception = model.MaxDateReception,
                DescriptionReception = model.DescriptionReception,
                NameCompanyDelivery = model.NameCompanyDelivery,
                CountryDelivery = model.CountryDelivery,
                PostCodeDelivery = model.PostCodeDelivery,
                CityDelivery = model.CItyDelivery,
                StreetDelivery = model.StreetDelivery,
                NumberOfBuildingDelivery = model.NumberOfBuildingDelivery,
                PhoneDelivery = model.PhoneDelivery,
                EmailDelivery = model.EmailDelivery,
                DataMaxDelivery = model.DataMaxDelivery,
                DescriptionDelivery = model.DescriptionDelivery,
                LoadWidth = model.LoadWeight,
                Width = model.Width,
                Height = model.Hegiht,
                Depth = model.Depth,


            };
            return result;
        }



        public List<OrderViewModel> GetAllOrder()
        {
            var model = new OrderDao().GetAllOrder();
            var result = new List<OrderViewModel>();
            foreach (var item in model)
            {
                result.Add(new OrderViewModel()
                {
                    Id = item.IdAllOrder,
                    Name = item.NameOrder
                });
            }
            return result;
        }

        

        /*
         * 
         * DODANIE NOWEGO ZAMÓWIENIA KLIENTA
         * 
         */

        internal void AddOrderClient(NewOrderFormClientViewModel model)
        {

            AllOrder order = new AllOrder();

            order.IdTypeCargo = model.TypeCargoId;
            order.NameCompanyReception = model.NameCompanyReception;
            order.CountryReception = model.CountryReception;
            order.PostCodeReception = model.PostCodeReception;
            order.CityReception = model.CityReception;
            order.StreetReception = model.StreetReception;
            order.NumberOfBuildingReception = model.NumberOfBuildingReception;
            order.PhoneReception = model.PhoneReception;
            order.EmailReception = model.EmailReception;
            order.MaxDateReception = model.MaxDateReception;
            order.DescriptionReception = model.DescriptionReception;
            order.NameCompanyDelivery = model.NameCompanyDelivery;
            order.CountryDelivery = model.CountryDelivery;
            order.PostCodeDelivery = model.PostCodeDelivery;
            order.CItyDelivery = model.CityDelivery;
            order.StreetDelivery = model.StreetDelivery;
            order.NumberOfBuildingDelivery = model.NumberOfBuildingDelivery;
            order.PhoneDelivery = model.PhoneDelivery;
            order.EmailDelivery = model.EmailDelivery;
            order.DataMaxDelivery = model.DataMaxDelivery;
            order.DescriptionDelivery = model.DescriptionDelivery;
            order.LoadWeight = model.LoadWidth;
            order.Hegiht = model.Height;
            order.Width = model.Width;
            order.Depth = model.Depth;
            order.Quantity = model.Quantity;

            int loginIdClient = new SessionContext().GetLoginId();
            order.IdCleint = new ClientDao().GetClient(loginIdClient).IdCleint;



            new OrderDao().Save(order);
        }


        internal void ValidateAddOrder(NewOrderFormClientViewModel model)
        {

        }



        /*
         * 
         * WSZYSTKIE ZLECENIA SPEDYTOR
         * 
         */

        public List<ShowAllOrderViewModel> GetAllOrders()
        {
            //1
            List<AllOrder> orderList = new OrderDao().GetOrders();

            return Map(orderList);
        }

        /*
        * 
        * WSZYSTKIE NOWE ZLECENIA 
        * 
        */

        public List<ShowAllOrderViewModel> GetAllNewOrders()
        {
            //1
            List<AllOrder> orderList = new OrderDao().GetNewOrders();

            return Map(orderList);
        }

        /*
        * 
        * WSZYSTKIE NOWE ZLECENIA 
        * 
        */

        public List<ShowAllOrderViewModel> GetAllOrdersInProgress()
        {
            //1
            List<AllOrder> orderList = new OrderDao().GeOrdersInProgress();

            return Map(orderList);
        }

        public List<ShowAllOrderViewModel> GetAllOrdersClose()
        {
            //1
            List<AllOrder> orderList = new OrderDao().GeOrdersClose();

            return Map(orderList);
        }

        /*
         * 
         * DODANIE NOWEGO ZLECENIA SPEDYTOR
         * 
         */

        internal void AddOrderForvarder(NewOrderFormForvarderViewModel model)
        {

            AllOrder order = new AllOrder();

            order.IdCleint = model.ClientId;
            order.IdTypeCargo = model.TypeCargoId;
            order.NameCompanyReception = model.NameCompanyReception;
            order.CountryReception = model.CountryReception;
            order.PostCodeReception = model.PostCodeReception;
            order.CityReception = model.CityReception;
            order.StreetReception = model.StreetReception;
            order.NumberOfBuildingReception = model.NumberOfBuildingReception;
            order.PhoneReception = model.PhoneReception;
            order.EmailReception = model.EmailReception;
            order.MaxDateReception = model.MaxDateReception;
            order.DescriptionReception = model.DescriptionReception;
            order.NameCompanyDelivery = model.NameCompanyDelivery;
            order.CountryDelivery = model.CountryDelivery;
            order.PostCodeDelivery = model.PostCodeDelivery;
            order.CItyDelivery = model.CityDelivery;
            order.StreetDelivery = model.StreetDelivery;
            order.NumberOfBuildingDelivery = model.NumberOfBuildingDelivery;
            order.PhoneDelivery = model.PhoneDelivery;
            order.EmailDelivery = model.EmailDelivery;
            order.DataMaxDelivery = model.DataMaxDelivery;
            order.DescriptionDelivery = model.DescriptionDelivery;
            order.LoadWeight = model.LoadWidth;
            order.Hegiht = model.Height;
            order.Width = model.Width;
            order.Depth = model.Depth;
            order.Quantity = model.Quantity;


            new OrderDao().Save(order);
        }


        internal void ValidateAddOrderForvarder(NewOrderFormForvarderViewModel model)
        {

        }

        private List<ShowALLOrderDriverViewModel> MapDriver(List<AllOrder> allOrderList)
        {
            var result = new List<ShowALLOrderDriverViewModel>();
            foreach (var orderAll in allOrderList)
            {
                var model = new ShowALLOrderDriverViewModel();

                model.OrderId = orderAll.IdAllOrder;
                model.NameOrder = orderAll.NameOrder;
                model.CityReception = orderAll.CityReception;
                model.MaxDateReception = orderAll.MaxDateReception;
                model.CityDelivery = orderAll.CItyDelivery;
                model.DataMaxDelivery = orderAll.DataMaxDelivery;


                result.Add(model);
            }
            return result;
        }
        public List<ShowALLOrderDriverViewModel> GetDriverOrder(int idLogin)
        {
            var orderList = new OrderDao().GetDriverOrder(idLogin);
            return MapDriver(orderList);
        }

    }
}