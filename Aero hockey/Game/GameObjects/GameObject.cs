using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace Aero_hockey.Game
{
    public abstract class GameObject
    {
        public Vector2f position;
        public Action Destroy;
        public Shape shape;
        public List<Component> components;
        public GameObject(Scene scene, Shape drawable)
        {
            shape = drawable;
            components = new List<Component>();
            components.Add(new CollideComponent(this));
            if(!(scene is null)) {
                CreateSceneBind(scene);
            }
            else {
                Destroy = (() => OnDestroy());
            }
        }
        private void CreateSceneBind(Scene scene)
        {
            scene.draw += Draw;
            scene.update += Update;
            Destroy = (() => {
                scene.Destroy(this);
                OnDestroy();
                scene.draw -= Draw;
                scene.update -= Update;
            });
        }
        public void Update()
        {
            shape.Position = position;
            foreach(var component in components) {
                component.Update();
            }
            OnUpdate();
        }
        public T GetComponent<T>() where T : Component
        {
            foreach(var component in components) {
                if (component.GetType() == typeof(T))
                    return component as T;
            }
            return default(T);
        }
        public Component GetChildComponent<T>() where T : Component
        {
            foreach (var component in components) {
                if (component is T)
                    return component;
            }
            return default(T);
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
        public virtual void OnCollisionWith(GameObject gameObject)
        {

        }
    }
}
