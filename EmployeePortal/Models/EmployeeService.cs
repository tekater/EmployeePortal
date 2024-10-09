using System.Xml.Linq;

namespace EmployeePortal.Models
{
    public class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1,  FullName = "Олег Денисович Иванов",         Email = "john@example.com",     Position = "Разработчик ПО",            Department = Department.Отдел_Айти,     HireDate = DateTime.Now.AddYears(-3), DateOfBirth = DateTime.Now.AddYears(-30), Type = EmployeeType.Постоянно,  Gender = "МУЖ", Salary = 60000 },
            new Employee { Id = 2,  FullName = "Евгения Александровна Грибова", Email = "jane@example.com",     Position = "Менеджер по персоналу",     Department = Department.Менеджер,       HireDate = DateTime.Now.AddYears(-5), DateOfBirth = DateTime.Now.AddYears(-35), Type = EmployeeType.Постоянно,  Gender = "ЖЕН", Salary = 80000 },
            new Employee { Id = 3,  FullName = "Семён Яков Воронов",            Email = "sam@example.com",      Position = "Продажи",                   Department = Department.Продажи,        HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-28), Type = EmployeeType.Контракт,   Gender ="МУЖ",  Salary = 50000 },
            new Employee { Id = 4,  FullName = "Анна Григорьевна Залуцкая",     Email = "anna@example.com",     Position = "Ассистент",                 Department = Department.Администрация,  HireDate = DateTime.Now.AddYears(-1), DateOfBirth = DateTime.Now.AddYears(-25), Type = EmployeeType.Временно,   Gender = "ЖЕН", Salary = 40000 },
            new Employee { Id = 5,  FullName = "Том Андреевич Мышев",           Email = "tom@example.com",      Position = "Сетевой инженер",           Department = Department.Отдел_Айти,     HireDate = DateTime.Now.AddYears(-4), DateOfBirth = DateTime.Now.AddYears(-32), Type = EmployeeType.Постоянно,  Gender = "МУЖ", Salary = 70000 },
            new Employee { Id = 6,  FullName = "Эмма Владимировна Быкова",      Email = "emma@example.com",     Position = "Специалист по персоналу",   Department = Department.Менеджер,       HireDate = DateTime.Now.AddYears(-6), DateOfBirth = DateTime.Now.AddYears(-34), Type = EmployeeType.Постоянно,  Gender = "ЖЕН", Salary = 75000 },
            new Employee { Id = 7,  FullName = "Олег Александрович Перьев",     Email = "luke@example.com",     Position = "Менеджер продаж",           Department = Department.Продажи,        HireDate = DateTime.Now.AddYears(-3), DateOfBirth = DateTime.Now.AddYears(-31), Type = EmployeeType.Контракт,   Gender = "МУЖ", Salary = 85000 },
            new Employee { Id = 8,  FullName = "Ольга Петровна Бочкарёва",      Email = "olivia@example.com",   Position = "Офис менеджер",             Department = Department.Администрация,  HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-29), Type = EmployeeType.Постоянно,  Gender = "ЖЕН", Salary = 65000 },
            new Employee { Id = 9,  FullName = "Эмилия Флоритовна Хофизова",    Email = "mia@example.com",      Position = "Системный администратор",   Department = Department.Отдел_Айти,     HireDate = DateTime.Now.AddYears(-1), DateOfBirth = DateTime.Now.AddYears(-26), Type = EmployeeType.Практика,   Gender = "ЖЕН", Salary = 30000 },
            new Employee { Id = 10, FullName = "Кирилл Евгеньевич Бандеров",    Email = "chris@example.com",    Position = "Аналитик подбора",          Department = Department.Менеджер,       HireDate = DateTime.Now.AddYears(-5), DateOfBirth = DateTime.Now.AddYears(-33), Type = EmployeeType.Временно,   Gender = "МУЖ", Salary = 55000 },
            new Employee { Id = 11, FullName = "Софья Дмитриевна Ноева",        Email = "sophia@example.com",   Position = "Специалист по продажам",    Department = Department.Продажи,        HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-27), Type = EmployeeType.Постоянно,  Gender = "ЖЕН", Salary = 52000 },
            new Employee { Id = 12, FullName = "Илья Игоревич Жирков",          Email = "liam@example.com",     Position = "Служащий ресепшна",         Department = Department.Администрация,  HireDate = DateTime.Now.AddYears(-1), DateOfBirth = DateTime.Now.AddYears(-24), Type = EmployeeType.Временно,   Gender = "МУЖ", Salary = 38000 },
            new Employee { Id = 13, FullName = "Николай Николаевич Николаев",   Email = "noah@example.com",     Position = "Системный администратор",   Department = Department.Отдел_Айти,     HireDate = DateTime.Now.AddYears(-3), DateOfBirth = DateTime.Now.AddYears(-29), Type = EmployeeType.Постоянно,  Gender = "МУЖ", Salary = 65000 },
            new Employee { Id = 14, FullName = "Изабель Андреевна Кузнецова",   Email = "isabella@example.com", Position = "Специалист по персоналу",   Department = Department.Менеджер,       HireDate = DateTime.Now.AddYears(-4), DateOfBirth = DateTime.Now.AddYears(-30), Type = EmployeeType.Постоянно,  Gender = "ЖЕН", Salary = 76000 },
            new Employee { Id = 15, FullName = "Анрей Евгеньевич Соболев",      Email = "james@example.com",    Position = "Торговый представитель",    Department = Department.Продажи,        HireDate = DateTime.Now.AddYears(-2), DateOfBirth = DateTime.Now.AddYears(-28), Type = EmployeeType.Контракт,   Gender = "МУЖ", Salary = 62000 }
         };

        public async Task<(List<Employee> Employees, int TotalCount)> GetEmployees(string search_term, string selected_department, string selected_type, int page_number, int page_size)
        {
            var filtered_employees = employees.AsQueryable();
            if (!string.IsNullOrEmpty(search_term))
            {
                filtered_employees = filtered_employees.Where(p => p.FullName.Contains(search_term, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(selected_department))
            {
                if (Enum.TryParse(selected_department, out Department department))
                {
                    filtered_employees = filtered_employees.Where(p => p.Department == department);
                }
            }
            if (!string.IsNullOrEmpty(selected_type))
            {
                if (Enum.TryParse(selected_type, out EmployeeType type))
                {
                    filtered_employees = filtered_employees.Where(p => p.Type == type);
                }
            }
            int totalCount = filtered_employees.Count();
            filtered_employees = filtered_employees.Skip((page_number - 1) * page_size).Take(page_size);
            return await Task.FromResult((filtered_employees.ToList(), totalCount));
        }

        public Employee? GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existing_employee = GetEmployeeById(employee.Id);
            if (existing_employee != null)
            {
                existing_employee.FullName      = employee.FullName;
                existing_employee.Email         = employee.Email;
                existing_employee.Position      = employee.Position;
                existing_employee.Department    = employee.Department;
                existing_employee.HireDate      = employee.HireDate;
                existing_employee.DateOfBirth   = employee.DateOfBirth;
                existing_employee.Type          = employee.Type;
                existing_employee.Gender        = employee.Gender;
                existing_employee.Salary        = employee.Salary;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null) employees.Remove(employee);
        }
    }
}