/*
http://www.cgsoso.com/forum-211-1.html

CG搜搜 Unity3d 每日Unity3d插件免费更新 更有VIP资源！

CGSOSO 主打游戏开发，影视设计等CG资源素材。

插件如若商用，请务必官网购买！

daily assets update for try.

U should buy the asset from home store if u use it in your project!
*/

using UnityEngine;
using System.Collections;
namespace IndieStudio.LetterWrite.Utility
{
    ///Developed by Indie Studio
    ///https://www.assetstore.unity3d.com/en/#!/publisher/9268
    ///www.indiestd.com
    ///info@indiestd.com
    namespace IndieStudio.LetterWrite.Utility
    {

        /// Escape or Back event
        public class EscapeEvent : MonoBehaviour
        {
            /// <summary>
            /// The name of the scene to be loaded.
            /// </summary>
            public string sceneName;

            /// <summary>
            /// Whether to leave the application on escape click.
            /// </summary>
            public bool leaveTheApplication;

            /// <summary>
            /// Whether to load the name of the scene in the shapes manager or not.
            /// </summary>
            public bool loadShapesManagerSceneName;

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    OnEscapeClick();
                }
            }

            /// <summary>
            /// On Escape click event.
            /// </summary>
            public void OnEscapeClick()
            {
                if (leaveTheApplication)
                {
                    GameObject exitConfirmDialog = GameObject.Find("ExitConfirmDialog");
                    if (exitConfirmDialog != null)
                    {
                        Dialog exitDialogComponent = exitConfirmDialog.GetComponent<Dialog>();
                        if (!exitDialogComponent.animator.GetBool("On"))
                        {
                            exitDialogComponent.Show();
                            //AdsManager.instance.ShowAdvertisment (AdsManager.AdAPI.AdEvent.Event.ON_SHOW_EXIT_DIALOG);
                        }
                    }
                }
                else
                {
                    if (loadShapesManagerSceneName)
                    {
                        StartCoroutine(SceneLoader.LoadSceneAsync(GameObject.Find(ShapesManagerLetter.shapesManagerReference).GetComponent<ShapesManagerLetter>().sceneName));
                    }
                    else
                    {
                        StartCoroutine(SceneLoader.LoadSceneAsync(sceneName));
                    }
                }
            }
        }
    }
}