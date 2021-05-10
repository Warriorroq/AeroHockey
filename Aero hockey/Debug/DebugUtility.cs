using SFML.System;
using SFML.Graphics;

namespace Project.Debug
{
    public class DebugUtility
    {
        private static Font _consoleFont;
        private static Text _LOG;

        public static void LoadContent(Font font)
        {
            _consoleFont = font;
            _LOG = new Text("", _consoleFont, 16) {
                OutlineColor = Color.Black,
                Color = Color.Black,
                Position = new Vector2f(0, 0)
            };
        }
        public static void Message(object message)
        {

            if (_consoleFont == null)
                return;

            if (message is null)
                _LOG.DisplayedString = "NULL";
            else
                _LOG.DisplayedString = message.ToString();

            Screen.window.Draw(_LOG);
        }
    }
}
