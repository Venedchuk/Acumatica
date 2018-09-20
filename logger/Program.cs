using Logger.Core;
using System;

namespace logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new Logger.Core.Logger();

            log.Targets.Add(new ConsoleOutputTarget()); //пишем в консоль
            log.Targets.Add(new FileOutputTarget() { Path = @"C:/out.txt" }); //пишем в файл
            
            log.Targets.Add(new DatabaseOutputTarget()
            {
                Callback = (mgs) => {
                    //тут будем дергать провайдер базы данных и писать в нее наш msg
                    return;
                }
            }); //пишем в файл

            log.Debug("debug message");

            Console.ReadLine();
        }
    }
}
