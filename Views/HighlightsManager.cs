using MyGame.Models.Map;
using MyGame.Models;
using System.Collections.Generic;

namespace MyGame.Views
{
    internal class HighlightsManager
    {
        internal readonly Dictionary<CubeCoordinate, Image> Highlights;
        internal readonly Dictionary<Color, string> ImageString;

        internal HighlightsManager()
        {
            Highlights = new Dictionary<CubeCoordinate, Image>();
            ImageString = new Dictionary<Color, string>() 
            {
                { Color.Blue, "highlight_blue" },
                { Color.Red, "highlight_red" }
            };
        }

        internal void TurnOnHighlight(Color color, CubeCoordinate coordinate)
        {
            if (Highlights.ContainsKey(coordinate))
                return;

            string imageString = ImageString[color];
            Highlights.Add(coordinate, Program.Content.GetImage(imageString));
        }

        internal void TurnOffHighlight(CubeCoordinate coordinate)
        {
            Highlights.Remove(coordinate);
        }
    }
}
