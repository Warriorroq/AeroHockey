using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
namespace AeroHockey.Game
{
    public class Bg : GameObject
    {
        private Color color;
        public Bg(Scene scene, Shape shape) : base(scene, shape)
        {
            color = Color.Red;
        }
        protected override void OnUpdate()
        {
            shape.FillColor = color;
        }
    }
}
