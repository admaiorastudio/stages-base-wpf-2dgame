using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BaseWpf2dGame.Entities
{
    public class SampleEntity : GameEntity
    {
        public SampleEntity()
        {

        }

        public override void Update()
        {
            
        }

        public override Shape Draw(Canvas canvas2d)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Fill = Brushes.Red;
            ellipse.Width = 100;
            ellipse.Height = 100;
            return ellipse;
        }
    }
}
