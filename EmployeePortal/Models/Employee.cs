using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{   
        public class Employee
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Полное имя *обязательно*")]
            [StringLength(100, ErrorMessage = "Полное имя не может быть длиннее 100 символов.")]
            [Display(Name = "Полное имя")]

            public string FullName { get; set; }
            [Required(ErrorMessage = "Электронная почта *обязательна*")]
            [EmailAddress(ErrorMessage = "Не корректный адрес электронной почты")]
            [Display(Name = "Электронная почта")]

            public string Email { get; set; }
            [Required(ErrorMessage = "Должность")]
            [StringLength(50, ErrorMessage = "Должность не может быть длиннее 50 символов.")]

            public string Position { get; set; }
            [Required(ErrorMessage = "Отделение *обязательно*")]

            public Department? Department { get; set; }
            [Required(ErrorMessage = "Дата найма *обязательно*")]
            [Display(Name = "Дата найма")]
            [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]

            public DateTime? HireDate { get; set; }
            [Required(ErrorMessage = "Дата рождения *обязательно*")]
            [Display(Name = "Дата рождения")]
            [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]

            public DateTime? DateOfBirth { get; set; }
            [Required(ErrorMessage = "Тип найма *обязательно*")]
            [Display(Name = "Тип найма")]

            public EmployeeType? Type { get; set; }
            [Required(ErrorMessage = "Пол *обязательно*")]
            [StringLength(6, ErrorMessage = "Пол должен быть МУЖ или ЖЕН")]

            public string? Gender { get; set; }
            [Required(ErrorMessage = "Зарплата *обязательно*")]
            [Range(0, double.MaxValue, ErrorMessage = "Зарплата не может быть отрицательной")]
            [DataType(DataType.Currency)]

            public decimal? Salary { get; set; }
        }
    }

