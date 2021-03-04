using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.PunPinYin
{
    public class ButtonSelect
    {
        public string buttonName { get; set; }

        public int left { get; set; }

        public int top { get; set; }


        public int width { get; set; }

        public int height { get; set; }
        ///// <summary>
        ///// if bool Reapeat Button action
        ///// </summary>
        //public bool boolReapeatButton { get; set; }
        ///// <summary>
        /////  if bool Reapeat Button action
        ///// </summary>
        //public string ReapeatButtonStartAction { get; set; }
        ///// <summary>
        /////  if bool Reapeat Button action
        ///// </summary>
        //public string ReapeatButtonStopAction { get; set; }

        public Boolean playSound = true;
    }
}
