
using System.Collections;
using UnityEngine;

public class AudioBCopy : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource ASource;
    public bool PlayAtStart = true;
    public bool ThreeDimensional = true;

    public Hashtable ManagedVars = new Hashtable();


    //Looping/repeating
    public bool looping = true;
    public float MinTime = 1.0f;
    public float MaxTime = 5.0f;

    //pitch
    public float Pitch = 1.0f;
    public float PitchRand = 0f;

    //location
    public bool Semisphere = false;
    public bool LocationRandomisation = true;
    public float MinSpawnDist = 5.0f;
    public float MaxSpawnDist = 10.0f;
    private GameObject prefab;

    //Rolloff
    public bool ShowRolloff;
    public float RolloffMin = 5.0f;
    public float RolloffMax = 10.0f;

    [HideInInspector] public bool stop = false;
    [HideInInspector] public bool Active = false;
    [HideInInspector] public bool playing = false;
    [HideInInspector] public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {

        ManagedVars.Add("looping", looping);
        ManagedVars.Add("MinTime", MinTime);
        ManagedVars.Add("MaxTime", MaxTime);
        ManagedVars.Add("Pitch", Pitch);
        ManagedVars.Add("PitchRand", PitchRand);
        ManagedVars.Add("LocationRandomisation", LocationRandomisation);
        ManagedVars.Add("MinSpawnDist", MinSpawnDist);
        ManagedVars.Add("MaxSpawnDist", MaxSpawnDist);
        ManagedVars.Add("RolloffMin", RolloffMin);
        ManagedVars.Add("RolloffMax", RolloffMax);


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
        if (Active == true && playing == false)
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


    private void OnDrawGizmos()
    {

        if (ShowRolloff == true && LocationRandomisation == false)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, RolloffMin);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, RolloffMax);
        }
        else if (LocationRandomisation == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, MinSpawnDist);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, MaxSpawnDist);
        }

    }

    IEnumerator PlayClip()
    {
        print("Coroutine Started");

        //makenoise
        while (stop == false)
        {
            playing = true;

            clip = clips[Random.Range(0, clips.Length - 1)];


            //pitchchange
            float P1 = (float)ManagedVars["Pitch"];
            float Pitchmod = Random.Range(P1 - PitchRand, P1 + PitchRand);



            if (LocationRandomisation == true)
            {
                Vector3 dir = new Vector3();
                float mag = Random.Range((float)ManagedVars["MinSpawnDist"], (float)ManagedVars["MaxSpawnDist"]);

                if (Semisphere == true)
                {
                    dir = GetPointOnUnitSphereCap(transform.up, 90f);
                }
                else
                {
                    dir = Random.onUnitSphere.normalized;

                }
                Vector3 DirMag = dir * mag;
                Vector3 NewLocation = transform.position + DirMag;
                Debug.DrawLine(transform.position, NewLocation, Color.green, 3.0f);
                Instantiate<GameObject>(prefab, NewLocation, Quaternion.Euler(0f, 0f, 0f), transform);
                foreach (Transform child in transform)
                {
                    if (child.name == "MagicLoc(Clone)")
                    {
                        var source = child.gameObject.AddComponent<AudioSource>();
                        source.enabled = true;
                        source.pitch = Pitchmod;
                        source.clip = clip;
                        source.spatialBlend = 1f;
                        source.minDistance = (float)ManagedVars["RolloffMin"];
                        source.maxDistance = (float)ManagedVars["RolloffMax"];
                        source.Play();
                        var D = child.gameObject.AddComponent<Destructo>();
                        D.delay = clip.length + (clip.length / 10);
                    }
                }
            }
            else
            {
                ASource.pitch = Pitchmod;
                ASource.clip = clip;
                ASource.Play();

            }

            float delay = Random.Range((float)ManagedVars["MinTime"], (float)ManagedVars["MaxTime"]);   ///Randomisation of delay between clips in range
            Debug.Log(delay);
            yield return new WaitForSeconds(delay);


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

    public static Vector3 GetPointOnUnitSphereCap(Quaternion targetDirection, float angle)
    {
        var angleInRad = Random.Range(0.0f, angle) * Mathf.Deg2Rad;
        var PointOnCircle = (Random.insideUnitCircle.normalized) * Mathf.Sin(angleInRad);
        var V = new Vector3(PointOnCircle.x, PointOnCircle.y, Mathf.Cos(angleInRad));
        return targetDirection * V;
    }
    public static Vector3 GetPointOnUnitSphereCap(Vector3 targetDirection, float angle)
    {
        return GetPointOnUnitSphereCap(Quaternion.LookRotation(targetDirection), angle);
    }
}
