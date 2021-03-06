﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BlueWay_Shangliao.UI.MyControl
{
    public class MyButton : Button
    {
        public enum MouseState
        {
            Normal,
            Enter,  //光标进入
            Hover,  //光标悬停
            Press,  //光标按下
            Release,//光标释放
            Leave,  //光标离开
            
        }
        
        public static bool pressed = false;    //按下次数，以便记录状态
        private bool holdPress = true;   //保持按下状态
        private static Control control = null;
        private MouseState mState = MouseState.Normal;
        private bool clicked = false;
        
        public bool Clicked
        {
            get
            {
                return clicked;
            }
            set
            {
                clicked = value;
            }
        }
        
        public bool HoldPress
        {
            get
            {
                return holdPress;
            }
            set
            {
                holdPress = value;
            }
        }
        
        //public delegate void EventHandler(object sender, EventArgs e);
        //public event EventHandler ButtonClick;
        public MyButton()
        {
            //this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlatStyle = FlatStyle.Flat;
            //this.FlatAppearance.BorderColor = Color.Aqua;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.BackgroundImage = BlueWay_Shangliao.Properties.Resources.btn_normal;// btn_normal_40_15;
            this.ForeColor = Color.White;
        }
        public void SetClicked(bool val)
        {
            Clicked = val;
            control = this;
            pressed = !pressed;
            this.BackgroundImage = BlueWay_Shangliao.Properties.Resources.btn_press;//btn_down_40_15;
        }
        
        protected override void OnMouseEnter(EventArgs e)
        {
            mState = MouseState.Enter;
            
            if(holdPress)
            {
                if(!pressed && Clicked == false)
                {
                    this.BackgroundImage = Image.FromFile("image\\btn_enter.png");//btn_enter_40_15
                }
                else if(pressed)
                {
                    if(control != null && control != this)
                    {
                        this.BackgroundImage = Image.FromFile("image\\btn_enter.png");
                    }
                }
            }
            else
            {
                this.BackgroundImage = Image.FromFile("image\\btn_enter.png");
            }
            
            base.OnMouseEnter(e);
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            mState = MouseState.Release;
            
            if(holdPress)
            {
                if(control != null && control != this)
                {
                    control.BackgroundImage = Image.FromFile("image\\btn_normal.png");
                }
                else
                {
                    pressed = !pressed;
                }
                
                if(pressed)
                {
                    this.BackgroundImage = Image.FromFile("image\\btn_press.png");
                }
                else
                {
                    this.BackgroundImage = Image.FromFile("image\\btn_enter.png");
                }
                
                control = this;
                
                if(Clicked)
                {
                    Clicked = false;
                }
            }
            else
            {
                this.BackgroundImage = Image.FromFile("image\\btn_press.png");
            }
            
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mState = MouseState.Release;
            
            if(holdPress)
            {
                if(pressed)
                {
                    this.BackgroundImage = Image.FromFile("image\\btn_press.png");
                }
                else
                {
                    this.BackgroundImage = Image.FromFile("image\\btn_enter.png");
                }
            }
            else
            {
                this.BackgroundImage = Image.FromFile("image\\btn_enter.png");
            }
            
            base.OnMouseUp(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            mState = MouseState.Leave;
            
            if(holdPress)
            {
                if(!pressed && Clicked == false)
                {
                    this.BackgroundImage = Image.FromFile("image\\btn_normal.png");
                }
                else if(pressed)
                {
                    if(control != null && control != this)
                    {
                        this.BackgroundImage = Image.FromFile("image\\btn_normal.png");
                    }
                }
            }
            else
            {
                this.BackgroundImage = Image.FromFile("image\\btn_normal.png");
            }
            
            base.OnMouseLeave(e);
        }
        
    }
}
