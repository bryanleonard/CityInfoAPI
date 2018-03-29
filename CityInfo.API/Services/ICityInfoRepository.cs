using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        bool CityExists(int cityId);

        IEnumerable<City> GetCities();

        City GetCity(int cityId, bool includePointsOfInterest);

        IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId);

        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);

        void DeletePointOfInterest(PointOfInterest pointOfInterest);

        bool Save();

        // Consumer of the repo can keep building on IQueryable with OrderBy, Where, etc.
        // But in a way, this leaks persistence-related logic out of the repository which 
        // violates the purpose of the repository pattern.
        //Which one you choose depends on needs. But this one is straightfoward
        //IQueryable<City> GetCities();
    }
}
