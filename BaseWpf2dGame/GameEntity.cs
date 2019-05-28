using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BaseWpf2dGame
{
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
