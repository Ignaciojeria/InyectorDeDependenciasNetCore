using NetCoreDI.Abstacciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreDI.Servicio
{

    public class Saludo : ISaludo
    {
        private string Nombre;

        public Guid Id { get; private set; }

        public void Nombrar(string nombre)
        {
            Nombre = nombre;
        }

        public void Saludar(){
            Console.WriteLine("Hola " + Nombre);
        }


    }
}
