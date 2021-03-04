using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.PunPinYin
{
    /// <summary>
    /// 全局通用变量
    /// </summary>
    public class CountAdjustScreen

    {
        private const int RawScreenWidth = 1024; private const int RawScreenHeight = 552;


        public static Rect GetDestScreenRect()
        {
            float tRatioStand = RawScreenWidth * (float)1.0 / RawScreenHeight;
            float tRatioReal = Screen.width * (float)1.0 / Screen.height;

            float DestinationWidth = 0;
            float DestinationHeight = 0;

            float DestinationLeft = 0;
            float DestinationTop = 0;

            if (tRatioStand >= tRatioReal)
            {///按照宽度变化
                DestinationWidth = Screen.width;
                DestinationHeight = DestinationWidth / tRatioStand;
                DestinationLeft = 0;
                DestinationTop = (Screen.height - DestinationHeight) / 2;
            }
            else {
                DestinationHeight = Screen.height;
                DestinationWidth = DestinationHeight * tRatioStand;
                DestinationLeft = (Screen.width - DestinationWidth) / 2;
                DestinationTop = 0;
               
            }

            Rect GetScreenRect = new Rect(DestinationLeft, DestinationTop, DestinationWidth, DestinationHeight);
            return GetScreenRect;

        }


        public static Rect GetThisSideRect(Rect RawRect) {
            float DestinationWidth = 0;
            float DestinationHeight = 0;

            float DestinationLeft = 0;
            float DestinationTop = 0;

            Rect backGroundRect = GetDestScreenRect();

            DestinationWidth = RawRect.width * (float)1.0 * backGroundRect.width / RawScreenWidth;
            DestinationHeight = RawRect.height * (float)1.0 * backGroundRect.height / RawScreenHeight;

            DestinationLeft = backGroundRect.xMin + RawRect.xMin * (float)1.0 * backGroundRect.width / RawScreenWidth;
            DestinationTop = backGroundRect.yMin+ RawRect.yMin * (float)1.0 * backGroundRect.height / RawScreenHeight;

            Rect GetDescRect = new Rect(DestinationLeft, DestinationTop, DestinationWidth, DestinationHeight);
            return GetDescRect;
        }
    }
}
