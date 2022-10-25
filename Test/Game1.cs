﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace Burrow_Rune
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardState _keyboardState;
        private KeyboardState Old_keyboardState;
        private MouseState Old_mouseState;
        private SpriteFont font;

        private float totalElapsed;
        private float timePerFrame;
        private int framePerSec;
        private Vector2 SetPO1 = new Vector2(560, 240);
        private Vector2 SetPO2 = new Vector2(860, 180);
        private Vector2 SetPO3 = new Vector2(620, 180);
        private int frame;
        private bool timeLoad;
        private int frameInCombat;
        private int Enemywaitingtime = 0;
        private int Partywaitingtime = 0;
        private int roomNum = 1;
        private int target = 0;
        private int ATKcount = 0;
        private int turn;
        private int iconOrder = 0;
        private string BattleTxt = "";
        private bool isFighting = false;
        private bool Resting = false;
        private bool isInteracting = false;
        bool isMap;
        bool isBattle;
        bool isTitle;
        bool isEvent;
        bool isLose;
        bool isRest;
        bool isCharactor;
        private bool Attacking = false;
        private bool Skilling = false;
        private bool Skilling2 = false;
        private bool Skilling3 = false;
        private bool Iteming = false;
        private bool Iteming2 = false;
        private bool Iteming3 = false;
        private int UseSkill = 0;
        private int UseItem = 0;

        private Texture2D first_floor_Background;
        private Texture2D Beetle_Text;
        private Texture2D Rocky_Text;
        private Texture2D Beetle_Icon;
        private Texture2D Rocky_Icon;
        private Texture2D Golem_Texture;
        private Texture2D Golem_Icon;
        private Texture2D Lurker_Texture;
        private Texture2D Lurker_Small_Icon;
        private Texture2D Lurker_Big_Icon;
        private Texture2D Inventor_Texture;
        private Texture2D Inventor_Small_Icon;
        private Texture2D Inventor_Big_Icon;
        private Texture2D Blood_Maiden_Texture;
        private Texture2D Blood_Maiden_Small_Icon;
        private Texture2D Blood_Maiden_Big_Icon;
        private Texture2D Dragonic_Texture;
        private Texture2D Dragonic_Small_Icon;
        private Texture2D Dragonic_Big_Icon;
        private Texture2D Arrow_Texture;
        private Texture2D Attack_Texture;
        private Texture2D Item_Texture;
        private Texture2D Skill_Texture;
        private Texture2D Turn_Order_Texture;
        private Texture2D Turn_Selector_Texture;
        private Texture2D FightNode_Texture;
        private Texture2D EventNode_Texture;
        private Texture2D RestNode_Texture;
        private Texture2D HPbar_Texture;

        public UnitClass Lurker = new UnitClass(true, 6, 30, 5, 0);
        public UnitClass Golem = new UnitClass(false,4, 40, 5, 3);
        public UnitClass inventor = new UnitClass(true, 5, 30, 5, 1);
        public UnitClass Beetle1 = new UnitClass(false,5, 10, 5, 3);
        public UnitClass Beetle2 = new UnitClass(false, 5, 10, 5, 3);
        public UnitClass Beetle3 = new UnitClass(false, 5, 10, 5, 3);
        public UnitClass Rocky1 = new UnitClass(false, 3, 10, 5, 3);
        public UnitClass Rocky2 = new UnitClass(false, 3, 10, 5, 3);
        public UnitClass Rocky3 = new UnitClass(false, 3, 10, 5, 3);
        public UnitClass Blood_Maiden = new UnitClass(true, 3, 30, 5, 2);
        public UnitClass Dragonic_hunter = new UnitClass(true, 3, 30, 6, 4);
        private UnitClass Nul = new UnitClass();

        private Button Attack_B = new Button(new Vector2(100, 360));
        private Button Skill_B = new Button(new Vector2(130, 410));
        private Button Item_B = new Button(new Vector2(100, 460));
        private Button Fight_B1 = new Button(new Vector2(1000, 1000));
        private Button Fight_B2 = new Button(new Vector2(1000, 1000));
        private Button Event_B1 = new Button(new Vector2(1000, 1000));
        private Button Event_B2 = new Button(new Vector2(1000, 1000));
        private Button Rest_B = new Button(new Vector2(1000, 1000));
        
        private Button Double_Slash = new Button(new Vector2(1000, 1000));
        private Button Wide_Slash = new Button(new Vector2(1000, 1000));

        private Button HeathPotion = new Button(new Vector2(1000, 1000));

        private Vector2 Turn_Selector_Position;
        private Vector2 Turn_Order_Position = new Vector2(0, 360);
        private Vector2 Arrow_Position = new Vector2(1000, 1000);

        private List<UnitClass> Party = new List<UnitClass>();
        private List<UnitClass> EnemyGroup = new List<UnitClass>();
        private List<Button> ButtoninBattle = new List<Button>();
        private List<Button> ButtoninMap = new List<Button>();
        private List<SoundEffect> BattleSFX = new List<SoundEffect>();

        private Song TitleBGM;
        private Song EventMapBGM;
        private Song BattleBGM_1;
        private Song BattleBGM_2;
        private Song BossBGM;
        private Song ShopBGM;
        private SoundEffect ClickSFX;


        //ok
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 1440;
            _graphics.PreferredBackBufferHeight = 560;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Beetle_Text = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Beetle/Flying-Rock_Sheet");
            Rocky_Text = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Rocky/Hermit-Rock-Sheet");
            Beetle_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Beetle/Flying-Rock-Icon");
            Rocky_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Rocky/Hermit-Rock-Icon");
            Golem_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Golem/Golem_Sprite_sheet");
            Dragonic_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Dragonic_hunter/Dragonic Sheet");
            Dragonic_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Dragonic Icon");
            Blood_Maiden_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Blood_maiden/Blood maiden sprite sheet-export");
            Blood_Maiden_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Blood Maiden Icon");
            Blood_Maiden_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Blood_maiden/Blood_maiden_sprite_sheet");
            Golem_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Golem/Golem-Sheet");
            Inventor_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Inventor/Inventor Sprite Sheet-export");
            Inventor_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Inventor Icon");
            Inventor_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Inventor/Inventor_Sprite_Sheet");
            Lurker_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Lurker/Lurker Sprite Sheet-export");
            Lurker_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Lurker Icon");
            Lurker_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Lurker/Lurker_Sprite_Sheet");
            first_floor_Background = Content.Load<Texture2D>("Asset 2D/Background/1st_floor_2");
            Arrow_Texture = Content.Load<Texture2D>("Asset 2D/UI/Arrow");
            Attack_Texture = Content.Load<Texture2D>("Asset 2D/UI/Attack");
            Item_Texture = Content.Load<Texture2D>("Asset 2D/UI/Item");
            Skill_Texture = Content.Load<Texture2D>("Asset 2D/UI/Skill");
            Turn_Order_Texture  = Content.Load<Texture2D>("Asset 2D/UI/Turn-Order-Hub");
            Turn_Selector_Texture = Content.Load<Texture2D>("Asset 2D/UI/Turn-Selector");
            FightNode_Texture = Content.Load<Texture2D>("Asset 2D/UI/Fight Node");
            EventNode_Texture = Content.Load<Texture2D>("Asset 2D/UI/Event Node");
            HPbar_Texture = Content.Load<Texture2D>("Asset 2D/UI/HP bar");
            RestNode_Texture = Content.Load<Texture2D>("Asset 2D/UI/Rest Node");

            font = Content.Load<SpriteFont>("font");

            TitleBGM = Content.Load<Song>("BGM/at-the-bottom-of-the-sea-where-the-sun-never-reaches-112916");
            EventMapBGM = Content.Load<Song>("BGM/a-beautiful-step-99284");
            BattleBGM_1 = Content.Load<Song>("BGM/light-15800");
            BattleBGM_2 = Content.Load<Song>("BGM/epic-recovery-9797");
            BossBGM = Content.Load<Song>("BGM/go-back-to-the-heavens-49981");
            ShopBGM = Content.Load<Song>("BGM/fruit-9530");
            ClickSFX = Content.Load<SoundEffect>("SFX/Ui_Click");

            MediaPlayer.Play(TitleBGM);

            framePerSec = 2;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            timeLoad = false;
            frameInCombat = 0;
            turn = 0;
            
            isBattle = false;
            isMap = false;
            isTitle = true;
            isEvent = false;
            isLose = false;
            isRest = false;
            isCharactor = false;

            ButtoninBattle.Add(Attack_B);
            ButtoninBattle.Add(Skill_B);
            ButtoninBattle.Add(Item_B);

            ButtoninMap.Add(Fight_B1);
            ButtoninMap.Add(Event_B1);
            ButtoninMap.Add(Fight_B2);
            ButtoninMap.Add(Event_B2);
            ButtoninMap.Add(Rest_B);

            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Sword_Hori"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Blow_Hori"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Philip_Hit"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Greed_Stab"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Effect_Heal"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Result_WaveLose"));

            Lurker.Skill_list.Add(Double_Slash);
            Lurker.Skill_list.Add(Wide_Slash);

            Lurker.Item_list.Add(HeathPotion);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _keyboardState = Keyboard.GetState();
            if (isBattle == true)
            {
                UpdateGameplay();
            }
            if (isMap == true)
            {
                UpdateEventMap();
            }
            if (isTitle == true)
            {
                UpdateTitle();
            }
            if (isEvent == true)
            {
                UpdateEvent();
            }
            if (isLose == true)
            {
                UpdateLose();
            }
            if (isRest == true)
            {
                UpdateRest();
            }
            if (isCharactor == true)
            {
                UpdateCharactor();
            }

            Old_keyboardState = _keyboardState;
            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if (isBattle == true)
            {
                DrawBattale1();
            }
            if (isMap == true)
            {
                DrawEventMap();
            }
            if (isTitle == true)
            {
                DrawTitle();
            }
            if (isEvent == true)
            {
                DrawEvent();
            }
            if (isLose == true)
            {
                DrawLose();
            }
            if (isRest == true)
            {
                DrawRest();
            }
            if (isCharactor == true)
            {
                DrawCharactor();
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % 4;
                totalElapsed -= timePerFrame;
            }
        }

        private void UpdateGameplay()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            var TurnOrder = new List<UnitClass>(Party.Count + EnemyGroup.Count);
            TurnOrder.AddRange(Party);
            TurnOrder.AddRange(EnemyGroup);

            for (int c = 0; c < (TurnOrder.Count - 1); c++)
            {
                for (int d = 0; d < TurnOrder.Count - c - 1; d++)
                {
                    if (TurnOrder[d].speed < TurnOrder[d + 1].speed)
                    {
                        Nul = TurnOrder[d];
                        TurnOrder[d] = TurnOrder[d + 1];
                        TurnOrder[d + 1] = Nul;
                    }
                }
            }

            for (int i = 0; i < TurnOrder.Count; i++)
            {
                Rectangle unitRectangle = new Rectangle((int)TurnOrder[i].spriteLocation.X, (int)TurnOrder[i].spriteLocation.Y, 270, 250);
                for (int m = 0; m < TurnOrder[i].Skill_list.Count; m++)
                {
                    if (m == 0)
                    {
                        TurnOrder[i].Skill_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y + 100);
                    }
                    if (m == 1)
                    {
                        TurnOrder[i].Skill_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y + 160);
                    }
                }
                for (int m = 0; m < TurnOrder[i].Skill_list.Count; m++)
                {
                    if (m == 0)
                    {
                        TurnOrder[i].Item_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y + 100);
                    }
                }
                if (unitRectangle.Contains(mousePosition))
                {
                    TurnOrder[i].mouseHover = true;
                }
                else
                {
                    TurnOrder[i].mouseHover = false;
                }
                if (i == turn)
                {
                    TurnOrder[i].myTurn = true;
                }
                if (TurnOrder[i].Alive == false)
                {
                    TurnOrder[i].State = Color.Black;
                }
                if (TurnOrder[i].myTurn == true && TurnOrder[i].Alive == false)
                {
                    turn += 1;
                    iconOrder += 1;
                    TurnOrder[i].myTurn = false;
                }

                if (TurnOrder[i].myTurn == true && TurnOrder[i].Alive == true)
                {
                    Turn_Selector_Position = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y + 10);
                    TurnOrder[i].Big_iconLocation = new Vector2(0, 380);
                    TurnOrder[i].Small_iconLocation = new Vector2(1000, 1090);

                    if (TurnOrder[i].playable == true)
                    {
                        if (mouseState.RightButton != ButtonState.Pressed && Old_mouseState.RightButton == ButtonState.Pressed)
                        {
                            Attacking = false;
                            Skilling = false;
                            Skilling2 = false;
                            Skilling3 = false;
                            Iteming = false;
                            Iteming2 = false;
                            Iteming3 = false;
                            for (int n = 0; n < TurnOrder[i].Skill_list.Count; n++)
                            {
                                TurnOrder[i].Skill_list[n].Position = new Vector2(1000, 1000);
                                TurnOrder[i].Skill_list[n].Pressed = false;
                                TurnOrder[i].Skill_list[n].mouseHover = false;
                            }
                            for (int n = 0; n < TurnOrder[i].Item_list.Count; n++)
                            {
                                TurnOrder[i].Item_list[n].Position = new Vector2(1000, 1000);
                                TurnOrder[i].Item_list[n].Pressed = false;
                                TurnOrder[i].Item_list[n].mouseHover = false;
                            }
                            for (int m = 0; m < ButtoninBattle.Count; m++)
                            {
                                ButtoninBattle[m].Pressed = false;
                                ButtoninBattle[m].mouseHover = false;
                            }
                        }
                        for (int n = 0; n < ButtoninBattle.Count; n++)
                        {
                            if(TurnOrder[i].isAttacking == true)
                            {
                                ButtoninBattle[n].Pressed = false;
                                for (int m = 0; m < TurnOrder[i].Skill_list.Count; m++)
                                {
                                    TurnOrder[i].Skill_list[m].Pressed = false;
                                }
                            }

                            if (ButtoninBattle[n].Pressed == false && Attacking == false)
                            {
                                Rectangle buttonRectangle = new Rectangle((int)ButtoninBattle[n].Position.X, (int)ButtoninBattle[n].Position.Y, 160, 50);
                                if (buttonRectangle.Contains(mousePosition))
                                {
                                    ButtoninBattle[n].mouseHover = true;
                                }
                                else
                                {
                                    ButtoninBattle[n].mouseHover = false;
                                }
                                if (ButtoninBattle[n].mouseHover == true)
                                {
                                    Arrow_Position = new Vector2(ButtoninBattle[n].Position.X + 160, ButtoninBattle[n].Position.Y + 10);
                                }
                                if (ButtoninBattle[n].mouseHover == false && ButtoninBattle[n].Pressed == false)
                                {
                                    ButtoninBattle[n].State = Color.White;
                                }
                                if (mouseState.LeftButton == ButtonState.Pressed && ButtoninBattle[n].mouseHover == true)
                                {
                                    ButtoninBattle[n].State = Color.Gray;
                                    ButtoninBattle[n].Pressed = true;
                                    ClickSFX.CreateInstance().Play();
                                    if (ButtoninBattle[n] == Attack_B)
                                    {
                                        Attacking = true;
                                    }
                                    if (ButtoninBattle[n] == Skill_B)
                                    {
                                        Skilling = true;
                                    }
                                    if (ButtoninBattle[n] == Item_B)
                                    {
                                        Iteming = true;
                                    }
                                }
                            }
                            if (ButtoninBattle[n].Pressed == false && Attacking == true)
                            {

                            }
                        }

                        if (Attacking == true)
                        {
                            for (int m = 0; m < EnemyGroup.Count; m++)
                            {
                                if (EnemyGroup[m].mouseHover == true)
                                {
                                    EnemyGroup[m].State = Color.Gray;
                                }
                                else
                                {
                                    EnemyGroup[m].State = Color.White;
                                }
                                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && EnemyGroup[m].mouseHover == true && EnemyGroup[m].Alive == true)
                                {
                                    TurnOrder[i].isAttacking = true;
                                    timeLoad = true;
                                    EnemyGroup[m].attacked = true;
                                    EnemyGroup[m].HP -= TurnOrder[i].Atk;
                                    EnemyGroup[m].spriteLocation2 = EnemyGroup[m].spriteLocation;
                                    EnemyGroup[m].spriteLocation.X += 20;
                                    TurnOrder[i].ATKframe = 1;
                                    BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                }
                            }
                        }
                        if (Skilling == true)
                        {
                            for (int m = 0; m < TurnOrder[i].Skill_list.Count; m++)
                            {
                                TurnOrder[i].Skill_list[m].Position = TurnOrder[i].Skill_list[m].ShowPosition;
                                Rectangle buttonRectangle = new Rectangle((int)TurnOrder[i].Skill_list[m].Position.X, (int)TurnOrder[i].Skill_list[m].Position.Y, 160, 50);
                                if (buttonRectangle.Contains(mousePosition))
                                {
                                    TurnOrder[i].Skill_list[m].mouseHover = true;
                                }
                                else
                                {
                                    TurnOrder[i].Skill_list[m].mouseHover = false;
                                }
                                if (TurnOrder[i].Skill_list[m].mouseHover == false && ButtoninBattle[m].Pressed == false)
                                {
                                    TurnOrder[i].Skill_list[m].State = Color.White;
                                }
                                if (TurnOrder[i].Skill_list[m].Pressed == true)
                                {
                                    TurnOrder[i].Skill_list[m].State = Color.Gray;
                                }
                                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && TurnOrder[i].Skill_list[m].mouseHover == true)
                                {
                                    Skilling2 = true;
                                    TurnOrder[i].Skill_list[m].Pressed = true;
                                    if (TurnOrder[i].Skill_list[m] == Double_Slash)
                                    {
                                        UseSkill = 1;
                                        BattleTxt = "Attack one target twice";
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Wide_Slash)
                                    {
                                        UseSkill = 2;
                                        BattleTxt = "Attack all enemy once";
                                    }
                                }
                                
                                if (Skilling2 == true)
                                {
                                    for (int n = 0; n < EnemyGroup.Count; n++)
                                    {
                                        if (EnemyGroup[n].mouseHover == true)
                                        {
                                            EnemyGroup[n].State = Color.Gray;
                                        }
                                        else
                                        {
                                            EnemyGroup[n].State = Color.White;
                                        }
                                        if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && EnemyGroup[n].mouseHover == true && EnemyGroup[n].Alive == true)
                                        {
                                            Skilling3 = true;
                                            target = n;
                                        }
                                        
                                    }
                                }
                                if (Skilling3 == true)
                                {
                                    if (UseSkill == 1)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            EnemyGroup[target].attacked = true;
                                            EnemyGroup[target].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[target].spriteLocation2 = EnemyGroup[target].spriteLocation;
                                            EnemyGroup[target].spriteLocation.X += 20;
                                            TurnOrder[i].ATKframe = 1;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                        Partywaitingtime += 1;
                                        if (Partywaitingtime == 20)
                                        {
                                            TurnOrder[i].isAttacking = true;
                                            timeLoad = true;
                                            EnemyGroup[target].attacked = true;
                                            EnemyGroup[target].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[target].spriteLocation2 = EnemyGroup[target].spriteLocation;
                                            EnemyGroup[target].spriteLocation.X += 20;
                                            TurnOrder[i].ATKframe = 1;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                    }
                                    if (UseSkill == 2)
                                    {
                                        TurnOrder[i].isAttacking = true;
                                        TurnOrder[i].ATKframe = 1;
                                        if (ATKcount < EnemyGroup.Count)
                                        {
                                            EnemyGroup[ATKcount].attacked = true;
                                            EnemyGroup[ATKcount].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[ATKcount].spriteLocation2 = EnemyGroup[ATKcount].spriteLocation;
                                            EnemyGroup[ATKcount].spriteLocation.X += 20;
                                            ATKcount += 1;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                        else
                                        {
                                            timeLoad = true;
                                        }

                                    }
                                }
                            }
                        }
                        if (Iteming == true)
                        {
                            for (int m = 0; m < TurnOrder[i].Item_list.Count; m++)
                            {
                                TurnOrder[i].Item_list[m].Position = TurnOrder[i].Item_list[m].ShowPosition;
                                Rectangle buttonRectangle = new Rectangle((int)TurnOrder[i].Item_list[m].Position.X, (int)TurnOrder[i].Item_list[m].Position.Y, 160, 50);
                                if (buttonRectangle.Contains(mousePosition))
                                {
                                    TurnOrder[i].Item_list[m].mouseHover = true;
                                }
                                else
                                {
                                    TurnOrder[i].Item_list[m].mouseHover = false;
                                }
                                if (TurnOrder[i].Item_list[m].mouseHover == false && ButtoninBattle[m].Pressed == false)
                                {
                                    TurnOrder[i].Item_list[m].State = Color.White;
                                }
                                if (TurnOrder[i].Item_list[m].Pressed == true)
                                {
                                    TurnOrder[i].Item_list[m].State = Color.Gray;
                                }
                                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && TurnOrder[i].Item_list[m].mouseHover == true)
                                {
                                    Iteming2 = true;
                                    TurnOrder[i].Item_list[m].Pressed = true;
                                    if (TurnOrder[i].Item_list[m] == HeathPotion)
                                    {
                                        UseItem = 1;
                                        BattleTxt = "Heal one ally 20 ";
                                    }
                                }
                                if (Iteming2 == true)
                                {
                                    Partywaitingtime += 1;
                                    for (int n = 0; n < Party.Count; n++)
                                    {
                                        if (Party[n].mouseHover == true)
                                        {
                                            Party[n].State = Color.Gray;
                                        }
                                        else
                                        {
                                            Party[n].State = Color.White;
                                        }
                                        if (Partywaitingtime > 5)
                                        {
                                            if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && Party[n].mouseHover == true && Party[n].Alive == true)
                                            {
                                                Party[n].healed = true;
                                                Party[n].HP += 20;
                                                {
                                                    if (Party[n].HP > Party[n].MaxHP)
                                                    {
                                                        Party[n].HP = Party[n].MaxHP;
                                                    }
                                                }
                                                BattleSFX[4].CreateInstance().Play();
                                                timeLoad = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (TurnOrder[i].playable == false && TurnOrder[i].Alive == true)
                    {
                        if (Enemywaitingtime == 0)
                        {
                            Random r = new Random();
                            target = r.Next(0, Party.Count);
                            if (Party[target].Alive == false)
                            {
                                if (target == Party.Count - 1)
                                {
                                    target = 0;
                                    Party[target].targeted = true;
                                }
                                if (target < Party.Count - 1)
                                {
                                    target += 1;
                                    Party[target].targeted = true;
                                }
                            }
                            if (Party[target].Alive == true)
                            {
                                Party[target].targeted = true;
                            }
                        }
                        Enemywaitingtime += 1;
                        if (Enemywaitingtime == 50)
                        {
                            TurnOrder[i].ATKframe = 1;
                            TurnOrder[i].isAttacking = true;
                            timeLoad = true;
                            Party[target].attacked = true;
                            Party[target].HP -= TurnOrder[i].Atk;
                            Party[target].spriteLocation2 = Party[target].spriteLocation;
                            Party[target].spriteLocation.X -= 20;
                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                        }
                    }

                    if (TurnOrder[i].Alive == false)
                    {
                        timeLoad = false;
                        frameInCombat = 0;
                        turn++;
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].isAttacking = false;
                        Enemywaitingtime = 0;
                    }
                }
                if (TurnOrder[i].isAttacking == false && TurnOrder[i].targeted == false && TurnOrder[i].myTurn == false && TurnOrder[i].mouseHover == false && TurnOrder[i].Alive == true && TurnOrder[i].healed == false)
                {
                    TurnOrder[i].State = Color.White;
                }
                if (frameInCombat > 30 && TurnOrder[i].myTurn == true)
                {
                    for (int m = 0; m < TurnOrder.Count; m++)
                    {
                        TurnOrder[m].targeted = false;
                        TurnOrder[m].attacked = false;
                        TurnOrder[m].healed = false;
                        for (int n = 0; n < TurnOrder[i].Skill_list.Count;n++)
                        {
                            TurnOrder[i].Skill_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Skill_list[n].Pressed = false;
                            TurnOrder[i].Skill_list[n].mouseHover = false;
                        }
                        for (int n = 0; n < TurnOrder[i].Item_list.Count; n++)
                        {
                            TurnOrder[i].Item_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Item_list[n].Pressed = false;
                            TurnOrder[i].Item_list[n].mouseHover = false;
                        }
                    }
                    for (int m = 0; m < ButtoninBattle.Count; m++)
                    {
                        ButtoninBattle[m].Pressed = false;
                        ButtoninBattle[m].mouseHover = false;
                    }
                    timeLoad = false;
                    frameInCombat = 0;
                    TurnOrder[i].ATKframe = 0;
                    turn++;
                    Attacking = false;
                    Skilling = false;
                    Skilling2 = false;
                    Skilling3 = false;
                    Iteming = false;
                    Iteming2 = false;
                    Iteming3 = false;
                    BattleTxt = "";
                    TurnOrder[i].myTurn = false;
                    TurnOrder[i].isAttacking = false;
                    Enemywaitingtime = 0;
                    Partywaitingtime = 0;
                    ATKcount = 0;
                    iconOrder += 1;
                    UseSkill = 0;
                    TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                }
                if (TurnOrder[i].targeted == true)
                {
                    TurnOrder[i].State = Color.HotPink;
                }
                if (TurnOrder[i].attacked == true)
                {
                    TurnOrder[i].State = Color.Red;
                }
                if (TurnOrder[i].healed == true)
                {
                    TurnOrder[i].State = Color.Green;
                }
                if (TurnOrder[i].attacked == false && TurnOrder[i].Alive == true)
                {
                    TurnOrder[i].State = Color.White;
                }

                if (TurnOrder[i].HP <= 0)
                {
                    TurnOrder[i].spriteLocation = new Vector2(1000, 1000);
                    TurnOrder[i].Alive = false;
                    

                }
                if (TurnOrder.Count == 6)
                {
                    if (i - iconOrder == 1 || i - iconOrder == -5)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 300);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 2 || i - iconOrder == -4)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(60, 250);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 3 || i - iconOrder == -3)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 200);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 4 || i - iconOrder == -2)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(60, 150);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 5 || i - iconOrder == -1)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 100);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                }
                if (TurnOrder.Count == 5)
                {
                    if (i - iconOrder == 1 || i - iconOrder == -4)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 300);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 2 || i - iconOrder == -3)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(60, 250);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 3 || i - iconOrder == -2)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 200);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 4 || i - iconOrder == -1)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(60, 150);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                }
                if (TurnOrder.Count == 4)
                {
                    if (i - iconOrder == 1 || i - iconOrder == -3)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 300);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 2 || i - iconOrder == -2)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(60, 250);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 3 || i - iconOrder == -1)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 200);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                }
                if (TurnOrder.Count == 3)
                {
                    if (i - iconOrder == 1 || i - iconOrder == -2)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 300);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                    if (i - iconOrder == 2 || i - iconOrder == -1)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(60, 250);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                }
                if (TurnOrder.Count == 2)
                {
                    if (i - iconOrder == 1 || i - iconOrder == -1)
                    {
                        TurnOrder[i].Small_iconLocation = new Vector2(0, 300);
                        TurnOrder[i].Big_iconLocation = new Vector2(1000, 1000);
                    }
                }
            }

            if (timeLoad == true)
            {
                frameInCombat += 1;
            }
            if (turn > TurnOrder.Count - 1)
            {
                turn = 0;
            }
            if (iconOrder == TurnOrder.Count)
            {
                iconOrder = 0;
            }

            if (EnemyGroup.Count == 3)
            {
                if (EnemyGroup[0].Alive == false && EnemyGroup[1].Alive == false && EnemyGroup[2].Alive == false)
                {
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                        for (int n = 0; n < TurnOrder[i].Skill_list.Count; n++)
                        {
                            TurnOrder[i].Skill_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Skill_list[n].Pressed = false;
                            TurnOrder[i].Skill_list[n].mouseHover = false;
                        }
                        for (int n = 0; n < TurnOrder[i].Item_list.Count; n++)
                        {
                            TurnOrder[i].Item_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Item_list[n].Pressed = false;
                            TurnOrder[i].Item_list[n].mouseHover = false;
                        }
                    }
                    MediaPlayer.Play(EventMapBGM);
                    ResetCombat();
                    RandomNode();
                    isMap = true;
                    isBattle = false;
                }
            }
            if (EnemyGroup.Count == 2)
            {
                if (EnemyGroup[0].Alive == false && EnemyGroup[1].Alive == false)
                {
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                        for (int n = 0; n < TurnOrder[i].Skill_list.Count; n++)
                        {
                            TurnOrder[i].Skill_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Skill_list[n].Pressed = false;
                            TurnOrder[i].Skill_list[n].mouseHover = false;
                        }
                        for (int n = 0; n < TurnOrder[i].Item_list.Count; n++)
                        {
                            TurnOrder[i].Item_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Item_list[n].Pressed = false;
                            TurnOrder[i].Item_list[n].mouseHover = false;
                        }
                    }
                    MediaPlayer.Play(EventMapBGM);
                    ResetCombat();
                    RandomNode();
                    isMap = true;
                    isBattle = false;
                }
            }
            if (EnemyGroup.Count == 1)
            {
                if (EnemyGroup[0].Alive == false)
                {
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                        for (int n = 0; n < TurnOrder[i].Skill_list.Count; n++)
                        {
                            TurnOrder[i].Skill_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Skill_list[n].Pressed = false;
                            TurnOrder[i].Skill_list[n].mouseHover = false;
                        }
                        for (int n = 0; n < TurnOrder[i].Item_list.Count; n++)
                        {
                            TurnOrder[i].Item_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Item_list[n].Pressed = false;
                            TurnOrder[i].Item_list[n].mouseHover = false;
                        }
                    }
                    MediaPlayer.Play(EventMapBGM);
                    ResetCombat();
                    RandomNode();
                    isMap = true;
                    isBattle = false;
                }
            }

            if (Party.Count == 3)
            {
                if (Party[0].Alive == false && Party[1].Alive == false && Party[2].Alive == false)
                {
                    MediaPlayer.Play(TitleBGM);
                    BattleSFX[5].CreateInstance().Play();
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                        for (int n = 0; n < TurnOrder[i].Skill_list.Count; n++)
                        {
                            TurnOrder[i].Skill_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Skill_list[n].Pressed = false;
                            TurnOrder[i].Skill_list[n].mouseHover = false;
                        }
                        for (int n = 0; n < TurnOrder[i].Item_list.Count; n++)
                        {
                            TurnOrder[i].Item_list[n].Position = new Vector2(1000, 1000);
                            TurnOrder[i].Item_list[n].Pressed = false;
                            TurnOrder[i].Item_list[n].mouseHover = false;
                        }
                    }
                    ResetCombat();
                    isLose = true;
                    isBattle = false;
                }
            }
            if (Party.Count == 2)
            {
                if (Party[0].Alive == false && Party[1].Alive == false)
                {
                    MediaPlayer.Play(TitleBGM);
                    BattleSFX[5].CreateInstance().Play();
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                    }
                    ResetCombat();
                    isLose = true;
                    isBattle = false;
                }
            }
            if (Party.Count == 1)
            {
                if (Party[0].Alive == false)
                {
                    MediaPlayer.Play(TitleBGM);
                    BattleSFX[5].CreateInstance().Play();
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                    }
                    ResetCombat();
                    isLose = true;
                    isBattle = false;
                }
            }

            Old_mouseState = mouseState;

            
        }

        private void UpdateEventMap()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

            for (int i = 0; i < ButtoninMap.Count; i++)
            {
                Rectangle buttonRectangle = new Rectangle((int)ButtoninMap[i].Position.X, (int)ButtoninMap[i].Position.Y, 215, 215);
                if (buttonRectangle.Contains(mousePosition))
                {
                    ButtoninMap[i].mouseHover = true;
                }
                else
                {
                    ButtoninMap[i].mouseHover = false;
                }
                if (ButtoninMap[i].mouseHover == true)
                {
                    ButtoninMap[i].State = Color.Gray;
                }
                if (ButtoninMap[i].mouseHover == false && ButtoninMap[i].Pressed == false)
                {
                    ButtoninMap[i].State = Color.White;
                }
                if (mouseState.LeftButton != ButtonState.Pressed && ButtoninMap[i].mouseHover == true && Old_mouseState.LeftButton == ButtonState.Pressed)
                {
                    ClickSFX.CreateInstance().Play();
                    if (Fight_B1.mouseHover == true)
                    {
                        isFighting = true;
                    }
                    if (Fight_B2.mouseHover == true)
                    {
                        isFighting = true;
                    }
                    if (Event_B1.mouseHover == true)
                    {
                        isInteracting = true;
                    }
                    if (Event_B2.mouseHover == true)
                    {
                        isInteracting = true;
                    }
                    if (Rest_B.mouseHover == true)
                    {
                        Resting = true;
                    }
                }
            }

            if (isFighting == true)
            {
                Random r = new Random();
                int x = r.Next(0, 6);

                if (x == 1)
                {
                    EnemyGroup.Add(Beetle1);
                    roomNum += 1;
                    MediaPlayer.Play(BattleBGM_1);
                    for (int i = 0; i < ButtoninMap.Count; i++)
                    {
                        ButtoninMap[i].mouseHover = false;
                        ButtoninMap[i].State = Color.White;
                        ButtoninMap[i].Pressed = false;
                        ButtoninMap[i].Position = new Vector2(1000, 1000);
                    }
                    isMap = false;
                    isBattle = true;
                    isFighting = false;
                }
                if (x == 2)
                {
                    EnemyGroup.Add(Rocky1);
                    roomNum += 1;
                    MediaPlayer.Play(BattleBGM_1);
                    for (int i = 0; i < ButtoninMap.Count; i++)
                    {
                        ButtoninMap[i].mouseHover = false;
                        ButtoninMap[i].State = Color.White;
                        ButtoninMap[i].Pressed = false;
                        ButtoninMap[i].Position = new Vector2(1000, 1000);
                    }
                    isMap = false;
                    isBattle = true;
                    isFighting = false;
                }

                if (x == 3)
                {
                    EnemyGroup.Add(Rocky1);
                    EnemyGroup.Add(Rocky2);

                    roomNum += 1;
                    MediaPlayer.Play(BattleBGM_1);
                    for (int i = 0; i < ButtoninMap.Count; i++)
                    {
                        ButtoninMap[i].mouseHover = false;
                        ButtoninMap[i].State = Color.White;
                        ButtoninMap[i].Pressed = false;
                        ButtoninMap[i].Position = new Vector2(1000, 1000);
                    }
                    isMap = false;
                    isBattle = true;
                    isFighting = false;
                }
                if (x == 4)
                {
                    EnemyGroup.Add(Beetle1);
                    EnemyGroup.Add(Beetle2);

                    roomNum += 1;
                    MediaPlayer.Play(BattleBGM_2);
                    for (int i = 0; i < ButtoninMap.Count; i++)
                    {
                        ButtoninMap[i].mouseHover = false;
                        ButtoninMap[i].State = Color.White;
                        ButtoninMap[i].Pressed = false;
                        ButtoninMap[i].Position = new Vector2(1000, 1000);
                    }
                    isMap = false;
                    isBattle = true;
                    isFighting = false;
                }
                if (x == 5)
                {
                    EnemyGroup.Add(Golem);
                    roomNum += 1;
                    MediaPlayer.Play(BossBGM);
                    for (int i = 0; i < ButtoninMap.Count; i++)
                    {
                        ButtoninMap[i].mouseHover = false;
                        ButtoninMap[i].State = Color.White;
                        ButtoninMap[i].Pressed = false;
                        ButtoninMap[i].Position = new Vector2(1000, 1000);
                    }
                    isMap = false;
                    isBattle = true;
                    isFighting = false;
                }
            }
            if (isInteracting == true)
            {
                roomNum += 1;
                for (int i = 0; i < ButtoninMap.Count; i++)
                {
                    ButtoninMap[i].mouseHover = false;
                    ButtoninMap[i].State = Color.White;
                    ButtoninMap[i].Pressed = false;
                    ButtoninMap[i].Position = new Vector2(1000, 1000);
                }
                isMap = false;
                isEvent = true;
                isInteracting = false;
            }
            if (Resting == true)
            {
                roomNum += 1;
                BattleSFX[4].CreateInstance().Play();
                for (int i = 0; i < Party.Count; i++)
                {
                    Party[i].HP = Party[i].MaxHP;
                }
                for (int i = 0; i < ButtoninMap.Count; i++)
                {
                    ButtoninMap[i].mouseHover = false;
                    ButtoninMap[i].State = Color.White;
                    ButtoninMap[i].Pressed = false;
                    ButtoninMap[i].Position = new Vector2(1000, 1000);
                }
                isMap = false;
                isRest = true;
                Resting = false;
            }


            Old_mouseState = mouseState;
        }

        private void UpdateTitle()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);

           
            if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                isCharactor = true;
                isTitle = false;
            }
            Old_mouseState = mouseState;
        }

        private void UpdateEvent()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);


            if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                isMap = true;
                isEvent = false;
                RandomNode();

            }
            Old_mouseState = mouseState;
        }

        private void UpdateLose()
        {

        }

        private void UpdateRest()
        {
            var mouseState = Mouse.GetState();

            if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                isMap = true;
                isRest = false;
                RandomNode();

            }
            Old_mouseState = mouseState;
        }

        private void UpdateCharactor()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            Rectangle LurkerRectangle = new Rectangle((int)Lurker.spriteLocation.X, (int)Lurker.spriteLocation.Y, 215, 215);
            Rectangle InventorRectangle = new Rectangle((int)inventor.spriteLocation.X, (int)inventor.spriteLocation.Y, 215, 215);
            Rectangle BloodRectangle = new Rectangle((int)Blood_Maiden.spriteLocation.X, (int)Blood_Maiden.spriteLocation.Y, 215, 215);
           

            if (LurkerRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(Lurker);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                RandomNode();
            }
            if (InventorRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(inventor);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                RandomNode();
            }
            if (BloodRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(Blood_Maiden);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                RandomNode();
            }
          
            Old_mouseState = mouseState;
        }

        private void DrawBattale1()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(Turn_Selector_Texture, Turn_Selector_Position, Color.White);
            
            for (int i = 0; i < Party.Count; i++)
            {
                if (Party[i] == Lurker)
                {
                    _spriteBatch.Draw(Lurker_Texture, Lurker.spriteLocation, new Rectangle(0, Lurker.ATKframe * 240, 270, 230), Lurker.State);
                }
                if (Party[i] == inventor)
                {
                    _spriteBatch.Draw(Inventor_Texture, inventor.spriteLocation, new Rectangle(0, inventor.ATKframe * 240, 270, 230), inventor.State);
                }
                if (Party[i] == Blood_Maiden)
                {
                    _spriteBatch.Draw(Blood_Maiden_Texture, Blood_Maiden.spriteLocation, new Rectangle(0, Blood_Maiden.ATKframe * 240, 270, 230), Blood_Maiden.State);
                }
                
                if (i == 0)
                {
                    Party[i].spriteLocation = SetPO1; 
                    Party[i].spriteLocation2 = Party[i].spriteLocation;
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X + 40, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].HPicon_Location = new Vector2(SetPO1.X, SetPO1.Y - 240);
                }
                if (i == 1)
                {
                    Party[i].spriteLocation = new Vector2(SetPO1.X - 200, SetPO1.Y);
                    Party[i].spriteLocation2 = Party[i].spriteLocation;
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 240, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 270, SetPO1.Y - 240);
                }
                if (i == 2)
                {
                    Party[i].spriteLocation = new Vector2(SetPO1.X - 400, SetPO1.Y);
                    Party[i].spriteLocation2 = Party[i].spriteLocation;
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 520, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 540, SetPO1.Y - 240);
                }
            }
            
            for (int i = 0; i < EnemyGroup.Count; i++)
            {
                if (EnemyGroup[i] == Golem)
                {
                    _spriteBatch.Draw(Golem_Texture, Golem.spriteLocation, new Rectangle(frame * 324, 0, 324, 310), Golem.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = SetPO2;
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }
                if (EnemyGroup[i] == Rocky1)
                {
                    _spriteBatch.Draw(Rocky_Text, Rocky1.spriteLocation, new Rectangle(frame * 100, 0, 100, 100), Rocky1.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }
                if (EnemyGroup[i] == Rocky2)
                {
                    _spriteBatch.Draw(Rocky_Text, Rocky2.spriteLocation, new Rectangle(frame * 100, 0, 100, 100), Rocky2.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }
                if (EnemyGroup[i] == Rocky3)
                {
                    _spriteBatch.Draw(Rocky_Text, Rocky3.spriteLocation, new Rectangle(frame * 100, 0, 100, 100), Rocky3.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 200);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }
                if ( EnemyGroup[i] == Beetle1)
                {
                    _spriteBatch.Draw(Beetle_Text, Beetle1.spriteLocation, new Rectangle(frame * 150, 0, 150, 150), Beetle1.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }
                if (EnemyGroup[i] == Beetle2)
                {
                    _spriteBatch.Draw(Beetle_Text, Beetle2.spriteLocation, new Rectangle(frame * 150, 0, 150, 150), Beetle2.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }
                if (EnemyGroup[i] == Beetle3)
                {
                    _spriteBatch.Draw(Beetle_Text, Beetle3.spriteLocation, new Rectangle(frame * 150, 0, 150, 150), Beetle3.State);
                    if (i == 0)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 1)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                    if (i == 2)
                    {
                        EnemyGroup[i].spriteLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 100);
                        EnemyGroup[i].spriteLocation2 = EnemyGroup[i].spriteLocation;
                        EnemyHP(i);
                    }
                }

            }

            _spriteBatch.Draw(Attack_Texture, Attack_B.Position, Attack_B.State);
            _spriteBatch.Draw(Skill_Texture, Skill_B.Position, Skill_B.State);
            _spriteBatch.Draw(Item_Texture, Item_B.Position, Item_B.State);
            _spriteBatch.Draw(Arrow_Texture, Arrow_Position, Color.White);
            _spriteBatch.Draw(Turn_Order_Texture, Turn_Order_Position, Color.White);

            for (int i = 0; i < Party.Count; i++)
            {
                if (Party[i] == Lurker)
                {
                    _spriteBatch.Draw(HPbar_Texture, Lurker.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Lurker.HPbar_Location, new Rectangle(0, 0, Lurker.HP * (240 / Lurker.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Lurker_Small_Icon, Lurker.Small_iconLocation, new Rectangle(0, 0, 126, 126), Lurker.State);
                    _spriteBatch.Draw(Lurker_Big_Icon, Lurker.Big_iconLocation, new Rectangle(0, 460, 200, 140), Color.White);
                    _spriteBatch.Draw(Lurker_Small_Icon, Lurker.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == inventor)
                {
                    _spriteBatch.Draw(HPbar_Texture, inventor.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, inventor.HPbar_Location, new Rectangle(0, 0, inventor.HP * (240 / inventor.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Inventor_Small_Icon, inventor.Small_iconLocation, new Rectangle(0, 0, 126, 126), inventor.State);
                    _spriteBatch.Draw(Inventor_Big_Icon, inventor.Big_iconLocation, new Rectangle(0, 300, 200, 140), Color.White);
                    _spriteBatch.Draw(Inventor_Small_Icon, inventor.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == Blood_Maiden)
                {
                    _spriteBatch.Draw(HPbar_Texture, Blood_Maiden.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Blood_Maiden.HPbar_Location, new Rectangle(0, 0, Blood_Maiden.HP * (240 / Blood_Maiden.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Blood_Maiden_Small_Icon, Blood_Maiden.Small_iconLocation, new Rectangle(0, 0, 126, 126), Blood_Maiden.State);
                    _spriteBatch.Draw(Blood_Maiden_Big_Icon, Blood_Maiden.Big_iconLocation, new Rectangle(0, 480, 200, 140), Color.White);
                    _spriteBatch.Draw(Blood_Maiden_Small_Icon, Blood_Maiden.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
            }
            for (int i = 0; i < EnemyGroup.Count; i++)
            {
                if (EnemyGroup[i] == Golem)
                {
                    _spriteBatch.Draw(HPbar_Texture, Golem.HPMPbar_iconLocation, new Rectangle(0, 0, 270, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Golem.HPbar_Location, new Rectangle(0, 0, Golem.HP * (280 / Golem.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Golem_Icon, Golem.Small_iconLocation, new Rectangle(35, 315, 90, 90), Golem.State);
                    _spriteBatch.Draw(Golem_Texture, Golem.Big_iconLocation, new Rectangle(50, 70, 120, 140), Color.White);
                }
                if (EnemyGroup[i] == Rocky1)
                {
                    _spriteBatch.Draw(HPbar_Texture, Rocky1.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Rocky1.HPbar_Location, new Rectangle(0, 0, Rocky1.HP * (190 / Rocky1.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Rocky_Icon, Rocky1.Small_iconLocation, new Rectangle(0, 0, 90, 90), Rocky1.State);
                    _spriteBatch.Draw(Rocky_Text, Rocky1.Big_iconLocation, new Rectangle(0, 0, 90, 90), Color.White);
                }
                if (EnemyGroup[i] == Rocky2)
                {
                    _spriteBatch.Draw(HPbar_Texture, Rocky2.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Rocky2.HPbar_Location, new Rectangle(0, 0, Rocky2.HP * (190 / Rocky2.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Rocky_Icon, Rocky2.Small_iconLocation, new Rectangle(0, 0, 90, 90), Rocky2.State);
                    _spriteBatch.Draw(Rocky_Text, Rocky2.Big_iconLocation, new Rectangle(0, 0, 90, 90), Color.White);
                }
                if (EnemyGroup[i] == Rocky3)
                {
                    _spriteBatch.Draw(HPbar_Texture, Rocky3.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Rocky3.HPbar_Location, new Rectangle(0, 0, Rocky3.HP * (190 / Rocky3.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Rocky_Icon, Rocky3.Small_iconLocation, new Rectangle(0, 0, 90, 90), Rocky3.State);
                    _spriteBatch.Draw(Rocky_Text, Rocky3.Big_iconLocation, new Rectangle(0, 0, 90, 90), Color.White);
                }
                if (EnemyGroup[i] == Beetle1)
                {
                    _spriteBatch.Draw(HPbar_Texture, Beetle1.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Beetle1.HPbar_Location, new Rectangle(0, 0, Beetle1.HP * (190 / Beetle1.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Beetle_Icon, Beetle1.Small_iconLocation, new Rectangle(0, 0, 90, 90), Beetle1.State);
                    _spriteBatch.Draw(Beetle_Text, Beetle1.Big_iconLocation, new Rectangle(0, 20, 120, 920), Color.White);
                }
                if (EnemyGroup[i] == Beetle2)
                {
                    _spriteBatch.Draw(HPbar_Texture, Beetle2.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Beetle2.HPbar_Location, new Rectangle(0, 0, Beetle2.HP * (190 / Beetle2.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Beetle_Icon, Beetle2.Small_iconLocation, new Rectangle(0, 0, 90, 90), Beetle2.State);
                    _spriteBatch.Draw(Beetle_Text, Beetle2.Big_iconLocation, new Rectangle(0, 20, 120, 920), Color.White);
                }
                if (EnemyGroup[i] == Beetle3)
                {
                    _spriteBatch.Draw(HPbar_Texture, Beetle3.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Beetle3.HPbar_Location, new Rectangle(0, 0, Beetle3.HP * (190 / Beetle3.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Beetle_Icon, Beetle3.Small_iconLocation, new Rectangle(0, 0, 90, 90), Beetle3.State);
                    _spriteBatch.Draw(Beetle_Text, Beetle3.Big_iconLocation, new Rectangle(0, 20, 120, 920), Color.White);
                }

            }
            _spriteBatch.Draw(Skill_Texture, Double_Slash.Position, Double_Slash.State);
            _spriteBatch.Draw(Skill_Texture, Wide_Slash.Position, Wide_Slash.State);
            _spriteBatch.Draw(Item_Texture, HeathPotion.Position, HeathPotion.State);

            _spriteBatch.DrawString(font, BattleTxt, new Vector2(300, 520), Color.White);
        }

        private void DrawEventMap()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            String room = "room: " + roomNum;
            _spriteBatch.DrawString(font, room, new Vector2(200, 300), Color.Red);
            _spriteBatch.Draw(FightNode_Texture, Fight_B1.Position, Fight_B1.State);
            _spriteBatch.Draw(FightNode_Texture, Fight_B2.Position, Fight_B2.State);
            _spriteBatch.Draw(EventNode_Texture, Event_B1.Position, Event_B1.State);
            _spriteBatch.Draw(EventNode_Texture, Event_B2.Position, Event_B2.State);
            _spriteBatch.Draw(RestNode_Texture, Rest_B.Position, Rest_B.State);
            for (int i = 0; i < Party.Count; i++)
            {
                if (Party[i] == Lurker)
                {
                    _spriteBatch.Draw(HPbar_Texture, Lurker.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Lurker.HPbar_Location, new Rectangle(0, 0, Lurker.HP * (240 / Lurker.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Lurker_Small_Icon, Lurker.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == inventor)
                {
                    _spriteBatch.Draw(HPbar_Texture, inventor.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, inventor.HPbar_Location, new Rectangle(0, 0, inventor.HP * (240 / inventor.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Inventor_Small_Icon, inventor.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == Blood_Maiden)
                {
                    _spriteBatch.Draw(HPbar_Texture, Blood_Maiden.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 30), Color.White);
                    _spriteBatch.Draw(HPbar_Texture, Blood_Maiden.HPbar_Location, new Rectangle(0, 0, Blood_Maiden.HP * (240 / Blood_Maiden.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Blood_Maiden_Small_Icon, Blood_Maiden.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (i == 0)
                {
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X + 40, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].HPicon_Location = new Vector2(SetPO1.X, SetPO1.Y - 240);
                }
                if (i == 1)
                {
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 240, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 270, SetPO1.Y - 240);
                }
                if (i == 2)
                {
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 520, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 540, SetPO1.Y - 240);
                }
            }
        }

        private void DrawTitle()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            String str = "Title Screen is here \n Click anywhere to continue";
            _spriteBatch.DrawString(font, str, new Vector2(400, 200), Color.Red);
        }

        private void DrawEvent()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            String str = "Something is suppose to happen here \n Click anywhere to continue";
            _spriteBatch.DrawString(font, str, new Vector2(400, 200), Color.Red);
        }

        private void DrawLose()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            String str = "You Lose";
            _spriteBatch.DrawString(font, str, new Vector2(400, 200), Color.Red);
        }

        private void DrawRest()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            String str = "Your party is healed YAY :) \n Click anywhere to continue";
            _spriteBatch.DrawString(font, str, new Vector2(400, 200), Color.Red);
        }

        private void DrawCharactor()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            String str = "Select Charactor";
            _spriteBatch.DrawString(font, str, new Vector2(400, 200), Color.Red);
            Lurker.spriteLocation = new Vector2(200, 300);
            inventor.spriteLocation = new Vector2(500, 300);
            Blood_Maiden.spriteLocation = new Vector2(800, 300);
            _spriteBatch.Draw(Lurker_Texture, Lurker.spriteLocation, new Rectangle(0, Lurker.ATKframe * 240, 270, 230), Lurker.State);
            _spriteBatch.Draw(Inventor_Texture, inventor.spriteLocation, new Rectangle(0, inventor.ATKframe * 240, 270, 230), inventor.State);
            _spriteBatch.Draw(Blood_Maiden_Texture, Blood_Maiden.spriteLocation, new Rectangle(0, Blood_Maiden.ATKframe * 240, 270, 230), Blood_Maiden.State);
        }

        private void ResetCombat()
        {
            for (int i = 0; i < EnemyGroup.Count; i++)
            {
                EnemyGroup[i].attacked = false;
                EnemyGroup[i].HP = EnemyGroup[i].MaxHP;
                EnemyGroup[i].Alive = true;
                EnemyGroup.RemoveAt(i);
            }
            for (int i = 0; i < ButtoninBattle.Count; i++)
            {
                ButtoninBattle[i].Pressed = false;
                ButtoninBattle[i].mouseHover = false;
            }
            turn = 0;
            timeLoad = false;
            frameInCombat = 0;
            Enemywaitingtime = 0;
            iconOrder = 0;
            Attacking = false;
            Skilling = false;
            Skilling2 = false;
            Skilling3 = false;
            UseSkill = 0;
            ATKcount = 0;
            BattleTxt = "";
        }

        private void RandomNode()
        {
            Random r = new Random();
            int x = r.Next(0, 5);
            if (x == 4)
            {
                int a = r.Next(0, 4);
                for (int i = 0; i < ButtoninMap.Count; i++)
                {
                    if (i == a)
                    {
                        ButtoninMap[i].Position = SetPO3;
                    }
                }
            }
            else
            {
                int a, b;
                do
                {
                    a = r.Next(0, 5);
                    b = r.Next(0, 5);
                }
                while (a == b);
                
                for (int i = 0; i < ButtoninMap.Count; i++)
                {
                    if (i == a)
                    {
                        ButtoninMap[i].Position = new Vector2(SetPO3.X - 300, SetPO3.Y);
                    }
                    if (i == b)
                    {
                        ButtoninMap[i].Position = new Vector2(SetPO3.X + 300, SetPO3.Y);
                    }
                }
            }
        }

        private void EnemyHP(int i)
        {
            if (i == 0)
            {
                if (EnemyGroup[i].Alive == true)
                {
                    EnemyGroup[i].HPMPbar_iconLocation = new Vector2(SetPO2.X, SetPO2.Y + 300);
                    EnemyGroup[i].HPbar_Location = EnemyGroup[i].HPMPbar_iconLocation;
                }
                else
                {
                    EnemyGroup[i].HPMPbar_iconLocation = new Vector2(1000, 1000);
                    EnemyGroup[i].HPbar_Location = EnemyGroup[i].HPMPbar_iconLocation;
                }
            }
            if (i == 1)
            {
                if (EnemyGroup[i].Alive == true)
                {
                    EnemyGroup[i].HPMPbar_iconLocation = new Vector2(SetPO2.X + 200, SetPO2.Y + 300);
                    EnemyGroup[i].HPbar_Location = EnemyGroup[i].HPMPbar_iconLocation;
                }
                else
                {
                    EnemyGroup[i].HPMPbar_iconLocation = new Vector2(1000, 1000);
                    EnemyGroup[i].HPbar_Location = EnemyGroup[i].HPMPbar_iconLocation;
                }
            }
            if (i == 2)
            {
                if (EnemyGroup[i].Alive == true)
                {
                    EnemyGroup[i].HPMPbar_iconLocation = new Vector2(SetPO2.X + 400, SetPO2.Y + 300);
                    EnemyGroup[i].HPbar_Location = EnemyGroup[i].HPMPbar_iconLocation;
                }
                else
                {
                    EnemyGroup[i].HPMPbar_iconLocation = new Vector2(1000, 1000);
                    EnemyGroup[i].HPbar_Location = EnemyGroup[i].HPMPbar_iconLocation;
                }
            }

        }
    }
}
