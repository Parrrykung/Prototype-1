using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Test
{
    public class UnitClass
    {
        public int HP;
        public int Atk;
        public int direction;
        public Vector2 spriteLocation;
        public Color State = Color.White;
        public int speed;
        public bool myTurn = false;
        public bool isAttacking = false;
        public bool playable;
        public bool targeted = false;
        public bool attacked = false;
        public bool Alive = true;
        public Texture2D Unit_Sprite;

        public UnitClass()
        {

        }

        public UnitClass( bool playable, int speed, int HP, int Atk)
        {
            
            this.speed = speed;
            this.playable = playable;
            this.HP = HP;
            this.Atk = Atk;
        }

    }
}
