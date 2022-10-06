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
        private MouseState _mouseState;

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
        private Vector2 Turn_Selector_Position;
        private Vector2 Turn_Order_Position = new Vector2(0, 180);
        private Vector2 Attack_Position = new Vector2(50, 180);
        private int target = 0;
        private int turn;
        bool isMenu;
        bool isGameplay;
        private bool isHit = false;

        private List<UnitClass> Party = new List<UnitClass>();
        private List<UnitClass> EnemyGroup = new List<UnitClass>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 720;
            _graphics.PreferredBackBufferHeight = 280;
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
            first_floor_Background = Content.Load<Texture2D>("1st_floor");
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
            isGameplay = true;
            isMenu = false;

            Lurker.spriteLocation = SetPO1; Lurker.spriteLocation2 = Lurker.spriteLocation;
     
            Golem.spriteLocation = SetPO2; Golem.spriteLocation2 = Golem.spriteLocation;

            inventor.spriteLocation = new Vector2(SetPO1.X - 100, SetPO1.Y); inventor.spriteLocation2 = inventor.spriteLocation;

            Beetle.spriteLocation = new Vector2(SetPO2.X + 125, SetPO2.Y); Beetle.spriteLocation2 = Beetle.spriteLocation;

            Blood_Maiden.spriteLocation = new Vector2(SetPO1.X - 200, SetPO1.Y); Blood_Maiden.spriteLocation2 = Blood_Maiden.spriteLocation;

            Rocky.spriteLocation = new Vector2(SetPO2.X-50 , SetPO2.Y +100); Rocky.spriteLocation2 = Rocky.spriteLocation;

            EnemyGroup.Add(Golem);
            EnemyGroup.Add(Beetle);
            EnemyGroup.Add(Rocky);

            Party.Add(Lurker);
            Party.Add(inventor);
            Party.Add(Blood_Maiden);


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (isGameplay == true)
            {
                UpdateGameplay();
            }
            if (isMenu == true)
            {
                UpdateTitle();
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
            if (isMenu == true)
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
            UnitClass[] speedDecider = new UnitClass[Party.Count + EnemyGroup.Count];
            for (int i = 0; i < speedDecider.Length; i++)
            {
                if (i <= Party.Count - 1)
                    speedDecider[i] = Party[i];
                else
                    speedDecider[i] = EnemyGroup[i - Party.Count];
            }

            for (int c = 0; c < (speedDecider.Length - 1); c++)
            {
                for (int d = 0; d < speedDecider.Length - c - 1; d++)
                {
                    if (speedDecider[d].speed < speedDecider[d + 1].speed)
                    {
                        Nul = speedDecider[d];
                        speedDecider[d] = speedDecider[d + 1];
                        speedDecider[d + 1] = Nul;
                    }
                }
            }

            _keyboardState = Keyboard.GetState();

            for (int i = 0; i < speedDecider.Length; i++)
            {
                Rectangle unitRectangle = new Rectangle((int)speedDecider[i].spriteLocation.X, (int)speedDecider[i].spriteLocation.Y, 70, 110);
                if (unitRectangle.Contains(mousePosition))
                {
                    speedDecider[i].mouseHover = true;
                }
                else
                {
                    speedDecider[i].mouseHover = false;
                }
                if (i == turn)
                {
                    speedDecider[i].myTurn = true;
                }
                if (speedDecider[i].myTurn == true && speedDecider[i].Alive == false)
                {
                    turn += 1;
                    speedDecider[i].myTurn = false;
                }

                if (speedDecider[i].myTurn == true && speedDecider[i].Alive == true)
                {
                    Turn_Selector_Position = new Vector2(speedDecider[i].spriteLocation.X, speedDecider[i].spriteLocation.Y + 10);


                    if (speedDecider[i].playable == true)
                    {
                        if (_keyboardState.IsKeyUp(Keys.Space) && Old_keyboardState.IsKeyDown(Keys.Space) && EnemyGroup[target].Alive == true)
                        {
                            speedDecider[i].isAttacking = true;
                            timeLoad = true;
                            EnemyGroup[target].attacked = true;
                            EnemyGroup[target].HP -= speedDecider[i].Atk;
                            EnemyGroup[target].spriteLocation2 = EnemyGroup[target].spriteLocation;
                            EnemyGroup[target].spriteLocation.X += 10;
                        }
                        if (EnemyGroup[target].Alive == true)
                        {
                            EnemyGroup[target].targeted = true;
                        }
                        if (EnemyGroup[target].Alive == false)
                        {
                            if (target == EnemyGroup.Count - 1)
                            {
                                target = 0;
                            }
                            if (target < EnemyGroup.Count - 1)
                            {
                                target += 1;
                            }
                        }

                        if (_keyboardState.IsKeyUp(Keys.D) && Old_keyboardState.IsKeyDown(Keys.D))
                        {
                            EnemyGroup[target].targeted = false;
                            if (target == EnemyGroup.Count - 1)
                            {
                                target = 0;
                            }
                            else
                            {
                                target += 1;
                                if (EnemyGroup[target].Alive == false && target < EnemyGroup.Count - 1)
                                {
                                    target += 1;
                                }
                                if (EnemyGroup[target].Alive == false && target == EnemyGroup.Count - 1)
                                {
                                    target = 0;
                                }
                            }
                        }
                        if (_keyboardState.IsKeyUp(Keys.A) && Old_keyboardState.IsKeyDown(Keys.A))
                        {
                            EnemyGroup[target].targeted = false;
                            if (target == 0)
                            {
                                target = EnemyGroup.Count - 1;
                            }
                            else
                            {
                                target -= 1;
                                if (EnemyGroup[target].Alive == false && target > 0)
                                {
                                    target -= 1;
                                }
                                if (EnemyGroup[target].Alive == false && target == 0)
                                {
                                    target = EnemyGroup.Count - 1;
                                }
                            }
                        }
                    }

                    if (speedDecider[i].playable == false && speedDecider[i].Alive == true)
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
                            speedDecider[i].isAttacking = true;
                            timeLoad = true;
                            Party[target].attacked = true;
                            Party[target].HP -= speedDecider[i].Atk;
                            Party[target].spriteLocation2 = Party[target].spriteLocation;
                            Party[target].spriteLocation.X -= 10; 
                        }
                    }

                    if (speedDecider[i].Alive == false)
                    {
                        timeLoad = false;
                        frameInCombat = 0;
                        turn++;
                        speedDecider[i].myTurn = false;
                        speedDecider[i].isAttacking = false;
                        EnemyGroup[target].attacked = false;
                        waitingtime = 0;
                    }
                }

                if (speedDecider[i].isAttacking == true)
                {
                    speedDecider[i].State = Color.CornflowerBlue;
                }
                if (speedDecider[i].isAttacking == false && speedDecider[i].targeted == false && speedDecider[i].myTurn == false && speedDecider[i].mouseHover == false)
                {
                    speedDecider[i].State = Color.White;
                }
                if (frameInCombat > 20 && speedDecider[i].myTurn == true)
                {
                    timeLoad = false;
                    frameInCombat = 0;
                    turn++;
                    speedDecider[i].myTurn = false;
                    speedDecider[i].isAttacking = false;
                    waitingtime = 0;
                    for (int m = 0; m < speedDecider.Length; m++)
                    {
                        speedDecider[m].targeted = false;
                        speedDecider[m].attacked = false;
                        if (speedDecider[m].Alive == true)
                        {
                            speedDecider[m].spriteLocation = speedDecider[m].spriteLocation2;
                        }
                    }

                }
                if (speedDecider[i].targeted == true && speedDecider[i].myTurn == false)
                {
                    speedDecider[i].State = Color.HotPink;
                }
                if (speedDecider[i].attacked == true && speedDecider[i].myTurn == false)
                {
                    speedDecider[i].State = Color.Red;
                }
                if (speedDecider[i].attacked == false && speedDecider[i].myTurn == true)
                {
                    speedDecider[i].State = Color.White;
                }
                if (speedDecider[i].mouseHover == true)
                {
                    speedDecider[i].State = Color.Black;
                }
                // HP เหลือ 0//
                if (speedDecider[i].HP <= 0)
                {
                    speedDecider[i].spriteLocation = new Vector2(1000, 1000);
                    speedDecider[i].Alive = false;

                }

            }

            if (timeLoad == true)
            {
                frameInCombat += 1;
            }
            if (turn > speedDecider.Length - 1)
            {
                turn = 0;
            }

            if (EnemyGroup[0].Alive == false && EnemyGroup[1].Alive == false && EnemyGroup[2].Alive == false)
            {
                isMenu = true;
                isGameplay = false;
            }

            Old_keyboardState = _keyboardState;

        }

        private void UpdateTitle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) == true)
            {
                isMenu = false;
                isGameplay = true;
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
            _spriteBatch.Draw(Attack_Texture, Attack_Position, Color.White);
            _spriteBatch.Draw(Turn_Order_Texture, Turn_Order_Position, Color.White);

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
