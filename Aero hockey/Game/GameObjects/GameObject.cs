using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace AeroHockey.Game
{
    public abstract class GameObject
    {
        public Vector2f position;
        public Shape shape;
        public Action Destroy;
        public event Action<GameObject> Collision;
        protected List<Component> _components;
        public GameObject(Scene scene, Shape drawable)
        {
            shape = drawable;
            _components = new List<Component>();
            if(!(scene is null)) {
                CreateSceneBind(scene);
            }
            else {
                Destroy = (() => OnDestroy());
            }
        }
        public void Update()
        {
            shape.Position = position;
            foreach(var component in _components) {
                component.Update();
            }
            OnUpdate();
        }
        public void AddComponent(Component component)
            =>_components.Add(component);
        public T GetComponent<T>() where T : Component
        {
            foreach(var component in _components) {
                if (component.GetType() == typeof(T))
                    return component as T;
            }
            return default(T);
        }
        public void RemoveComponent<T>() where T : Component
            =>_components.Remove(GetComponent<T>());
        public Component GetChildComponent<T>() where T : Component
        {
            foreach (var component in _components) {
                if (component is T)
                    return component;
            }
            return default(T);
        }
        public void RemoveChildComponent<T>() where T : Component
            =>_components.Remove(GetChildComponent<T>());
        public virtual void Draw()
            =>Screen.window.Draw(shape);
        public virtual void OnCollisionWith(GameObject gameObject)
        {
            Collision?.Invoke(gameObject);
        }
        protected virtual void OnDestroy()
        {

        }
        protected virtual void OnUpdate()
        {

        }
        protected void CreateSceneBind(Scene scene)
        {
            scene.draw += Draw;
            scene.update += Update;
            Destroy = (() => {
                _components.ForEach(x => x.Destroy());
                scene.Destroy(this);
                scene.draw -= Draw;
                scene.update -= Update;
                OnDestroy();
            });
        }
    }
}
