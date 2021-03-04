using Assets.Script.PunPinYin;
using Assets.Scripts.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XiaoPaoPao2Button : Assets.Scripts.PunPinYin.pubButton
{





    void Start()
    {
        //ztf  change sprite
        #region Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj
        if (Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj != null)
        {
             List<Sprite> ListSprite = new List<Sprite>();
            List<String> varListSpriteSound = new List<String>();
            int intAddNum = 0;
            for (int i = 0; i < Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.FileTrainingList.Count; i++)
            {
                if (Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.FileTrainingList[i].mChecked)
                {

                    SprieWWWResourcePlayer sprieWWWResource = getSprite(i);
                    ListSprite.Add(sprieWWWResource.mySprite);


                    string strSoundRecordWavpath = Path.Combine(Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.StrOutRecordPath, Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.FileTrainingList[i].strRecordFilePath);
                    varListSpriteSound.Add(strSoundRecordWavpath);

                  //  LevelManager.ingrediendSprites[3 + intAddNum] = sprieWWWResource.mySprite;
                    if (intAddNum >= 6) break;
                    intAddNum++;
                }
            }
            Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.ListSprite = ListSprite;
            Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj.ListSpriteSound = varListSpriteSound;

        }
        #endregion


        myButtonSelctList = new ButtonSelect[1];
        myButtonSelctList[0] = new ButtonSelect { buttonName = "Exit", left = 28, top = 370 };
    }

    override
    public void MainSelect(string strWhich)
    {
        //StaticGlobalService.getTargetItemListPath();
        switch (strWhich)
        {
            case "Exit":
                UnityEngine.SceneManagement.SceneManager.LoadScene("Select");
                break;

        }
        // UnityEngine.SceneManagement.SceneManager.LoadScene(strWhich);
    }

    // Update is called once per frame
    void Update()
    {

    }



    private SprieWWWResourcePlayer getSprite(int itemIndex)
    {
        var ddddGloaltextList = Assets.Script.PunPinYin.StaticGlobal.gStaticTrainingobj;
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


        SprieWWWResourcePlayer sprieWWWResource = new SprieWWWResourcePlayer();

        System.String strPathmyText = ddddGloaltextList.FileTrainingList[itemIndex].strFileTextname.toString();

        // myPicPosText.text = (itemIndex + 1).ToString() + "/" + GloaltextList.Count.ToString();

        string sssContent = File.ReadAllText(System.IO.Path.Combine(ddddGloaltextList.StrOutResourcePath, strPathmyText));

        //string strPathmyPic = (strPathmyText.Substring(0, strPathmyText.Length - 4) + "jpg");
        string strFileSmall = (strPathmyText.Substring(0, strPathmyText.Length - 4) + "_small.jpg");
        LoadRawImage LoadRawImageService = new LoadRawImage();
        Texture2D tPicext = LoadRawImageService.loadLocalFile(System.IO.Path.Combine(ddddGloaltextList.StrOutResourcePath, strFileSmall));


        sprieWWWResource.iflockSprite = string.IsNullOrEmpty(ddddGloaltextList.FileTrainingList[itemIndex].strRecordFilePath);



        // Texture2D text = www.texture;
        sprieWWWResource.mySprite = Sprite.Create(tPicext, new Rect(0, 0, tPicext.width, tPicext.height), new Vector2(0.5f, 0.5f));
        

        sprieWWWResource.strContent = sssContent;
        return sprieWWWResource;
    }






}
