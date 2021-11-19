using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Models.Entities;

namespace WebApplication2.Controllers
{
    public class userController1 : Controller
    {
        BaseData bd = new BaseData();
        Client client = new Client();

        public string SeeData()
        {
            string sql = "SELECT * FROM client";
            string result = bd.ejecutarSql(sql);

            return result;
        }

        public string InsertClient (Client model)
        {
            string sql = "INSERT INTO client(Name, Last_name, Document_id) VALUES ('"+model.Name+"','"+model.Last_name+"','"+model.Document_id+"'); ";
            string result = bd.ejecutarSql(sql);

            return result;
        }
        

    }
}
