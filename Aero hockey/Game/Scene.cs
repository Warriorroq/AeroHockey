﻿using System;
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
            foreach (var obj1 in _objects)
            {
                foreach (var obj2 in _objects)
                {
                    if(obj1 != obj2)
                    {
                        obj1.Collide(obj2);
                    }
                }
            }
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
