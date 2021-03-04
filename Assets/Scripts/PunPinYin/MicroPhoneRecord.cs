using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class MicroPhoneRecord : MonoBehaviour
{
    private int DeviceLength;
    private const int HEADER_SIZE = 44;
    public const int SamplingRate = 11025;
    /// <summary>
    /// 录音时长
    /// </summary>
    private const int RecordSeonds = 30;///
    private delegate void AudioRecordHandle(AudioClip audioClip);
    //public AudioSource audioSource;
    private AudioClip micClip;
    /// <summary>
    /// 实际录音时长
    /// </summary>
    private int lastaudioPos;

    private bool isMicRecordFinished = true;

    private List<float> micDataList = new List<float>();
    private float[] micDataTemp;

    private string micName;
    private string RecordFileName;

    /// <summary>
    /// 是否正在录音
    /// </summary>
    private bool boolRecording = false;///
    private bool boolresetMicrophone = false;///

    private DateTime StartMicrophoneframeTime = DateTime.Now;//记录接受动作的时间，小于0.5秒的放弃/  
                                                             //private AudioSource aud;

    public void StartMicrophone(String argRecordFileName)
    {
        if (DateTime.Now.Ticks - StartMicrophoneframeTime.Ticks < 500) return;
        RecordFileName = argRecordFileName;
        Debug.Log(RecordFileName);
        //new AndoridSD().WriteSD();
        // newRecordAudioClip = null;////清楚可以录音后播放的声音
        boolRecording = true;
        boolresetMicrophone = false;
        //StopCoroutine(StartMicrophone(Microphone.devices[0], saveAudioRecord));
        //StartCoroutine(StartMicrophone(Microphone.devices[0], saveAudioRecord));

        OnRecording(true, null);
        StartMicrophoneframeTime = DateTime.Now;
    }
    public void StopMicrophone()
    {
        OnRecording(false, saveAudioRecord);
        boolRecording = false;
        //Debug.Log("Stop mic");
        isMicRecordFinished = true;
    }
    public void resetMicrophone()
    {
        if (boolRecording)
        {
            boolRecording = false;
            boolresetMicrophone = true;
            StopMicrophone();
        }
    }

    void OnRecording(bool flag, AudioRecordHandle audioRecordFinishedEvent)
    {
        if (flag)
        {//按钮按下开始录音
            Microphone.End(null);//这句可以不需要，但是在开始录音以前调用一次是好习惯
            micClip = Microphone.Start(Microphone.devices[0], false, RecordSeonds, SamplingRate);
        }
        else
        {//按钮弹起结束录音
            int audioLength;//录音的长度，单位为秒，ui上可能需要显示
            lastaudioPos = Microphone.GetPosition(null);
            if (Microphone.IsRecording(null))
            {//录音小于10秒
                audioLength = lastaudioPos / SamplingRate;//录音时长
            }
            else
            {
                audioLength = RecordSeonds;
            }
            Microphone.End(null);//此时录音结束，clip已可以播放了
            if (audioLength < 1.0f) return;//录音小于1秒就不处理了
                                           //如果要便于传输还需要进行压缩，压缩后的recordData就可以用于网络传输了
            audioRecordFinishedEvent(micClip);
        }
    }


    IEnumerator StartMicrophone(string microphoneName, AudioRecordHandle audioRecordFinishedEvent)
    {
        Debug.Log("Start Mic");
        micDataList = new List<float>();
        micName = microphoneName;
        micClip = Microphone.Start(micName, true, 2, 16000);
        isMicRecordFinished = false;
        int length = micClip.channels * micClip.samples;
        bool isSaveFirstHalf = true;//将音频从中间分生两段，然后分段保存
        int micPosition;
        while (!isMicRecordFinished || isSaveFirstHalf)////true不能结束
        {
            if (isSaveFirstHalf)
            {
                yield return new WaitUntil(() => { micPosition = Microphone.GetPosition(micName); return micPosition > length * 6 / 10 && micPosition < length; });//保存前半段
                micDataTemp = new float[length / 2];
                micClip.GetData(micDataTemp, 0);
                micDataList.AddRange(micDataTemp);
                isSaveFirstHalf = !isSaveFirstHalf;
            }
            else
            {
                yield return new WaitUntil(() => { micPosition = Microphone.GetPosition(micName); return micPosition > length / 10 && micPosition < length / 2; });//保存后半段
                micDataTemp = new float[length / 2];
                micClip.GetData(micDataTemp, length / 2);
                micDataList.AddRange(micDataTemp);
                isSaveFirstHalf = !isSaveFirstHalf;
            }

        }
        micPosition = Microphone.GetPosition(micName);
        if (micPosition <= length)//前半段
        {
            micDataTemp = new float[micPosition / 2];
            micClip.GetData(micDataTemp, 0);
        }
        else
        {
            micDataTemp = new float[micPosition - length / 2];
            micClip.GetData(micDataTemp, length / 2);
        }
        micDataList.AddRange(micDataTemp);
        Microphone.End(micName);
        AudioClip newAudioClip = AudioClip.Create("RecordClip", micDataList.Count, 1, 16000, false);
        newAudioClip.SetData(micDataList.ToArray(), 0);
        audioRecordFinishedEvent(newAudioClip);
        Debug.Log("RecordEnd");
    }





    void saveAudioRecord(AudioClip newAudioClip)
    {
        // GetComponent<AudioSource>().clip = newAudioClip;
        // GetComponent<AudioSource>().Play();
        //newRecordAudioClip = newAudioClip;////可以录音后播放使用

        if (boolresetMicrophone)
        {
            boolresetMicrophone = false;
            return;////不保存了
        }
        SaveRecordedWav(RecordFileName, newAudioClip);
    }





    //保存wav 模式
    public bool SaveRecordedWav(string filename, AudioClip clip)
    {



#if UNITY_IPHONE
 Debug.Log("这里是苹果设备>_<");
//		path_1 = Application.persistentDataPath;
		string filepath = Path.Combine(Application.persistentDataPath, filename);
#endif

#if UNITY_STANDALONE_WIN
        try
        {

           
            string path_save = filename;
           
#endif
#if UNITY_ANDROID

        
        try
        {
           
          
            //存储路径
            string destination = Application.persistentDataPath;
            Debug_Log.Call_WriteLog(destination, "这里是安卓设备persistentDataPath");
            //若没路径 创建
            if (!Directory.Exists((destination)))
            {
                Directory.CreateDirectory(destination);
            }

            string strFolderTest = "FolderTest";
            string strAllFolderTest = Path.Combine(destination, strFolderTest);
            if (!Directory.Exists((strAllFolderTest)))
            {
                Directory.CreateDirectory(strAllFolderTest);
            }

            //文件完整路径
            string path_save = Path.Combine(strAllFolderTest, filename);
           


           
#endif
            using (FileStream fileStream = CreateEmpty(path_save))
            {

                ConvertAndWrite(fileStream, clip);
                WriteHeader(fileStream, clip);
            }
            if (File.Exists((path_save)))
            {
                Debug_Log.Call_WriteLog(path_save, "录音路径成功", "录音成功");
            }
            else
            {
                Debug_Log.Call_WriteLog(path_save, "录音路径失败", "录音成功");
            }
        }
        catch (Exception eee)
        {
            Debug_Log.Call_WriteLog(eee, "写报错", "这里是设备");
        }

        return true; // TODO: return false if there's a failure saving the file
    }
    FileStream CreateEmpty(string filepath)
    {
        FileStream fileStream = new FileStream(filepath, FileMode.Create);
        byte emptyByte = new byte();

        for (int i = 0; i < HEADER_SIZE; i++) //preparing the header
        {
            fileStream.WriteByte(emptyByte);
        }

        return fileStream;
    }
    void ConvertAndWrite(FileStream fileStream, AudioClip clip)
    {
        //int ddddd = audioLength;
        float[] samples = new float[lastaudioPos];

        clip.GetData(samples, 0);

        Int16[] intData = new Int16[samples.Length];
        //converting in 2 float[] steps to Int16[], //then Int16[] to Byte[]

        Byte[] bytesData = new Byte[samples.Length * 2];
        //bytesData array is twice the size of
        //dataSource array because a float converted in Int16 is 2 bytes.

        int rescaleFactor = 32767; //to convert float to Int16

        for (int i = 0; i < samples.Length; i++)
        {
            intData[i] = (short)(samples[i] * rescaleFactor);
            Byte[] byteArr = new Byte[2];
            byteArr = BitConverter.GetBytes(intData[i]);
            byteArr.CopyTo(bytesData, i * 2);
        }

        fileStream.Write(bytesData, 0, bytesData.Length);
    }
    void WriteHeader(FileStream fileStream, AudioClip clip)
    {

        int hz = clip.frequency;
        int channels = clip.channels;
        //int samples = clip.samples;

        fileStream.Seek(0, SeekOrigin.Begin);

        Byte[] riff = System.Text.Encoding.UTF8.GetBytes("RIFF");
        fileStream.Write(riff, 0, 4);

        Byte[] chunkSize = BitConverter.GetBytes(fileStream.Length - 8);
        fileStream.Write(chunkSize, 0, 4);

        Byte[] wave = System.Text.Encoding.UTF8.GetBytes("WAVE");
        fileStream.Write(wave, 0, 4);

        Byte[] fmt = System.Text.Encoding.UTF8.GetBytes("fmt ");
        fileStream.Write(fmt, 0, 4);

        Byte[] subChunk1 = BitConverter.GetBytes(16);
        fileStream.Write(subChunk1, 0, 4);

        UInt16 two = 2;
        UInt16 one = 1;

        Byte[] audioFormat = BitConverter.GetBytes(one);
        fileStream.Write(audioFormat, 0, 2);

        Byte[] numChannels = BitConverter.GetBytes(channels);
        fileStream.Write(numChannels, 0, 2);

        Byte[] sampleRate = BitConverter.GetBytes(hz);
        fileStream.Write(sampleRate, 0, 4);

        Byte[] byteRate = BitConverter.GetBytes(hz * channels * 2); // sampleRate * bytesPerSample*number of channels, here 44100*2*2
        fileStream.Write(byteRate, 0, 4);

        UInt16 blockAlign = (ushort)(channels * 2);
        fileStream.Write(BitConverter.GetBytes(blockAlign), 0, 2);

        UInt16 bps = 16;
        Byte[] bitsPerSample = BitConverter.GetBytes(bps);
        fileStream.Write(bitsPerSample, 0, 2);

        Byte[] datastring = System.Text.Encoding.UTF8.GetBytes("data");
        fileStream.Write(datastring, 0, 4);

        Byte[] subChunk2 = BitConverter.GetBytes(lastaudioPos * channels * 2);
        fileStream.Write(subChunk2, 0, 4);

        //		fileStream.Close();
    }
    /* */

    /// <summary>
    /// 获取麦克风设备
    /// </summary>
    public void GetMicrophoneDevice()
    {
        string[] mDevice = Microphone.devices;
        DeviceLength = mDevice.Length;
        if (DeviceLength == 0)
            Debug.Log("找不到麦克风设备！");
    }


}