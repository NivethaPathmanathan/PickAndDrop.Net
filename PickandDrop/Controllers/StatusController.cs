using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using PickandDrop.Models;
using System.Data.SqlClient;

namespace PickandDrop
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StatusController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            String query = @"select StatusId, StatusName from dbo.Status";
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

        //[HttpPost]
        //public JsonResult Post(Status sts)
        //{
        //    String query = @"insert into dbo.Status values('" + sts.StatusName + @"')";
        //    DataTable table = new DataTable();
        //    String SqlDataSource = _configuration.GetConnectionString("ComplaintAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(SqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Added Sucessfully!!");

        //}

        [HttpPut]
        public JsonResult Put(Status sts)
        {
            String query = @"
                             update dbo.Status set
                             StatusName ='" + sts.StatusName + @"'
                             Where StatusId = " + sts.StatusId + @"
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

        //[HttpDelete("{id}")]
        //public JsonResult Delete(int id)
        //{
        //    String query = @"
        //                    delete from dbo.Status
        //                    where " + id + @"
        //                    ";
        //    DataTable table = new DataTable();
        //    String SqlDataSource = _configuration.GetConnectionString("ComplaintAppCon");
        //    SqlDataReader myReader;
        //    using (SqlConnection myCon = new SqlConnection(SqlDataSource))
        //    {
        //        myCon.Open();
        //        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //        {
        //            myReader = myCommand.ExecuteReader();
        //            table.Load(myReader);

        //            myReader.Close();
        //            myCon.Close();
        //        }
        //    }

        //    return new JsonResult("Successfully Deleted!!");
        //}
    }
}
