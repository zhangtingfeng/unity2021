using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using IndieStudio.DrawingAndColoring.Utility;

///Developed by Indie Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268
///www.indiestd.com
///info@indiestd.com

namespace IndieStudio.DrawingAndColoring.Logic
{
	/// <summary>
	/// User interface events for (buttons,sliders,...etc).
	/// </summary>
	[DisallowMultipleComponent]
	public class UIEvents : MonoBehaviour
	{
		public void ResetZoom(){
			CameraZoomDraw.ResetZoom ();
		}

		public void PointerButtonEvent(Pointer pointer){
			if (pointer == null) {
				return;
			}
			if (pointer.group != null) {
				ScrollSlider scrollSlider = GameObject.FindObjectOfType (typeof(ScrollSlider)) as ScrollSlider;
				if (scrollSlider != null) {
					scrollSlider.DisableCurrentPointer ();
					FindObjectOfType<ScrollSlider> ().currentGroupIndex = pointer.group.Index;
					scrollSlider.GoToCurrentGroup ();
				}
			}
		}

		public void PrintClickEvent(){
			GameObject.FindObjectOfType<WebPrint> ().PrintScreen ();
		}

		public void UndoClickEvent ()
		{
			History history = GameObject.FindObjectOfType<History> ();
			if (history != null) {
				history.UnDo ();
			}
		}

		public void RedoClickEvent ()
		{
			History history = GameObject.FindObjectOfType<History> ();
			if (history != null) {
				GameManagerDraw.interactable = false;
				history.Redo ();
			}
		}

		public void AlbumShapeEvent (TableShapeDraw tableShape)
		{
			if (tableShape == null) {
				return;
			}

			TableShapeDraw.selectedShape = tableShape;
			LoadGameScene ();
		}

		public void ThicknessSizeEvent (ThicknessSize thicknessSize)
		{
			if (thicknessSize == null) {
				return;
			}

			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();

			if (gameManager.currentTool == null) {
				return;
			}

			if (!(gameManager.currentTool.feature == Tool.ToolFeature.Line)) {
				return;
			}

			gameManager.currentThickness = thicknessSize;
			gameManager.ChangeThicknessSizeColor ();
		}

		public void ShowTrashConfirmDialog ()
		{
			AdsManagerDrawing.instance.ShowAdvertisment (AdPackageDrawing.AdEvent.Event.ON_SHOW_TRASH_DIALOG);
			DisableGameManager ();
			GameObject.Find ("TrashConfirmDialog").GetComponent<ConfirmDialog> ().Show ();
		}

		public void TrashConfirmDialogEvent (GameObject value)
		{
			if (value == null) {
				return;
			}
			
			if (value.name.Equals ("YesButton")) {
				Debug.Log ("Trash Confirm Dialog : Yes button clicked");
				GameObject.FindObjectOfType<GameManagerDraw> ().CleanCurrentShapeScreen ();

			} else if (value.name.Equals ("NoButton")) {
				Debug.Log ("Trash Confirm Dialog : No button clicked");
			}
			value.GetComponentInParent<ConfirmDialog> ().Hide ();
			EnableGameManager ();
			AdsManagerDrawing.instance.ShowAdvertisment (AdPackageDrawing.AdEvent.Event.ON_LOAD_GAME_SCENE);
		}

		public void ToolClickEvent (Tool tool)
		{
			if (tool == null) {
				return;
			}

			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();
			
			if (tool.useAsToolContent) {//like an eraser
				gameManager.currentToolContent = tool.GetComponent<ToolContent> ();
			}
			
			if (tool.useAsCursor) {
				//Set the tool as cursor
				gameManager.currentCursorSprite = tool.GetComponent<Image> ().sprite;
			}
			
			gameManager.currentTool.DisableSelection ();

			tool.EnableSelection ();
			gameManager.HideToolContents (gameManager.currentTool);
			gameManager.currentTool = tool;
			gameManager.LoadCurrentToolContents ();

			if (tool.contents.Count != 0) {
				//Select current content of the tool
				if(tool.selectedContentIndex >=0 && tool.selectedContentIndex < tool.contents.Count)
					gameManager.SelectToolContent (tool.contents [tool.selectedContentIndex].GetComponent<ToolContent>());
			}

			if (tool.feature == Tool.ToolFeature.Hand) {
				CameraDragDraw.isRunning = true;
			} else {
				CameraDragDraw.isRunning = false;
			}
		}

		public void ToolContentClickEvent (ToolContent content)
		{
			if (content == null) {
				return;
			}

			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();
			gameManager.SelectToolContent (content);
		}

		public void NextButtonClickEvent ()
		{
			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();
			gameManager.NextShape ();
		}

		public void PreviousButtonClickEvent ()
		{
			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();
			gameManager.PreviousShape ();
		}

		public void OnPointerEnterDrawArea(){
			GameManagerDraw.pointerInDrawArea = true;
		}

		public void OnPointerExitDrawArea(){
			GameManagerDraw.pointerInDrawArea = false;
		}

		public void DisableGameManager ()
		{
			if (!GameManagerDraw.clickDownOnDrawArea) {
				GameManagerDraw.interactable = false;
			}
		}
		
		public void EnableGameManager ()
		{
			GameManagerDraw.interactable = true;
		}

		public void OnDrawAreaClickDown ()
		{
			GameManagerDraw.clickDownOnDrawArea = true;
		}

		public void OnDrawAreaClickUp ()
		{
			GameManagerDraw.clickDownOnDrawArea = false;
		}

		public void ChangeCursorToArrow ()
		{
			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();
			if (gameManager != null)
				gameManager.ChangeCursorToArrow ();
		}

		public void ChangeCursorToCurrentSprite ()
		{
			GameManagerDraw gameManager = GameObject.FindObjectOfType<GameManagerDraw> ();
			if (gameManager != null)
				gameManager.ChangeCursorToCurrentSprite ();
		}

		public void LoadAlbumScene ()
		{
			StartCoroutine (LoadSceneAsync("DrawAlbum"));
		}

		public void LoadGameScene ()
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("DrawingAndColoring Extra/Scenes/DrawingGame");

			//StartCoroutine(LoadSceneAsync("DrawingGame"));
		}

		public void LeaveApp(){
			Application.Quit ();
		}

		IEnumerator LoadSceneAsync (string sceneName)
		{
			if (!string.IsNullOrEmpty (sceneName)) {
				#if UNITY_PRO_LICENSE
				//Show loading panel here
				AsyncOperation async = Application.LoadLevelAsync (sceneName);
				while (!async.isDone) {
					yield return 0;
				}
				#else
				Application.LoadLevel (sceneName);
				yield return 0;
				#endif
			}
		}
	}
}
