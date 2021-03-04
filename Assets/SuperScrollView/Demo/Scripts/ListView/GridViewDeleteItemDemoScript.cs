using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SuperScrollView
{

    public class GridViewDeleteItemDemoScript : MonoBehaviour
    {
        public LoopListView2 mLoopListView;
        public Button mSelectAllButton;
        public Button mCancelAllButton;
        public Button mDeleteButton;
        public Button mBackButton;
        public Button mOkButton;
        /// <summary>
        /// the count of each row  ztf
        /// </summary>
        const int mItemCountPerRow = 6;
        int mListItemTotalCount = 0;

        // Use this for initialization
        void Start()
        {

            ////需要异步加载场景

            mListItemTotalCount = DataSourceMgr.Get.TotalItemCount;
            int count = mListItemTotalCount / mItemCountPerRow;
            if (mListItemTotalCount % mItemCountPerRow > 0)
            {
                count++;
            }
            mLoopListView.InitListView(count, OnGetItemByIndex);
            mBackButton.onClick.AddListener(OnBackBtnClicked);
            mOkButton.onClick.AddListener(OnOkBtnClicked);
            mSelectAllButton.onClick.AddListener(OnSelectAllBtnClicked);
            mCancelAllButton.onClick.AddListener(OnCancelAllBtnClicked);
            mDeleteButton.onClick.AddListener(OnDeleteBtnClicked);
        }

        void OnBackBtnClicked()
        {
            int intNum = 0;
            Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj = DataSourceMgr.GloalStaticTrainingobjList;
            for (int i = 0; i < Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.FileTrainingList.Count; i++) {
                if (DataSourceMgr.mItemDataList[i].mChecked) {
                    Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.FileTrainingList[i].mChecked = true;
                    intNum++;
                }
            }
            if (intNum < 6) {///not use  this var if less than 6
                Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj = null;
            }

            if (Assets.Script.PunPinYin.StaticGlobal.SelectDestinationTargetItem == "01OneSyllable")
            {
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = ("Scence/Sub/OneWord");
            }
            else if (Assets.Script.PunPinYin.StaticGlobal.SelectDestinationTargetItem == "02TwoSyllable")
            {
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = ("Scence/Sub/TwoSyllable");
            }
            else if (Assets.Script.PunPinYin.StaticGlobal.SelectDestinationTargetItem == "03ThreeSyllable")
            {
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = ("Scence/Sub/ThreeSyllable");
            }
            else if (Assets.Script.PunPinYin.StaticGlobal.SelectDestinationTargetItem == "10Video")
            {
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = ("Scence/Sub/VideoPlay");
            }
            else if (Assets.Script.PunPinYin.StaticGlobal.SelectDestinationTargetItem == "11Shoot")
            {
                Assets.Script.PunPinYin.StaticGlobal.nextSceneName = ("JellyGarden/Scenes/gameJellyGarden");
            }
            string strJump = "Scence/Loading";
            //Assets.Script.PunPinYin.StaticGlobal.nextSceneName = "SuperScrollView/Demo/Scenes/GridViewSelectItem";
            UnityEngine.SceneManagement.SceneManager.LoadScene(strJump);

            // UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }

        void OnOkBtnClicked()
        {
            OnBackBtnClicked();
           // UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
       


        LoopListViewItem2 OnGetItemByIndex(LoopListView2 listView, int index)
        {
            if (index < 0)
            {
                return null;
            }
            LoopListViewItem2 item = listView.NewListViewItem("ItemPrefab1");
            ListItem10 itemScript = item.GetComponent<ListItem10>();
            if (item.IsInitHandlerCalled == false)
            {
                item.IsInitHandlerCalled = true;
                itemScript.Init();
            }
            for (int i = 0; i < mItemCountPerRow; ++i)
            {
                int itemIndex = index * mItemCountPerRow + i;
                if (itemIndex >= mListItemTotalCount)
                {
                    itemScript.mItemList[i].gameObject.SetActive(false);
                    continue;
                }
                ItemData itemData = DataSourceMgr.Get.GetItemDataByIndex(itemIndex);
                if (itemData != null)
                {
                    itemScript.mItemList[i].gameObject.SetActive(true);
                    itemScript.mItemList[i].SetItemData(itemData, itemIndex);
                }
                else
                {
                    itemScript.mItemList[i].gameObject.SetActive(false);
                }
            }
            return item;
        }

        void OnSelectAllBtnClicked()
        {
            DataSourceMgr.Get.CheckAllItem();
            mLoopListView.RefreshAllShownItem();
        }

        void OnCancelAllBtnClicked()
        {
            DataSourceMgr.Get.UnCheckAllItem();
            mLoopListView.RefreshAllShownItem();
        }

        void OnDeleteBtnClicked()
        {
            bool isChanged = DataSourceMgr.Get.DeleteAllCheckedItem();
            if (isChanged == false)
            {
                return;
            }
            SetListItemTotalCount(DataSourceMgr.Get.TotalItemCount);
        }


        void SetListItemTotalCount(int count)
        {
            mListItemTotalCount = count;
            if (mListItemTotalCount < 0)
            {
                mListItemTotalCount = 0;
            }
            if (mListItemTotalCount > DataSourceMgr.Get.TotalItemCount)
            {
                mListItemTotalCount = DataSourceMgr.Get.TotalItemCount;
            }
            int count1 = mListItemTotalCount / mItemCountPerRow;
            if (mListItemTotalCount % mItemCountPerRow > 0)
            {
                count1++;
            }
            mLoopListView.SetListItemCount(count1, false);
            mLoopListView.RefreshAllShownItem();
        }

    }

}
