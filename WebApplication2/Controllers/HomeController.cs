using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Models.Entities;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        BaseData bd = new BaseData();
        userController1 userc = new userController1();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public string insertClient([FromBody] Client client)
        {
            string sql = "INSERT INTO client(Name, Last_name, Document_id) VALUES ('" + client.Name + "','" + client.Last_name + "','" + client.Document_id + "') ";
            string result = bd.ejecutarSql(sql);
            return result;
        }

        public string insertInvoice([FromBody] Invoice nvoice)
        {

            string sql = "";
            
            sql += $"Insert into invoice (Id_client, Cod) values ({nvoice.Id_client}, {nvoice.Cod});";
            sql += "SELECT @@IDENTITY as id;";
            
            foreach (Invoices_detail item in nvoice.details)
            {
                sql += $"Insert into invoice_datail(id_invoice, Description, Value) values (@@IDENTITY,'{item.Description}', {item.Value});";
            }

            string response = bd.ejecutarSql(sql);

            return response;
        }
        public IEnumerable<Invoice> selectInvoice(int id)
        {
            string sql = $"Select i.*, id.* from invoice i inner join invoice_datail id on i.Id = id.Id_invoice WHERE id.Id_invoice = {id}";
            DataTable dt = bd.getTable(sql);
            List<Invoice> InvoiceList = new List<Invoice>();
            List<Invoices_detail> InvoiceDList = new List<Invoices_detail>();

            InvoiceDList = (from DataRow dr in dt.Rows
                           select new Invoices_detail()
                           {
                               ID = Convert.ToInt32(dr["Id"]),
                               Description = dr["Description"].ToString(),
                               Value = Convert.ToInt32(dr["Value"]),
                           }).ToList();

            InvoiceList = (from DataRow dr in dt.Rows
                           select new Invoice()
                           {
                               ID = Convert.ToInt32(dr["Id"]),
                               Id_client = Convert.ToInt32(dr["Id_client"]),
                               Cod = Convert.ToInt32(dr["Cod"]),
                               details = InvoiceDList,
                           }).ToList();
            return InvoiceList;
        }

        public IEnumerable<Client> selectOneClients(int Id)
        {
            string sql = "SELECT * FROM client WHERE Id = '"+Id+"'";
            DataTable dt = bd.getTable(sql);
            List<Client> clientsList = new List<Client>();
            clientsList = (from DataRow dr in dt.Rows
                           select new Client()
                           {
                               Id = Convert.ToInt32(dr["Id"]),
                               Name = dr["Name"].ToString(),
                               Last_name = dr["Last_Name"].ToString(),
                               Document_id = dr["Document_ID"].ToString(),

                           }).ToList();
            return clientsList;
        }

        public IEnumerable<Client> selectClients()
        {
            string sql = "SELECT * FROM client";
            DataTable dt = bd.getTable(sql);

            List<Client> clientsList = new List<Client>();
            clientsList = (from DataRow dr in dt.Rows
                           select new Client()
                           {
                               Id = Convert.ToInt32(dr["ID"]),
                               Name = dr["Name"].ToString(),
                               Last_name = dr["Last_Name"].ToString(),
                               Document_id = dr["Document_ID"].ToString(),

                           }).ToList();
            return clientsList;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
