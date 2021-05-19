using System.Collections;
using System.Collections.Generic;

namespace PhysioCam.Models
{
    public class Program
    {
        public int Id { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        
        public Client Client { get; set; }
        public Clinic Clinic { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    
    public class Clinic : User
    {
        public ICollection<Client> Clients { get; set; }
    }

    public class Client : User
    {
    }
}