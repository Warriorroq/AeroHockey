using SFML.Graphics;
using SFML.System;

namespace Aero_hockey
{
    public static class Screen
    {
        public static RenderWindow window = null;
        public static uint heightWindow = 720;
        public static uint widthWindow = 1080;
        public static Vector2f Resolution => new Vector2f(widthWindow, heightWindow);

    }
}
