using DataModels.Entity;

namespace Infrastructure.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return employees.Where(e => e.firstName.ToLower().Contains(lowerCaseTerm));
        }

    }
}
