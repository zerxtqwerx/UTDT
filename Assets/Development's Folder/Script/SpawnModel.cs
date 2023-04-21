using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModel : MonoBehaviour
{
    public GameObject model;
    public GameObject characterOrientation;
    private object instRes;

    public float points, edges, polygons;

    public Count count;

    public void Spawn_Model()
    {
        instRes = Instantiate(model, characterOrientation.transform.position + characterOrientation.transform.forward, Quaternion.identity);
    }

    public void GiveData()
    {
        count.GlobalPoints += points;
        count.GlobalEdges += edges;
        count.GlobalPolygons += polygons;
        count.GlobalAmount += 1;
    }
}
