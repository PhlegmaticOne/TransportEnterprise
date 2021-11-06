using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransportEnterprise.Models.Extensions
{
    /// <summary>
    /// Extensions for car caprk
    /// </summary>
    public static class CarParkExtensions
    {
        /// <summary>
        /// Gets semitrailers depending on a specified predicate
        /// </summary>
        public static ICollection<Semitrailer> GetSemitrailers(this CarPark carPark, Func<Semitrailer, bool> predicate) =>
            carPark.Semitrailers.Where(predicate).ToList();
        /// <summary>
        /// Gets truck tractors depending of a specified predicate
        /// </summary>
        public static ICollection<TruckTractor> GetTruckTractors(this CarPark carPark, Func<TruckTractor, bool> predicate) =>
            carPark.TruckTractors.Where(predicate).ToList();
        /// <summary>
        /// Gets first semitrailer from the car cark which is equal to specified semitrailer
        /// </summary>
        public static Semitrailer GetByPattern(this CarPark carPark, Semitrailer semitrailer) =>
            carPark.Semitrailers.FirstOrDefault(s => s.Equals(semitrailer));
        /// <summary>
        /// Gets first truck tractor from the car cark which is equal to specified truck tractor
        /// </summary>
        public static TruckTractor GetByPattern(this CarPark carPark, TruckTractor truckTractor) =>
            carPark.TruckTractors.FirstOrDefault(t => t.Equals(truckTractor));
        /// <summary>
        /// Gets string representation, which contains all semitrailers and truck tractors of car park
        /// </summary>
        /// <returns></returns>
        public static string ToStringRepresentation(this CarPark carPark) => new StringBuilder()
            .AppendLine(carPark.ToString() + "\n")
            .AppendLine("Semitrailers:")
            .AppendLine(string.Join('\n', carPark.Semitrailers.Select(s => s.ToString())) + '\n')
            .AppendLine("TruckTracktors:")
            .AppendLine(string.Join('\n', carPark.TruckTractors.Select(t => t.ToString())))
            .ToString();
    }
}
