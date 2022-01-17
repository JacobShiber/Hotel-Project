using Exam_Practicing_Vol1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Exam_Practicing_Vol1.Controllers.API
{
    public class GuestsController : ApiController
    {
        HoteldbContext dataContext = new HoteldbContext();
        // GET: api/Guests
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(new { Massage = "Success", Guests = dataContext.GuestsTable.ToList()});
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

        // GET: api/Guests/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                GuestModel expectedGuest = await dataContext.GuestsTable.FindAsync(id);
                if (expectedGuest.FirstName != null) return Ok(new { Massage = "Success", expectedGuest });
                else return NotFound();
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

        // POST: api/Guests
        public async Task<IHttpActionResult> Post([FromBody] GuestModel newGuest)
        {
            try
            {
                dataContext.GuestsTable.Add(newGuest);
                await dataContext.SaveChangesAsync();

                return Ok(new { Massage = "Success, new guest added" });
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

        // PUT: api/Guests/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] GuestModel editedGuest)
        {
            try
            {
                GuestModel expectedGuest = await dataContext.GuestsTable.FindAsync(id);

                if(expectedGuest.FirstName != null)
                {
                    expectedGuest.FirstName = editedGuest.FirstName;
                    expectedGuest.LastName = editedGuest.LastName;
                    expectedGuest.Gender = editedGuest.Gender;
                    expectedGuest.BirthDate = editedGuest.BirthDate;
                    expectedGuest.CheckIn = editedGuest.CheckIn;

                    await dataContext.SaveChangesAsync();

                    return Ok(new { Massage = "Success, guest edited" });
                }

                return NotFound();

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

        // DELETE: api/Guests/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                GuestModel expectedGuest = await dataContext.GuestsTable.FindAsync(id);

                if (expectedGuest.FirstName != null)
                {
                    dataContext.GuestsTable.Remove(expectedGuest);

                    await dataContext.SaveChangesAsync();

                    return Ok(new { Massage = "Success, guest deleted" });
                }
                return NotFound();
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
