﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CloudTrain.Models
{
    public class RouteContext: IdentityDbContext<User>
    {
        public RouteContext() : base("ConnectionRoute")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<RouteContext>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<RouteContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways< RouteContext > ());
            //Database.SetInitializer<RouteContext>(new IdentityDbInit());

        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Route> Routes{ get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Carriage> Carriages { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<UserPlace> UserPlaces { get; set; }
        public DbSet<PurchasedPlaces> PurchasedPlaces { get; set; }
        public DbSet<RouteTrain> RouteTrains{ get; set; }



        public static RouteContext Create()
        {
            return new RouteContext();
        }
    }



    
}