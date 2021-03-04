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
using UnityEngine.UI;
namespace IndieStudio.LetterWrite.Utility
{
    ///Developed by Indie Studio
    ///https://www.assetstore.unity3d.com/en/#!/publisher/9268
    ///www.indiestd.com
    ///info@indiestd.com

    public class UIEvents : MonoBehaviour
    {
        public void AlbumShapeEvent(TableShape tableShape)
        {
            if (tableShape == null)
            {
                return;
            }

            if (tableShape.isLocked)
            {
                return;
            }

            TableShape.selectedShape = tableShape;
            LoadGameScene();
        }

        public void PointerButtonEvent(Pointer pointer)
        {
            if (pointer == null)
            {
                return;
            }
            if (pointer.group != null)
            {
                ScrollSlider scrollSlider = GameObject.FindObjectOfType(typeof(ScrollSlider)) as ScrollSlider;
                if (scrollSlider != null)
                {
                    scrollSlider.DisableCurrentPointer();
                    FindObjectOfType<ScrollSlider>().currentGroupIndex = pointer.group.Index;
                    scrollSlider.GoToCurrentGroup();
                }
            }
        }

        public void LoadMainScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scence/ClearData");
           // StartCoroutine(SceneLoader.LoadSceneAsync("Select"));
        }

        public void LoadGameScene()
        {
            StartCoroutine(SceneLoader.LoadSceneAsync("LetterGame"));
        }

        public void LoadAlbumScene()
        {
            if (!string.IsNullOrEmpty(ShapesManagerLetter.shapesManagerReference))
                StartCoroutine(SceneLoader.LoadSceneAsync(GameObject.Find(ShapesManagerLetter.shapesManagerReference).GetComponent<ShapesManagerLetter>().sceneName));
        }

        public void LoadLowercaseAlbumScene()
        {
            ShapesManagerLetter.shapesManagerReference = "LShapesManager";
            StartCoroutine(SceneLoader.LoadSceneAsync("LowercaseAlbum"));
        }

        public void LoadUppercaseAlbumScene()
        {
            ShapesManagerLetter.shapesManagerReference = "UShapesManager";
            StartCoroutine(SceneLoader.LoadSceneAsync("UppercaseAlbum"));
        }

        public void LoadbpmfAlbumScene()
        {
            ShapesManagerLetter.shapesManagerReference = "bpmfShapesManager";
            StartCoroutine(SceneLoader.LoadSceneAsync("bpmfcaseAlbum"));
        }


        public void LoadNumbersAlbumScene()
        {
            ShapesManagerLetter.shapesManagerReference = "NShapesManager";
            StartCoroutine(SceneLoader.LoadSceneAsync("NumbersAlbum"));
        }

        public void LoadSentenceAlbumScene()
        {
            ShapesManagerLetter.shapesManagerReference = "SShapesManager";
            StartCoroutine(SceneLoader.LoadSceneAsync("SentenceAlbum"));
        }

        public void NextClickEvent()
        {
            try
            {
                GameObject.FindObjectOfType<GameManager>().NextShape();
            }
            catch (System.Exception ex)
            {

            }
        }

        public void PreviousClickEvent()
        {
            try
            {
                GameObject.FindObjectOfType<GameManager>().PreviousShape();
            }
            catch (System.Exception ex)
            {

            }
        }

        public void SpeechClickEvent()
        {
            Shape shape = GameObject.FindObjectOfType<Shape>();
            if (shape == null)
            {
                return;
            }
            shape.Spell();
        }

        public void ResetShape()
        {
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                if (!gameManager.shape.completed)
                {
                    gameManager.DisableGameManager();
                    GameObject.Find("ResetConfirmDialog").GetComponent<Dialog>().Show();
                }
                else
                {
                    gameManager.ResetShape();
                }
            }
        }

        public void PencilClickEvent(Pencil pencil)
        {
            if (pencil == null)
            {
                return;
            }
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            if (gameManager == null)
            {
                return;
            }
            if (gameManager.currentPencil != null)
            {
                gameManager.currentPencil.DisableSelection();
                gameManager.currentPencil = pencil;
            }
            gameManager.SetShapeOrderColor();
            pencil.EnableSelection();
        }

        public void ResetConfirmDialogEvent(GameObject value)
        {
            if (value == null)
            {
                return;
            }

            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();

            if (value.name.Equals("YesButton"))
            {
                Debug.Log("Reset Confirm Dialog : Yes button clicked");
                if (gameManager != null)
                {
                    gameManager.ResetShape();
                }

            }
            else if (value.name.Equals("NoButton"))
            {
                Debug.Log("Reset Confirm Dialog : No button clicked");
            }

            value.GetComponentInParent<Dialog>().Hide();

            if (gameManager != null)
            {
                gameManager.EnableGameManager();
            }
        }


        public void ResetGame()
        {
            DataManager.ResetGame();
        }

        public void LeaveApp()
        {
            Application.Quit();
        }
    }
}