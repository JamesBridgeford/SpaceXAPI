using SpaceXAPI.Interfaces;
using System;

namespace SpaceXAPI.Models
{
    public class Launchpad : IEntity
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }

    }
}
