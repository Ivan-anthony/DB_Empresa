using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class BusinessLayer
{
    private string connectionString = "tu_cadena_de_conexión"; // Reemplaza "tu_cadena_de_conexión" con tu conexión real

    // Método para obtener todos los trabajadores y calcular su sueldo neto
    public List<Worker> GetAllWorkersAndCalculateNetSalary()
    {
        List<Worker> workers = new List<Worker>();

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Trabajadores", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Worker worker = new Worker();
                    worker.Id = Convert.ToInt32(reader["ID"]);
                    worker.Name = reader["Nombre"].ToString();
                    worker.LastName = reader["Apellidos"].ToString();
                    worker.Salary = Convert.ToDecimal(reader["SueldoBruto"]);
                    worker.Category = reader["Categoria"].ToString();

                    // Calcular sueldo neto
                    decimal netSalary = CalculateNetSalary(worker.Salary);
                    worker.NetSalary = netSalary;

                    workers.Add(worker);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los trabajadores y calcular el sueldo neto: " + ex.Message);
        }

        return workers;
    }

    // Método para calcular el sueldo neto según la categoría del trabajador
    private decimal CalculateNetSalary(decimal salary)
    {
        decimal percentageIncrease = 0;

        if (salary <= 1000)
            percentageIncrease = 0.1m;
        else if (salary <= 2000)
            percentageIncrease = 0.2m;
        else if (salary <= 4000)
            percentageIncrease = 0.3m;
        else
            percentageIncrease = 0.4m;

        return salary * (1 + percentageIncrease);
    }
}
