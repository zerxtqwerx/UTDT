using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCSpawnModel : MonoBehaviour
{
    public GameObject model;

    public GameObject characterOrientation;

    public KeyCode spawnKey;

    private object instRes;

    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            Spawn_Model(model);
        }
    }

    public void Spawn_Model(GameObject model)
    {
        instRes = Instantiate(model, characterOrientation.transform.position + characterOrientation.transform.forward, characterOrientation.transform.rotation);
    }
}
