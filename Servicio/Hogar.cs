using NetCoreDI.Abstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI.Servicio
{
    public class Hogar : IHogar
    {
       public Guid Id { get; private set;}

        public void Bienvenido() => Console.WriteLine("Bienvenido a casa! "+"desde instancia "+ Id.ToString());
    }
}
