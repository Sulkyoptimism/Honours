
using System.Collections;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip clip1;
    AudioSource ASource;
    Transform MagicLoc;
    public bool PlayStart = true;
    public bool Attenuate = true;

    //Looping/repeating
    public bool looping = true;
    public float MinTime = 1.0f;
    public float MaxTime = 5.0f;

    //pitch
    public float Pitch = 1.0f;
    public float PitchRand = 0f;


    private bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        ASource = gameObject.AddComponent<AudioSource>();
        ASource.clip = clip1;

        MagicLoc = gameObject.AddComponent<Transform>();

        if (Attenuate == true)
        {
            ASource.spatialBlend = 1;
        }
        else
        {
            ASource.spatialBlend = 0;
        }

        if (looping == true)
        {
            StartCoroutine(PlayClip());
        }
        else
        {
            PlayClipOneshot();
        }

    }

    IEnumerator PlayClip()
    {
        print("Coroutine Started");
        

        //makenoise
        while (stop==false)
        {
            //clipswitch
            //ASource.clip = clip1;


            //pitchchange
            float Pitchmod = Random.Range(Pitch - PitchRand, Pitch + PitchRand);
            ASource.pitch = Pitchmod;


            ASource.Play();
            
            float delay = Random.Range(MinTime, MaxTime);   ///Randomisation of delay between clips in range
            yield return new WaitForSeconds(delay);
            print("Coroutine finish");

        }
    }


    void PlayClipOneshot()
    {
        //makenoise
        if (stop == false && PlayStart == true)
        {
            ASource.Play();
            stop = true;
        }
    }
}