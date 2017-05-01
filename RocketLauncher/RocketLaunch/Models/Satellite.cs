namespace RocketLaunch.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;

    public class Satellite
    {
        public string Category { get; set; }

        [Key]
        public string Name { get; set; }
    }
}

