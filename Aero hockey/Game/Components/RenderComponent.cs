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
            scene.draw += Draw;
            OnDestroy = () => scene.draw -= Draw;
        }
        public override void Update()
        {
            shape.Position = parent.position;
        }
        public virtual void Draw(int layer)
        {
            if (this.layer == layer)
                Screen.window.Draw(shape);
        }
    }
}
