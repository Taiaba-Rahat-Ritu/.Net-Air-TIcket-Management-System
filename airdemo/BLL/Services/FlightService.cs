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
    public class FlightService
    {
        public static bool CreateFlight(FlightDTO flightDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FlightDTO, Flight>();
            });
            var mapper = new Mapper(config);
            var flight = mapper.Map<Flight>(flightDTO);

            return DataAccessFactory.FlightDataAccess().Create(flight);
        }

        public static bool UpdateFlight(FlightDTO flightDTO)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<FlightDTO, Flight>();
            });
            var mapper = new Mapper(config);
            var flight = mapper.Map<Flight>(flightDTO);

            return DataAccessFactory.FlightDataAccess().Update(flight);
        }

        public static bool DeleteFlight(int id)
        {
            return DataAccessFactory.FlightDataAccess().Delete(id);
        }
        public static List<FlightDTO> GetFlights()
        {
            var data = DataAccessFactory.FlightDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Flight, FlightDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<List<FlightDTO>>(data);
            return convertedData;
        }

        public static FlightDTO GetFlight(int id)
        {
            var data = DataAccessFactory.FlightDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Flight, FlightDTO>();
            });
            var mapper = new Mapper(config);
            var convertedData = mapper.Map<FlightDTO>(data);
            return convertedData;
        }

    }
}
