using UnityEngine;
using System;

public class Fish_Player : Fish {
    
    public static event EventHandler<InfoEventArgs<int>> playerDeathEvent;
    public Animator fishAnim;
    [SerializeField]
    private int playerInitSize;
    Rigidbody rb;
    private bool rightFacing;


    void Start ()
    {
        setSize(playerInitSize);
        init();
        rb = GetComponent<Rigidbody>();
        rightFacing = true;
	}
	
	void FixedUpdate ()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 vel = rb.velocity;

        constrainPosition(pos, vel);
        updateAnim(vel);
        validateDirection();
        
        Debug.Log("Horizontal velocity is: " + vel.x);
    }

    /**
    <summary>
        Rotates fish between 180 and 0 depending on sign of horizontal velocity
        </summary>
    */
    private void validateDirection()
    {
        float xInput = Input.GetAxis("Horizontal");
        if (xInput < 0 && rightFacing)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rightFacing = false;
        }
        if (xInput > 0 && !rightFacing)
        {
            transform.eulerAngles = Vector3.zero;
            rightFacing = true; 
        }
    }

    /**
    <summary>
        If velocity is close to zero, sets idle animation.
        </summary>
    */
    private void updateAnim(Vector3 vel)
    {
        bool swim = Math.Abs(vel.x) + Math.Abs(vel.y) > .1;
        fishAnim.SetBool("swim", swim);
    }

    /**
    <summary>
        Checks if position is outside the screen bounds and constrains them
        </summary>
    */
    private void constrainPosition(Vector3 pos, Vector3 vel)
    {
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
