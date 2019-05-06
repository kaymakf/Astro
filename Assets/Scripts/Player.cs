using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 10f;
    public Transform cameraTr;
    public GameObject GameOverPanel;
	Rigidbody2D rb;
    public Text scoreboard;
    GameObject dontFall;
    public LevelGenerator lg;

    public static int score;

	float movement = 0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (Input.GetButtonDown("right"))
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else if (Input.GetButtonDown("left"))
            transform.eulerAngles = new Vector3(0f, 180f, 0f);

        score = (int)(cameraTr.position.y / 2.9f) - 1;
        scoreboard.text = (score>=0) ? score.ToString() : "0";
        if (score % (lg.numberOfPlatforms / lg.platformPrefab.Length) == 1 & score > 1)
            scoreboard.text = score + "  NEW PLANET";
    }

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "GameOver")
        {
            GameOverPanel.SetActive(true);
        }

    }

}
