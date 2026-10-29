using Microsoft.Data.SqlClient;

namespace HW_260316_CarsWithCheckboxes.Models
{
    public class CarsDbManager
    {
        private string _connectionString;
        public CarsDbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Car> GetAllCars()
        {

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Cars";
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Car> cars = new List<Car>();
            while (reader.Read())
            {
                cars.Add(new Car
                {
                    Id = (int)reader["Id"],
                    Make = (string)reader["Make"],
                    Model = (string)reader["Model"],
                    Year = (int)reader["Year"],
                    Price = (decimal)reader["Price"],
                    CarType = (CarType)reader["CarType"],
                    HasLeatherSeats = (bool)reader["HasLeatherSeats"]
                });
            }

            return cars;
        }

        public void AddCar(Car car)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Cars (Make, Model, Year, Price, CarType, HasLeatherSeats) VALUES (@Make, @Model, @Year, @Price, @CarType, @HasLeatherSeats)";
            command.Parameters.AddWithValue("@Make", car.Make);
            command.Parameters.AddWithValue("@Model", car.Model);
            command.Parameters.AddWithValue("@Year", car.Year);
            command.Parameters.AddWithValue("@Price", car.Price);
            command.Parameters.AddWithValue("@CarType", car.CarType);
            command.Parameters.AddWithValue("@HasLeatherSeats", car.HasLeatherSeats);
            connection.Open();
            command.ExecuteNonQuery();
        }        
    }
}
