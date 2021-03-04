using Assets.Script.PunPinYin;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace SuperScrollView
{

    public class ItemData
    {
        public int mId;
        public string mName;
        public int mFileSize;
        public string mDesc;
        /// <summary>
        /// sprite name
        /// </summary>
        public string mIcon;
        public int mStarCount;
        public bool mChecked;
        public bool mIsExpand;
    }

    public class DataSourceMgr : MonoBehaviour
    {

        public static List<ItemData> mItemDataList = new List<ItemData>();
        System.Action mOnRefreshFinished = null;
        System.Action mOnLoadMoreFinished = null;
        int mLoadMoreCount = 20;
        float mDataLoadLeftTime = 0;
        float mDataRefreshLeftTime = 0;
        bool mIsWaittingRefreshData = false;
        bool mIsWaitLoadingMoreData = false;
        /// <summary>
        /// DataSourceMgr   gameobject传值
        /// </summary>
        public int mTotalDataCount = 0;
        public static StaticTrainingobj GloalStaticTrainingobjList = new StaticTrainingobj();
        static DataSourceMgr instance = null;

        public static DataSourceMgr Get
        {
            get
            {
                if (instance == null)
                {
                    instance = Object.FindObjectOfType<DataSourceMgr>();
                }
                return instance;
            }

        }

        void Awake()
        {
            Init();
        }


        public void Init()
        {

            if (StaticGlobal.SelectDestinationTargetItem == "11Shoot")
            {
                string PathLetter = StaticGlobal.getLetterPath(0);
                string PathLetter0 = Path.Combine(PathLetter, "01OneSyllable");
                string PathLetter1 = Path.Combine(PathLetter, "02TwoSyllable");
                string PathLetter2 = Path.Combine(PathLetter, "03ThreeSyllable");
                //; ; "11Shoot"


                StaticTrainingobj GloalStaticTrainingobjList01 = Assets.Script.PunPinYin.GloaltextList.getGloaltextList(PathLetter0);
                StaticTrainingobj GloalStaticTrainingobjList02 = Assets.Script.PunPinYin.GloaltextList.getGloaltextList(PathLetter1);
                StaticTrainingobj GloalStaticTrainingobjList03 = Assets.Script.PunPinYin.GloaltextList.getGloaltextList(PathLetter2);

                List<Trainingobj> tempFileTrainingList = new List<Trainingobj>();
                addtempFileTrainingList(tempFileTrainingList, GloalStaticTrainingobjList01);
                addtempFileTrainingList(tempFileTrainingList, GloalStaticTrainingobjList02);
                addtempFileTrainingList(tempFileTrainingList, GloalStaticTrainingobjList03);
                GloalStaticTrainingobjList.FileTrainingList = tempFileTrainingList;
                GloalStaticTrainingobjList.StrOutRecordPath = GloalStaticTrainingobjList01.StrOutRecordPath;
                GloalStaticTrainingobjList.StrOutResourcePath = GloalStaticTrainingobjList01.StrOutResourcePath;

            }
            else {
                string PathLetter = StaticGlobal.getLetterPath();
                GloalStaticTrainingobjList = Assets.Script.PunPinYin.GloaltextList.getGloaltextList(PathLetter);
            }
            // System.String PathLetter1 = ;


            SetDataTotalCount(GloalStaticTrainingobjList.FileTrainingList.Count);

            DoRefreshDataSource();
        }

        private void addtempFileTrainingList(List<Trainingobj> __01List, StaticTrainingobj __02OBJ)
        {
            for (int i = 0; i < __02OBJ.FileTrainingList.Count; i++)
            {
                __01List.Add(__02OBJ.FileTrainingList[i]);
            }
        }


        public ItemData GetItemDataByIndex(int index)
        {
            if (index < 0 || index >= mItemDataList.Count)
            {
                return null;
            }
            return mItemDataList[index];
        }

        public ItemData GetItemDataById(int itemId)
        {
            int count = mItemDataList.Count;
            for (int i = 0; i < count; ++i)
            {
                if (mItemDataList[i].mId == itemId)
                {
                    return mItemDataList[i];
                }
            }
            return null;
        }

        public int TotalItemCount
        {
            get
            {
                return mItemDataList.Count;
            }
        }

        public void RequestRefreshDataList(System.Action onReflushFinished)
        {
            mDataRefreshLeftTime = 1;
            mOnRefreshFinished = onReflushFinished;
            mIsWaittingRefreshData = true;
        }

        public void RequestLoadMoreDataList(int loadCount, System.Action onLoadMoreFinished)
        {
            mLoadMoreCount = loadCount;
            mDataLoadLeftTime = 1;
            mOnLoadMoreFinished = onLoadMoreFinished;
            mIsWaitLoadingMoreData = true;
        }

        public void Update()
        {
            if (mIsWaittingRefreshData)
            {
                mDataRefreshLeftTime -= Time.deltaTime;
                if (mDataRefreshLeftTime <= 0)
                {
                    mIsWaittingRefreshData = false;
                    DoRefreshDataSource();
                    if (mOnRefreshFinished != null)
                    {
                        mOnRefreshFinished();
                    }
                }
            }
            if (mIsWaitLoadingMoreData)
            {
                mDataLoadLeftTime -= Time.deltaTime;
                if (mDataLoadLeftTime <= 0)
                {
                    mIsWaitLoadingMoreData = false;
                    DoLoadMoreDataSource();
                    if (mOnLoadMoreFinished != null)
                    {
                        mOnLoadMoreFinished();
                    }
                }
            }

        }

        public void SetDataTotalCount(int count)
        {
            mTotalDataCount = count;
            DoRefreshDataSource();
        }

        public void ExchangeData(int index1, int index2)
        {
            ItemData tData1 = mItemDataList[index1];
            ItemData tData2 = mItemDataList[index2];
            mItemDataList[index1] = tData2;
            mItemDataList[index2] = tData1;
        }

        public void RemoveData(int index)
        {
            mItemDataList.RemoveAt(index);
        }

        public void InsertData(int index, ItemData data)
        {
            mItemDataList.Insert(index, data);
        }

        void DoRefreshDataSource()
        {
            mItemDataList.Clear();
            for (int i = 0; i < mTotalDataCount; ++i)
            {
                ItemData tData = new ItemData();
                tData.mId = i;
                tData.mName = "Me" + i;
                tData.mDesc = "Item Desc For Item " + i;
                tData.mIcon = ResManager.Get.GetSpriteNameByIndex(Random.Range(0, 24));
                tData.mStarCount = Random.Range(0, 6);
                tData.mFileSize = Random.Range(20, 999);
                tData.mChecked = false;
                tData.mIsExpand = false;
                mItemDataList.Add(tData);
            }
            // int dddd = 0;
            //----
        }

        void DoLoadMoreDataSource()
        {
            int count = mItemDataList.Count;
            for (int k = 0; k < mLoadMoreCount; ++k)
            {
                int i = k + count;
                ItemData tData = new ItemData();
                tData.mId = i;
                tData.mName = "Item" + i;
                tData.mDesc = "Item Desc For Item " + i;
                tData.mIcon = ResManager.Get.GetSpriteNameByIndex(Random.Range(0, 24));
                tData.mStarCount = Random.Range(0, 6);
                tData.mFileSize = Random.Range(20, 999);
                tData.mChecked = false;
                tData.mIsExpand = false;
                mItemDataList.Add(tData);
            }
            mTotalDataCount = mItemDataList.Count;
        }

        public void CheckAllItem()
        {
            int count = mItemDataList.Count;
            for (int i = 0; i < count; ++i)
            {
                mItemDataList[i].mChecked = true;
            }
        }

        public void UnCheckAllItem()
        {
            int count = mItemDataList.Count;
            for (int i = 0; i < count; ++i)
            {
                mItemDataList[i].mChecked = false;
            }
        }

        public bool DeleteAllCheckedItem()
        {
            int oldCount = mItemDataList.Count;
            mItemDataList.RemoveAll(it => it.mChecked);
            return (oldCount != mItemDataList.Count);
        }

    }

}