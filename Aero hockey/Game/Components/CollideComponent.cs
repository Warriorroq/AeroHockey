using SFML.Graphics;
using System;
namespace Aero_hockey.Game
{
    public class CollideComponent : Component
    {
        public CollideComponent(GameObject parent) : base(parent)
        {

        }
        public void Collide(GameObject gameObject)
        {
            if (parent.shape.GetGlobalBounds().Intersects(gameObject.shape.GetGlobalBounds()))
                parent.OnCollisionWith(gameObject);
            
        }
    }
}
