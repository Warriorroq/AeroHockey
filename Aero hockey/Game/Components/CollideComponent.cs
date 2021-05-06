using SFML.Graphics;

namespace Project.Game
{
    public class CollideComponent : Component
    {

        public CollideComponent(GameObject parent) : base(parent) { }
        public void Collide(GameObject gameObject)
        {
            var bounds = GetBounds(gameObject);
            if (GetBounds(parent).Intersects(bounds))
                parent.OnCollisionWith(gameObject);
        }
        public FloatRect GetBounds(GameObject obj)
            => obj.GetComponent<RenderComponent>().shape.GetGlobalBounds();
    }
}
