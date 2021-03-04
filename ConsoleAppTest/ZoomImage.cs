﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ConsoleAppTest
{
    class ZoomImage
    {
        //使用方法调用GenerateHighThumbnail()方法即可
        //参数oldImagePath表示要被缩放的图片路径
        //参数newImagePath表示缩放后保存的图片路径
        //参数width和height分别是缩放范围宽和高
        public static void GenerateHighThumbnail(string oldImagePath, string newImagePath, int width, int height)
        {
            System.Drawing.Image oldImage = System.Drawing.Image.FromFile(oldImagePath);
            int newWidth = AdjustSize(width, height, oldImage.Width, oldImage.Height).Width;
            int newHeight = AdjustSize(width, height, oldImage.Width, oldImage.Height).Height;
            //。。。。。。。。。。。
            System.Drawing.Image thumbnailImage = oldImage.GetThumbnailImage(newWidth, newHeight, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(thumbnailImage);
            //处理JPG质量的函数
            System.Drawing.Imaging.ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            if (ici != null)
            {
                System.Drawing.Imaging.EncoderParameters ep = new System.Drawing.Imaging.EncoderParameters(1);
                ep.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)100);
                bm.Save(newImagePath, ici, ep);
                //释放所有资源，不释放，可能会出错误。
                ep.Dispose();
                ep = null;
            }
            ici = null;
            bm.Dispose();
            bm = null;
            thumbnailImage.Dispose();
            thumbnailImage = null;
            oldImage.Dispose();
            oldImage = null;
        }


        private static bool ThumbnailCallback()
        {
            return false;
        }


        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }


        public struct PicSize
        {
            public int Width;
            public int Height;
        }


        public static PicSize AdjustSize(int spcWidth, int spcHeight, int orgWidth, int orgHeight)
        {
            PicSize size = new PicSize();
            // 原始宽高在指定宽高范围内，不作任何处理 
            if (orgWidth <= spcWidth && orgHeight <= spcHeight)
            {
                size.Width = orgWidth;
                size.Height = orgHeight;
            }
            else
            {
                // 取得比例系数 
                float w = orgWidth / (float)spcWidth;
                float h = orgHeight / (float)spcHeight;
                // 宽度比大于高度比 
                if (w > h)
                {
                    size.Width = spcWidth;
                    size.Height = (int)(w >= 1 ? Math.Round(orgHeight / w) : Math.Round(orgHeight * w));
                }
                // 宽度比小于高度比 
                else if (w < h)
                {
                    size.Height = spcHeight;
                    size.Width = (int)(h >= 1 ? Math.Round(orgWidth / h) : Math.Round(orgWidth * h));
                }
                // 宽度比等于高度比 
                else
                {
                    size.Width = spcWidth;
                    size.Height = spcHeight;
                }
            }
            return size;
        }



        public void readfile(string strFrom,string strTo) {

            Bitmap srcBitmap = (Bitmap)Bitmap.FromFile(strFrom, false);
            Bitmap tttttt=ZoomImageAct(srcBitmap, 100, 100);
            tttttt.Save(strTo);
        }

        /// <summary>
        /// 等比例缩放图片
        /// </summary>
        /// <param name="bitmap">图片</param>
        /// <param name="destHeight">高度</param>
        /// <param name="destWidth">宽度</param>
        /// <returns></returns>
        private Bitmap ZoomImageAct(Bitmap bitmap, int destHeight, int destWidth)
        {
            try
            {
                System.Drawing.Image sourImage = bitmap;
                int width = 0, height = 0;
                //按比例缩放
                int sourWidth = sourImage.Width;
                int sourHeight = sourImage.Height;
                if (sourHeight > destHeight || sourWidth > destWidth)
                {
                    if ((sourWidth * destHeight) > (sourHeight * destWidth))
                    {
                        width = destWidth;
                        height = (destWidth * sourHeight) / sourWidth;
                    }
                    else
                    {
                        height = destHeight;
                        width = (sourWidth * destHeight) / sourHeight;
                    }
                }
                else
                {
                    width = sourWidth;
                    height = sourHeight;
                }
                Bitmap destBitmap = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage(destBitmap);
                g.Clear(Color.Transparent);
                //设置画布的描绘质量
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(sourImage, new Rectangle((destWidth - width) / 2, (destHeight - height) / 2, width, height), 0, 0, sourImage.Width, sourImage.Height, GraphicsUnit.Pixel);
                g.Dispose();
                //设置压缩质量
                System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                System.Drawing.Imaging.EncoderParameter encoderParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                sourImage.Dispose();
                return destBitmap;
            }
            catch
            {
                return bitmap;
            }
        }
    }



}
