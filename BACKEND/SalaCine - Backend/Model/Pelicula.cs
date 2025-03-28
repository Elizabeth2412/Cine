using System;
using System.Collections.Generic;

namespace SalaCine___Backend.Model;

public partial class Pelicula
{
    public int IdPelicula { get; set; }

    public string Nombre { get; set; } = null!;

    public TimeOnly Duracion { get; set; }

    public virtual ICollection<PeliculaSalacine> PeliculaSalacines { get; set; } = new List<PeliculaSalacine>();
}
