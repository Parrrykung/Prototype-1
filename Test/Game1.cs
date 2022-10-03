using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Test
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardState _keyboardState;
        private KeyboardState Old_keyboardState;

        private float totalElapsed;
        private float timePerFrame;
        private int framePerSec;
        private Vector2 SetPO1 = new Vector2(280, 90);
        private Vector2 SetPO2 = new Vector2(480, 90);
        private int frame;
        private bool timeLoad;
        private int frameInCombat;
        private int waitingtime = 0;

        private Texture2D first_floor_Background;
        private Texture2D Farmer;
        private Texture2D Golem_Texture;
        private Texture2D Lurker_Texture;
        private Texture2D Inventor_Texture;
        private Texture2D Blood_Maiden_Texture;
        public UnitClass Lurker = new UnitClass(true, 6, 50, 5);
        public UnitClass Golem = new UnitClass(false,4, 10, 5);
        public UnitClass inventor = new UnitClass(true, 5, 50, 5);
        public UnitClass Farmer4 = new UnitClass(false,4, 10, 5);
        public UnitClass Blood_Maiden = new UnitClass(true, 3, 50, 5);
        public UnitClass Farmer6 = new UnitClass(false,4, 10, 5);
        private UnitClass Nul = new UnitClass();
        private int target = 0;
        private int turn;



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
            Farmer = Content.Load<Texture2D>("Char01");
            Blood_Maiden_Texture = Content.Load<Texture2D>("Blood_maiden_sprite_sheet");
            Golem_Texture = Content.Load<Texture2D>("Golem_Sprite_sheet");
            Inventor_Texture = Content.Load<Texture2D>("Inventor_Sprite_Sheet");
            Lurker_Texture = Content.Load<Texture2D>("Lurker_Sprite_Sheet");
            first_floor_Background = Content.Load<Texture2D>("1st_floor");
            framePerSec = 2;
            timePerFrame = (float)1 / framePerSec;
            frame = 0;
            totalElapsed = 0;
            timeLoad = false;
            frameInCombat = 0;
            turn = 0;

            Lurker.spriteLocation = SetPO1;

            Golem.spriteLocation = SetPO2;

            inventor.spriteLocation = new Vector2(SetPO1.X - 100, SetPO1.Y);

            Farmer4.direction = 1;
            Farmer4.spriteLocation = new Vector2(SetPO2.X + 50, SetPO2.Y);

            Blood_Maiden.spriteLocation = new Vector2(SetPO1.X - 200, SetPO1.Y);

            Farmer6.direction = 1;
            Farmer6.spriteLocation = new Vector2(SetPO2.X + 100, SetPO2.Y);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            UnitClass[] Party = { Lurker, inventor, Blood_Maiden };
            UnitClass[] EnemyGroup1 = { Golem, Farmer4, Farmer6};

            UnitClass[] speedDecider = new UnitClass[Party.Length + EnemyGroup1.Length];
            for (int i = 0; i < speedDecider.Length; i++)
            {
                if (i <= Party.Length - 1)
                    speedDecider[i] = Party[i];
                else
                    speedDecider[i] = EnemyGroup1[i - Party.Length];
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
                if (i == turn)
                {
                    speedDecider[i].myTurn = true;
                }
                
                if (speedDecider[i].myTurn == true)
                {
                    speedDecider[i].State = Color.Gray;
                    
                    
                    if (speedDecider[i].playable == true)
                     {
                        if (_keyboardState.IsKeyUp(Keys.Space) && Old_keyboardState.IsKeyDown(Keys.Space))
                        {
                            speedDecider[i].isAttacking = true;
                            timeLoad = true;
                            EnemyGroup1[target].attacked = true;
                            EnemyGroup1[target].HP -= speedDecider[i].Atk;
                        }
                        if(EnemyGroup1[target].Alive == true)
                        {
                            EnemyGroup1[target].targeted = true;
                        }
                        if (EnemyGroup1[target].Alive == false)
                        {
                            if (target == EnemyGroup1.Length - 1)
                            {
                                target = 0;
                            }
                            if (target < EnemyGroup1.Length - 1)
                            {
                                target += 1;
                            }
                        }

                        if (_keyboardState.IsKeyUp(Keys.D) && Old_keyboardState.IsKeyDown(Keys.D))
                        {
                            EnemyGroup1[target].targeted = false;
                            if (target == EnemyGroup1.Length - 1)
                            {
                                target = 0;
                            }
                            else
                            {
                                target += 1;
                                if (EnemyGroup1[target].Alive == false && target < EnemyGroup1.Length - 1)
                                {
                                    target += 1;
                                }
                                if (EnemyGroup1[target].Alive == false && target == EnemyGroup1.Length - 1)
                                {
                                    target = 0;
                                }
                            }
                        }
                        if (_keyboardState.IsKeyUp(Keys.A) && Old_keyboardState.IsKeyDown(Keys.A))
                        {
                            EnemyGroup1[target].targeted = false;
                            if (target == 0)
                            {
                                target = EnemyGroup1.Length - 1;
                            }
                            else
                            {
                                target -= 1;
                                if (EnemyGroup1[target].Alive == false && target >0)
                                {
                                    target -= 1;
                                }
                                if (EnemyGroup1[target].Alive == false && target == 0)
                                {
                                    target = EnemyGroup1.Length - 1;
                                }
                            }
                        }
                    }

                    if (speedDecider[i].playable == false && speedDecider[i].Alive == true)
                    {
                        if (waitingtime == 0)
                        {
                            Random r = new Random();
                            target = r.Next(0, Party.Length);
                            Party[target].targeted = true;
                        }
                        waitingtime += 1;
                        if (waitingtime == 50)
                        {
                            speedDecider[i].isAttacking = true;
                            timeLoad = true;
                            Party[target].attacked = true;
                            Party[target].HP -= speedDecider[i].Atk;
                        }
                    }

                    if (speedDecider[i].Alive == false)
                    {
                        timeLoad = false;
                        frameInCombat = 0;
                        turn++;
                        speedDecider[i].myTurn = false;
                        speedDecider[i].isAttacking = false;
                        EnemyGroup1[target].attacked = false;
                        waitingtime = 0;
                    }
                }

                if (speedDecider[i].isAttacking == true)
                {
                    speedDecider[i].State = Color.CornflowerBlue;
                }
                if (speedDecider[i].isAttacking == false && speedDecider[i].targeted == false && speedDecider[i].myTurn == false)
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
                    EnemyGroup1[target].attacked = false;
                    waitingtime = 0;
                    for (int m = 0; m < speedDecider.Length; m++)
                    {
                        speedDecider[m].targeted = false;
                        speedDecider[m].attacked = false;
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
            

            UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            Old_keyboardState = _keyboardState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(first_floor_Background, Vector2.Zero, Color.White);
            _spriteBatch.Draw(Lurker_Texture, Lurker.spriteLocation, new Rectangle(0,
                0, 135, 125), Lurker.State);
            _spriteBatch.Draw(Golem_Texture, Golem.spriteLocation, new Rectangle(0,
                0, 183, 155), Golem.State);
            _spriteBatch.Draw(Inventor_Texture, inventor.spriteLocation, new Rectangle(0,
                0, 135, 125), inventor.State);
            _spriteBatch.Draw(Farmer, Farmer4.spriteLocation, new Rectangle(frame * 32,
                Golem.direction * 48, 32, 48), Farmer4.State);
            _spriteBatch.Draw(Blood_Maiden_Texture, Blood_Maiden.spriteLocation, new Rectangle(0,
                0, 135, 125), Blood_Maiden.State);
            _spriteBatch.Draw(Farmer, Farmer6.spriteLocation, new Rectangle(frame * 32,
                Golem.direction * 48, 32, 48), Farmer6.State);

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
    }
}
