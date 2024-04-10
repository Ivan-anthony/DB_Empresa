using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class DataAccessLayer
{
    private string connectionString = "tu_cadena_de_conexión"; // Reemplaza "tu_cadena_de_conexión" con tu conexión real

    // Método para ejecutar un procedimiento almacenado que calcula el sueldo neto de los trabajadores
    public void CalcularSueldoNeto()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("CalcularSueldoNeto", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al calcular el sueldo neto: " + ex.Message);
        }
    }

    // Método para obtener todos los trabajadores de la base de datos
    public List<Worker> GetAllWorkers()
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

                    workers.Add(worker);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener los trabajadores: " + ex.Message);
        }

        return workers;
    }
}
