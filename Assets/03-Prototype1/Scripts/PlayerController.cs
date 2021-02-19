using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public Text countText;
    public Text winText;

    public GameObject clickHalo;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void Awake()
    {
        Transform clickHaloTrans = transform.Find("ClickHalo");
        clickHalo = clickHalo.gameObject;
        clickHalo.SetActive(false);
    }
    void OnMouseEnter()
    {
        clickHalo.SetActive(true);
    }
    void OnMouseExit()
    {
        clickHalo.SetActive(false);
    }

    void OnCollisionEnter(Collision coll)
    {
        // find how what hit player
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Missile")
        {
            Destroy(collidedWith);

            count = count - 1;
            SetCountText();

            // parse text of score board
            // int score = int.Parse(countText.text);
            // minus points for collision with missile
            //score -= 1;
            // convert score back to a string a display
            // countText.text = score.ToString();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
