// See https://aka.ms/new-console-template for more information
using ConsoleDemo;
using ConsoleDemo.Entities;

Console.WriteLine("Hello, World!");
Console.WriteLine("creando contexto");
ContextDemo ContextDemo = new ContextDemo();
var Data = new Vehicle()
{
    Model = new Model()
    {
        Name = "modelo EFCore7 3",
    },
    Trademark = new Trademark()
    {
        Name = "Trademark EF7 3"
    },
    Description = "año description con EF7 3"
};
await ContextDemo.AddAsync(Data);
var ModelToUpdate = ContextDemo.Models.Where(o => o.Id == 10).FirstOrDefault();
ModelToUpdate.Name = "name 2";
ContextDemo.Models.Update(ModelToUpdate);
Console.WriteLine("guardando cambios");
await ContextDemo.SaveChangesAsync();
Console.WriteLine($"datos guardados: model:{Data.Model.Id} trademark:{Data.Trademark.Id} vehicle {Data.Id}");
Console.ReadLine();