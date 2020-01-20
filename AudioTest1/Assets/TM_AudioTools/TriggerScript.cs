using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool AttachedToParent = false;
    public GameObject TargetOBJ;
    public string Specific_Collider;

    private void Start()
    {
        if (AttachedToParent==true)
        {
            TargetOBJ = transform.parent.gameObject;

        }
        gameObject.AddComponent<BoxCollider>().isTrigger = true;
        

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name==Specific_Collider)
        {
            SetActive();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Specific_Collider)
        {
            SetInactive();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.localScale );
    }

    void SetActive()
    {
        try
        {
            TargetOBJ.GetComponent<AudioContainer>().Active = true;
            TargetOBJ.GetComponent<AudioContainer>().stop = false;
        }
        catch (Exception e)
        {
            Debug.Log("TargetObject is Probably Lacking AudioContainer: "+e, this);
        }
    }
    void SetInactive()
    {
        try
        {
            TargetOBJ.GetComponent<AudioContainer>().stop = true;
        }
        catch (Exception e)
        {
            Debug.Log("TargetObject is Probably Lacking AudioContainer: " + e, this);
        }
    }
}
