using SFML.Graphics;
using SFML.System;
using System;

namespace Project.Game.AeroHokey
{
    public class GravityParticlesCollideComponent : Component
    {
        public Action CreateParticles;
        public GravityParticlesCollideComponent(GameObject parent, Scene scene, int particles) : base(parent)
        {
            CreateParticles = () => AddParticlesToScreen(scene, particles);
        }
        private void AddParticlesToScreen(Scene scene, int particles)
        {
            for (int i = 0; i < particles; i++)
            {
                scene.Add(new BallParticleWithGravity(scene,
                    new CircleShape(5)
                    {
                        FillColor = Color.Magenta,
                        Origin = new Vector2f(10, 10) / 2f
                    }, parent.position));
            }
        }
    }
}
