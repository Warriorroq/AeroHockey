using SFML.System;
using SFML.Graphics;
using System;
namespace Aero_hockey.Game
{
    public abstract class GameObject
    {
        public Vector2f position;
        public Action Destroy;
        protected Shape shape;
        public GameObject(Scene scene, Shape drawable)
        {
            shape = drawable;
            if(!(scene is null))
            {
                CreateSceneBind(scene);
            }
            else
            {
                Destroy = (() => OnDestroy());
            }
        }
        private void CreateSceneBind(Scene scene)
        {
            scene.draw += Draw;
            scene.update += Update;
            Destroy = (() => {
                OnDestroy();
                scene.draw -= Draw;
                scene.update -= Update;
            });
        }
        public void Update()
        {
            shape.Position = position;
            OnUpdate();
        }
        public virtual void OnDestroy()
        {

        }
        public virtual void OnUpdate()
        {

        }
        public virtual void Draw()
        {
            Screen.window.Draw(shape);
        }
    }
}
