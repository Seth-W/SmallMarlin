using UnityEngine;
using System;

public class Fish_Player : Fish {
    public int playerInitSize;
    public static event EventHandler<InfoEventArgs<int>> playerDeathEvent;
    Rigidbody rb;
	// Use this for initialization
	void Start ()
    {
        setSize(playerInitSize);
        init();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 vel = rb.velocity;
        if (pos.x > 10)
        {
            pos.x = -10;
            gameObject.transform.position = pos;
        }
        else if (pos.x < -10)
        {
            pos.x = 10;
            gameObject.transform.position = pos;
        }
        
        if (pos.y > 4.85)
        {
            pos.y = 4.850f;
            gameObject.transform.position = pos;
            vel.y = 0;
            rb.velocity = vel;
            
        }
        else if (pos.y < -4.85)
        {
            pos.y = -4.850f;
            gameObject.transform.position = pos;
            vel.y = 0;
            rb.velocity = vel;
        }

    }
    protected override void eat(Fish other)
    {
        if (_size <= other.size)
        {
            playerDeathEvent(this, new InfoEventArgs<int>(_size));
            GameObject.Destroy(this);
        }
    }
}
