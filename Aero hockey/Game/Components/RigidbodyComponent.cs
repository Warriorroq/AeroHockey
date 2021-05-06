using SFML.System;
using System;

namespace Project.Game
{
    public sealed class RigidbodyComponent : Component
    {
        public Vector2f Velocity {
            get => _velocity;
        }

        private const float _gravity = 160f;
        private Vector2f _velocity;
        public RigidbodyComponent(GameObject parent) : base(parent)
        {

        }
        public void SetVelocity(Vector2f newVelocity)
            => _velocity = newVelocity;
        public sealed override void Update()
        {
            parent.position += _velocity * Time.deltaTime;
            _velocity.Y += _gravity * Time.deltaTime;
        }
    }
}
