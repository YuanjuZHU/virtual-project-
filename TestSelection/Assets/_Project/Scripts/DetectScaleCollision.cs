﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectScaleCollision : MonoBehaviour
{
    public MeshCreateControlPoints meshCreateControlPoints;
    public float K;
    public bool colHappen;
    void Start()
    {
        meshCreateControlPoints = GameObject.Find("Selection Manager").GetComponent<MeshCreateControlPoints>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision !!!!!!");
        //K = meshCreateControlPoints.scale;
        //meshCreateControlPoints.collision = true; 
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exit  !!!!!!");
        //K = meshCreateControlPoints.scaleRatio;
        //meshCreateControlPoints.collision = false;
    }

}
