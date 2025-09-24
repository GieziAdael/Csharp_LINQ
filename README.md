## Prácticas de LINQ en C#

Este proyecto es un **estudio práctico de LINQ** (Language Integrated Query) en C#.  
Su objetivo es demostrar el uso de distintas operaciones de consulta y manipulación de datos a través de colecciones en memoria.

## Descripción

El código crea dos listas en memoria:

- **celulares**: Lista de objetos `Phones` que representan diferentes modelos de teléfonos, con sus propiedades:
  - Name (modelo)
  - Brand (marca)
  - Ram (memoria RAM en GB)

- **pcountry**: Lista de objetos `PCountrys` que relacionan el **nombre de la marca** con su **país de origen**.

Sobre estas colecciones se aplican varias consultas LINQ para demostrar:

- Filtrado
- Proyecciones (selección de campos)
- Ordenamiento ascendente y descendente
- Agrupamiento y conteo
- Uniones (JOIN) entre colecciones

## Requisitos

- .NET 6.0 o superior (o la versión que uses para compilar)
- Un IDE como Visual Studio, Visual Studio Code o compatible.

## Estructura del Código

El código principal se encuentra en la clase Program dentro del método Main().  
Se realizan las siguientes operaciones con LINQ:

1. SELECT
Obtiene todos los nombres de los teléfonos:

    var consultaAll = from c in celulares
                      select c.Name;

2. SELECT con múltiples valores
Proyecta solo el nombre y la marca:

    var consultNameBrand = from c in celulares
                           select new { c.Name, c.Brand };

3. WHERE
Filtra los teléfonos con 16 GB de RAM o más:

    var consultCRAM = from c in celulares
                      where c.Ram >= 16
                      select new { c.Name, c.Brand, c.Ram };

4. ORDER BY
Ordena los modelos de Xiaomi en orden alfabético:

    var consultX = from c in celulares
                   where c.Brand == "Xiaomi"
                   orderby c.Name
                   select new { c.Name };

Y en orden descendente:

    orderby c.Name descending

5. GROUP BY
Agrupa los teléfonos por marca y cuenta cuántos modelos hay en cada una:

    var consltG = from c in celulares
                  group c by c.Brand into cantidadXMarca
                  select new
                  {
                      Brand = cantidadXMarca.Key,
                      Cant = cantidadXMarca.Count()
                  };

Luego se ordena de mayor a menor cantidad:

    orderby c.Cant descending

6. JOIN
Realiza una unión con la lista pcountry para conocer el país de origen de cada marca:

    var c_j = from c in celulares
              join marcas in pcountry on c.Brand equals marcas.Name
              select new
              {
                  Name = c.Name,
                  Brand = c.Brand,
                  Country = marcas.Country
              };

## Ejecución

1. Clona o descarga el proyecto.
2. Abre la solución en Visual Studio o el editor de tu preferencia.
3. Compila y ejecuta el programa.
4. En la consola se mostrarán los resultados de cada consulta LINQ, separados por líneas divisorias.

## Objetivo de Aprendizaje

Este código tiene un fin didáctico, ideal para:

- Comprender la sintaxis de LINQ en C#.
- Practicar operaciones básicas de filtrado, selección, ordenamiento y agrupación.
- Entender cómo realizar JOINs entre dos colecciones en memoria.

## Estructura de Clases

El proyecto requiere la definición de al menos estas clases:

    public class Phones
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Ram { get; set; }
    }

    public class PCountrys
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

(En el código original se asume que estas clases ya están definidas en el espacio de nombres Linq_Estudio.)

## Notas

- El código usa el método p.sl(); para imprimir separadores en consola, lo cual pertenece a una clase auxiliar Basura incluida en el proyecto.
  Su función es únicamente estética para facilitar la lectura de los resultados.

Autor: Práctica personal de estudio sobre LINQ en C#.
Propósito: Aprender y reforzar el uso de consultas LINQ en colecciones en memoria.
"""

