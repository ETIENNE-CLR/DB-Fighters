using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFighters.Utils
{
    internal static class LogicsUtils
    {
        /// <summary>
        /// Méthode qui retourne le nombre précis en fonction de son pourcentage
        /// </summary>
        public static float GetNumberFromPercentage(float percentage, float total)
        {
            return (percentage / 100f) * total;
        }
    }
}
