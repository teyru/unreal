using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChanging : MonoBehaviour
{
    [SerializeField] GameObject[] Worlds;

    //Animation animation;

    public bool worldIsChanging = false;

    void Start()
    {
        Worlds[0].SetActive(true);
        Worlds[1].SetActive(false);
    }

    void Update()
    {
        ChangeWorld();
    }

    private void ChangeWorld()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Worlds[0].activeSelf)
            {
                Worlds[0].SetActive(false);
                Worlds[1].SetActive(true);
            }
            else
            {
                Worlds[1].SetActive(false);
                Worlds[0].SetActive(true);
            }
        }
    }
}
