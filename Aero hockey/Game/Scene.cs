using System;
using System.Collections.Generic;
namespace Aero_hockey.Game
{
    public class Scene
    {
        public event Action update;
        public event Action draw;
        private List<GameObject> _objects;
        private List<GameObject> _objectsForDestroy;
        public void Init()
        {
            _objects = new List<GameObject>();
            _objectsForDestroy = new List<GameObject>();
        }
        public void Update()
        {
            update?.Invoke();
            DestroyObjects();
        }
        public void Draw()
        {
            draw?.Invoke();
        }
        public void Add(GameObject obj)
        {
            _objects.Add(obj);
        }
        public void Destroy(GameObject obj)
        {
            _objectsForDestroy.Add(obj);
        }
        private void DestroyObjects()
        {
            foreach(var obj in _objectsForDestroy)
            {
                _objects.Remove(obj);
                obj.Destroy();
            }
        }
    }
}
