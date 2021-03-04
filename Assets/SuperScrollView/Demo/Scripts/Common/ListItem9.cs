using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace SuperScrollView
{


    class SprieWWWResource
    {
        public Sprite mySprite;
        public string strContent;
        public bool iflockSprite;

    }

    public class ListItem9 : MonoBehaviour
    {
        public Image LockImage;
        public Text mNameText;
        public Image mIcon;
        public Image mStarIcon;
        public Text mStarCount;
        public Text mDescText;
        public Color32 mRedStarColor = new Color32(236, 217, 103, 255);
        public Color32 mGrayStarColor = new Color32(215, 215, 215, 255);
        public Toggle mToggle;
        int mItemDataIndex = -1;
        //private static List<System.String> GloaltextList = new List<string>();

        private LoadRawImage LoadRawImageService = new LoadRawImage();
        public void Init()
        {
            ClickEventListener listener = ClickEventListener.Get(mStarIcon.gameObject);
            listener.SetClickEventHandler(OnStarClicked);
            mToggle.onValueChanged.AddListener(OnToggleValueChanged);






        }

        void OnToggleValueChanged(bool check)
        {
            ItemData data = DataSourceMgr.Get.GetItemDataByIndex(mItemDataIndex);
            if (data == null)
            {
                return;
            }
            data.mChecked = check;
        }

        void OnStarClicked(GameObject obj)
        {
            ItemData data = DataSourceMgr.Get.GetItemDataByIndex(mItemDataIndex);
            if (data == null)
            {
                return;
            }
            if (data.mStarCount == 5)
            {
                data.mStarCount = 0;
            }
            else
            {
                data.mStarCount = data.mStarCount + 1;
            }
            SetStarCount(data.mStarCount);
        }

        public void SetStarCount(int count)
        {
            mStarCount.text = count.ToString();
            if (count == 0)
            {
                mStarIcon.color = mGrayStarColor;
            }
            else
            {
                mStarIcon.color = mRedStarColor;
            }
        }

        public void SetItemData(ItemData itemData, int itemIndex)
        {
            mItemDataIndex = itemIndex;
            mNameText.text = itemData.mName;
            mDescText.text = itemData.mFileSize.ToString() + "KB";
            //mIcon.sprite = ResManager.Get.GetSpriteByName(itemData.mIcon);
            SprieWWWResource sprieWWWResource = getSprite(itemIndex);
            mIcon.sprite = sprieWWWResource.mySprite;
            mNameText.text = sprieWWWResource.strContent;

            LockImage.gameObject.SetActive( sprieWWWResource.iflockSprite);
            mToggle.gameObject.SetActive( !sprieWWWResource.iflockSprite);

            SetStarCount(itemData.mStarCount);
            mToggle.isOn = itemData.mChecked;
        }


        private SprieWWWResource getSprite(int itemIndex)
        {
            var ddddGloaltextList = DataSourceMgr.GloalStaticTrainingobjList;
            //if (GloaltextList.Count == 0)
            //{

            //#region   getSprite
            //System.String PathLetter = Assets.Script.PunPinYin.StaticGlobal.getLetterPath();
            //Debug_Log.Call_WriteLog("1","2", "getSprite");
            //if (System.IO.Directory.Exists(PathLetter))
            //{

            //    //string[] ddddd = System.IO.Directory.GetFiles(bb,);
            //    System.Linq.IOrderedEnumerable<System.String> textList = System.IO.Directory.GetFiles(PathLetter, "*.*", System.IO.SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".txt")).OrderBy(s => s.ToString()); ;
            //    GloaltextList = textList.ToList();

            //}
            //Debug_Log.Call_WriteLog("3", "4", "getSprite");
            //#endregion
            //}


            SprieWWWResource sprieWWWResource = new SprieWWWResource();

            System.String strPathmyText = ddddGloaltextList.FileTrainingList[itemIndex].strFileTextname.toString();

            // myPicPosText.text = (itemIndex + 1).ToString() + "/" + GloaltextList.Count.ToString();

            string sssContent = File.ReadAllText(Path.Combine(ddddGloaltextList.StrOutResourcePath, strPathmyText));

            //string strPathmyPic = (strPathmyText.Substring(0, strPathmyText.Length - 4) + "jpg");
            string strFileSmall = (strPathmyText.Substring(0, strPathmyText.Length - 4) + "_small.jpg");

            Texture2D tPicext = LoadRawImageService.loadLocalFile(Path.Combine(ddddGloaltextList.StrOutResourcePath, strFileSmall));


            sprieWWWResource.iflockSprite = string.IsNullOrEmpty(ddddGloaltextList.FileTrainingList[itemIndex].strRecordFilePath);



            // Texture2D text = www.texture;
            sprieWWWResource.mySprite = Sprite.Create(tPicext, new Rect(0, 0, tPicext.width, tPicext.height), new Vector2(0, 0));


            sprieWWWResource.strContent = sssContent;
            return sprieWWWResource;
        }

    }
}
