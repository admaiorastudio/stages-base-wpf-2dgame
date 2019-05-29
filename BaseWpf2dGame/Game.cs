using BaseWpf2dGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace BaseWpf2dGame
{
    public class Screen
    {
        private Canvas _canvas2d;

        public double Left
        {
            get
            {
                return 0;
            }
        }

        public double Top
        {
            get
            {
                return 0;
            }
        }


        public double Width
        {
            get
            {
                return _canvas2d.ActualWidth;
            }
        }

        public double Height
        {
            get
            {
                return _canvas2d.ActualHeight;
            }
        }

        public Screen(Canvas canvas2d)
        {
            _canvas2d = canvas2d;
        }
    }

    public class Input
    {
        public KeyEventArgs KeyboardStatus
        {
            get;
            set;
        }

        public bool HasKeyboardInput
        {
            get { return this.KeyboardStatus != null; }
        }            
    }
        


    public class Game
    {
        #region Internal Logic 

        private Canvas _canvas2d;

        private int _nextEntityId;
        private List<GameEntity> _entities;

        private bool _isInitialized;

        public Input Input
        {
            get;
            private set;
        }

        public Screen Screen
        {
            get;
            private set;
        }      

        public IReadOnlyList<GameEntity> Entities
        {
            get { return _entities; }
        }

        public Game(Canvas canvas2d)
        {
            _canvas2d = canvas2d;
            this.Screen = new Screen(canvas2d);

            _entities = new List<GameEntity>();
            
            this.Input = new Input();            
        }

        /// <summary>
        /// This is where all the logic of your game should happend
        /// </summary>
        public void Update()
        {
            if (!_isInitialized)
            {
                _isInitialized = true;
                InitEntities();
            }

            foreach (var entity in _entities)
                entity.Update();            
        }

        /// <summary>
        /// This is where all the render of your game should happend
        /// </summary>
        public void Draw()
        {
            _canvas2d.Children.Clear();
            foreach (var entity in _entities)
            {
                Shape shape = entity.Draw(_canvas2d);
                _canvas2d.Children.Add(shape);
                Canvas.SetLeft(shape, entity.X);
                Canvas.SetTop(shape, entity.Y);                
            }

        }

        /// <summary>
        /// This method add a new entity in the list of entities handled by the game
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private int AddEntity(GameEntity entity)
        {
            _nextEntityId++;
            entity.EntityId = _nextEntityId;
            entity.CurrentGame = this;
            _entities.Add(entity);

            return entity.EntityId;
        }

        #endregion

        /// <summary>
        /// Initialize here your entities
        /// </summary>
        private void InitEntities()
        {            
            Ball ball = new Ball(30, 30, 2);
            ball.Move((float)this.Screen.Width / 2f - ball.Width / 2f, (float)this.Screen.Height / 2f - ball.Height / 2f);
            AddEntity(ball);

            Player player = new Player(PlayerNumber.Player);
            player.Move(0, 490);
            AddEntity(player);

            Player player2 = new Player(PlayerNumber.Player2);
            player2.Move(1890, 490);
            AddEntity(player2);
        }
    }
}
