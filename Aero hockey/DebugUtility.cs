using System;
using SFML.System;
using SFML.Graphics;

namespace Aero_hockey
{
    public class DebugUtility
    {
        public static Font consoleFont;
        private static Text _LOG;

        public static void LoadContent(string font)
        {
            consoleFont = new Font(font);
            _LOG = new Text("", consoleFont, 16)
            {
                OutlineColor = Color.Black,
                Color = Color.Black,
                Position = new Vector2f(0, 0)
            };
        }
        public static void Message(GameLoop gameLoop, object message)
        {

            if (consoleFont == null)
                return;

            if (message is null)
                _LOG.DisplayedString = "NULL";
            else
                _LOG.DisplayedString = message.ToString();

            Screen.window.Draw(_LOG);
        }
    }
}
