﻿using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private DbContext _db;

        private GenericRepository<Route> _routeRepository;

        private GenericRepository<Train> _trainRepository;

        private GenericRepository<Carriage> _carriageRepository;

        private GenericRepository<Place> _placeRepository;

        private GenericRepository<Station> _stationRepository;

        private GenericRepository<RouteStation> _routeStationRepository;


        private GenericRepository<RouteDate> _routeDateRepository;

        private GenericRepository<UserPlace> _userPlaceRepository;

        
        public UnitOfWork(string connectionString)
        {
            _db = new RouteContext( connectionString);
            _routeRepository = new GenericRepository<Route>(_db);
            _routeStationRepository = new GenericRepository<RouteStation>(_db);
            _trainRepository = new GenericRepository<Train>(_db);
            _carriageRepository = new GenericRepository<Carriage>(_db);
            _placeRepository = new GenericRepository<Place>(_db); 
            _stationRepository = new GenericRepository<Station>(_db);
            _userPlaceRepository = new GenericRepository<UserPlace>(_db);
            _routeDateRepository = new GenericRepository<RouteDate>(_db);
        }
        public IRepository<Route> Routes
        {
            get
            {
                if (_routeRepository == null)
                    _routeRepository = new GenericRepository<Route>(_db);
                return _routeRepository;
            }
        }

        public IRepository<RouteStation> RouteStations
        {
            get
            {
                if (_routeStationRepository == null)
                    _routeStationRepository = new GenericRepository<RouteStation>(_db);
                return _routeStationRepository;
            }
        }

        public IRepository<RouteDate> RouteDates
        {
            get
            {
                if (_routeDateRepository == null)
                    _routeDateRepository = new GenericRepository<RouteDate>(_db);
                return _routeDateRepository;
            }
        }
        public IRepository<UserPlace> UserPlaces
        {
            get
            {
                if (_userPlaceRepository == null)
                    _userPlaceRepository = new GenericRepository<UserPlace>(_db);
                return _userPlaceRepository;
            }
        }




        public IRepository<Train> Trains
        {
            get
            {
                if (_trainRepository == null)
                    _trainRepository = new GenericRepository<Train>(_db);
                return _trainRepository;
            }
        }

        public IRepository<Carriage> Carriages
        {
            get
            {
                if (_carriageRepository == null)
                    _carriageRepository = new GenericRepository<Carriage>(_db);
                return _carriageRepository;
            }
        }

        public IRepository<Place> Places
        {
            get
            {
                if (_placeRepository == null)
                    _placeRepository = new GenericRepository<Place>(_db);
                return _placeRepository;
            }
        }

        public IRepository<Station> Stations
        {
            get
            {
                if (_stationRepository == null)
                    _stationRepository = new GenericRepository<Station>(_db);
                return _stationRepository;
            }
        }



        public void Save()
        {
            _db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
