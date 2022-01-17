using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_Practicing_Vol1.Models
{
    public class RoomModel
    {
        public RoomModel(int id, int roomNumber, string roomType, bool isAvailable, int price)
        {
            Id = id;
            RoomNumber = roomNumber;
            RoomType = roomType;
            IsAvailable = isAvailable;
            Price = price;
        }

        public RoomModel()
        {

        }
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public bool IsAvailable { get; set; }
        public int Price { get; set; }
    }
}