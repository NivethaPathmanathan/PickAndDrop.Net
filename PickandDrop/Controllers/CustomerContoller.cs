using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PickandDrop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PickandDrop
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContoller : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerContoller(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            String query = @"select Id, Name, Email, Complaint, Status from dbo.Customer";
            DataTable table = new DataTable();
            String SqlDataSource = _configuration.GetConnectionString("ComplaintAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Customer cust)
        {
            String query = @"insert into dbo.Customer values('" + cust.Name + @"',
                                                             '" + cust.Email + @"',
                                                             '" + cust.Complaint + @"',
                                                             '" + cust.Status + @"')";
            DataTable table = new DataTable();
            String SqlDataSource = _configuration.GetConnectionString("ComplaintAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Sucessfully!!");

        }

        [HttpPut]
        public JsonResult Put(Customer cust)
        {
            String query = @"
                             update dbo.Status set
                             Name ='" + cust.Name + @"',
                             Email ='" + cust.Email + @"',
                             Complaint ='" + cust.Complaint + @"',
                             Status='" + cust.Status + @"',
                             Where Id = " + cust.Id + @"
                               ";
            DataTable table = new DataTable();
            String SqlDataSource = _configuration.GetConnectionString("ComplaintAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Successfully Updated!!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            String query = @"
                            delete from dbo.Customer
                            where " + id + @"
                            ";
            DataTable table = new DataTable();
            String SqlDataSource = _configuration.GetConnectionString("ComplaintAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(SqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Successfully Deleted!!");
        }
    }
}
