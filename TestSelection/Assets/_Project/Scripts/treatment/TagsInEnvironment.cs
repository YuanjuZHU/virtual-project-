﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TagsInEnvironment : MonoBehaviour
{
    private ReadJson readJson;
    private List<GameObject> tags = new List<GameObject>();
    private Image imageTags;
    private Text hideDisplayTags;

    // Start is called before the first frame update
    void Start()
    {
        readJson = GameObject.Find("Selection Manager").GetComponent<ReadJson>();

        imageTags = GameObject.Find("Hide/show tags").GetComponent<Image>();
        hideDisplayTags = GameObject.Find("Hide/show tags").transform.Find("Text").GetComponent<Text>();
        imageTags.color = new Color(0f, 0.6f, 1f, 1f);


    }

    private Vector3 FindBarycenter(List<int> cageVerticesIndex)
    {
        Vector3 baryCenter = new Vector3();
        for (int i = 0; i < cageVerticesIndex.Count; i++)
        {
            baryCenter += readJson.cageVertices[cageVerticesIndex[i]];
        }
        baryCenter /= cageVerticesIndex.Count;
        return (baryCenter);
    }

    // Update is called once per frame
    void Update()
    {

        if (readJson.levelChange)
        {
            foreach (var VARIABLE in tags)
            {
                Destroy(VARIABLE);
            }
            tags.Clear();
            for (int i = 0; i < readJson.treeNodeLevelx.Count; i++)
            {

                var theText = new GameObject();
                tags.Add(theText);
                var textMesh = theText.AddComponent<TextMesh>();

                // do some settings here that are needed in the component
                // set the text
                textMesh.text = readJson.treeNodeLevelx[i].GetData().tag;
                var colorSegment= new Color(readJson.treeNodeLevelx[i].GetData().color[0], readJson.treeNodeLevelx[i].GetData().color[1], readJson.treeNodeLevelx[i].GetData().color[2], 255);
                textMesh.color = Complementary(colorSegment);
                textMesh.fontSize = 89;
                textMesh.anchor = TextAnchor.MiddleCenter;
                theText.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
                theText.transform.position = FindBarycenter(readJson.treeNodeLevelx[i].GetData().cageVerticesIndex); ;
                theText.name = "Segment tag";
                theText.SetActive(false);

            }

        }

        foreach (var VARIABLE in tags)
        {
            VARIABLE.transform.rotation = Camera.main.transform.rotation;
        }
        
    }

    private Color Complementary(Color color)
    {
        Color complementaryColor=new Color();

        complementaryColor = new Color(255 - color.r, 255 - color.g, 255 - color.b, 255)/255;

        return (complementaryColor);
    }

    public void HideTags()
   {

       foreach (var VARIABLE in tags)
       {
           if (VARIABLE.activeSelf)
           {
               VARIABLE.SetActive(false);
               imageTags.color =  new Color(0f, 0.6f, 1f, 1f);
                hideDisplayTags.text = "Display tags";
           }

           else
           {
               VARIABLE.SetActive(true);
               imageTags.color = new Color(0f, 1f, 0.6f, 1f);
                hideDisplayTags.text = "Hide tags";
           }
       }

   }

}