using SFML.Graphics;
using SFML.System;

namespace AeroHockey
{
    public static class Screen
    {
        public static RenderWindow window = null;
        public static uint heightWindow = 720;
        public static uint widthWindow = 1080;
        public static Vector2u Resolution => new Vector2u(widthWindow, heightWindow);

    }
}
