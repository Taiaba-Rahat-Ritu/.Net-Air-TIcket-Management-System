using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        public static List<CustomerDTO> GetCustomers()
        {
            var data = DataAccessFactory.CustomerDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<CustomerDTO>>(data);
            return convertedData;
        }

        public static CustomerDTO GetCustomer(int id)
        {
            var data = DataAccessFactory.CustomerDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<CustomerDTO>(data);
            return convertedData;
        }

        public static bool CreateCustomer(CustomerDTO customerDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var customer = mapper.Map<Customer>(customerDTO);

            return DataAccessFactory.CustomerDataAccess().Create(customer);
        }

        public static bool UpdateCustomer(CustomerDTO customerDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            var mapper = new Mapper(config);
            var customer = mapper.Map<Customer>(customerDTO);

            return DataAccessFactory.CustomerDataAccess().Update(customer);
        }

        public static bool DeleteCustomer(int id)
        {
            return DataAccessFactory.CustomerDataAccess().Delete(id);
        }
    }
}
