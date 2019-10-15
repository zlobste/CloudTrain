﻿using System;
using System.Collections.Generic;

namespace CloudTrain.Models
{
    public class Carriage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }   //coupe, reserved seat, general
        public Train Train { get; set; }
        public int TrainId { get; set; }
        public ICollection<Place> Places { get; set; }
        public Carriage()
        {
            Places = new List<Place>();
        }
    }
}