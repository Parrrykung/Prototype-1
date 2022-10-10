using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Vector2 SetPO1 = new Vector2(280, 120);
        private Vector2 SetPO2 = new Vector2(480, 90);
        private int frame;
        private bool timeLoad;
        private int frameInCombat;
        private int waitingtime = 0;

        private Texture2D first_floor_Background;
        private Texture2D Beetle_Text;
        private Texture2D Rocky_Text;
        private Texture2D Golem_Texture;
        private Texture2D Lurker_Texture;
        private Texture2D Inventor_Texture;
        private Texture2D Blood_Maiden_Texture;
        private Texture2D Arrow_Texture;
        private Texture2D Attack_Texture;
        private Texture2D Item_Texture;
        private Texture2D Skill_Texture;
        private Texture2D Turn_Order_Texture;
        private Texture2D Turn_Selector_Texture;
        
        public UnitClass Lurker = new UnitClass(true, 6, 10, 5);
        public UnitClass Golem = new UnitClass(false,4, 20, 5);
        public UnitClass inventor = new UnitClass(true, 5, 10, 5);
        public UnitClass Beetle = new UnitClass(false,5, 10, 5);
        public UnitClass Rocky = new UnitClass(false, 3, 10, 5);
        public UnitClass Blood_Maiden = new UnitClass(true, 3, 10, 5);
        private UnitClass Nul = new UnitClass();

        private Button Attack_B = new Button(new Vector2(50, 180));
        private Button Skill_B = new Button(new Vector2(65, 205));
        private Button Item_B = new Button(new Vector2(50, 230));

        private Vector2 Turn_Selector_Position;
        private Vector2 Turn_Order_Position = new Vector2(0, 180);
        private Vector2 Arrow_Position = new Vector2(1000, 1000);

        private int target = 0;
        private int turn;
        private int iconOrder;
        bool isMap;
        bool isGameplay;
        private bool isHit = false;
        private bool Attacking = false;

        private List<UnitClass> Party = new List<UnitClass>();
        private List<UnitClass> EnemyGroup = new List<UnitClass>();
        private List<Button> ButtoninBattle = new List<Button>();


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
            Beetle_Text = Content.Load<Texture2D>("Flying Rock_Sheet");
            Rocky_Text = Content.Load<Texture2D>("Hermit Rock-Sheet");
            Blood_Maiden_Texture = Content.Load<Texture2D>("Blood_maiden_sprite_sheet");
            Golem_Texture = Content.Load<Texture2D>("Golem-Sheet");
            Inventor_Texture = Content.Load<Texture2D>("Inventor_Sprite_Sheet");
            Lurker_Texture = Content.Load<Texture2D>("Lurker_Sprite_Sheet");
            first_floor_Background = Content.Load<Texture2D>("1st_floor_2");
            Arrow_Texture = Content.Load<Texture2D>("Arrow");
            Attack_Texture = Content.Load<Texture2D>("Attack");
            Item_Texture = Content.Load<Texture2D>("Item");
            Skill_Texture = Content.Load<Texture2D>("Skill");
            Turn_Order_Texture  = Content.Load<Texture2D>("Turn Order Hub");
            Turn_Selector_Texture = Content.Load<Texture2D>("Turn Selector");
            framePerSec = 2;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            timeLoad = false;
            frameInCombat = 0;
            turn = 0;
            isGameplay = false;
            isMap = true;

            ButtoninBattle.Add(Attack_B);
            ButtoninBattle.Add(Skill_B);
            ButtoninBattle.Add(Item_B);

            Party.Add(Lurker);
            Party.Add(inventor);
            Party.Add(Blood_Maiden);

            EnemyGroup.Add(Golem);
            EnemyGroup.Add(Beetle);
            EnemyGroup.Add(Rocky);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isGameplay == true)
            {
                UpdateGameplay();
            }
            if (isMap == true)
            {
                UpdateEventMap();
            }

            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            if (isGameplay == true)
            {
                DrawGameplay();
            }
            if (isMap == true)
            {
                DrawMenu();
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

            _keyboardState = Keyboard.GetState();

            for (int i = 0; i < TurnOrder.Count; i++)
            {
                Rectangle unitRectangle = new Rectangle((int)TurnOrder[i].spriteLocation.X, (int)TurnOrder[i].spriteLocation.Y, 70, 110);
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
                if (TurnOrder[i].myTurn == true && TurnOrder[i].Alive == false)
                {
                    turn += 1;
                    TurnOrder[i].myTurn = false;
                }

                if (TurnOrder[i].myTurn == true && TurnOrder[i].Alive == true)
                {
                    Turn_Selector_Position = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y + 10);
                    TurnOrder[i].Big_iconLocation = new Vector2(0, 190);
                    TurnOrder[i].Small_iconLocation = new Vector2(1000, 1090);

                    if (TurnOrder[i].playable == true)
                    {
                        for (int n = 0; n < ButtoninBattle.Count; n++)
                        {
                            if(TurnOrder[i].isAttacking == true)
                            {
                                ButtoninBattle[n].Pressed = false;
                            }
                            if (ButtoninBattle[n].Pressed == false && Attacking == false)
                            {
                                Rectangle buttonRectangle = new Rectangle((int)ButtoninBattle[n].Position.X, (int)ButtoninBattle[n].Position.Y, 80, 30);
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
                                    Arrow_Position = new Vector2(ButtoninBattle[n].Position.X + 80, ButtoninBattle[n].Position.Y + 5);
                                }
                                if (ButtoninBattle[n].mouseHover == false && ButtoninBattle[n].Pressed == false)
                                {
                                    ButtoninBattle[n].State = Color.White;
                                }
                                if (mouseState.LeftButton == ButtonState.Pressed && ButtoninBattle[n].mouseHover == true)
                                {
                                    ButtoninBattle[n].State = Color.Gray;
                                    Attacking = true;
                                    ButtoninBattle[n].Pressed = true;
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
                                    EnemyGroup[m].spriteLocation.X += 10;
                                }
                            }
                        }
                    }

                    if (TurnOrder[i].playable == false && TurnOrder[i].Alive == true)
                    {
                        if (waitingtime == 0)
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
                        waitingtime += 1;
                        if (waitingtime == 50)
                        {
                            TurnOrder[i].isAttacking = true;
                            timeLoad = true;
                            Party[target].attacked = true;
                            Party[target].HP -= TurnOrder[i].Atk;
                            Party[target].spriteLocation2 = Party[target].spriteLocation;
                            Party[target].spriteLocation.X -= 10; 
                        }
                    }

                    if (TurnOrder[i].Alive == false)
                    {
                        timeLoad = false;
                        frameInCombat = 0;
                        turn++;
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].isAttacking = false;
                        waitingtime = 0;
                    }
                }

                if (TurnOrder[i].isAttacking == true)
                {
                    TurnOrder[i].State = Color.CornflowerBlue;
                }
                if (TurnOrder[i].isAttacking == false && TurnOrder[i].targeted == false && TurnOrder[i].myTurn == false && TurnOrder[i].mouseHover == false)
                {
                    TurnOrder[i].State = Color.White;
                }
                if (frameInCombat > 20 && TurnOrder[i].myTurn == true)
                {
                    timeLoad = false;
                    frameInCombat = 0;
                    turn++;
                    Attacking = false;
                    TurnOrder[i].myTurn = false;
                    TurnOrder[i].isAttacking = false;
                    waitingtime = 0;
                    iconOrder = TurnOrder.Count - 1;
                    for (int m = 0; m < TurnOrder.Count; m++)
                    {
                        TurnOrder[m].targeted = false;
                        TurnOrder[m].attacked = false;
                        if (TurnOrder[m].Alive == true)
                        {
                            TurnOrder[m].spriteLocation = TurnOrder[m].spriteLocation2;
                        }
                    }
                    for (int m = 0; m < ButtoninBattle.Count; m++)
                    {
                        ButtoninBattle[m].Pressed = false;
                    }

                }
                if (TurnOrder[i].targeted == true && TurnOrder[i].myTurn == false)
                {
                    TurnOrder[i].State = Color.HotPink;
                }
                if (TurnOrder[i].attacked == true && TurnOrder[i].myTurn == false)
                {
                    TurnOrder[i].State = Color.Red;
                }
                if (TurnOrder[i].attacked == false && TurnOrder[i].myTurn == true)
                {
                    TurnOrder[i].State = Color.White;
                }
                // HP เหลือ 0//
                if (TurnOrder[i].HP <= 0)
                {
                    TurnOrder[i].spriteLocation = new Vector2(1000, 1000);
                    TurnOrder[i].Alive = false;

                }
                if (iconOrder == 1)
                {
                    TurnOrder[i].Small_iconLocation = new Vector2(0, 160);
                }
                if (i == 2)
                {
                    TurnOrder[i].Small_iconLocation = new Vector2(40, 120);
                }
                if (i == 3)
                {
                    TurnOrder[i].Small_iconLocation = new Vector2(0, 160);
                }
                if (i == 4)
                {
                    TurnOrder[i].Small_iconLocation = new Vector2(40, 120);
                }
                if (i == 5)
                {
                    TurnOrder[i].Small_iconLocation = new Vector2(0, 160);
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

            

            if (EnemyGroup[0].Alive == false && EnemyGroup[1].Alive == false && EnemyGroup[2].Alive == false)
            {
                isMap = true;
                isGameplay = false;
                for (int i = 0; i < TurnOrder.Count; i++)
                {
                    if (TurnOrder[i].playable == false)
                    {
                        TurnOrder.RemoveAt(i);
                    }
                }
            }

            Old_keyboardState = _keyboardState;
            Old_mouseState = mouseState;

            
        }

        private void UpdateEventMap()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) == true)
            {
                isMap = false;
                isGameplay = true;

                Lurker.spriteLocation = SetPO1; Lurker.spriteLocation2 = Lurker.spriteLocation;
                inventor.spriteLocation = new Vector2(SetPO1.X - 100, SetPO1.Y); inventor.spriteLocation2 = inventor.spriteLocation;
                Blood_Maiden.spriteLocation = new Vector2(SetPO1.X - 200, SetPO1.Y); Blood_Maiden.spriteLocation2 = Blood_Maiden.spriteLocation;
                
                Golem.spriteLocation = SetPO2; Golem.spriteLocation2 = Golem.spriteLocation;
                Beetle.spriteLocation = new Vector2(SetPO2.X + 125, SetPO2.Y); Beetle.spriteLocation2 = Beetle.spriteLocation;             
                Rocky.spriteLocation = new Vector2(SetPO2.X - 50, SetPO2.Y + 100); Rocky.spriteLocation2 = Rocky.spriteLocation;

                

            }
        }

        private void DrawGameplay()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(Turn_Selector_Texture, Turn_Selector_Position, Color.White);
            _spriteBatch.Draw(Lurker_Texture, Lurker.spriteLocation, new Rectangle(0, 0, 135, 125), Lurker.State);
            _spriteBatch.Draw(Golem_Texture, Golem.spriteLocation, new Rectangle(frame * 162, 0, 162, 155), Golem.State);
            _spriteBatch.Draw(Inventor_Texture, inventor.spriteLocation, new Rectangle(0, 0, 135, 125), inventor.State);
            _spriteBatch.Draw(Beetle_Text, Beetle.spriteLocation, new Rectangle(frame * 75, 0, 75, 75), Beetle.State);
            _spriteBatch.Draw(Blood_Maiden_Texture, Blood_Maiden.spriteLocation, new Rectangle(0, 0, 135, 125), Blood_Maiden.State);
            _spriteBatch.Draw(Rocky_Text, Rocky.spriteLocation, new Rectangle(frame * 50, 0, 50, 50), Rocky.State);
            _spriteBatch.Draw(Attack_Texture, Attack_B.Position, Attack_B.State);
            _spriteBatch.Draw(Skill_Texture, Skill_B.Position, Skill_B.State);
            _spriteBatch.Draw(Item_Texture, Item_B.Position, Item_B.State);
            _spriteBatch.Draw(Arrow_Texture, Arrow_Position, Color.White);
            _spriteBatch.Draw(Turn_Order_Texture, Turn_Order_Position, Color.White);
            _spriteBatch.Draw(Lurker_Texture, new Vector2(Lurker.spriteLocation2.X - 40, Lurker.spriteLocation2.Y - 120), new Rectangle(0, 420, 135, 40), Color.White);
            _spriteBatch.Draw(Lurker_Texture, Lurker.Small_iconLocation, new Rectangle(25, 160, 45, 45), Color.White);
            _spriteBatch.Draw(Lurker_Texture, Lurker.Big_iconLocation, new Rectangle(0, 235, 78, 65), Color.White);
            _spriteBatch.Draw(Inventor_Texture, inventor.Big_iconLocation, new Rectangle(25, 160, 45, 45), Color.White);
            _spriteBatch.Draw(Blood_Maiden_Texture, Blood_Maiden.Small_iconLocation, new Rectangle(25, 160, 45, 45), Color.White);

            if (isHit == true)
            {
                _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            }
        }

        private void DrawMenu()
        {
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
        }
    }
}
