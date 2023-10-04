public class LinqQueries
{
    private List<Books> librosCollection = new List<Books>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("book.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Books>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

        }

    }
    //Toda la coleccion
    public IEnumerable<Books> TodaLaColeccion()
    {
        return librosCollection;
    }
    //Libros despues del 2000
    public IEnumerable<Books> LibrosDespuesDel2000()
    {
        //Extension method
        // return librosCollection.Where(p => p.PublishedDate.Year > 2000);

        //query method
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }
    public IEnumerable<Books> LibrosArriba250PalabraInAction()
    {
        // return librosCollection.Where(p=>p.PageCount>250 && p.Title.Contains("in Action"));
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool AlgunoPublicado2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Books> LibrosDePython()
    {
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Books> LibrosDeJavaNombreAcendente()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Books> LibrosDeMas450PaginasDecreciente()
    {
        return librosCollection.Where(p => p.PageCount >= 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Books> TresLibrosPorfechaDeJava()
    {
        return librosCollection
        .Where(p => p.Categories.Contains("Java"))
        .OrderByDescending(p => p.PublishedDate)
        .Take(3);
    }
    public IEnumerable<Books> TercerYCuartoLibroDeMas400Paginas()
    {
        return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Books> TresPrimerosLibrosDeLaColeccion()
    {
      return  librosCollection.Take(3).Select(p => new Books
        {
            Title = p.Title,
            PageCount = p.PageCount
        });

    }

    public int CantidadLibrosEntre200y500Pag()
    {
        return librosCollection.Count(p=>p.PageCount>=200 && p.PageCount<=500);
    }

    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p=>p.PublishedDate);
    }

    public IEnumerable<IGrouping<int, Books>> LibrosDespuesdel2000AgrupadosporAno()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000).GroupBy(p=> p.PublishedDate.Year);
    }
}