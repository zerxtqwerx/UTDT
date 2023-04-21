using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCSpawnModel : MonoBehaviour
{
    public GameObject model;

    public GameObject characterOrientation;

    public KeyCode spawnKey;

    private object instRes;

    public float points, edges, polygons;

    public Count count;

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
        GiveData();
    }

    public void GiveData()
    {
        count.GlobalPoints += points;
        count.GlobalEdges += edges;
        count.GlobalPolygons += polygons;
        count.GlobalAmount += 1;
    }
}
