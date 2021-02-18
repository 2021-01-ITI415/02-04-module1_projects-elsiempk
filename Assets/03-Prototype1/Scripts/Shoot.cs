using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

  public GameObject playerLaunch;
    
  void Awake()
    {
        Transform playerLaunchTrans = transform.Find("PlayerLaunch");
        playerLaunch = playerLaunchTrans.gameObject;
        playerLaunch.SetActive(false);
    }

  void OnMouseEnter()
    {
        print("Shoot:OnMouseEnter()");
        playerLaunch.SetActive(true);
    }
    void OnMouseExit()
    {
        print("Shoot:OnMouseExit()");
        playerLaunch.SetActive(false);
    }
}
