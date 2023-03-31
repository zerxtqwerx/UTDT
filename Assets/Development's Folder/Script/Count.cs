using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Text textPEPC;

    public float GlobalPoints = 0;
    public float GlobalEdges = 0;
    public float GlobalPolygons = 0;
    public float GlobalAmount = 0;

    void Start()
    {
        textPEPC.text = "Points = " + GlobalPoints + "\n" + "Edges = " + GlobalEdges + "\n" + "Polygons = " + GlobalPolygons + "\n" + "Amount = " + GlobalAmount;
    }

    void Update()
    {
        textPEPC.text = "Points = " + GlobalPoints + "\n" + "Edges = " + GlobalEdges + "\n" + "Polygons = " + GlobalPolygons + "\n" + "Amount = " + GlobalAmount;
    }
}