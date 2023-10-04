// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


LinqQueries queries = new LinqQueries();


void PrintValues(IEnumerable<Books> listaLibros){
      Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
       foreach(var item in listaLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
void ImprimirGrupo(IEnumerable<IGrouping<int,Books>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

// PrintValues(queries.TodaLaColeccion());

// PrintValues(queries.LibrosDespuesDel2000());

// PrintValues(queries.LibrosArriba250PalabraInAction());

// Console.WriteLine($"Todos los libros tienene Status? {queries.TodosLosLibrosTienenStatus()}");

// Console.WriteLine($"Algun elemento es publicado en el 2005? {queries.AlgunoPublicado2005()}");

// PrintValues(queries.LibrosDePython());

// PrintValues(queries.LibrosDeJavaNombreAcendente());
// Console.WriteLine("\n\nDescendente\n");
// PrintValues(queries.LibrosDeMas450PaginasDecreciente());

// PrintValues(queries.TresLibrosPorfechaDeJava());

// PrintValues(queries.TercerYCuartoLibroDeMas400Paginas());

// foreach( var i in queries.TresPrimerosLibrosDeLaColeccion()){
//     Console.Write($"{i.Title} {i.PageCount}");
// }

// Console.Write(queries.CantidadLibrosEntre200y500Pag());

// Console.Write(queries.FechaDePublicacionMenor());

ImprimirGrupo(queries.LibrosDespuesdel2000AgrupadosporAno());

