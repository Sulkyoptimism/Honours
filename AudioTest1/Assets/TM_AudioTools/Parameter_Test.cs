using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parameter_Test : MonoBehaviour
{
    public GameObject AGameObject;

    public float RangeMin =10f;
    public float RangeMax= 150f;
    public AnimationCurve Pcur;
    public bool InvertP = false;
    public string Variable;
    private float P=0f;


    void Update()
    {
        //Get P To change variable
        GetP_DistX(AGameObject);

        //Get and Change Parameter
        gameObject.GetComponent<AudioContainer>().ManagedVars[Variable] = Pcur.Evaluate(P); 
    }

    private float GetP_DistX(GameObject x)   //Write Parameter Function Here-- Dist to X template
    {

        float distance = Vector3.Distance(x.transform.position, transform.position);
        //Debug.Log(distance);

        if (distance>RangeMin&&distance<RangeMax)
        {
            float range = (RangeMax - RangeMin);
            float inD = distance - RangeMin;
            if (InvertP == false)
            {
                P = 1 - (inD / range);
            }
            else
            {
                P = inD / range;
            }
          //  Debug.Log(P);
        }

        return P;
    }
}
