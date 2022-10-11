using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geometrische_Figuren
{
    class Program
    {
        static void Main()
        {
            //TestGeoFigur test = new TestGeoFigur();
            //test.erstellenRandomKreise(5);
            //test.erstellenRandomQuadrat(5);
            //test.erstellenRandomRechteck(5);

            //test.SehenAllenDetailDesObjekts(test.GetKreisen());
            //test.SehenAllenFlaecheninhaltDesFigurList(test.GetKreisen());

            //test.SehenAllenDetailDesObjekts(test.GetQuadrats());
            //test.SehenAllenFlaecheninhaltDesFigurList(test.GetQuadrats());

            //test.SehenAllenDetailDesObjekts(test.GetRechtecks());
            //test.SehenAllenFlaecheninhaltDesFigurList(test.GetRechtecks());
            
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            
        }
    }
}
