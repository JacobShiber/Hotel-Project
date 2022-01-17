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
    public class RoomsController : ApiController
    {
        string connectionString = "Data Source=DESKTOP-76KPC67;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: api/Rooms
        public IHttpActionResult Get()
        {
            try
            {
                List<RoomModel> roomsList = new List<RoomModel>();

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM RoomsTable";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            roomsList.Add(new RoomModel(dataReader.GetInt32(0), dataReader.GetInt32(1), dataReader.GetString(2), dataReader.GetBoolean(3), dataReader.GetInt32(4)));
                        }
                    }
                    connection.Close();
                    return Ok(new { Massage = "Success", roomsList });
                }
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

        // GET: api/Rooms/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                RoomModel expectedRoom = new RoomModel();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"SELECT * FROM RoomsTable WHERE RoomsTable.Id = {id} ";

                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            expectedRoom.Id = dataReader.GetInt32(0);
                            expectedRoom.RoomNumber = dataReader.GetInt32(1);
                            expectedRoom.RoomType = dataReader.GetString(2);
                            expectedRoom.IsAvailable = dataReader.GetBoolean(3);
                            expectedRoom.Price = dataReader.GetInt32(4);
                        }
                    }
                    connection.Close();
                    if (expectedRoom.RoomType != null) return Ok(new { Massage = "Success", expectedRoom });
                    else return NotFound();

                }
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

        // POST: api/Rooms
        public IHttpActionResult Post([FromBody] RoomModel newRoom)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"INSERT INTO RoomsTable (RoomNumber, RoomType, IsAvailable, Price) VALUES ({newRoom.RoomNumber}, '{newRoom.RoomType}', '{newRoom.IsAvailable}', {newRoom.Price} )";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rows = command.ExecuteNonQuery();

                    connection.Close();

                    return Ok(new { Massage = "Success, new room added" });
                }
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

        // PUT: api/Rooms/5
        public IHttpActionResult Put(int id, [FromBody] RoomModel editedRoom)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"UPDATE RoomsTable SET RoomNumber = {editedRoom.RoomNumber}, RoomType = '{editedRoom.RoomType}', IsAvailable = '{editedRoom.IsAvailable}', Price = {editedRoom.Price} WHERE RoomsTable.Id = {id} ";

                    SqlCommand command = new SqlCommand(query, connection);

                    int rows = command.ExecuteNonQuery();

                    connection.Close();
                    return Ok(new { Massage = "Success, room edited" });
                }
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

        // DELETE: api/Rooms/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = $@"DELETE FROM RoomsTable WHERE RoomsTable.Id = {id}";

                    SqlCommand command = new SqlCommand(query, connection);

                    int rows = command.ExecuteNonQuery();

                    connection.Close();

                    return Ok(new { Massage = "Success, room deleted" });
                }
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
