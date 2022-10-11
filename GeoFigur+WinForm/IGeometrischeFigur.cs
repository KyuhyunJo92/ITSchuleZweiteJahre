using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geometrische_Figuren
{
    interface IGeometrischeFigur
    {
        
        double BerechneFlaecheninhalt();
        string NamenDesFigurUndInhalten();
        string GetArtDesFigur();

        void Paint(Graphics g);
    }
}
