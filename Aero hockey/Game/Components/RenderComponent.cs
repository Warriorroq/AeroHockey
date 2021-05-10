using SFML.Graphics;

namespace Project.Game
{
    public class RenderComponent : Component
    {
        public Shape shape;
        public int layer;
        public RenderComponent(GameObject parent ,Shape shape, Scene scene) : base(parent)
        {
            this.shape = shape;
        }
        public override void Update()
            =>shape.Position = owner.position;
        public virtual void Draw()
            =>Screen.window.Draw(shape);
    }
}
