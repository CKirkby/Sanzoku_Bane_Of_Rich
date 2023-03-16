using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject thisSelectedObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;

    // Update is called once per frame
    void Update()
    {
        if(lookingAtObject == true)
        {
            thisSelectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }

    //When mouse goes over the object selected will be called.
    void OnMouseOver()
    {
        thisSelectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if(startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
            Debug.Log(CastingToObject.selectedObject);
        }
    }

    //Sets material back to normal on mouse exit
    void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        thisSelectedObject.GetComponent<Renderer>().material.color = new Color32(150, 150, 150, 255);
    }

    IEnumerator FlashObject()
    {
        while(lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.05f);
            if(flashingIn == true)
            {
                if(blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    redCol -= 15;
                    greenCol -= 15;
                }
            }

            if(flashingIn == false)
            {
                if (blueCol >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    redCol += 15;
                    greenCol += 15;
                }
            }
        }
    }
}
