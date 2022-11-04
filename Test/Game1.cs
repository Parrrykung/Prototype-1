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

        private Vector2 SetPO1 = new Vector2(560, 240);
        private Vector2 SetPO2 = new Vector2(860, 180);
        private Vector2 SetPO3 = new Vector2(620, 180);
        private int unloop_frame_1 = 0;
        private int unloop_frame_2 = 0;
        private bool timeLoad;
        private int frameInCombat;
        private int Enemywaitingtime = 0;
        private int Partywaitingtime = 0;
        private int roomNum = 1;
        private int CharactorCode;
        private int eventNum = 0;
        private int eventChance = 0;
        private int target = 0;
        private int ATKcount = 0;
        private int Gold = 0;
        private string GoldNum = "";
        private int HPPotionAmo = 1;
        private int MPPotionAmo = 1;
        private int BombAmo = 1;
        private int turn;
        private int iconOrder = 0;
        private string BattleTxt = "";
        private string ShopTxt = "Click an item to buy";
        private string EventTxt = "";
        private bool isFighting = false;
        private bool Resting = false;
        private bool isInteracting = false;
        private bool Yes = false;
        private bool No = false;
        private bool Rreturn = false;
        private bool TargetAlly = false;
        private bool TargetEnemy = false;
        bool isMap;
        bool isBattle;
        bool isTitle;
        bool isEvent;
        bool isLose;
        bool isRest;
        bool isCharactor;
        bool isShop;
        private bool Attacking = false;
        private bool Skilling = false;
        private bool Skilling2 = false;
        private bool Skilling3 = false;
        private bool Iteming = false;
        private bool Iteming2 = false;
        private int UseSkill = 0;
        private int UseItem = 0;

        private Texture2D Background_Texture;
        private Texture2D Background_Texture_1;
        private Texture2D Background_Texture_2;
        private Texture2D Background_Texture_3;
        private Texture2D Beetle_Text;
        private Texture2D Rocky_Text;
        private Texture2D Beetle_Icon;
        private Texture2D Rocky_Icon;
        private Texture2D Beetle_Big_Icon;
        private Texture2D Rocky_Big_Icon;
        private Texture2D Golem_Texture;
        private Texture2D Golem_Icon;
        private Texture2D Golem_Big_Icon;
        private Texture2D Ice_Golem_Texture;
        private Texture2D Ice_Golem_Icon;
        private Texture2D Ice_Golem_Big_Icon;
        private Texture2D Lurker_Small_Icon;
        private Texture2D Lurker_Big_Icon;
        private Texture2D Inventor_Small_Icon;
        private Texture2D Inventor_Big_Icon;
        private Texture2D Blood_Maiden_Small_Icon;
        private Texture2D Blood_Maiden_Big_Icon;
        private Texture2D Dragonic_Small_Icon;
        private Texture2D Dragonic_Big_Icon;
        private Texture2D Boss_Texture;
        private Texture2D Boss_Icon;
        private Texture2D Boss_Big_Icon;
        private Texture2D Arrow_Texture;
        private Texture2D Attack_Texture;
        private Texture2D Item_Texture;
        private Texture2D Skill_Texture;
        private Texture2D Turn_Order_Texture;
        private Texture2D Turn_Selector_Texture;
        private Texture2D FightNode_Texture;
        private Texture2D EventNode_Texture;
        private Texture2D RestNode_Texture;
        private Texture2D HPMPbar_Texture;
        private Texture2D Yes_Texture;
        private Texture2D No_Texture;
        private Texture2D Return_Texture;
        private Texture2D Logo_Texture;
        private Texture2D Taptostart_Texture;
        private Texture2D Gameover_Texture;
        private Texture2D HitEffect_Texture;
        private Texture2D Double_Slash_Texture;
        private Texture2D Wide_Slash_Texture;
        private Texture2D Blood_Drain_Texture;
        private Texture2D Ankle_Cut_Texture;
        private Texture2D Blood_Curse_Texture;
        private Texture2D Power_Boost_Texture;
        private Texture2D Aid_Texture;
        private Texture2D HeathPotio_Texture;
        private Texture2D ManaPotio_Texture;
        private Texture2D Bomb_Texture;
        private Texture2D HeathPotio_Texture2;
        private Texture2D ManaPotio_Texture2;
        private Texture2D Bomb_Texture2;
        private Texture2D Shop_Texture;
        private Texture2D Rest_Texture;
        private Texture2D Event_Texture;
        private Texture2D Event1_Texture;
        private Texture2D Event2_Texture;
        private Texture2D Event3_Texture;
        private Texture2D Event4_Texture;


        public UnitClass Lurker = new UnitClass(true, 6, 30, 5, 0, 20);
        public UnitClass Golem = new UnitClass(false,4, 40, 5, 3, 0);
        public UnitClass Ice_Golem = new UnitClass(false, 4, 60, 10, 3, 0);
        public UnitClass inventor = new UnitClass(true, 5, 30, 5, 1, 20);
        public UnitClass Beetle1 = new UnitClass(false,5, 10, 5, 3, 0);
        public UnitClass Beetle2 = new UnitClass(false, 5, 10, 5, 3, 0);
        public UnitClass Beetle3 = new UnitClass(false, 5, 10, 5, 3, 0);
        public UnitClass Rocky1 = new UnitClass(false, 3, 10, 5, 3, 0);
        public UnitClass Rocky2 = new UnitClass(false, 3, 10, 5, 3, 0);
        public UnitClass Rocky3 = new UnitClass(false, 3, 10, 5, 3, 0);
        public UnitClass Blood_Maiden = new UnitClass(true, 3, 30, 5, 2, 20);
        public UnitClass Dragonic_hunter = new UnitClass(true, 3, 30, 6, 0, 20);
        public UnitClass Boss = new UnitClass(false, 4, 100, 10, 8, 10);
        private UnitClass Nul = new UnitClass();


        private Button Attack_B = new Button(new Vector2(100, 360));
        private Button Skill_B = new Button(new Vector2(130, 410));
        private Button Item_B = new Button(new Vector2(100, 460));
        private Button Fight_B1 = new Button(new Vector2(1000, 1000));
        private Button Fight_B2 = new Button(new Vector2(1000, 1000));
        private Button Event_B1 = new Button(new Vector2(1000, 1000));
        private Button Event_B2 = new Button(new Vector2(1000, 1000));
        private Button Rest_B = new Button(new Vector2(1000, 1000));
        private Button Return_B = new Button(new Vector2(1000, 1000));
        private Button Yes_B = new Button(new Vector2(1000, 1000));
        private Button No_B = new Button(new Vector2(1000, 1000));

        private Button Double_Slash = new Button(new Vector2(1000, 1000));
        private Button Wide_Slash = new Button(new Vector2(1000, 1000));
        private Button Blood_Drain = new Button(new Vector2(1000, 1000));
        private Button Power_Boost = new Button(new Vector2(1000, 1000));
        private Button Ankle_Cut = new Button(new Vector2(1000, 1000));
        private Button Blood_Curse = new Button(new Vector2(1000, 1000));
        private Button Aid = new Button(new Vector2(1000, 1000));

        private Button HeathPotion = new Button(new Vector2(1000, 1000));
        private Button ManaPotion = new Button(new Vector2(1000, 1000));
        private Button Bomb = new Button(new Vector2(1000, 1000));

        private Vector2 Turn_Selector_Position;
        private Vector2 Turn_Order_Position = new Vector2(0, 360);
        private Vector2 Arrow_Position = new Vector2(1000, 1000);
        private Vector2 HitEffect_Position = new Vector2(1000, 1000);

        private List<UnitClass> Party = new List<UnitClass>();
        private List<UnitClass> EnemyGroup = new List<UnitClass>();
        private List<UnitClass> AllplayAble = new List<UnitClass>();
        private List<Button> ButtoninBattle = new List<Button>();
        private List<Button> ButtoninMap = new List<Button>();
        private List<Button> ButtoninShop = new List<Button>();
        private List<Button> ButtoninEvent = new List<Button>();
        private List<SoundEffect> BattleSFX = new List<SoundEffect>();

        private Song TitleBGM;
        private Song LoseBGM;
        private Song EventMapBGM;
        private Song EventMapBGM_Grass;
        private Song EventMapBGM_Cave;
        private Song EventMapBGM_Ice;
        private Song BattleBGM_1;
        private Song BattleBGM_2;
        private Song BossBGM;
        private Song BattleBGM_1_Grass;
        private Song BattleBGM_2_Grass;
        private Song BossBGM_Grass;
        private Song BattleBGM_1_Cave;
        private Song BattleBGM_2_Cave;
        private Song BossBGM_Cave;
        private Song BattleBGM_1_Ice;
        private Song BattleBGM_2_Ice;
        private Song BossBGM_Ice;
        private SoundEffect ClickSFX;
        private SoundEffect WinSFX;
        private SoundEffect CancleSFX;
        private SoundEffect GainSFX;
        private SoundEffect DeadSFX;

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
            Golem_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Golem/Golem-Icon");
            Beetle_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Beetle/Flying-Rock-Big-Icon");
            Rocky_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Rocky/Hermit-Rock-Big-Icon");
            Golem_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Golem/Golem-Big-Icon");
            Dragonic_hunter.ATK_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Dragonic_hunter/Dragonic-attack");
            Dragonic_hunter.Idle_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Dragonic_hunter/Dragonic-Idel-Sheet");
            Dragonic_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Dragonic_hunter/Dra_Face");
            Dragonic_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Dragonic-Icon");
            Blood_Maiden.ATK_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Blood_maiden/Blood-maiden-Attack");
            Blood_Maiden.Idle_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Blood_maiden/Blood-maiden-idel-Sheet");
            Blood_Maiden_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Blood Maiden Icon");
            Blood_Maiden_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Blood_maiden/BM_Face");
            Golem_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Golem/Golem-Sheet");
            Ice_Golem_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Ice-Golem-Sheet");
            Ice_Golem_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Ice-Golem-Icon");
            Ice_Golem_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Ice-Golem-Big-Icon");
            Boss_Texture = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Boss-Sheet2");
            Boss_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Boss-Icon");
            Boss_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Enemy/Boss-Big-Icon");
            inventor.ATK_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Inventor/Inventor-attack");
            inventor.Idle_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Inventor/Inventor-idel-sheet");
            Inventor_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Inventor Icon");
            Inventor_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Inventor/INV_Face");
            Lurker.ATK_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Lurker/Lurker-attack");
            Lurker.Idle_Sprite = Content.Load<Texture2D>("Asset 2D/Sprite/Lurker/Lurker-idel-sheet");
            Lurker_Small_Icon = Content.Load<Texture2D>("Asset 2D/UI/Lurker Icon");
            Lurker_Big_Icon = Content.Load<Texture2D>("Asset 2D/Sprite/Lurker/LU_Face");
            Background_Texture_1 = Content.Load<Texture2D>("Asset 2D/Background/Map_2");
            Background_Texture_2 = Content.Load<Texture2D>("Asset 2D/Background/1st_floor_2");
            Background_Texture_3 = Content.Load<Texture2D>("Asset 2D/Background/map_3_");
            Arrow_Texture = Content.Load<Texture2D>("Asset 2D/UI/Arrow");
            Attack_Texture = Content.Load<Texture2D>("Asset 2D/UI/Attack");
            Item_Texture = Content.Load<Texture2D>("Asset 2D/UI/Item");
            Skill_Texture = Content.Load<Texture2D>("Asset 2D/UI/Skill");
            Turn_Order_Texture  = Content.Load<Texture2D>("Asset 2D/UI/Turn-Order-Hub");
            Turn_Selector_Texture = Content.Load<Texture2D>("Asset 2D/UI/Turn Selector");
            FightNode_Texture = Content.Load<Texture2D>("Asset 2D/UI/Fight Node");
            EventNode_Texture = Content.Load<Texture2D>("Asset 2D/UI/Event Node");
            HPMPbar_Texture = Content.Load<Texture2D>("Asset 2D/UI/HP_MP_Bar");
            RestNode_Texture = Content.Load<Texture2D>("Asset 2D/UI/Rest Node");
            Yes_Texture = Content.Load<Texture2D>("Asset 2D/UI/button_yes");
            No_Texture = Content.Load<Texture2D>("Asset 2D/UI/button_no");
            Return_Texture = Content.Load<Texture2D>("Asset 2D/UI/button_return");
            Logo_Texture = Content.Load<Texture2D>("Asset 2D/UI/logo");
            Taptostart_Texture = Content.Load<Texture2D>("Asset 2D/UI/tap to start");
            HitEffect_Texture = Content.Load<Texture2D>("Asset 2D/UI/Hit-Effect");
            Gameover_Texture = Content.Load<Texture2D>("Asset 2D/Background/GameOver_version5");
            Double_Slash_Texture = Content.Load<Texture2D>("Asset 2D/UI/Double slash");
            Wide_Slash_Texture = Content.Load<Texture2D>("Asset 2D/UI/Wide slash");
            Blood_Drain_Texture = Content.Load<Texture2D>("Asset 2D/UI/Blood drain");
            Blood_Curse_Texture = Content.Load<Texture2D>("Asset 2D/UI/Blood curse");
            Power_Boost_Texture = Content.Load<Texture2D>("Asset 2D/UI/Power_boost");
            Ankle_Cut_Texture = Content.Load<Texture2D>("Asset 2D/UI/Ankle slash");
            Aid_Texture = Content.Load<Texture2D>("Asset 2D/UI/Aid");
            HeathPotio_Texture = Content.Load<Texture2D>("Asset 2D/UI/HP-Potion");
            ManaPotio_Texture = Content.Load<Texture2D>("Asset 2D/UI/MP-Potion");
            Bomb_Texture = Content.Load<Texture2D>("Asset 2D/UI/Bomb2");
            HeathPotio_Texture2 = Content.Load<Texture2D>("Asset 2D/UI/HP Potion");
            ManaPotio_Texture2 = Content.Load<Texture2D>("Asset 2D/UI/MP Potion");
            Bomb_Texture2 = Content.Load<Texture2D>("Asset 2D/UI/Bomb");
            Shop_Texture = Content.Load<Texture2D>("Asset 2D/Background/SHOP");
            Rest_Texture = Content.Load<Texture2D>("Asset 2D/Background/Camp");
            Event1_Texture = Content.Load<Texture2D>("Asset 2D/Background/Chest");
            Event2_Texture = Content.Load<Texture2D>("Asset 2D/Background/Hekp");
            Event3_Texture = Content.Load<Texture2D>("Asset 2D/Background/Trap");
            Event4_Texture = Content.Load<Texture2D>("Asset 2D/Background/Gold");


            font = Content.Load<SpriteFont>("font");

            TitleBGM = Content.Load<Song>("BGM/at-the-bottom-of-the-sea-where-the-sun-never-reaches-112916");
            EventMapBGM_Grass = Content.Load<Song>("BGM/monster-forest-114171");
            EventMapBGM_Cave = Content.Load<Song>("BGM/a-beautiful-step-99284");
            EventMapBGM_Ice = Content.Load<Song>("BGM/cold-snow-116417");
            BattleBGM_1_Grass = Content.Load<Song>("BGM/grasslands-9611");
            BattleBGM_2_Grass = Content.Load<Song>("BGM/warped-love-9260");
            BossBGM_Grass = Content.Load<Song>("BGM/human-14050");
            BattleBGM_1_Cave = Content.Load<Song>("BGM/light-15800");
            BattleBGM_2_Cave = Content.Load<Song>("BGM/epic-recovery-9797");
            BossBGM_Cave = Content.Load<Song>("BGM/go-back-to-the-heavens-49981");
            BattleBGM_1_Ice = Content.Load<Song>("BGM/on-a-snowy-night-9435");
            BattleBGM_2_Ice = Content.Load<Song>("BGM/eternal-loop-121064");
            BossBGM_Ice = Content.Load<Song>("BGM/cracked-40857");
            LoseBGM = Content.Load<Song>("BGM/to-a-beautiful-flower-with-no-name-20871");
            ClickSFX = Content.Load<SoundEffect>("SFX/Ui_Click");
            WinSFX = Content.Load<SoundEffect>("SFX/Result_EndWin");
            CancleSFX = Content.Load<SoundEffect>("SFX/Ui_Cancel");
            GainSFX = Content.Load<SoundEffect>("SFX/Story_ClothCatch");
            DeadSFX = Content.Load<SoundEffect>("SFX/WoodMachine_Kill");

            MediaPlayer.Play(TitleBGM);

            timeLoad = false;
            frameInCombat = 0;
            turn = 0;
            GoldNum = "" + Gold;
            
            isBattle = false;
            isMap = false;
            isTitle = true;
            isEvent = false;
            isLose = false;
            isRest = false;
            isCharactor = false;

            AllplayAble.Add(Lurker);
            AllplayAble.Add(inventor);
            AllplayAble.Add(Blood_Maiden);
            AllplayAble.Add(Dragonic_hunter);

            ButtoninBattle.Add(Attack_B);
            ButtoninBattle.Add(Skill_B);
            ButtoninBattle.Add(Item_B);

            ButtoninMap.Add(Fight_B1);
            ButtoninMap.Add(Event_B1);
            ButtoninMap.Add(Fight_B2);
            ButtoninMap.Add(Event_B2);
            ButtoninMap.Add(Rest_B);

            ButtoninShop.Add(HeathPotion);
            ButtoninShop.Add(ManaPotion);
            ButtoninShop.Add(Bomb);
            ButtoninShop.Add(Return_B);

            ButtoninEvent.Add(Yes_B);
            ButtoninEvent.Add(No_B);

            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Sword_Hori")); //0//
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Blow_Hori"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Philip_Hit"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Greed_Stab"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Effect_Heal"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Effect_Bleeding")); //5//
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/Effect_Buff"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/MatchGirl_Explosion"));
            BattleSFX.Add(Content.Load<SoundEffect>("SFX/SnowQueen_Atk"));

            Lurker.Skill_list.Add(Double_Slash);
            Lurker.Skill_list.Add(Ankle_Cut);
            Dragonic_hunter.Skill_list.Add(Double_Slash);
            Dragonic_hunter.Skill_list.Add(Wide_Slash);
            inventor.Skill_list.Add(Power_Boost);
            inventor.Skill_list.Add(Aid);
            Blood_Maiden.Skill_list.Add(Blood_Drain);
            Blood_Maiden.Skill_list.Add(Blood_Curse);

            Lurker.Item_list.Add(HeathPotion);
            inventor.Item_list.Add(HeathPotion);
            Blood_Maiden.Item_list.Add(HeathPotion);
            Dragonic_hunter.Item_list.Add(HeathPotion);
            Lurker.Item_list.Add(ManaPotion);
            inventor.Item_list.Add(ManaPotion);
            Blood_Maiden.Item_list.Add(ManaPotion);
            Dragonic_hunter.Item_list.Add(ManaPotion);
            Lurker.Item_list.Add(Bomb);
            inventor.Item_list.Add(Bomb);
            Blood_Maiden.Item_list.Add(Bomb);
            Dragonic_hunter.Item_list.Add(Bomb);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _keyboardState = Keyboard.GetState();
            if (isBattle == true)
            {
                UpdateGameplay(gameTime);
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
                UpdateCharactor(gameTime);
            }
            if (isShop == true)
            {
                UpdateShop();
            }

            if (roomNum >= 0 && roomNum < 15)
            {
                Background_Texture = Background_Texture_1;
                EventMapBGM = EventMapBGM_Grass;
                BattleBGM_1 = BattleBGM_1_Grass;
                BattleBGM_2 = BattleBGM_2_Grass;
                BossBGM = BossBGM_Grass;
            }
            if (roomNum >= 15 && roomNum < 30)
            {
                Background_Texture = Background_Texture_2;
                EventMapBGM = EventMapBGM_Cave;
                BattleBGM_1 = BattleBGM_1_Cave;
                BattleBGM_2 = BattleBGM_2_Cave;
                BossBGM = BossBGM_Cave;
            }
            if (roomNum >= 30)
            {
                Background_Texture = Background_Texture_3;
                EventMapBGM = EventMapBGM_Ice;
                BattleBGM_1 = BattleBGM_1_Ice;
                BattleBGM_2 = BattleBGM_2_Ice;
                BossBGM = BossBGM_Ice;
            }

            Old_keyboardState = _keyboardState;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
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
            if (isShop == true)
            {
                DrawShop();
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void UpdateGameplay(GameTime gameTime)
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
                TurnOrder[i].HPtext = "" + TurnOrder[i].HP;
                TurnOrder[i].MPtext = "" + TurnOrder[i].MP;
                Rectangle unitRectangle = new Rectangle((int)TurnOrder[i].spriteLocation.X, (int)TurnOrder[i].spriteLocation.Y, 270, 250);
                for (int m = 0; m < TurnOrder[i].Skill_list.Count; m++)
                {
                    if (m == 0)
                    {
                        TurnOrder[i].Skill_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y - 60);
                    }
                    if (m == 1)
                    {
                        TurnOrder[i].Skill_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X + 60, TurnOrder[i].spriteLocation.Y - 60);
                    }
                }
                for (int m = 0; m < TurnOrder[i].Item_list.Count; m++)
                {
                    if (m == 0)
                    {
                        TurnOrder[i].Item_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y - 60);
                    }
                    if (m == 1)
                    {
                        TurnOrder[i].Item_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y - 120);
                    }

                    if (m == 2)
                    {
                        TurnOrder[i].Item_list[m].ShowPosition = new Vector2(TurnOrder[i].spriteLocation.X, TurnOrder[i].spriteLocation.Y - 180);
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
                if (TurnOrder[i].isAttacking == true)
                {
                    TurnOrder[i].Unit_Sprite = TurnOrder[i].ATK_Sprite;
                    TurnOrder[i].frame = 0;
                    TurnOrder[i].ATKframe = 1;
                }
                else
                {
                    TurnOrder[i].Unit_Sprite = TurnOrder[i].Idle_Sprite;
                    TurnOrder[i].UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
                    TurnOrder[i].ATKframe = 0;
                }

                if (TurnOrder[i].myTurn == true && TurnOrder[i].Alive == true)
                {
                    Turn_Selector_Position = new Vector2(TurnOrder[i].spriteLocation.X + 30, TurnOrder[i].spriteLocation.Y - 30);
                    TurnOrder[i].Big_iconLocation = new Vector2(0, 360);
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
                            TargetAlly = false;
                            TargetEnemy = false;
                            BattleTxt = "";
                            UseSkill = 0;
                            UseItem = 0;
                            ATKcount = 0;
                            Partywaitingtime = 0;
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

                            if (ButtoninBattle[n].Pressed == false && Attacking == false && Skilling == false && Iteming == false)
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

                        if (Attacking == true && Skilling == false && Iteming == false)
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
                                    HitEffect_Position = EnemyGroup[m].spriteLocation;
                                    TurnOrder[i].ATKframe = 1;
                                    BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                }
                            }
                        }
                        if (Skilling == true && Attacking == false && Iteming == false)
                        {
                            for (int m = 0; m < TurnOrder[i].Skill_list.Count; m++)
                            {
                                TurnOrder[i].Skill_list[m].Position = TurnOrder[i].Skill_list[m].ShowPosition;
                                Rectangle buttonRectangle = new Rectangle((int)TurnOrder[i].Skill_list[m].Position.X, (int)TurnOrder[i].Skill_list[m].Position.Y, 50, 50);
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
                                    if (TurnOrder[i].Skill_list[m] == Double_Slash)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 1;
                                            Skilling2 = true;
                                            TargetEnemy = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "Attack one target twice";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Wide_Slash)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 2;
                                            Skilling2 = true;
                                            TargetEnemy = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "Attack all enemy once";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Blood_Drain)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 3;
                                            Skilling2 = true;
                                            TargetEnemy = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "Drain one enemy";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Power_Boost)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 4;
                                            Skilling2 = true;
                                            TargetAlly = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "increse an ally attack power by 5 for this battle";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Ankle_Cut)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 5;
                                            Skilling2 = true;
                                            TargetEnemy = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "Attack and decrese enemy speed by 2";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Blood_Curse)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 6;
                                            Skilling2 = true;
                                            TargetEnemy = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "Decrese all enemy Attack by 2";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                    if (TurnOrder[i].Skill_list[m] == Aid)
                                    {
                                        if (TurnOrder[i].MP >= 5)
                                        {
                                            UseSkill = 7;
                                            Skilling2 = true;
                                            TargetAlly = true;
                                            TurnOrder[i].Skill_list[m].Pressed = true;
                                            BattleTxt = "Heal one ally 20";
                                        }
                                        else
                                        {
                                            BattleTxt = "No enought mana";
                                        }
                                    }
                                }
                                
                                if (Skilling2 == true)
                                {
                                    Enemywaitingtime += 1;
                                    if (TargetEnemy == true)
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
                                                Skilling2 = false;
                                                target = n;
                                            }
                                        }
                                    }
                                    if (TargetAlly == true)
                                    {
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
                                            if (ATKcount == 0 && Enemywaitingtime > 5)
                                            {
                                                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && Party[n].mouseHover == true && Party[n].Alive == true)
                                                {
                                                    Skilling3 = true;
                                                    Skilling2 = false;
                                                    target = n;
                                                    ATKcount += 1;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (Skilling3 == true)
                                {
                                    if (UseSkill == 1)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            TurnOrder[i].isAttacking = true;
                                            EnemyGroup[target].attacked = true;
                                            EnemyGroup[target].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[target].spriteLocation2 = EnemyGroup[target].spriteLocation;
                                            EnemyGroup[target].spriteLocation.X += 20;
                                            TurnOrder[i].ATKframe = 1;
                                            HitEffect_Position = EnemyGroup[target].spriteLocation;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                        Partywaitingtime += 1;
                                        if (Partywaitingtime == 20)
                                        {
                                            timeLoad = true;
                                            TurnOrder[i].MP -= 5;
                                            EnemyGroup[target].attacked = true;
                                            EnemyGroup[target].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[target].spriteLocation2 = EnemyGroup[target].spriteLocation;
                                            EnemyGroup[target].spriteLocation.X += 20;
                                            TurnOrder[i].ATKframe = 1;
                                            HitEffect_Position = EnemyGroup[target].spriteLocation;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                    }
                                    if (UseSkill == 2)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            TurnOrder[i].MP -= 5;
                                        }
                                        Partywaitingtime += 1;
                                        TurnOrder[i].isAttacking = true;
                                        TurnOrder[i].ATKframe = 1;
                                        if (ATKcount < EnemyGroup.Count)
                                        {
                                            EnemyGroup[ATKcount].attacked = true;
                                            EnemyGroup[ATKcount].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[ATKcount].spriteLocation2 = EnemyGroup[ATKcount].spriteLocation;
                                            EnemyGroup[ATKcount].spriteLocation.X += 20;
                                            ATKcount += 1;
                                            HitEffect_Position = EnemyGroup[target].spriteLocation;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                        else
                                        {
                                            timeLoad = true;
                                        }
                                    }
                                    if (UseSkill == 3)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            TurnOrder[i].isAttacking = true;
                                            TurnOrder[i].ATKframe = 1;
                                            EnemyGroup[target].attacked = true;
                                            EnemyGroup[target].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[target].spriteLocation2 = EnemyGroup[ATKcount].spriteLocation;
                                            EnemyGroup[target].spriteLocation.X += 20;
                                            TurnOrder[i].HP += TurnOrder[i].Atk;
                                            if (TurnOrder[i].HP > TurnOrder[i].MaxHP)
                                            {
                                                TurnOrder[i].HP = TurnOrder[i].MaxHP;
                                            }
                                            timeLoad = true;
                                            TurnOrder[i].MP -= 5;
                                            HitEffect_Position = EnemyGroup[target].spriteLocation;
                                            BattleSFX[5].CreateInstance().Play();
                                        }
                                        Partywaitingtime += 1;
                                    }
                                    if (UseSkill == 4)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            TurnOrder[i].isAttacking = true;
                                            TurnOrder[i].ATKframe = 1;
                                            Party[target].healed = true;
                                            Party[target].Atk += 5;
                                            timeLoad = true;
                                            BattleSFX[4].CreateInstance().Play();
                                        }
                                        Partywaitingtime += 1;
                                    }
                                    if (UseSkill == 5)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            TurnOrder[i].isAttacking = true;
                                            TurnOrder[i].ATKframe = 1;
                                            EnemyGroup[target].attacked = true;
                                            EnemyGroup[target].HP -= TurnOrder[i].Atk;
                                            EnemyGroup[target].spriteLocation2 = EnemyGroup[ATKcount].spriteLocation;
                                            EnemyGroup[target].spriteLocation.X += 20;
                                            EnemyGroup[target].speed -= 2;
                                            HitEffect_Position = EnemyGroup[target].spriteLocation;
                                            timeLoad = true;
                                            BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                        }
                                        Partywaitingtime += 1;
                                    }
                                    if (UseSkill == 6)
                                    {
                                        TurnOrder[i].isAttacking = true;
                                        TurnOrder[i].ATKframe = 1;
                                        if (ATKcount < EnemyGroup.Count)
                                        {
                                            EnemyGroup[ATKcount].attacked = true;
                                            EnemyGroup[ATKcount].Atk -= 2;
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
                                    if (UseSkill == 7)
                                    {
                                        if (Partywaitingtime == 0)
                                        {
                                            TurnOrder[i].isAttacking = true;
                                            TurnOrder[i].ATKframe = 1;
                                            Party[target].healed = true;
                                            Party[target].HP += 20;
                                            if (Party[target].HP > Party[i].MaxHP)
                                            {
                                                Party[i].HP = Party[i].MaxHP;
                                            }
                                            timeLoad = true;
                                            BattleSFX[4].CreateInstance().Play();
                                        }
                                        Partywaitingtime += 1;
                                    }
                                }
                            }
                        }
                        if (Iteming == true && Attacking == false && Skilling == false)
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
                                    if (TurnOrder[i].Item_list[m] == HeathPotion)
                                    {
                                        if (HPPotionAmo > 0)
                                        {
                                            Iteming2 = true;
                                            TurnOrder[i].Item_list[m].Pressed = true;
                                            UseItem = 1;
                                            TargetAlly = true;
                                            BattleTxt = "Heal one ally 20 HP(" + HPPotionAmo + ")";
                                        }
                                        else
                                        {
                                            BattleTxt = "No Potion left";
                                        }
                                    }
                                    if (TurnOrder[i].Item_list[m] == ManaPotion)
                                    {
                                        if (MPPotionAmo > 0)
                                        {
                                            Iteming2 = true;
                                            TurnOrder[i].Item_list[m].Pressed = true;
                                            UseItem = 2;
                                            TargetAlly = true;
                                            BattleTxt = "Heal one ally 10 MP(" + MPPotionAmo + ")";
                                        }
                                        else
                                        {
                                            BattleTxt = "No Potion left";
                                        }
                                    }
                                    if (TurnOrder[i].Item_list[m] == Bomb)
                                    {
                                        if (BombAmo > 0)
                                        {
                                            Iteming2 = true;
                                            TurnOrder[i].Item_list[m].Pressed = true;
                                            UseItem = 3;
                                            TargetEnemy = true;
                                            BattleTxt = "Deal massive damage to an enemy(" + BombAmo + ")";
                                        }
                                        else
                                        {
                                            BattleTxt = "No Bomb left";
                                        }
                                    }
                                }
                                if (Iteming2 == true)
                                {
                                    Enemywaitingtime += 1;
                                    if (TargetAlly == true)
                                    {
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
                                            if (ATKcount == 0 && Enemywaitingtime > 5)
                                            {
                                                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && Party[n].mouseHover == true && Party[n].Alive == true)
                                                {
                                                    if (UseItem == 1)
                                                    {
                                                        Party[n].healed = true;
                                                        Party[n].HP += 20;
                                                        HPPotionAmo -= 1;
                                                        ATKcount += 1;
                                                        if (Party[n].HP > Party[n].MaxHP)
                                                        {
                                                            Party[n].HP = Party[n].MaxHP;
                                                        }
                                                        BattleSFX[4].CreateInstance().Play();
                                                        timeLoad = true;
                                                    }
                                                    if (UseItem == 2)
                                                    {
                                                        Party[n].healed = true;
                                                        Party[n].MP += 10;
                                                        MPPotionAmo -= 1;
                                                        ATKcount += 1;
                                                        if (Party[n].MP > Party[n].MaxMP)
                                                        {
                                                            Party[n].MP = Party[n].MaxMP;
                                                        }
                                                        BattleSFX[4].CreateInstance().Play();
                                                        timeLoad = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (TargetEnemy == true)
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
                                            if (ATKcount == 0 && Enemywaitingtime > 5)
                                            {
                                                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed && EnemyGroup[n].mouseHover == true)
                                                {
                                                    if (UseItem == 3)
                                                    {
                                                        EnemyGroup[n].attacked = true;
                                                        EnemyGroup[n].HP -= 20;
                                                        BombAmo -= 1;
                                                        ATKcount += 1;
                                                        timeLoad = true;
                                                        BattleSFX[7].CreateInstance().Play();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (TurnOrder[i].playable == false && TurnOrder[i].Alive == true)
                    {
                        if (TurnOrder[i] == Boss)
                        {
                            if (TurnOrder[i].MP == 10)
                            {
                                Skilling = true;
                            }
                            if (Skilling == true)
                            {
                                Enemywaitingtime += 1;
                                TurnOrder[i].isAttacking = true;
                                if (ATKcount < Party.Count)
                                {
                                    Party[ATKcount].attacked = true;
                                    Party[ATKcount].HP -= TurnOrder[i].Atk;
                                    Party[ATKcount].spriteLocation2 = Party[ATKcount].spriteLocation;
                                    Party[ATKcount].spriteLocation.X -= 20;
                                    ATKcount += 1;
                                    HitEffect_Position = Party[target].spriteLocation;
                                    BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                }
                                else
                                {
                                    timeLoad = true;
                                    TurnOrder[i].MP -= 10;
                                    Skilling = false;
                                    ATKcount = 0;
                                }
                            }
                            if (Skilling == false)
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
                                    HitEffect_Position = Party[target].spriteLocation;
                                    TurnOrder[i].MP += 5;
                                    BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                                }
                            }
                        }
                        else
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
                                HitEffect_Position = Party[target].spriteLocation;
                                BattleSFX[TurnOrder[i].AttackSFX].CreateInstance().Play();
                            }
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
                    BattleTxt = "";
                    TurnOrder[i].myTurn = false;
                    TurnOrder[i].isAttacking = false;
                    Enemywaitingtime = 0;
                    Partywaitingtime = 0;
                    ATKcount = 0;
                    iconOrder += 1;
                    UseSkill = 0;
                    TargetAlly = false;
                    TargetEnemy = false;
                    HitEffect_Position = new Vector2(1000, 1000);
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
                    if (TurnOrder[i].playable == false)
                    {
                        for (int m = 0; m < EnemyGroup.Count; m++)
                        {
                            if (TurnOrder[i] == EnemyGroup[m])
                            {
                                DeadSFX.CreateInstance().Play();
                                EnemyGroup[m].attacked = false;
                                EnemyGroup[m].HP = EnemyGroup[m].MaxHP;
                                EnemyGroup[m].Alive = true;
                                EnemyGroup[m].speed = EnemyGroup[m].Ospeed;
                                EnemyGroup[m].Atk = EnemyGroup[m].Oatk;
                                if (EnemyGroup[m] == Golem)
                                {
                                    Gold += 200;
                                }
                                else
                                {
                                    Gold += 50;
                                }
                                EnemyGroup.RemoveAt(m);
                            }
                        }
                    }

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

            if (EnemyGroup.Count == 0)
            {
                if (ATKcount == 0 && Enemywaitingtime == 0)
                {
                    WinSFX.CreateInstance().Play();
                    BattleTxt = "Victory!";
                    MediaPlayer.Stop();
                    ATKcount += 1;
                }
                Enemywaitingtime += 1;
                if (Enemywaitingtime == 80)
                {
                    for (int i = 0; i < TurnOrder.Count; i++)
                    {
                        TurnOrder[i].myTurn = false;
                        TurnOrder[i].ATKframe = 0;
                        TurnOrder[i].Atk = TurnOrder[i].Oatk;
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
                    RandomNode();
                    ResetCombat();
                    isMap = true;
                    isBattle = false;
                }
            }
            

            if (Party.Count == 3)
            {
                if (Party[0].Alive == false && Party[1].Alive == false && Party[2].Alive == false)
                {
                    MediaPlayer.Play(LoseBGM);
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
                    MediaPlayer.Play(LoseBGM);
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
            if (Party.Count == 1)
            {
                if (Party[0].Alive == false)
                {
                    MediaPlayer.Play(LoseBGM);
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

            Old_mouseState = mouseState;

            
        }

        private void UpdateEventMap()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            for (int i = 0; i < Party.Count; i++)
            {
                Party[i].HPtext = "" + Party[i].HP;
                Party[i].MPtext = "" + Party[i].MP;
            }

            for (int i = 0; i < ButtoninMap.Count; i++)
            {
                Rectangle buttonRectangle = new Rectangle((int)ButtoninMap[i].Position.X, (int)ButtoninMap[i].Position.Y, 215, 215);
                if (isFighting == false && isInteracting == false && Resting == false)
                {
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
            }

            if (isFighting == true && isInteracting == false && Resting == false)
            {
                Random r = new Random();
                int x = r.Next(1, 6);

                if (x == 1)
                {
                    EnemyGroup.Add(Beetle1);

                    MediaPlayer.Play(BattleBGM_1);
                }
                if (x == 2)
                {
                    EnemyGroup.Add(Rocky1);

                    MediaPlayer.Play(BattleBGM_1);
                }

                if (x == 3)
                {
                    EnemyGroup.Add(Rocky1);
                    EnemyGroup.Add(Rocky2);

                    MediaPlayer.Play(BattleBGM_1);
                }
                if (x == 4)
                {
                    EnemyGroup.Add(Beetle1);
                    EnemyGroup.Add(Beetle2);

                    MediaPlayer.Play(BattleBGM_2);
                }
                if (x == 5)
                {
                    MediaPlayer.Play(BossBGM);
                    if (roomNum >= 20)
                    {
                        EnemyGroup.Add(Ice_Golem);
                    }
                    if (roomNum >= 30)
                    {
                        EnemyGroup.Add(Boss);
                    }
                    else
                    {
                        EnemyGroup.Add(Golem);
                    }
                }
                roomNum += 1;
                ResetMap();
                isMap = false;
                isBattle = true;
                isFighting = false;
                BattleTxt = "";
            }

            if (isInteracting == true && isFighting == false && Resting == false)
            {
                Random r = new Random();
                int x = r.Next(1, 4);
                if (x == 1 || x == 3)
                {
                    eventNum = r.Next(1, 4);
                    isEvent = true;
                    ResetMap();
                    roomNum += 1;
                    isMap = false;
                    isInteracting = false;
                }
                if (x == 2)
                {
                    isShop = true;
                    ResetMap();
                    roomNum += 1;
                    isMap = false;
                    isInteracting = false;
                }
            }

            if (Resting == true && isFighting == false && isInteracting == false)
            {
                roomNum += 1;
                BattleSFX[4].CreateInstance().Play();
                for (int i = 0; i < Party.Count; i++)
                {
                    if (Party[i].Alive == false)
                    {
                        Party[i].Alive = true;
                        Party[i].HP = 10;
                    }
                    else
                    {
                        Party[i].HP = Party[i].MaxHP;
                        Party[i].MP = Party[i].MaxMP;
                    }
                }
                ResetMap();
                isMap = false;
                isRest = true;
                Resting = false;
            }

            if (_keyboardState.IsKeyUp(Keys.L) == true && Old_keyboardState.IsKeyDown(Keys.L) == true)
            {
                Party.Add(Lurker);
            }
            if (_keyboardState.IsKeyUp(Keys.I) == true && Old_keyboardState.IsKeyDown(Keys.I) == true)
            {
                Party.Add(inventor);
            }
            if (_keyboardState.IsKeyUp(Keys.B) == true && Old_keyboardState.IsKeyDown(Keys.B) == true)
            {
                Party.Add(Blood_Maiden);
            }
            if (_keyboardState.IsKeyUp(Keys.D) == true && Old_keyboardState.IsKeyDown(Keys.D) == true)
            {
                Party.Add(Dragonic_hunter);
            }
            if (_keyboardState.IsKeyUp(Keys.D) == true && Old_keyboardState.IsKeyDown(Keys.D8) == true)
            {
                EnemyGroup.Add(Boss);
                MediaPlayer.Play(BossBGM_Ice);
                roomNum += 1;
                ResetMap();
                isMap = false;
                isBattle = true;
                isFighting = false;
                BattleTxt = "";
            }
            if (_keyboardState.IsKeyUp(Keys.D) == true && Old_keyboardState.IsKeyDown(Keys.D7) == true)
            {
                EnemyGroup.Add(Ice_Golem);
                MediaPlayer.Play(BossBGM_Ice);
                roomNum += 1;
                ResetMap();
                isMap = false;
                isBattle = true;
                isFighting = false;
                BattleTxt = "";
            }

            Old_mouseState = mouseState;
        }

        private void UpdateTitle()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            
            if (unloop_frame_1 == 1 && unloop_frame_2 == 5)
            {
                Partywaitingtime = 0;
                if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
                {
                    isCharactor = true;
                    isTitle = false;
                }
            }
            else
            {
                Partywaitingtime += 1;
            }
            

            if (Partywaitingtime == 5)
            {
                Partywaitingtime = 0;
                unloop_frame_1 += 1;
            }
            if (unloop_frame_1 == 3)
            {
                unloop_frame_2 += 1;
                unloop_frame_1 = 0;
            }
            Old_mouseState = mouseState;
        }

        private void UpdateEvent()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            Random r = new Random();
            for (int i = 0; i < Party.Count; i++)
            {
                Party[i].HPtext = "" + Party[i].HP;
                Party[i].MPtext = "" + Party[i].MP;
                if (Party[i].HP <= 0)
                {
                    Party[i].Alive = false;
                }
            }

            if (eventNum == 1 || eventNum == 3)
            {
                if (Yes == false)
                {
                    EventTxt = "There's a unopen 'chest' \n Do you want to open it?";
                    Event_Texture = Event1_Texture;
                }
                if (Yes == true)
                {
                    if(eventChance == 1 || eventChance == 4)
                    {
                        if (Partywaitingtime == 0)
                        {
                            Event_Texture = Event3_Texture;
                            EventTxt = "It was trap!";
                            int x = r.Next(0, Party.Count);
                            BattleSFX[0].CreateInstance().Play();
                            Party[x].HP -= 10;
                            Return_B.Position = new Vector2(0, 500);
                        }
                        Partywaitingtime += 1;
                    }
                    if (eventChance == 2 || eventChance == 3)
                    {
                        if (Partywaitingtime == 0)
                        {
                            Event_Texture = Event4_Texture;
                            EventTxt = "You gain 150 gold!";
                            Gold += 150;
                            GainSFX.CreateInstance().Play();
                            Return_B.Position = new Vector2(0, 500);
                        }
                        Partywaitingtime += 1;
                    }
                }
            }
            if (eventNum == 2)
            {
                Event_Texture = Event2_Texture;
                if (Yes == false)
                {
                    EventTxt = "You hear a person fight group of monster \n Do you want to help?";
                }
                if (Yes == true)
                {
                    for (int i = 0; i < Party.Count; i++)
                    {
                        if (Partywaitingtime == 0)
                        {
                            do
                            {
                                CharactorCode = r.Next(0, AllplayAble.Count);
                            }
                            while (Party[i] == AllplayAble[CharactorCode]);
                        }
                        Partywaitingtime += 1;
                        if (Partywaitingtime == 5)
                        {
                            Party.Add(AllplayAble[CharactorCode]);
                            EnemyGroup.Add(Rocky1);
                            EnemyGroup.Add(Rocky2);
                            EnemyGroup.Add(Rocky3);
                            MediaPlayer.Play(BattleBGM_2);
                            EventTxt = "";
                            isBattle = true;
                            isEvent = false;
                            Yes = false;
                            Partywaitingtime = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < ButtoninEvent.Count; i++)
            {
                if (Yes == false && No == false)
                {
                    Rectangle buttonRectangle = new Rectangle((int)ButtoninEvent[i].Position.X, (int)ButtoninEvent[i].Position.Y, 160, 60);
                    if (buttonRectangle.Contains(mousePosition))
                    {
                        ButtoninEvent[i].mouseHover = true;
                    }
                    else
                    {
                        ButtoninEvent[i].mouseHover = false;
                    }
                    if (ButtoninEvent[i].mouseHover == true)
                    {
                        ButtoninEvent[i].State = Color.Gray;
                    }
                    if (ButtoninEvent[i].mouseHover == false && ButtoninEvent[i].Pressed == false)
                    {
                        ButtoninEvent[i].State = Color.White;
                    }
                    if (mouseState.LeftButton != ButtonState.Pressed && ButtoninEvent[i].mouseHover == true && Old_mouseState.LeftButton == ButtonState.Pressed)
                    {
                        eventChance = r.Next(1, 5);
                        if (ButtoninEvent[i] == Yes_B)
                        {
                            Yes = true;
                            ClickSFX.CreateInstance().Play();
                        }
                        if (ButtoninEvent[i] == No_B)
                        {
                            No = true;
                            CancleSFX.CreateInstance().Play();
                        }
                    }
                }
            }
            Rectangle RbuttonRectangle = new Rectangle((int)Return_B.Position.X, (int)Return_B.Position.Y, 160, 60);
            if (RbuttonRectangle.Contains(mousePosition))
            {
                Return_B.mouseHover = true;
            }
            else
            {
                Return_B.mouseHover = false;
            }
            if (Return_B.mouseHover == true)
            {
                Return_B.State = Color.Gray;
            }
            if (Return_B.mouseHover == false && Return_B.Pressed == false)
            {
                Return_B.State = Color.White;
            }
            if (mouseState.LeftButton != ButtonState.Pressed && Return_B.mouseHover == true && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Rreturn = true;
            }
            if (No == true || Rreturn == true)
            {
                EventTxt = "";
                isMap = true;
                isEvent = false;
                RandomNode();
                No = false;
                Yes = false;
                Rreturn = false;
                Partywaitingtime = 0;
            }
            if (Party.Count == 3)
            {
                if (Party[0].Alive == false && Party[1].Alive == false && Party[2].Alive == false)
                {
                    MediaPlayer.Play(LoseBGM);
                    isLose = true;
                    isEvent = false;
                }
            }
            if (Party.Count == 2)
            {
                if (Party[0].Alive == false && Party[1].Alive == false)
                {
                    MediaPlayer.Play(LoseBGM);
                    isLose = true;
                    isEvent = false;
                }
            }
            if (Party.Count == 1)
            {
                if (Party[0].Alive == false)
                {
                    MediaPlayer.Play(LoseBGM);
                    isLose = true;
                    isEvent = false;
                }
            }

            Old_mouseState = mouseState;
        }

        private void UpdateLose()
        {
            var mouseState = Mouse.GetState();
            if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                isTitle = true;
                isLose = false;
                MediaPlayer.Play(TitleBGM);
                unloop_frame_1 = 0;
                unloop_frame_2 = 0;
                Partywaitingtime = 0;
                roomNum = 1;
                Gold = 0;
                HPPotionAmo = 1;
                MPPotionAmo = 1;
                BombAmo = 1;
                ResetCombat();
                for (int i = 0; i < AllplayAble.Count; i++)
                {
                    AllplayAble[i].Alive = true;
                    for (int m = 0; m < Party.Count; m++)
                    {
                        if (AllplayAble[i] == Party[m])
                        {
                            Party[m].attacked = false;
                            Party[m].HP = Party[m].MaxHP;
                            Party[m].Alive = true;
                            Party[m].speed = Party[m].Ospeed;
                            Party[m].Atk = Party[m].Oatk;
                            Party[m].MP = Party[m].MaxMP;
                            Party[m].State = Color.White;
                            Party.RemoveAt(m);
                        }
                    }
                }
                for (int m = 0; m < EnemyGroup.Count; m++)
                {
                    EnemyGroup[m].attacked = false;
                    EnemyGroup[m].HP = EnemyGroup[m].MaxHP;
                    EnemyGroup[m].Alive = true;
                    EnemyGroup[m].speed = EnemyGroup[m].Ospeed;
                    EnemyGroup[m].Atk = EnemyGroup[m].Oatk;
                    EnemyGroup.RemoveAt(m);
                }
            }
            Old_mouseState = mouseState;
        }

        private void UpdateRest()
        {
            var mouseState = Mouse.GetState();
            for (int i = 0; i < Party.Count; i++)
            {
                Party[i].HPtext = "" + Party[i].HP;
                Party[i].MPtext = "" + Party[i].MP;
            }

            if (mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                isMap = true;
                isRest = false;
                RandomNode();

            }
            Old_mouseState = mouseState;
        }

        private void UpdateCharactor(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            Rectangle LurkerRectangle = new Rectangle((int)Lurker.spriteLocation.X, (int)Lurker.spriteLocation.Y, 215, 215);
            Rectangle InventorRectangle = new Rectangle((int)inventor.spriteLocation.X, (int)inventor.spriteLocation.Y, 215, 215);
            Rectangle BloodRectangle = new Rectangle((int)Blood_Maiden.spriteLocation.X, (int)Blood_Maiden.spriteLocation.Y, 215, 215);
            Rectangle DragonicRectangle = new Rectangle((int)Dragonic_hunter.spriteLocation.X, (int)Dragonic_hunter.spriteLocation.Y, 215, 215);
            for (int i = 0; i < AllplayAble.Count; i++)
            {
                AllplayAble[i].Unit_Sprite = AllplayAble[i].Idle_Sprite;
                AllplayAble[i].UpdateFrame((float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (LurkerRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(Lurker);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                ClickSFX.CreateInstance().Play();
                RandomNode();
            }
            if (InventorRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(inventor);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                ClickSFX.CreateInstance().Play();
                RandomNode();
            }
            if (BloodRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(Blood_Maiden);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                ClickSFX.CreateInstance().Play();
                RandomNode();
            }
            if (DragonicRectangle.Contains(mousePosition) && mouseState.LeftButton != ButtonState.Pressed && Old_mouseState.LeftButton == ButtonState.Pressed)
            {
                Party.Add(Dragonic_hunter);
                isMap = true;
                isCharactor = false;
                MediaPlayer.Play(EventMapBGM);
                ClickSFX.CreateInstance().Play();
                RandomNode();
            }
            

            Old_mouseState = mouseState;
        }

        private void UpdateShop()
        {
            var mouseState = Mouse.GetState();
            var mousePosition = new Point(mouseState.X, mouseState.Y);
            Return_B.Position = new Vector2(0, 500);
            for (int i = 0; i < ButtoninShop.Count; i++)
            {
                Rectangle buttonRectangle = new Rectangle((int)ButtoninShop[i].Position.X, (int)ButtoninShop[i].Position.Y, 150, 150);
                if (i == 0)
                {
                    ButtoninShop[i].Position = new Vector2(750, 320);
                }
                if (i == 1)
                {
                    ButtoninShop[i].Position = new Vector2(960, 320);
                }
                if (i == 2)
                {
                    ButtoninShop[i].Position = new Vector2(1170, 320);
                }
                if (buttonRectangle.Contains(mousePosition))
                {
                    ButtoninShop[i].mouseHover = true;
                }
                else
                {
                    ButtoninShop[i].mouseHover = false;
                }
                if (ButtoninShop[i].mouseHover == true)
                {
                    ButtoninShop[i].State = Color.Gray;
                }
                if (ButtoninShop[i].mouseHover == false && ButtoninShop[i].Pressed == false)
                {
                    ButtoninShop[i].State = Color.White;
                }
                if (mouseState.LeftButton != ButtonState.Pressed && ButtoninShop[i].mouseHover == true && Old_mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (ButtoninShop[i] == HeathPotion)
                    {
                        if (Gold >= 200)
                        {
                            Gold -= 200;
                            HPPotionAmo += 1;
                            ClickSFX.CreateInstance().Play();
                        }
                        else
                        {
                            ShopTxt = "Not enought gold";
                        }
                    }
                    if (ButtoninShop[i] == ManaPotion)
                    {
                        if (Gold >= 200)
                        {
                            Gold -= 200;
                            MPPotionAmo += 1;
                            ClickSFX.CreateInstance().Play();
                        }
                        else
                        {
                            ShopTxt = "Not enought gold";
                        }
                    }
                    if (ButtoninShop[i] == Bomb)
                    {
                        if (Gold >= 300)
                        {
                            Gold -= 300;
                            BombAmo += 1;
                            ClickSFX.CreateInstance().Play();
                        }
                        else
                        {
                            ShopTxt = "Not enought gold";
                        }
                    }
                    if (ButtoninShop[i] == Return_B)
                    {
                        Rreturn = true;
                    }
                }
            }

            if (Rreturn == true)
            {
                for (int i = 0; i < ButtoninShop.Count; i++)
                {
                    ButtoninShop[i].Position = new Vector2(1000, 1000);
                    ButtoninShop[i].Pressed = false;
                    ButtoninShop[i].mouseHover = false;
                }
                isMap = true;
                isShop = false;
                Rreturn = false;
                RandomNode();
                CancleSFX.CreateInstance().Play();
            }
            Old_mouseState = mouseState;
        }

        private void DrawBattale1()
        {
            _spriteBatch.Draw(Background_Texture, Vector2.Zero, Color.White);
            _spriteBatch.Draw(Turn_Selector_Texture, Turn_Selector_Position, Color.White);
            
            for (int i = 0; i < Party.Count; i++)
            {
                if (Party[i] == Lurker)
                {
                    _spriteBatch.Draw(Lurker.Unit_Sprite, Lurker.spriteLocation, new Rectangle(Lurker.frame * 150, 0, 150 + (60 * Lurker.ATKframe), 210), Lurker.State);
                }
                if (Party[i] == inventor)
                {
                    _spriteBatch.Draw(inventor.Unit_Sprite, inventor.spriteLocation, new Rectangle(inventor.frame * 150, 0, 150 + (60 * inventor.ATKframe), 210), inventor.State);
                }
                if (Party[i] == Blood_Maiden)
                {
                    _spriteBatch.Draw(Blood_Maiden.Unit_Sprite, Blood_Maiden.spriteLocation, new Rectangle(Blood_Maiden.frame * 180, 0, 180, 210 + (30 * Blood_Maiden.ATKframe)), Blood_Maiden.State);
                }
                if (Party[i] == Dragonic_hunter)
                {
                    _spriteBatch.Draw(Dragonic_hunter.Unit_Sprite, Dragonic_hunter.spriteLocation, new Rectangle(Dragonic_hunter.frame * 152, 0, 152 + (80 * Dragonic_hunter.ATKframe), 210), Dragonic_hunter.State);
                }
                if (i == 0)
                {
                    Party[i].spriteLocation = SetPO1; 
                    Party[i].spriteLocation2 = Party[i].spriteLocation;
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X + 40, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].MPbar_Location = new Vector2(Party[i].HPMPbar_iconLocation.X, Party[i].HPMPbar_iconLocation.Y + 30);
                    Party[i].HPicon_Location = new Vector2(SetPO1.X, SetPO1.Y - 240);
                }
                if (i == 1)
                {
                    Party[i].spriteLocation = new Vector2(SetPO1.X - 200, SetPO1.Y);
                    Party[i].spriteLocation2 = Party[i].spriteLocation;
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 240, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].MPbar_Location = new Vector2(Party[i].HPMPbar_iconLocation.X, Party[i].HPMPbar_iconLocation.Y + 30);
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 270, SetPO1.Y - 240);
                }
                if (i == 2)
                {
                    Party[i].spriteLocation = new Vector2(SetPO1.X - 400, SetPO1.Y);
                    Party[i].spriteLocation2 = Party[i].spriteLocation;
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 520, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].MPbar_Location = new Vector2(Party[i].HPMPbar_iconLocation.X, Party[i].HPMPbar_iconLocation.Y + 30);
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 540, SetPO1.Y - 240);
                }
            }
            
            for (int i = 0; i < EnemyGroup.Count; i++)
            {
                if (EnemyGroup[i] == Golem)
                {
                    _spriteBatch.Draw(Golem_Texture, Golem.spriteLocation, new Rectangle(Golem.frame * 324, 0, 324, 310), Golem.State);
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
                if (EnemyGroup[i] == Ice_Golem)
                {
                    _spriteBatch.Draw(Ice_Golem_Texture, Ice_Golem.spriteLocation, new Rectangle(Ice_Golem.frame * 322, 0, 322, 310), Ice_Golem.State);
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
                if (EnemyGroup[i] == Boss)
                {
                    _spriteBatch.Draw(Boss_Texture, Boss.spriteLocation, new Rectangle(Boss.frame * 390, 0, 390, 324), Boss.State);
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
                    _spriteBatch.Draw(Rocky_Text, Rocky1.spriteLocation, new Rectangle(Rocky1.frame * 100, 0, 100, 100), Rocky1.State);
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
                    _spriteBatch.Draw(Rocky_Text, Rocky2.spriteLocation, new Rectangle(Rocky2.frame * 100, 0, 100, 100), Rocky2.State);
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
                    _spriteBatch.Draw(Rocky_Text, Rocky3.spriteLocation, new Rectangle(Rocky3.frame * 100, 0, 100, 100), Rocky3.State);
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
                    _spriteBatch.Draw(Beetle_Text, Beetle1.spriteLocation, new Rectangle(Beetle1.frame * 150, 0, 150, 150), Beetle1.State);
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
                    _spriteBatch.Draw(Beetle_Text, Beetle2.spriteLocation, new Rectangle(Beetle2.frame * 150, 0, 150, 150), Beetle2.State);
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
                    _spriteBatch.Draw(Beetle_Text, Beetle3.spriteLocation, new Rectangle(Beetle3.frame * 150, 0, 150, 150), Beetle3.State);
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
            _spriteBatch.Draw(HitEffect_Texture, HitEffect_Position, new Rectangle((frameInCombat / 3) * 150, 0, 150, 150) , Color.White);

            PartyHPbar();
            for (int i = 0; i < Party.Count; i++)
            {
                if (Party[i] == Lurker)
                {
                    _spriteBatch.Draw(Lurker_Small_Icon, Lurker.Small_iconLocation, new Rectangle(0, 0, 126, 126), Lurker.State);
                    _spriteBatch.Draw(Lurker_Big_Icon, new Vector2(Lurker.Big_iconLocation.X - 20, Lurker.Big_iconLocation.Y), Color.White);
                    _spriteBatch.Draw(Lurker_Small_Icon, Lurker.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == inventor)
                {
                    _spriteBatch.Draw(Inventor_Small_Icon, inventor.Small_iconLocation, new Rectangle(0, 0, 126, 126), inventor.State);
                    _spriteBatch.Draw(Inventor_Big_Icon, new Vector2(inventor.Big_iconLocation.X - 20, inventor.Big_iconLocation.Y) , Color.White);
                    _spriteBatch.Draw(Inventor_Small_Icon, inventor.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == Blood_Maiden)
                {
                    _spriteBatch.Draw(Blood_Maiden_Small_Icon, Blood_Maiden.Small_iconLocation, new Rectangle(0, 0, 126, 126), Blood_Maiden.State);
                    _spriteBatch.Draw(Blood_Maiden_Big_Icon, new Vector2(Blood_Maiden.Big_iconLocation.X - 20, Blood_Maiden.Big_iconLocation.Y), Color.White);
                    _spriteBatch.Draw(Blood_Maiden_Small_Icon, Blood_Maiden.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
                if (Party[i] == Dragonic_hunter)
                {
                    _spriteBatch.Draw(Dragonic_Small_Icon, Dragonic_hunter.Small_iconLocation, new Rectangle(0, 0, 126, 126), Dragonic_hunter.State);
                    _spriteBatch.Draw(Dragonic_Big_Icon, new Vector2(Dragonic_hunter.Big_iconLocation.X - 20, Dragonic_hunter.Big_iconLocation.Y),  Color.White);
                    _spriteBatch.Draw(Dragonic_Small_Icon, Dragonic_hunter.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                }
            }
            for (int i = 0; i < EnemyGroup.Count; i++)
            {
                if (EnemyGroup[i] == Golem)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Golem.HPMPbar_iconLocation, new Rectangle(0, 0, 270, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Golem.HPbar_Location, new Rectangle(0, 0, Golem.HP * (280 / Golem.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Golem_Icon, Golem.Small_iconLocation, Golem.State);
                    _spriteBatch.Draw(Golem_Big_Icon, Golem.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Golem.HPtext, new Vector2(Golem.HPMPbar_iconLocation.X + 120, Golem.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Ice_Golem)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Ice_Golem.HPMPbar_iconLocation, new Rectangle(0, 0, 270, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Ice_Golem.HPbar_Location, new Rectangle(0, 0, Ice_Golem.HP * (280 * 2 / Ice_Golem.MaxHP * 2), 30), Color.Red);
                    _spriteBatch.Draw(Ice_Golem_Icon, Ice_Golem.Small_iconLocation,Ice_Golem.State);
                    _spriteBatch.Draw(Ice_Golem_Big_Icon, Ice_Golem.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Ice_Golem.HPtext, new Vector2(Ice_Golem.HPMPbar_iconLocation.X + 120, Ice_Golem.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Boss)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Boss.HPMPbar_iconLocation, new Rectangle(0, 0, 270, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Boss.HPbar_Location, new Rectangle(0, 0, Boss.HP * (300 / Boss.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Boss_Icon, Boss.Small_iconLocation, new Rectangle(0, 0, 90, 90), Boss.State);
                    _spriteBatch.Draw(Boss_Big_Icon, Boss.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Boss.HPtext, new Vector2(Boss.HPMPbar_iconLocation.X + 120, Boss.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Rocky1)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Rocky1.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Rocky1.HPbar_Location, new Rectangle(0, 0, Rocky1.HP * (190 / Rocky1.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Rocky_Icon, Rocky1.Small_iconLocation,Rocky1.State);
                    _spriteBatch.Draw(Rocky_Big_Icon, Rocky1.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Rocky1.HPtext, new Vector2(Rocky1.HPMPbar_iconLocation.X + 90, Rocky1.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Rocky2)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Rocky2.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Rocky2.HPbar_Location, new Rectangle(0, 0, Rocky2.HP * (190 / Rocky2.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Rocky_Icon, Rocky2.Small_iconLocation, Rocky2.State);
                    _spriteBatch.Draw(Rocky_Big_Icon, Rocky2.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Rocky2.HPtext, new Vector2(Rocky2.HPMPbar_iconLocation.X + 90, Rocky2.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Rocky3)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Rocky3.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Rocky3.HPbar_Location, new Rectangle(0, 0, Rocky3.HP * (190 / Rocky3.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Rocky_Icon, Rocky3.Small_iconLocation, Rocky3.State);
                    _spriteBatch.Draw(Rocky_Big_Icon, Rocky3.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Rocky3.HPtext, new Vector2(Rocky3.HPMPbar_iconLocation.X + 90, Rocky3.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Beetle1)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Beetle1.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Beetle1.HPbar_Location, new Rectangle(0, 0, Beetle1.HP * (190 / Beetle1.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Beetle_Icon, Beetle1.Small_iconLocation, Beetle1.State);
                    _spriteBatch.Draw(Beetle_Big_Icon, Beetle1.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Beetle1.HPtext, new Vector2(Beetle1.HPMPbar_iconLocation.X + 90, Beetle1.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Beetle2)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Beetle2.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Beetle2.HPbar_Location, new Rectangle(0, 0, Beetle2.HP * (190 / Beetle2.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Beetle_Icon, Beetle2.Small_iconLocation, Beetle2.State);
                    _spriteBatch.Draw(Beetle_Big_Icon, Beetle2.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Beetle2.HPtext, new Vector2(Beetle2.HPMPbar_iconLocation.X + 90, Beetle2.HPMPbar_iconLocation.Y), Color.Black);
                }
                if (EnemyGroup[i] == Beetle3)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Beetle3.HPMPbar_iconLocation, new Rectangle(0, 0, 180, 30), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Beetle3.HPbar_Location, new Rectangle(0, 0, Beetle3.HP * (190 / Beetle3.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(Beetle_Icon, Beetle3.Small_iconLocation, Beetle3.State);
                    _spriteBatch.Draw(Beetle_Big_Icon, Beetle3.Big_iconLocation, Color.White);
                    _spriteBatch.DrawString(font, Beetle3.HPtext, new Vector2(Beetle3.HPMPbar_iconLocation.X + 90, Beetle3.HPMPbar_iconLocation.Y), Color.Black);
                }

            }
            _spriteBatch.Draw(Double_Slash_Texture, Double_Slash.Position, Double_Slash.State);
            _spriteBatch.Draw(Wide_Slash_Texture, Wide_Slash.Position, Wide_Slash.State);
            _spriteBatch.Draw(Blood_Drain_Texture, Blood_Drain.Position, Blood_Drain.State);
            _spriteBatch.Draw(Power_Boost_Texture, Power_Boost.Position, Power_Boost.State);
            _spriteBatch.Draw(Ankle_Cut_Texture, Ankle_Cut.Position, Ankle_Cut.State);
            _spriteBatch.Draw(Blood_Curse_Texture, Blood_Curse.Position, Blood_Curse.State);
            _spriteBatch.Draw(Aid_Texture, Aid.Position, Aid.State);
            _spriteBatch.Draw(HeathPotio_Texture, HeathPotion.Position, HeathPotion.State);
            _spriteBatch.Draw(ManaPotio_Texture, ManaPotion.Position, ManaPotion.State);
            _spriteBatch.Draw(Bomb_Texture, Bomb.Position, Bomb.State);

            string HPpotiontxt = "" + HPPotionAmo;
            _spriteBatch.DrawString(font, HPpotiontxt, new Vector2(HeathPotion.Position.X + 80, HeathPotion.Position.Y + 15), Color.White);
            string MPpotiontxt = "" + MPPotionAmo;
            _spriteBatch.DrawString(font, MPpotiontxt, new Vector2(ManaPotion.Position.X + 80, ManaPotion.Position.Y + 15), Color.White);
            string Bombtxt = "" + BombAmo;
            _spriteBatch.DrawString(font, Bombtxt, new Vector2(Bomb.Position.X + 80, Bomb.Position.Y + 15), Color.White);
            _spriteBatch.DrawString(font, BattleTxt, new Vector2(300, 520), Color.White);
            String goldtxt = "Gold: " + Gold;
            _spriteBatch.DrawString(font, goldtxt, new Vector2(1200, 15), Color.Red);
        }

        private void DrawEventMap()
        {
            _spriteBatch.Draw(Background_Texture, Vector2.Zero, Color.White);
            String room = "room: " + roomNum;
            _spriteBatch.DrawString(font, room, new Vector2(200, 300), Color.Red);
            String goldtxt = "Gold: " + Gold;
            _spriteBatch.DrawString(font, goldtxt, new Vector2(1200, 15), Color.Red);
            _spriteBatch.Draw(FightNode_Texture, Fight_B1.Position, Fight_B1.State);
            _spriteBatch.Draw(FightNode_Texture, Fight_B2.Position, Fight_B2.State);
            _spriteBatch.Draw(EventNode_Texture, Event_B1.Position, Event_B1.State);
            _spriteBatch.Draw(EventNode_Texture, Event_B2.Position, Event_B2.State);
            _spriteBatch.Draw(RestNode_Texture, Rest_B.Position, Rest_B.State);
            PartyHPbar();
        }
    
        private void DrawTitle()
        {
            _spriteBatch.Draw(Logo_Texture, new Vector2(150,0), new Rectangle((unloop_frame_1) * 1050, unloop_frame_2 * 540, 1050, 540), Color.White);
            _spriteBatch.Draw(Taptostart_Texture, new Vector2(500,450 - unloop_frame_2 * 5), Color.White);
        }

        private void DrawEvent()
        {
            _spriteBatch.Draw(Event_Texture, Vector2.Zero, Color.White);
            _spriteBatch.DrawString(font, EventTxt, new Vector2(400, 200), Color.Red);
            String goldtxt = "Gold: " + Gold;
            _spriteBatch.DrawString(font, goldtxt, new Vector2(1200, 15), Color.Red);
            No_B.Position = new Vector2(400, 400);
            _spriteBatch.Draw(No_Texture, No_B.Position, No_B.State);
            Yes_B.Position = new Vector2(800, 400);
            _spriteBatch.Draw(Yes_Texture, Yes_B.Position, Yes_B.State);
            _spriteBatch.Draw(Return_Texture, Return_B.Position, Return_B.State);
            PartyHPbar();
        }

        private void DrawLose()
        {
            _spriteBatch.Draw(Gameover_Texture, Vector2.Zero, Color.White);
        }

        private void DrawRest()
        {
            _spriteBatch.Draw(Rest_Texture, Vector2.Zero, Color.White);
            String goldtxt = "Gold: " + Gold;
            _spriteBatch.DrawString(font, goldtxt, new Vector2(1200, 15), Color.Red);
            PartyHPbar();
        }

        private void DrawCharactor()
        {
            _spriteBatch.Draw(Background_Texture, Vector2.Zero, Color.White);
            String str = "Select a starting Charactor";
            _spriteBatch.DrawString(font, str, new Vector2(500, 200), Color.Black);
            Lurker.spriteLocation = new Vector2(200, 300);
            inventor.spriteLocation = new Vector2(500, 300);
            Blood_Maiden.spriteLocation = new Vector2(800, 300);
            Dragonic_hunter.spriteLocation = new Vector2(1100, 300);
            _spriteBatch.Draw(Lurker.Unit_Sprite, Lurker.spriteLocation, new Rectangle(Lurker.frame * 150, 0, 150, 210), Lurker.State);
            _spriteBatch.Draw(inventor.Unit_Sprite, inventor.spriteLocation, new Rectangle(inventor.frame * 150, 0, 150, 210), inventor.State);
            _spriteBatch.Draw(Blood_Maiden.Unit_Sprite, Blood_Maiden.spriteLocation, new Rectangle(Blood_Maiden.frame * 180, 0, 180, 216), Blood_Maiden.State);
            _spriteBatch.Draw(Dragonic_hunter.Unit_Sprite, Dragonic_hunter.spriteLocation, new Rectangle(Dragonic_hunter.frame * 152, 0, 152, 210), Dragonic_hunter.State);
        }

        private void DrawShop()
        {
            _spriteBatch.Draw(Shop_Texture, Vector2.Zero, Color.White);
            String goldtxt = "Gold: " + Gold;
            _spriteBatch.DrawString(font, goldtxt, new Vector2(1200, 15), Color.Black);
            _spriteBatch.DrawString(font, ShopTxt, new Vector2(500, 15), Color.Black);
            String PotionPrice = "-200";
            _spriteBatch.DrawString(font, PotionPrice, new Vector2(HeathPotion.Position.X + 35, HeathPotion.Position.Y + 190), Color.Red);
            _spriteBatch.DrawString(font, PotionPrice, new Vector2(ManaPotion.Position.X + 35, ManaPotion.Position.Y + 190), Color.Red);
            String BombPrice = "-300";
            _spriteBatch.DrawString(font, BombPrice, new Vector2(Bomb.Position.X + 35, Bomb.Position.Y + 190), Color.Red);
            string potiontxt = "" + HPPotionAmo;
            _spriteBatch.DrawString(font, potiontxt, new Vector2(HeathPotion.Position.X + 100, HeathPotion.Position.Y + 15), Color.Black);
            string MPpotiontxt = "" + MPPotionAmo;
            _spriteBatch.DrawString(font, MPpotiontxt, new Vector2(ManaPotion.Position.X + 100, ManaPotion.Position.Y + 15), Color.Black);
            string Bombtxt = "" + BombAmo;
            _spriteBatch.DrawString(font, Bombtxt, new Vector2(Bomb.Position.X + 100, Bomb.Position.Y + 15), Color.Black);
            _spriteBatch.Draw(HeathPotio_Texture2, HeathPotion.Position, HeathPotion.State);
            _spriteBatch.Draw(ManaPotio_Texture2, ManaPotion.Position, ManaPotion.State);
            _spriteBatch.Draw(Bomb_Texture2, Bomb.Position, Bomb.State);
            Return_B.Position = new Vector2(0, 500);
            _spriteBatch.Draw(Return_Texture, Return_B.Position, Return_B.State);
        }

        private void ResetCombat()
        {
            for (int i = 0; i < ButtoninBattle.Count; i++)
            {
                ButtoninBattle[i].Pressed = false;
                ButtoninBattle[i].mouseHover = false;
            }
            for (int i = 0; i < Party.Count; i++)
            {
                Party[i].isAttacking = false;
            }
            turn = 0;
            timeLoad = false;
            frameInCombat = 0;
            Partywaitingtime = 0;
            Enemywaitingtime = 0;
            iconOrder = 0;
            Attacking = false;
            Skilling = false;
            Skilling2 = false;
            Skilling3 = false;
            UseSkill = 0;
            UseItem = 0;
            ATKcount = 0;
            BattleTxt = "";
            TargetAlly = false;
            TargetEnemy = false;
            HitEffect_Position = new Vector2(1000, 1000);
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

        private void ResetMap()
        {
            for (int i = 0; i < ButtoninMap.Count; i++)
            {
                ButtoninMap[i].mouseHover = false;
                ButtoninMap[i].State = Color.White;
                ButtoninMap[i].Pressed = false;
                ButtoninMap[i].Position = new Vector2(1000, 1000);
            }
        }

        private void PartyHPbar()
        {
            for (int i = 0; i < Party.Count; i++)
            {
                if (Party[i] == Lurker)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Lurker.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 54), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Lurker.HPbar_Location, new Rectangle(0, 0, Lurker.HP * (240 / Lurker.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(HPMPbar_Texture, Lurker.MPbar_Location, new Rectangle(0, 30, Lurker.MP * (240 / Lurker.MaxMP), 30), Color.DodgerBlue);
                    _spriteBatch.Draw(Lurker_Small_Icon, Lurker.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                    _spriteBatch.DrawString(font, Lurker.HPtext, new Vector2(Lurker.HPMPbar_iconLocation.X + 120, Lurker.HPMPbar_iconLocation.Y), Color.Black);
                    _spriteBatch.DrawString(font, Lurker.MPtext, new Vector2(Lurker.MPbar_Location.X + 120, Lurker.MPbar_Location.Y - 7), Color.Black);
                }
                if (Party[i] == inventor)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, inventor.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 54), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, inventor.HPbar_Location, new Rectangle(0, 0, inventor.HP * (240 / inventor.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(HPMPbar_Texture, inventor.MPbar_Location, new Rectangle(0, 30, inventor.MP * (240 / inventor.MaxMP), 30), Color.DodgerBlue);
                    _spriteBatch.Draw(Inventor_Small_Icon, inventor.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                    _spriteBatch.DrawString(font, inventor.HPtext, new Vector2(inventor.HPMPbar_iconLocation.X + 120, inventor.HPMPbar_iconLocation.Y), Color.Black);
                    _spriteBatch.DrawString(font, inventor.MPtext, new Vector2(inventor.MPbar_Location.X + 120, inventor.MPbar_Location.Y - 7), Color.Black);
                }
                if (Party[i] == Blood_Maiden)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Blood_Maiden.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 54), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Blood_Maiden.HPbar_Location, new Rectangle(0, 0, Blood_Maiden.HP * (240 / Blood_Maiden.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(HPMPbar_Texture, Blood_Maiden.MPbar_Location, new Rectangle(0, 30, Blood_Maiden.MP * (240 / Blood_Maiden.MaxMP), 30), Color.DodgerBlue);
                    _spriteBatch.Draw(Blood_Maiden_Small_Icon, Blood_Maiden.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                    _spriteBatch.DrawString(font, Blood_Maiden.HPtext, new Vector2(Blood_Maiden.HPMPbar_iconLocation.X + 120, Blood_Maiden.HPMPbar_iconLocation.Y), Color.Black);
                    _spriteBatch.DrawString(font, Blood_Maiden.MPtext, new Vector2(Blood_Maiden.MPbar_Location.X + 120, Blood_Maiden.MPbar_Location.Y - 7), Color.Black);
                }
                if (Party[i] == Dragonic_hunter)
                {
                    _spriteBatch.Draw(HPMPbar_Texture, Dragonic_hunter.HPMPbar_iconLocation, new Rectangle(0, 0, 230, 54), Color.White);
                    _spriteBatch.Draw(HPMPbar_Texture, Dragonic_hunter.HPbar_Location, new Rectangle(0, 0, Dragonic_hunter.HP * (240 / Dragonic_hunter.MaxHP), 30), Color.Red);
                    _spriteBatch.Draw(HPMPbar_Texture, Dragonic_hunter.MPbar_Location, new Rectangle(0, 30, Dragonic_hunter.MP * (240 / Dragonic_hunter.MaxMP), 30), Color.DodgerBlue);
                    _spriteBatch.Draw(Dragonic_Small_Icon, Dragonic_hunter.HPicon_Location, new Rectangle(0, 0, 126, 126), Color.White);
                    _spriteBatch.DrawString(font, Dragonic_hunter.HPtext, new Vector2(Dragonic_hunter.HPMPbar_iconLocation.X + 120, Dragonic_hunter.HPMPbar_iconLocation.Y), Color.Black);
                    _spriteBatch.DrawString(font, Dragonic_hunter.MPtext, new Vector2(Dragonic_hunter.MPbar_Location.X + 120, Dragonic_hunter.MPbar_Location.Y - 7), Color.Black);
                }
                if (i == 0)
                {
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X + 40, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].MPbar_Location = new Vector2(Party[i].HPMPbar_iconLocation.X, Party[i].HPMPbar_iconLocation.Y + 30);
                    Party[i].HPicon_Location = new Vector2(SetPO1.X, SetPO1.Y - 240);
                }
                if (i == 1)
                {
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 240, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].MPbar_Location = new Vector2(Party[i].HPMPbar_iconLocation.X, Party[i].HPMPbar_iconLocation.Y + 30);
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 270, SetPO1.Y - 240);
                }
                if (i == 2)
                {
                    Party[i].HPMPbar_iconLocation = new Vector2(SetPO1.X - 520, SetPO1.Y - 220);
                    Party[i].HPbar_Location = Party[i].HPMPbar_iconLocation;
                    Party[i].MPbar_Location = new Vector2(Party[i].HPMPbar_iconLocation.X, Party[i].HPMPbar_iconLocation.Y + 30);
                    Party[i].HPicon_Location = new Vector2(SetPO1.X - 540, SetPO1.Y - 240);
                }
            }
        }
    }
}
