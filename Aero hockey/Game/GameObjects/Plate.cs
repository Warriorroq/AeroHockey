using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace Aero_hockey.Game
{
    public class Plate : GameObject
    {
        protected float _speed = Screen.heightWindow;
        protected float _deltaSpeed = 0f;
        public Plate(Scene scene, Shape shape) : base(scene, shape)
        {
            position = new Vector2f(50, 300);
            Screen.window.KeyPressed += VelocityWithKey;
        }

        private void VelocityWithKey(object sender, KeyEventArgs e)
        {
            if(e.Code.Equals(Keyboard.Key.S))
                _deltaSpeed = _speed * Time.deltaTime;
            
            else if(e.Code.Equals(Keyboard.Key.W))
                _deltaSpeed = -_speed * Time.deltaTime;
            
        }

        public override void OnUpdate()
        {
            if (position.Y + _deltaSpeed + 100 > Screen.heightWindow || position.Y + _deltaSpeed < 0)
                _deltaSpeed = 0;
           
            position.Y += _deltaSpeed;
        }
    }
}
