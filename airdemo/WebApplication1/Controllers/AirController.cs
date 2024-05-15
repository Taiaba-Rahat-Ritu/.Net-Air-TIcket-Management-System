using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.AuthFilters;

namespace WebApplication1.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AirController : ApiController
    {
        
        // Customer Endpoints
        [HttpGet]
        [Route("api/customers/all")]
        public HttpResponseMessage GetAllCustomers()
        {
            try
            {
                var data = CustomerService.GetCustomers();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/customers/{id}")]
        public HttpResponseMessage GetCustomer(int id)
        {
            try
            {
                var data = CustomerService.GetCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/customers/create")]
        public HttpResponseMessage CreateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                var result = CustomerService.CreateCustomer(customerDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/customers/update")]
        public HttpResponseMessage UpdateCustomer(CustomerDTO customerDTO)
        {
            try
            {
                var result = CustomerService.UpdateCustomer(customerDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/customers/{id}")]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            try
            {
                var result = CustomerService.DeleteCustomer(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Flight Endpoints
        [HttpPost]
        [Route("api/flights/create")]
        public HttpResponseMessage CreateFlight(FlightDTO flightDTO)
        {
            try
            {
                var result = FlightService.CreateFlight(flightDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/flights/update")]
        public HttpResponseMessage UpdateFlight(FlightDTO flightDTO)
        {
            try
            {
                var result = FlightService.UpdateFlight(flightDTO);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/flights/{id}")]
        public HttpResponseMessage DeleteFlight(int id)
        {
            try
            {
                var result = FlightService.DeleteFlight(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
