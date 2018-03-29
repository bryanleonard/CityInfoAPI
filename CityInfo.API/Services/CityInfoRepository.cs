﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {

        //constuctor injection!
        private CityInfoContext _context;
        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        // utility methods
        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public void AddPointOfInterestForCity(int cityid, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityid, false);
            city.PointsOfInterest.Add(pointOfInterest);

        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


        //

        public IEnumerable<City> GetCities()
        {
            // ToList forces query to be executed at that time. :)
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                        .Where(c => c.Id == cityId).FirstOrDefault();
            }

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest
                    .Where(p => p.CityId == cityId).OrderBy(p => p.Name).ToList();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest
                    .Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

    }
}
