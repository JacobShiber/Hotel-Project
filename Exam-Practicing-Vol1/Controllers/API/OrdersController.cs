using Exam_Practicing_Vol1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Exam_Practicing_Vol1.Controllers.API
{
    public class OrdersController : ApiController
    {
        static string connectionString = "Data Source=DESKTOP-76KPC67;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        OrdersContextDataContext dataContext = new OrdersContextDataContext(connectionString);
        // GET: api/Orders
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success", Orders = dataContext.OrdersTables.ToList() });
            }
            catch(SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Orders/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(new { Massage = "Success", Order = dataContext.OrdersTables.First(order => order.Id == id) });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Orders
        public IHttpActionResult Post([FromBody] OrdersTable newOrder)
        {
            try
            {
                dataContext.OrdersTables.InsertOnSubmit(newOrder);
                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success, new order added" });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Orders/5
        public IHttpActionResult Put(int id, [FromBody] OrdersTable editedOrder)
        {
            try
            {
                OrdersTable expectedOrder = dataContext.OrdersTables.First(order => order.Id == id);

                expectedOrder.CostumerId = editedOrder.CostumerId;
                expectedOrder.WorkerId = editedOrder.WorkerId;
                expectedOrder.OrderDate = editedOrder.OrderDate;
                expectedOrder.Paid = editedOrder.Paid;
                expectedOrder.Price = editedOrder.Price;

                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success, order edited" });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Orders/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                dataContext.OrdersTables.DeleteOnSubmit(dataContext.OrdersTables.First(order => order.Id == id));
                dataContext.SubmitChanges();

                return Ok(new { Massage = "Success, order deleted" });
            }
            catch (SqlException sqlEx)
            {
                return BadRequest(sqlEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
