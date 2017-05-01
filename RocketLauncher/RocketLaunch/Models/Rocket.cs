namespace RocketLaunch.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class Rocket
    {
        public string Destination { get; set; }

        [Key]
        public string Name { get; set; }

        public string Satellites { get; set; }
    }
}

