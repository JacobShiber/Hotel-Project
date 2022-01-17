using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exam_Practicing_Vol1.Models
{
    public class GuestModel
    {
        public GuestModel(int id, string firstName, string lastName, string gender, DateTime birthDate, DateTime checkIn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            CheckIn = checkIn;
        }

        public GuestModel()
        {

        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CheckIn { get; set; }
    }
}