using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{

     [SerializeField] public GameObject[] chekPlates;
    private int countOfPlates;

    void Update()
    {
        for(int i = 0; i<chekPlates.Length; i++)
        {
            if (chekPlates[i].GetComponent<ChekPlatform>().checkComplete)
            {
                countOfPlates++;
            }
            else
            {
                countOfPlates = 0;
                break;
            }
        }

        if(countOfPlates == chekPlates.Length)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
