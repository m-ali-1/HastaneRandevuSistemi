﻿namespace Hastane.Models
{
    public class Doktor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}