using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {

        public static IRepo<Customer, int, bool> CustomerDataAccess()
        {
            return new CustomerRepo();
        }
        public static IRepo<Flight, int, bool> FlightDataAccess()
        {
            return new FlightRepo();
        }

        public static IRepo<User, string, bool> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Token, int, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }
    }
}
