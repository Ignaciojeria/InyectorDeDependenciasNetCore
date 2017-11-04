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
             
            //Instancia global y única. Consume pocos recursos pero no nos serviría trabajar en las request de un api
            // donde implique hacer persistencia de datos.
            a.-Singleton: nos provee una única instancia del contenedor que será
                provista siempre que le pidamos al inyector de dependencias el uso de ese servicio.
            

            //un poco más eficiente y nos serviría para inyectar dependenciar en un api rest por ejemplo.
             b.-Scope:el contenedor nos provee un singleton pero cada vez que
                      hacemos una solicitud de ese singleton se crea uno nuevo a partir de esa instancia a nivel de request,
                      es decir, que llamas a un singleton, al hacer una solicitud del uso de ese servicio que contiene
                      un singleton crea internamente otra instancia única a partir del singleton que contiene el contenedor
                      y puedes modificar esa instancia de forma local a lo largo del request sin tocar el singleton global
                      es cómo una nueva instancia per request (por solicitud) a nivel de scope.
                      
            //consume más recursos.
            c.-Un transient devuelve siempre una nueva instancia del servicio cada vez que lo solicitemos.
             */
            var services = new ServiceCollection();
            services.AddSingleton<ISaludo, Saludo>();
            services.AddSingleton<IHogar, Hogar>();

            //la instancia saludo 1 y saludo 2 son la misma instancia que nos provee el serviceProvider
            var serviceProvider = services.BuildServiceProvider();

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

            /*Ejemplo Scope Que toma un singleton y en base a ese singleton crea una nueva instancia dentro de la petición
             (Instancia per request en este ejemplo puntual) */
            using (var scope = services.BuildServiceProvider().CreateScope()) {
                var saludo3 = scope.ServiceProvider.GetService<ISaludo>();
                Console.WriteLine(saludo3.GetHashCode().ToString());
            }

        }
    }
}
