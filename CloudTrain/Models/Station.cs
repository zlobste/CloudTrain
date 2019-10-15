﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /*public int? RouteId { get; set; }
        public Route Route { get; set; }*/
        public ICollection<RouteStation> Routes { get; set; }
        public Station()
        {
            Routes = new List<RouteStation>();
        }
    }
}
