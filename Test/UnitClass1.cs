using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Burrow_Rune
{
    public class UnitClass
    {
        public int HP;
        public int MaxHP;
        public int MP;
        public int MaxMP;
        public int Atk;
        public int Oatk;
        public int direction;
        public int ATKframe = 0;
        public Vector2 spriteLocation;
        public Vector2 spriteLocation2;
        public Color State = Color.White;
        public int speed;
        public int Ospeed;
        public bool myTurn = false;
        public bool isAttacking = false;
        public bool playable;
        public bool targeted = false;
        public bool attacked = false;
        public bool healed = false;
        public bool Alive = true;
        public Texture2D Unit_Sprite;
        public bool mouseHover = false;
        public int iconOrder;
        public Vector2 Big_iconLocation = new Vector2(1000, 1000);
        public Vector2 Small_iconLocation = new Vector2(1000, 1000);
        public Vector2 HPMPbar_iconLocation = new Vector2(1000, 1000);
        public Vector2 HPbar_Location = new Vector2(1000, 1000);
        public Vector2 MPbar_Location = new Vector2(1000, 1000);
        public Vector2 HPicon_Location = new Vector2(1000, 1000);
        public int AttackSFX;
        public List<Button> Skill_list = new List<Button>();
        public List<Button> Item_list = new List<Button>();
        public string HPtext = "";
        public string MPtext = "";

        public UnitClass()
        {

        }

        public UnitClass( bool playable, int speed, int HP, int Atk, int AttackSFX, int MP)
        {
            
            this.speed = speed;
            Ospeed = speed;
            this.playable = playable;
            this.HP = HP;
            MaxHP = HP;
            this.Atk = Atk;
            Oatk = Atk;
            this.AttackSFX = AttackSFX;
            this.MP = MP;
            MaxMP = MP;
        }

    }
}
