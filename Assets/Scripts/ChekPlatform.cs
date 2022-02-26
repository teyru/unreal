    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPlatform : MonoBehaviour
{
    public bool checkComplete = false;

    private void OnTriggerStay(Collider other)
    {
        if(gameObject.GetComponent<Renderer>().material.name == other.gameObject.GetComponent<Renderer>().material.name)
        {
            checkComplete = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.GetComponent<Renderer>().material != other.gameObject.GetComponent<Renderer>().material || other == null)
        {
            checkComplete = false;
        }
    }
}
