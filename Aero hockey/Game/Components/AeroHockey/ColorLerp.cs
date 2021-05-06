using SFML.Graphics;
namespace Project.Game.AeroHokey
{
    public class ColorLerp : Component
    {
        public float speed = 1f;
        private Color _deltaColor;
        private Shape _shape;
        public ColorLerp(GameObject parent, Shape shape, Color startColor, Color endColor, float time) : base(parent)
        {
            _shape = shape;
            _shape.FillColor = startColor;
            var color = endColor - startColor;
            var alfa = Time.deltaTime / time * speed;
            color.A = (byte)(color.A * alfa);
            color.R = (byte)(color.R * alfa);
            color.G = (byte)(color.G * alfa);
            color.B = (byte)(color.B * alfa);
            _deltaColor = color;
        }
        public override void Update()
        {
            _shape.FillColor = _shape.FillColor + _deltaColor;
        }
    }
}
