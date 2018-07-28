using MyPatchV3.UI.Models;
using MyPatchV3.UI.Utils;
using MyPatchV3.UI.DataServices.Base;
using MyPatchV3.UI.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyPatchV3.UI.ViewModels
{
    public class EmployeeListViewModel : ViewModelBase
    {
        private readonly IEmployeeListService _employeeListService;

        public ICommand ItemSelectCommand => new Command<Employee>(OnSelectEmployee);

        private Employee _selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                RaisePropertyChanged(() => SelectedEmployee);
            }
        }

        private ObservableRangeCollection<Employee> _employeeList;

        public ObservableRangeCollection<Employee> EmployeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                RaisePropertyChanged(() => EmployeeList);
            }
        }

        public ICommand RefreshCommand => new Command(RefreshEmployeesCommand);

        public EmployeeListViewModel(IEmployeeListService employeeListService)
        {
            _employeeListService = employeeListService;
            _employeeList = new ObservableRangeCollection<Employee>();
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await LoadData();
        }

        private async void RefreshEmployeesCommand(object obj)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            IsBusy = true;

            try
            {
                //var employees = GenerateStubData();
                var employees = await _employeeListService.GetEmployees();
                EmployeeList = new ObservableRangeCollection<Employee>(employees);
                SelectedEmployee = null;
            }
            catch (Exception ex) when (ex is WebException || ex is HttpRequestException)
            {
                await DialogService.ShowAlertAsync("Communication error", "Error", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in: {ex}");
            }

            IsBusy = false;
        }

        private async void OnSelectEmployee(Employee item)
        {
            if (!item.IsSelected)
            {
                Console.WriteLine("Employee selected: " + item.Name);

                if (SelectedEmployee != null)
                {
                    SelectedEmployee.IsSelected = false;
                }

                item.IsSelected = true;
                SelectedEmployee = item;
            }
        }

        public ICommand NextCommand => new Command(NextAsync);

        private async void NextAsync()
        {
            if (SelectedEmployee != null)
            {
                await NavigationService.NavigateToAsync<SyncViewModel>();
            }
            else
            {
                await DialogService.ShowAlertAsync("Please select one of the employees to proceed.", "Information", "Ok");
            }
        }

        private List<Employee> GenerateStubData()
        {
            return new List<Employee>
                {
                    new Employee
                    {
                        Id = 0,
                        Employee_ID = "V2KX201",
                        Name = "V2KX201",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 1,
                        Employee_ID = "V2KX202",
                        Name = "V2KX202",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 2,
                        Employee_ID = "V2KX203",
                        Name = "V2KX203",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 3,
                        Employee_ID = "V2KX204",
                        Name = "V2KX204",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 4,
                        Employee_ID = "V2KX205",
                        Name = "V2KX205",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 5,
                        Employee_ID = "V2KX206",
                        Name = "V2KX206",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 6,
                        Employee_ID = "V2KX207",
                        Name = "V2KX207",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 7,
                        Employee_ID = "V2KX208",
                        Name = "V2KX208",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 8,
                        Employee_ID = "V2KX209",
                        Name = "V2KX209",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 9,
                        Employee_ID = "V2KX210",
                        Name = "V2KX210",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 10,
                        Employee_ID = "V2KX211",
                        Name = "V2KX211",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 11,
                        Employee_ID = "V2KX212",
                        Name = "V2KX212",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 12,
                        Employee_ID = "V2KX213",
                        Name = "V2KX213",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 13,
                        Employee_ID = "V2KX214",
                        Name = "V2KX214",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 14,
                        Employee_ID = "V2KX215",
                        Name = "V2KX215",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 15,
                        Employee_ID = "V2KX216",
                        Name = "V2KX216",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 16,
                        Employee_ID = "V2KX217",
                        Name = "V2KX217",
                        IsSelected = false
                    },
                    new Employee
                    {
                        Id = 17,
                        Employee_ID = "V2KX218",
                        Name = "V2KX218",
                        IsSelected = false
                    }
                };
        }
    }
}
