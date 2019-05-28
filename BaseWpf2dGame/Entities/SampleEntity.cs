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
        private float _speedX = 20;
        private float _speedY = 20;

        public SampleEntity()
        {

        }

        public override void Update()
        {
            if (this.CurrentGame.Input.HasKeyboardInput)
            {
                switch (this.CurrentGame.Input.KeyboardStatus.Key)
                {
                    case System.Windows.Input.Key.Left:
                        this.X -= _speedX;
                        break;

                    case System.Windows.Input.Key.Right:
                        this.X += _speedX;
                        break;

                    case System.Windows.Input.Key.Up:
                        this.Y -= _speedY;
                        break;

                    case System.Windows.Input.Key.Down:
                        this.Y += _speedY;
                        break;
                }
            }
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
