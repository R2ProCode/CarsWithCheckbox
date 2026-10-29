using HW_260316_CarsWithCheckboxes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HW_260316_CarsWithCheckboxes.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=Cars;Integrated Security=true;TrustServerCertificate=true;";
        public IActionResult Index(string? sort)
        {
            CarsDbManager manager = new CarsDbManager(_connectionString);
            IEnumerable<Car> cars = manager.GetAllCars();

            var viewModel = new DisplayCarsViewModel();
            viewModel.CurrentSort = sort;

            if (string.IsNullOrEmpty(sort))
            {
                viewModel.Cars = cars.ToList();
                viewModel.CurrentSort = "asc";
                return View(viewModel);
            }
            else if (sort == "asc")
            {
                viewModel.Cars = cars.OrderBy(c => c.Year).ThenBy(c => c.Price).ToList();
            }
            else if (sort == "desc")
            {
                viewModel.Cars = cars.OrderByDescending(c => c.Year).ThenByDescending(c => c.Price).ToList();
            }
            return View(viewModel);
        }
        public IActionResult ShowAddForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            CarsDbManager manager = new CarsDbManager(_connectionString);
            manager.AddCar(car);
            return Redirect("/home/index");
        }
    }
}
