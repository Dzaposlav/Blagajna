using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OOblagajna.Controllers;

namespace OOblagajna
{
    public enum mjernaJed
    {
        poKomadu, poKilogramu

    };
    class Program
    {
        static void Main(string[] args)
        {
            MainController test = new MainController();
            test.start();
        }


    }




}
