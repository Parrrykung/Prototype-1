using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Burrow_Rune
{
    public class Button
    {
        public bool mouseHover = false;
        public bool Pressed = false;
        public Vector2 Position;
        public Color State = Color.White;
        public bool UsethisSkill = false;
        public Vector2 ShowPosition;

        public Button()
        {
            
        }
        public Button(Vector2 Position)
        {
            this.Position = Position;
        }
    }
}
