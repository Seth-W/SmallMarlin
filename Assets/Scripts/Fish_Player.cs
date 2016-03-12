using UnityEngine;
using System;

public class Fish_Player : Fish {
    
    public static event EventHandler<InfoEventArgs<int>> playerDeathEvent;
    public Animator fishAnim;
    [SerializeField]
    private int playerInitSize;
    Rigidbody rb;


    void Start ()
    {
        setSize(playerInitSize);
        init();
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate ()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 vel = rb.velocity;
        if (pos.x > 9.5f)
        {
            pos.x = -9.5f;
            gameObject.transform.position = pos;
        }
        else if (pos.x < -9.5f)
        {
            pos.x = 9.5f;
            gameObject.transform.position = pos;
        }
        
        if (pos.y > 4.75)
        {
            pos.y = 4.750f;
            gameObject.transform.position = pos;
            vel.y = 0;
            rb.velocity = vel;
            
        }
        else if (pos.y < -4.8)
        {
            pos.y = -4.800f;
            gameObject.transform.position = pos;
            vel.y = 0;
            rb.velocity = vel;
        }
        bool swim = Math.Abs(vel.x) + Math.Abs(vel.y) > .1;
        fishAnim.SetBool("swim", swim);
    }
    protected override void eat(Fish other)
    {
        if (_size <= other.size)
        {
            playerDeathEvent(this, new InfoEventArgs<int>(_size));
            GameObject.Destroy(this);
        } else
        {
            _size += other.size;
        }
    }
}
