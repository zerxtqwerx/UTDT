using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModel : MonoBehaviour
{
    public GameObject model;
    public GameObject character;
    private object instRes;

    public float points, edges, polygons;

    public Count count;

    public void Spawn_Model()
    {
        instRes = Instantiate(model, character.transform.position + character.transform.forward, Quaternion.identity);
    }

    public void GiveData()
    {
        count.GlobalPoints += points;
        count.GlobalEdges += edges;
        count.GlobalPolygons += polygons;
        count.GlobalAmount += 1;
    }
}
