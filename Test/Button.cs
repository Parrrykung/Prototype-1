using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Burrow_Rune
{
    class Button
    {
        public bool mouseHover = false;
        public bool Pressed = false;
        public Vector2 Position;
        public Color State = Color.White;

        public Button()
        {
            
        }
        public Button(Vector2 Position)
        {
            this.Position = Position;
        }
    }
}
