﻿using System;
using System.Collections.Generic;

namespace AeroHockey.Game
{
    public abstract class Component
    {
        public GameObject parent;
        public Component(GameObject parent)
        {
            this.parent = parent;
        }
        public virtual void Update() { }
        public virtual void Destroy() { }
    }
}
