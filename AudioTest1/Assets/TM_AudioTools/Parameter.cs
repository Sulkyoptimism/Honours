using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter : MonoBehaviour
{
    private Component[] Acomps;
    public AnimationCurve curve;
    private void Start()
    {

        //gameObject.GetComponent<AudioContainer>();

        //CreateScript.Create(gameObject);
       
    }


    private void Update()
    {
        float pos =curve.Evaluate(0);
        Debug.Log(pos);
        pos =curve.Evaluate(1);
        Debug.Log(pos);

    }
}
