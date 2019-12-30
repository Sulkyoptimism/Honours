using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class AudioPostUnit : MonoBehaviour
{
    public bool UseSaveData = false;
    float[] NewAudio;

    float[] tmp;
    float[] AudioOut;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        NewAudio = new float[clip.samples * clip.channels];
        tmp = new float[clip.samples * clip.channels];
        AudioOut = new float[clip.samples * clip.channels];
        AudioClip moddedclip= AudioClip.Create("moddedclip", clip.samples, clip.channels, clip
            .frequency, stream: false);
        Debug.Log(clip.samples);

        if (UseSaveData==true)
        {
            LoadFile(AudioOut);
            moddedclip.SetData(AudioOut, 0);
            moddedclip.LoadAudioData();
            Debug.Log("loaded");
        }
        else
        {
            clip.GetData(tmp, 72115);
            SaveFile(tmp);
            Debug.Log("saved");
        }

        
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().clip=moddedclip;
        gameObject.GetComponent<AudioSource>().loop = true;
        gameObject.GetComponent<AudioSource>().Play();

        Debug.Log(moddedclip.samples);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveFile(float[] s)
    {
        string destination = "C:/Users/thorf/Documents/GitHub/Honours/AudioTest1/Assets/TM_AudioTools/AudioSaves" + "/save.dat";
        //string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        SaveAudioData data = new SaveAudioData(s);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }


    public void LoadFile(float[] o)
    {
        string destination = "C:/Users/thorf/Documents/GitHub/Honours/AudioTest1/Assets/TM_AudioTools/AudioSaves" + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        SaveAudioData data = (SaveAudioData)bf.Deserialize(file);
        file.Close();

        o = data.Modclip;

        }

}
