using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    public GameObject launchPoint;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
    }
    // Start is called before the first frame update
    void OnMouseEnter()
    {
        print("SlingShot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        print("SlingShot:OnMouseExit()");
        launchPoint.SetActive(false);
    }
}
