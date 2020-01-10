using UnityEngine;
public class AudioPostUnit : MonoBehaviour
{
    public bool UseSaveData = false;
    public AudioClip clip;


    private AudioClip moddedclip;

    private string PathName = "C:/Users/thorf/Documents/GitHub/Honours/AudioTest1/Assets/TM_AudioTools/AudioSaves";
    private string ext = ".ogg";
    private bool goAhead = false;

    // Start is called before the first frame update
    void Start()
    {
        string name = transform.name + "ModAud";

        

        if (UseSaveData == true)
        {
            try
            {
                AudioClip moddedclip = Resources.Load<AudioClip>(PathName + name +ext);
                Debug.Log("loaded");
                goAhead = true;
            }
            catch
            {
                Debug.LogError("No File : " + PathName + name + ext);
            }

            if (goAhead==true)
            {
                gameObject.AddComponent<AudioSource>();
                gameObject.GetComponent<AudioSource>().clip = moddedclip;
                gameObject.GetComponent<AudioSource>().Play();
            }
           

        }
        else
        {
            SavOgg.Save(name, clip);
            Debug.Log("saved");

            gameObject.AddComponent<AudioSource>();
            gameObject.GetComponent<AudioSource>().clip = clip;
            gameObject.GetComponent<AudioSource>().Play();

        }



    }

    void test()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}