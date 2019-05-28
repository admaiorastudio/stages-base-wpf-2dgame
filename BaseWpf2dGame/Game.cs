using BaseWpf2dGame.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BaseWpf2dGame
{
    public class Screen
    {
        private Canvas _canvas2d;

        public double Width
        {
            get
            {
                return _canvas2d.Width;
            }
        }

        public double Height
        {
            get
            {
                return _canvas2d.Height;
            }
        }

        public Screen(Canvas canvas2d)
        {
            _canvas2d = canvas2d;
        }
    }
        


    public class Game
    {
        #region Internal Logic 

        private Canvas _canvas2d;

        private int _nextEntityId;
        private List<GameEntity> _entities;

        public Screen Screen
        {
            get;
            private set;
        }

        public Game(Canvas canvas2d)
        {
            _canvas2d = canvas2d;
            this.Screen = new Screen(canvas2d);

            _entities = new List<GameEntity>();
            InitEntities();
        }

        /// <summary>
        /// This is where all the logic of your game should happend
        /// </summary>
        public void Update()
        {
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
            SampleEntity sampleEntity = new SampleEntity();
            sampleEntity.Move(100, 100);
            AddEntity(sampleEntity);
        }
    }
}
