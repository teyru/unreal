    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPlatform : MonoBehaviour
{
    public bool checkComplete = false;

    private void OnTriggerStay(Collider other)
    {
        print(other.GetComponent<Renderer>().material.name);
        print(gameObject.GetComponent<Renderer>().material.name);
        if (gameObject.GetComponent<Renderer>().material.name == other.GetComponent<Renderer>().material.name)
        {
            checkComplete = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (gameObject.GetComponent<Renderer>().material != other.GetComponent<Renderer>().material || other == null)
        {
            checkComplete = false;
        }
    }
}
