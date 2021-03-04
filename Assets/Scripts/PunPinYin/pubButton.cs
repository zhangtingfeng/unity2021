using Assets.Script.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.PunPinYin
{


    public class pubButton : MonoBehaviour
    {
        public GUISkin mySkin;
        public AudioClip menuSound;
        private const int ButtonWidth = 144; private int ButtonHeight = 51;
        private float frameTime;//记录按下的时间/  

        public ButtonSelect[] myButtonSelctList;

        void start()
        {
            frameTime = -1.0f;
        }
        void OnGUI()
        {
            GUI.skin = mySkin;
            if (myButtonSelctList == null || myButtonSelctList.Length < 1) return;
            for (int i = 0; i < myButtonSelctList.Length; i++)
            {
                ButtonSelect myButtonSelct = myButtonSelctList[i];
                Rect curRect = CountAdjustScreen.GetThisSideRect(new Rect(myButtonSelct.left, myButtonSelct.top, myButtonSelct.width > 0 ? myButtonSelct.width : ButtonWidth, myButtonSelct.height > 0 ? myButtonSelct.height : ButtonHeight));///;// new Rect(835, 469, ButtonWidth, ButtonHeight);
                /*
                if (myButtonSelct.boolReapeatButton)
                {
                    if (GUI.RepeatButton(curRect, "", GUI.skin.GetStyle(myButtonSelct.buttonName)))
                    {
                        frameTime += Time.deltaTime;

                        ///Debug_Log.Call_WriteLog(frameTime.toString(), frameTime.toString());
                        // 
                    }

                    //每当鼠标按下时将frameTime重置，一遍进行下次记录/  
                    if (Input.GetMouseButtonDown(0))
                    {
                        UnityAction<string> action = new UnityAction<string>(MainSelect);
                        action(myButtonSelct.ReapeatButtonStartAction);
                        frameTime = 0;
                        //Debug.Log(frameTime);
                        Debug_Log.Call_WriteLog(frameTime.toString(), "ReapeatButtonStartAction" + frameTime.toString());

                    }

                    //每当鼠标时将frameTime重置，一遍进行下次记录/  
                    if (Input.GetMouseButtonUp(0))
                    {
                        UnityAction<string> action = new UnityAction<string>(MainSelect);
                        action(myButtonSelct.ReapeatButtonStopAction);
                        frameTime = -1.0f;
                        //Debug.Log(frameTime);
                        Debug_Log.Call_WriteLog(frameTime.toString(), "ReapeatButtonStopAction" + frameTime.toString());

                    }
                }
                else
                
                */
                if (GUI.Button(curRect, "", GUI.skin.GetStyle(myButtonSelct.buttonName)))
                {
                    UnityAction<string> action = new UnityAction<string>(MainSelect);
                    if (myButtonSelct.playSound)
                    {
                        PlayAudio(menuSound, action, myButtonSelct.buttonName);
                    }
                    else
                    {
                        action(myButtonSelct.buttonName);
                    }
                }
            }

        }

        virtual
       public void MainSelect(string strWhich)
        {
            //StaticGlobalService.getTargetItemListPath();
            Debug.Log(1);

            // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
        }

        #region  播放按钮声音
        public void PlayAudio(AudioClip clip, UnityAction<string> callback = null, string strWhich = null)
        {
            AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
            //执行协成获取音频文件的时间
            StartCoroutine(AudioPlayFinished(clip.length, callback, strWhich));
        }

        private IEnumerator AudioPlayFinished(float timelength, UnityAction<string> callback = null, string strWhich = null)
        {
            yield return new WaitForSeconds(timelength);
            callback(strWhich);
        }


        void Update()
        {

        }

        #endregion  播放按钮声音
    }
}
