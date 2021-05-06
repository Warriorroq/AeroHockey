using SFML.Graphics;
using System;
namespace Project.Game
{
    public class CollideComponent : Component
    {

        public CollideComponent(GameObject parent) : base(parent) { }
        public void Collide(GameObject gameObject)
        {
            var bounds = gameObject.GetComponent<RenderComponent>().shape.GetGlobalBounds();
            if (parent.GetComponent<RenderComponent>().shape.GetGlobalBounds().Intersects(bounds))
                parent.OnCollisionWith(gameObject);
        }
    }
}
