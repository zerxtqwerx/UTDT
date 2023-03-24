using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModel : MonoBehaviour
{
    public GameObject model;
    public GameObject character;
    private object instRes;

    public float points, faces, polygons;

    public void Spawn_Model()
    {
        instRes = Instantiate(model, character.transform.position + Vector3.forward, Quaternion.identity);
    }



}
