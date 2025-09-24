using Linq_Estudio;
using System;

class Program
{
    public static void Main(string[] args)
    {
        var p = new Basura();
        var celulares = new List<Phones>()
{
            new Phones(){Name = "15 Ultra 5G", Brand = "Xiaomi", Ram = 16},
            new Phones(){Name = "X200 Pro", Brand = "Vivo", Ram = 12},
            new Phones(){Name = "G32", Brand = "Motorola", Ram = 4},
            new Phones(){Name = "Redmi Note 12s", Brand = "Xiaomi", Ram = 8},
            new Phones(){Name = "16 Pro Max", Brand = "iPhone", Ram = 16},
            new Phones(){Name = "13 Pro", Brand = "iPhone", Ram = 8},
            new Phones(){Name = "Galaxy S25 Ultra", Brand = "Samsung", Ram = 16},
            new Phones(){Name = "14 Pro", Brand = "iPhone", Ram = 12}
        };

        var pcountry = new List<PCountrys>()
        {
            new PCountrys(){Name = "Xiaomi", Country = "China"},
            new PCountrys(){Name = "Vivo", Country = "China"},
            new PCountrys(){Name = "Motorola", Country = "EEUU"},
            new PCountrys(){Name = "iPhone", Country = "EEUU"},
            new PCountrys(){Name = "Samsung", Country = "South Korea"}
        };

        //Usar LINQ para consultar, ordenar, agrupar, etc//

        //SELECT
        var consultaAll = from c in celulares
                          select c.Name;

        foreach (var c in consultaAll)
        {
            System.Console.WriteLine(c);
        }

        p.sl();

        //SELECT dos valores
        var consultNameBrand = from c in celulares
                               select new { c.Name, c.Brand};

        foreach (var c in consultNameBrand)
        {
            System.Console.WriteLine($"{c.Brand} {c.Name}");
        }

        p.sl();

        //WHERE
        var consultCRAM = from c in celulares
                          where c.Ram >= 16
                          select new { c.Name, c.Brand, c.Ram };

        foreach (var c in consultCRAM)
        {
            System.Console.WriteLine($"{c.Brand} {c.Name} - {c.Ram} RAM");
        }

        p.sl();

        //Ordenado ABC
        var consultX = from c in celulares
                       where c.Brand == "Xiaomi"
                       orderby c.Name
                       select new { c.Name };

        foreach (var c in consultX)
        {
            System.Console.WriteLine(c.Name);
        }

        p.sl();

        //Ordenado ABC desentiente
        var consultXnt = from c in celulares
                       where c.Brand == "Xiaomi"
                       orderby c.Name descending
                       select new { c.Name };

        foreach (var c in consultXnt)
        {
            System.Console.WriteLine(c.Name);
        }

        p.sl();

        //GROUP BY

        var consltG = from c in celulares
                     group c by c.Brand into cantidadXMarca
                      select new
                     {
                         Brand = cantidadXMarca.Key,
                         Cant = cantidadXMarca.Count()
                     };

        //Ordenar de mayor a menor numero de dispositivos X Marca
        var conslGOrder = from c in consltG
                          orderby c.Cant descending
                          select new
                          {
                              c.Brand,
                              c.Cant
                          };

        foreach (var c in conslGOrder)
        {
            System.Console.WriteLine($"{c.Brand}: {c.Cant}");
        }

        p.sl();

        //JOIN
        var c_j = from c in celulares
                  join marcas in pcountry on c.Brand equals marcas.Name
                  select new
                  {
                      Name = c.Name,
                      Brand = c.Brand,
                      Country = marcas.Country
                  };

        foreach (var c in c_j)
        {
            System.Console.WriteLine ($"{c.Brand} {c.Name} es de {c.Country}");
        }

        Console.ReadKey();
    }
}