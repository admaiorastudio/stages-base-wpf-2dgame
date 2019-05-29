using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BaseWpf2dGame
{
    public class Rectangle2D
    {
        public float X;
        public float Y;

        public float Width;
        public float Height;

        public float Left => this.X;
        public float Top => this.Y;
        public float Right => this.X + this.Width;
        public float Bottom => this.Y + this.Height;

        public bool Intersect(Rectangle2D rectangle2d)
        {
            if (this.Left < rectangle2d.Right && this.Right > rectangle2d.Left &&
                this.Top < rectangle2d.Bottom && this.Bottom > rectangle2d.Top)
            {
                return true;
            }

            return false;
        }
    }

    public abstract class GameEntity
    {
        public int EntityId
        {
            get;
            set;
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float Width
        {
            get;
            set;
        }

        public float Height
        {
            get;
            set;
        }

        public Rectangle2D Rectangle
        {
            get
            {
                return new Rectangle2D
                {
                    X = this.X,
                    Y = this.Y,
                    Width = this.Width,
                    Height = this.Height
                };
            }
        }

        public Game CurrentGame
        {
            get;
            set;
        }

        public GameEntity()
        {            
        }

        /// <summary>
        /// This is where all the logic of your entity should happend
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// This is where all the render of your entity should happend
        /// </summary>
        public abstract Shape Draw(Canvas canvas2d);

        public void Move(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
