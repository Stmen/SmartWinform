﻿//MIT License
//
//Copyright (c) [2017] [Gavin-Huang]
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
///
///
//*********************************************************
//*      Author: Gavin-Huang                              *
//*      Email:huangwangyi16@163.com                      *
//*      if you have any question , contact me !          *
//*********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SmartWinForm.UI.SmartControls
{
    public partial class SmartRadioButton : UserControl
    {
       private  bool check = false;
       Image wrong = global::SmartWinForm.Properties.Resources.radiooff32;
       Image right = global::SmartWinForm.Properties.Resources.radioon32;

       public event EventHandler<EventArgs> GotClicked;
       public event EventHandler<CheckerChanged> CheckerChanged;
        public SmartRadioButton()
        {
            InitializeComponent();
        }
       
        public bool Checked
        {
            get {
                return check;
            }
            set {
               
                if (value != check)
                {
                    var temp = CheckerChanged;
                    if (temp != null)
                    {
                        CheckerChanged we = new CheckerChanged(value);
                        CheckerChanged(this,we);
                    }
                }
                check = value;
                if (value)
                {
                    this.BackgroundImage = right;

                }
                else
                {
                    this.BackgroundImage = wrong;
                }
            }
        }
        private void Checker_Click(object sender, EventArgs e)
        {
            if (!check)
            {
                this.Checked = true;

                Control tem = this.Parent;
                foreach(Control aa in  tem.Controls )
                {
                    if (aa is SmartRadioButton &&!aa.Equals(this))
                    {
                        ((SmartRadioButton)(aa)).SetCheckStateWithoutEvent(false);
                    }
                }

            }
            var rte=GotClicked;
            if(rte!=null)
            GotClicked(this, EventArgs.Empty);
        }
        public void SetCheckStateWithoutEvent(bool value)
        {
            check = value;
            if (value)
            {
                this.BackgroundImage = right;

            }
            else
            {
                this.BackgroundImage = wrong;
            }
        }
        public void PerformGotChecked()
        {
            this.Checked = true;
            Control tem = this.Parent;
            foreach (Control aa in tem.Controls)
            {
                if (aa is SmartRadioButton && !aa.Equals(this))
                {
                    ((SmartRadioButton)(aa)).Checked = false;
                }
            }
        }
     
      
    }
}
