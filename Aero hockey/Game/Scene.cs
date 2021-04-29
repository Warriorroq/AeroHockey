using System;
using System.Collections.Generic;
using System.Linq;
namespace Aero_hockey.Game
{
    public class Scene
    {
        public event Action update;
        public event Action draw;
        private List<GameObject> _objects;
        private List<GameObject> _objectsForDestroy;
        //public int Count => _objects.Count;
        public void Init()
        {
            _objects = new List<GameObject>();
            _objectsForDestroy = new List<GameObject>();
        }
        public void Update()
        {
            CheckCollisions();
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
        private void CheckCollisions()
        {
            var colliders = _objects.Where(x => !(x.GetComponent<CollideComponent>() is null)).Select(x => x.GetComponent<CollideComponent>()).ToArray();
            foreach (var obj1 in colliders) {
                foreach (var obj2 in colliders) {
                    if(obj1 != obj2)
                        obj1.Collide(obj2.parent);
                }
            }
        }
        private void DestroyObjects()
        {
            foreach(var obj in _objectsForDestroy)
                _objects.Remove(obj);
            _objectsForDestroy.Clear();
        }
    }
}
