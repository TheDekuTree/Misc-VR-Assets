using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAction : MonoBehaviour
{
    Color c;
    public GameObject projectorLight;
    private void Start()
    {
        c = gameObject.GetComponent<MeshRenderer>().material.color;
    }
    public void click()
    {
        projectorLight.SetActive(!projectorLight.activeInHierarchy);
    }
    public void enterHover ()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(c.r, c.g, c.b + 1);
    }
    public void exitHover ()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(c.r, c.g, c.b);
    }
}
