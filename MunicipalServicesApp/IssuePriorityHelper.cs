using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public static class IssuePriorityHelper
    {
        public static int GetPriority(string category)
        {
            switch (category)
            {
                case "Electricity":
                case "Water and Sanitation":
                    return 3;

                case "Roads and Potholes":
                case "Traffic Lights":
                case "Street Lights":
                    return 2;

                default:
                    return 1;
            }
        }

        public static string GetPriorityName(int priority)
        {
            switch (priority)
            {
                case 3: return "High";
                case 2: return "Medium";
                default: return "Low";
            }
        }
    }
}
