using System.Collections.Generic;
using MunicipalServicesApp.Models;

namespace MunicipalServicesApp
{
    public static class IssueRepository
    {
        public static List<Issue> Issues { get; } = new List<Issue>();
    }
}