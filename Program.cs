using Microsoft.Extensions.DependencyInjection;
using NetCoreDI.Abstacciones;
using NetCoreDI.Servicio;
using System;

namespace NetCoreDI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            /*Contenedor del inyector de dependencias!
             1.-Contiene las instancias que vamos a inyectar a nuestras clases
             2.- las instancias a inyectar se pueden definir como Singleton,Scopes o Transient
             
            a.-Singleton nos provee una única instancia del contenedor que será
                provista siempre que le pidamos al inyector de dependencias ese servicio.

             b.-Deberás estudiar el comportamiento de un Scope! xD
            
            c.-Un transient devuelve siempre una nueva instancia del servicio
               es cómo cuando trabajamos con dbContext y lo utilizamos per request.
             */
            var service = new ServiceCollection();
            service.AddSingleton<ISaludo, Saludo>();
            service.AddSingleton<IHogar, Hogar>();

            //la instancia saludo 1 y saludo 2 son la misma instancia que nos provee el serviceProvider
            var serviceProvider = service.BuildServiceProvider();

            ISaludo saludo1 = serviceProvider.GetService<ISaludo>();

            ISaludo saludo2= serviceProvider.GetService<ISaludo>();
            /*Imprimimos el HashCode de saludo1 y  saludo2. En consola visualizaremos que es el mismo código
               y esto es porque el inyector de dependencias nos devolvió un singleton que se asignaron
               a las instancias: saludo1, saludo2 y estas instancias referencian a un mismo objeto único
               y de acceso global.
            */
            saludo1.Nombrar("Ignacio");
            saludo1.Saludar();
            saludo2.Saludar();
            Console.WriteLine(saludo1.GetHashCode().ToString());
            Console.WriteLine(saludo2.GetHashCode().ToString());

        }
    }
}
