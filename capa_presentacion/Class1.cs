using System;
using System.Collections.Generic;

public class PresentationLayer
{
    private BusinessLayer businessLayer;

    public PresentationLayer()
    {
        businessLayer = new BusinessLayer();
    }

    // Método para mostrar todos los trabajadores y su sueldo neto
    public void DisplayAllWorkersAndNetSalary()
    {
        List<Worker> workers = businessLayer.GetAllWorkersAndCalculateNetSalary();

        Console.WriteLine("Lista de Trabajadores y Sueldo Neto:");
        Console.WriteLine("ID\tNombre\t\tApellidos\tSueldo Bruto\tCategoría\tSueldo Neto");
        foreach (Worker worker in workers)
        {
            Console.WriteLine($"{worker.Id}\t{worker.Name}\t\t{worker.LastName}\t{worker.Salary}\t\t{worker.Category}\t\t{worker.NetSalary}");
        }
    }
}
