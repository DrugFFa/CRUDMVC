using Microsoft.AspNetCore.Mvc;
using SIBKMNET_WebAPP.Data;
using SIBKMNET_WebAPP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_WebAPP.Controllers
{
    public class CountryController : Controller
    {
        SqlConnection sqlConnection;
        CountryDBAccessLayer countrydb = new CountryDBAccessLayer();
        /*
         * Data Source -> Server
         * Initial Catalog -> Database
         * User ID -> username
         * Password -> password
         * Connect Timeout
         */
        string connectionString = "Data Source=LAPTOP-LE58BBBM;Initial Catalog=SIBKMNET;" + "User ID=sibkmnet;Password=111;Connect Timeout=30;";
        public IActionResult Index()
        {
            List<Country> countrys = new List<Country>();
            CountryDAO countryDAO = new CountryDAO();

            countrys = countryDAO.FetchAll();
            return View("Index", countrys);
        }

        public IActionResult Details(int id)
        {
            CountryDAO countryDAO = new CountryDAO();
            Country country = countryDAO.FetchOne(id);
            return View("Details", country);
        }

        //CREATE

        //GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind]Country country)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string resp = countrydb.AddCountry(country);
                    TempData["msg"] = resp;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }


        //UPDATE
        //GET
        [HttpGet]
        public IActionResult Update(int id)
        {
            CountryDAO countryDAO = new CountryDAO();
            Country country = countryDAO.FetchOne(id);
            return View("Update", country);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Country country)
        {
            CountryDAO countryDAO = new CountryDAO();
            countryDAO.CreateorUpdate(country);
            return View("Details", country);
        }
        //Delete
        public IActionResult Delete(int id)
        {
            CountryDAO countryDAO = new CountryDAO();
            countryDAO.Delete(id);

            List<Country> country = countryDAO.FetchAll();
            return View("Index", country);
        }
    }
}
