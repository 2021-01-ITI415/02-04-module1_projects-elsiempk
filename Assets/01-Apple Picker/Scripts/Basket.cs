using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        // Find reference to ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // get GUIText component of GameObject
        scoreGT = scoreGO.GetComponent<Text>();
        // Set starting number of points to be 0 
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        // Get screen position of the mouse 
        Vector3 mousePos2D = Input.mousePosition;

        // Get camera position - sees how far to push the mouse
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move x position of the basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find what hits the basket
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // Add points for catching an apple
            score += 100;
            scoreGT.text = score.ToString();
            if (score > HighScore.score)
                HighScore.score = score;
        }
    }
}
