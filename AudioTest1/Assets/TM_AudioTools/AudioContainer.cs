
using System.Collections;
using UnityEngine;

public class AudioContainer : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource ASource;
    public bool PlayAtStart = true;
    public bool ThreeDimensional = true;

    //Looping/repeating
    public bool looping = true;
    public float MinTime = 1.0f;
    public float MaxTime = 5.0f;

    //pitch
    public float Pitch = 1.0f;
    public float PitchRand = 0f;

    //location
    public bool LocationRandomisation = true;
    public float MinSpawnDist=5.0f;
    public float MaxSpawnDist=10.0f;
    private GameObject prefab;

    //Rolloff
    public float RolloffMin;
    public float RolloffMax;

    [HideInInspector] public bool stop = false;
    [HideInInspector] public bool Active = false;
    [HideInInspector] public bool playing = false;

    // Start is called before the first frame update
    void Start()
    {

        
        if (LocationRandomisation == true)
        {
            prefab = new GameObject("MagicLoc");
        }
        else
        {
            ASource = gameObject.AddComponent<AudioSource>();
            ASource.clip = clips[Random.Range(0, clips.Length - 1)];

            if (ThreeDimensional == true)
            {
                ASource.spatialBlend = 1;
                ASource.minDistance = RolloffMin;
                ASource.maxDistance = RolloffMax;

            }
            else
            {
                ASource.spatialBlend = 0;
            }
        }

        if (PlayAtStart == true)
        {

            if (looping == true)
            {
                StartCoroutine(PlayClip());
            }
            else
            {
                PlayClipOneshot();
            }
        }
    }

    private void Update()
    {
        if (Active==true&&playing==false)
        {
            if (looping == true)
            {
                StartCoroutine(PlayClip());
            }
            else
            {
                PlayClipOneshot();

            }
            Active = false;
            Debug.Log("activation done");
        }
    }




    IEnumerator PlayClip()
    {
        print("Coroutine Started");

        //makenoise
        while (stop==false)
        {
            playing = true;

            //clipswitch
            //ASource.clip = clip1;


            //pitchchange
            float Pitchmod = Random.Range(Pitch - PitchRand, Pitch + PitchRand);
            

            if (LocationRandomisation == true)
            {
                Vector3 dir = Random.onUnitSphere.normalized;
                float mag = Random.Range(MinSpawnDist, MaxSpawnDist);
                Vector3 DirMag = dir * mag;
                Vector3 NewLocation = transform.position + DirMag;
                Debug.DrawLine(transform.position, NewLocation, Color.green, 3.0f);
                Instantiate<GameObject>(prefab,NewLocation,Quaternion.Euler(0f,0f,0f),transform);
                foreach (Transform child in transform)
                {
                    child.gameObject.AddComponent<AudioSource>();
                    child.gameObject.GetComponent<AudioSource>().enabled = true;
                    child.gameObject.GetComponent<AudioSource>().pitch = Pitchmod;
                    child.gameObject.GetComponent<AudioSource>().clip = clips[Random.Range(0,clips.Length-1)];
                    child.gameObject.GetComponent<AudioSource>().spatialBlend = 1f;
                    child.gameObject.GetComponent<AudioSource>().minDistance = RolloffMin;
                    child.gameObject.GetComponent<AudioSource>().maxDistance = RolloffMax;
                    child.gameObject.GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                ASource.pitch = Pitchmod;
               
                ASource.Play();
           
            }

            float delay = Random.Range(MinTime, MaxTime);   ///Randomisation of delay between clips in range
            yield return new WaitForSeconds(delay);
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

        }
        playing = false;
        Debug.Log("Coroute done");
    }


    void PlayClipOneshot()
    {
        //makenoise
        if (stop == false && PlayAtStart == true)
        {
            ASource.Play();
            stop = true;
        }
    }
}