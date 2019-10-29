﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Infrastructure;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services
{
    public class RouteService: IRouteService
    {
        IUnitOfWork Database { get; set; }

        public RouteService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeRoute(RouteDTO routeDto)
        {

            Route route = new Route
            {

                Name = routeDto.Name,
                CoupeFare = routeDto.CoupeFare,
                ReservedSeatFare = routeDto.ReservedSeatFare,
                GeneralFare = routeDto.GeneralFare 

               
            };
            Database.Routes.Create(route);
            Database.Save();
        }

        public IEnumerable<RouteDTO> GetRoutes()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Route, RouteDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Route>, List<RouteDTO>>(Database.Routes.GetAll());
        }

        public RouteDTO GetRoute(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id маршрута", "");
            var route = Database.Routes.Get(id.Value);
            if (route == null)
                throw new ValidationException("маршрут не найден", "");

            return new RouteDTO { Name = route.Name, Id = route.Id, CoupeFare=route.CoupeFare, GeneralFare=route.GeneralFare, ReservedSeatFare= route.ReservedSeatFare };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
