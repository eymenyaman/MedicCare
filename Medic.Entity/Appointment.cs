using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Appointment
    {
        public int Id { get; set; }  
        public string NameSurname { get; set; } 
        public string Email { get; set; }  
        public string Phone { get; set; }  
        public DateTime Date { get; set; }
        public string Text { get; set; } 
       
    }
}
