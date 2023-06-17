﻿namespace DriverManagementSystemAPI.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Driver()
        {
            FirstName = " "; 
            LastName = " ";
            Email = " ";
            PhoneNumber = " ";
        }
    }
}