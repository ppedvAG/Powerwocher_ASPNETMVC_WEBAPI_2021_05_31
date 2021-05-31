using DependencyInjectionsSampleLib;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course._Samples
{
    public class ServiceCollectionAndServiceProviderSample
    {
        public void Sample ()
        {
            IServiceCollection servicesCollection = new ServiceCollection();
            
            //Programmierer kann seine Objekte einbinden
            servicesCollection.AddSingleton(typeof(ICar), typeof(MockCar));

            //wenn startup fertig ist, dann wird im Hintergrund diese Zeile ausgeführt
            IServiceProvider provider = servicesCollection.BuildServiceProvider();


            //Beim instanziieren der Controller-Klasse wird anhand des Controller-Konstruktors verschiede Interface/Objekte aufgelöst.
            // Diese Codezeile geschiet im Hintergrund in der ControllerFactory-Klasse
            ICar mockCar = provider.GetRequiredService<ICar>();
        }
    }
}
