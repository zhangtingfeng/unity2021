using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Pub
{
    public class WWW_Load_RawImage
    {
        /// <summary>
        /// 使用 WWW 加载图片，并赋值给 _rawImage
        /// </summary>
        /// <param name="_url">图片地址</param>
        /// <param name="_rawImage"></param>
        /// <returns></returns>
        public static IEnumerator LoadTexture2DByWWW(string _url, RawImage _rawImage)
        {
            WWW _www = new WWW(_url);
            yield return _www;
            if (_www.error == null)
            {
                _rawImage.texture = _www.texture;
            }
            else
            {
                Debug.LogError(_www.error);
            }
        }
        /// <summary>
        /// 使用 WWW 加载图片，并将图片转换成 Sprite 类型赋值给 _image
        /// </summary>
        /// <param name="_url">图片地址</param>
        /// <param name="_image"></param>
        /// <returns></returns>
        public static IEnumerator LoadSpriteByWWW(string _url, Image _image)
        {
            WWW _www = new WWW(_url);
            yield return _www;
            if (_www.error == null)
            {
                _image.sprite = Sprite.Create(_www.texture, new Rect(0, 0, _www.texture.width, _www.texture.height), new Vector2(0.5f, 0.5f));
            }
            else
            {
                Debug.LogError(_www.error);
            }
        }
    }
}
