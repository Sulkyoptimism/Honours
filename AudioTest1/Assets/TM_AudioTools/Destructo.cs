using System.Collections;
using UnityEngine;

public class Destructo : MonoBehaviour
{
    public float delay=0f;

    private void Start()
    {
        transform.parent=null;
        StartCoroutine(Destruct(delay));
    }


    IEnumerator Destruct(float time)
    {

        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
