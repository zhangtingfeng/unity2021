using Assets.Script.PunPinYin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;




public class PlayLocalFileSound : MonoBehaviour
{
    public AudioSource audioSource;
   


    public void PlayLocalFile(string audioPath)
    {
        var exists = File.Exists(audioPath);
        //Debug.LogFormat("{0}，存在:{1}", audioPath, exists);
        StartCoroutine(LoadAudio(audioPath, (audioClip) =>
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }));
    }

    public void stopPlayLocalFile()
    {
        //var exists = File.Exists(audioPath);
        ////Debug.LogFormat("{0}，存在:{1}", audioPath, exists);
        //StartCoroutine(LoadAudio(audioPath, (audioClip) =>
        //{
        //    audioSource.clip = audioClip;
            audioSource.Stop();
        //}));
    }

    IEnumerator LoadAudio(string filePath, Action<AudioClip> loadFinish)
    {
        //安卓和PC上的文件路径
        filePath = "file:///" + filePath;
        //Debug.LogFormat("local audioclip :{0}", filePath);
        WWW www = new WWW(filePath);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            AudioClip audioClip = null;
            //OGG文件会报：Streaming of 'ogg' on this platform is not supported
            //if (filePath.EndsWith("ogg"))
            //{
            //    audioClip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
            //}
            //else
            {

                audioClip = www.GetAudioClip();
            }
            loadFinish(audioClip);
        }
        else
        {
            //  Debug.LogErrorFormat("www load file error:{0}", www.error);
        }
    }

}

