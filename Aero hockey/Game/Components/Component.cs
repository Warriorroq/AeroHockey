using System;
using System.Collections.Generic;

namespace Project.Game
{
    public abstract class Component
    {
        public GameObject parent;
        public Action OnDestroy;
        public Component(GameObject parent)
        {
            this.parent = parent;
        }
        public virtual void Update() { }
        public void Destroy() {
            OnDestroy?.Invoke();
        }
    }
}
