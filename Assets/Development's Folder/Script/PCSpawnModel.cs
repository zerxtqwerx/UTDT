using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCSpawnModel : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public GameObject model3;
    public GameObject model4;

    public GameObject character;
    private object instRes;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Spawn_Model(model1);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            Spawn_Model(model2);
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            Spawn_Model(model3);
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            Spawn_Model(model4);
        }
    }

    public void Spawn_Model(GameObject model)
    {
        instRes = Instantiate(model, character.transform.position + Vector3.forward, Quaternion.identity);
    }
}
