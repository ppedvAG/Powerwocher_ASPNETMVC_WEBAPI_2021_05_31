using System;

namespace DependencyInjectionsSampleLib
{
    #region BadCode 
    //Problem 1: DLL A - harte Verdrahtung
    //Problem 2: Programmierer A benötigt 5 Tage
    public class BadCar 
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructYear { get; set; }
    }

    //Problem 1: DLL A&B - harte Verdrahtung ->  public void RepairCar(BadCar car)
    //Problem 2: Programmierer B benötigt 3 Tage
    public class BadCarService //DLL B
    {
        public void RepairCar(BadCar car)
        {
            //Mach etwas....
        }
    }
    #endregion



    #region Good Code


    //Wir verdenden Interfaces!!!!!
    
    public interface ICar
    {
        string Brand { get; set; }
        string Model { get; set; }
        DateTime ConstructYear { get; set; }
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }

   
    //Programmierer A benötigt 5 Tage
    public class Car : ICar
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime ConstructYear { get; set; }
    }

    //Programmierer B benötigt 3 Tage
    public class CarService : ICarService
    {
        public void Repair(ICar car) //Kann ich einen Funktionstest angehen? 
        {
            //car.Model
            //Mach was..
        }
    }

    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
        public DateTime ConstructYear { get; set; } = DateTime.Now;
    }



    public class TheProgrammCSClss
    {
        public void TheMainMethode()
        {
            //Programmierer B kann an Tag 3-4 seinen Code mit einem Mock-Objekt testen. 
            ICar myTestCarObj = new MockCar();

            ICarService service = new CarService();

            service.Repair(myTestCarObj); //Somit kann ich auch Funktionstest angehen. 


        }
    }








    #endregion
}
