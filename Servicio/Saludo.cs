using NetCoreDI.Abstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI.Servicio
{
    public class Saludo : ISaludo
    {
        public Guid Id { get; private set;}

        public void Saludar()=>Console.WriteLine("Hola Ignacio"+ " desde instancia: "+ Id.ToString());
        


    }
}
