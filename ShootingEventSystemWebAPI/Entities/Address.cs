﻿using System.ComponentModel.DataAnnotations;

namespace ShootingEventSystemWebAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string PostalCode { get; set; }

    }
}
