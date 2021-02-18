using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Set in Inspctor")]
    public GameObject prefabProjectile;

    [Header("Set Dynamically")]
    public GameObject playerLaunch;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;
    

    void Awake()
    {
        Transform playerLaunchTrans = transform.Find("PlayerLaunch");
        playerLaunch = playerLaunchTrans.gameObject;
        playerLaunch.SetActive(false);
        launchPos = playerLaunchTrans.position;
    }

    void OnMouseEnter()
    {
        print("Shooter:OnMouseEnter()");
        playerLaunch.SetActive(true);
    }

    // Update is called once per frame
    void OnMouseExit()
    {
        print("Shooter:OnMouseExit()");
        playerLaunch.SetActive(false);
    }

    void OnMouseDown()
    {
        // player has pressed mouse while over shooter
        aimingMode = true;
        // instantiate projectile
        projectile = Instantiate(prefabProjectile) as GameObject;
        // start at launchpoint
        projectile.transform.position = launchPos;
        // set it to iskinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
