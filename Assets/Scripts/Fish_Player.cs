using UnityEngine;
using System;

public class Fish_Player : Fish {
    
    public static event EventHandler<InfoEventArgs<int>> playerDeathEvent;
    public Animator fishAnim;
    [SerializeField, Range(1,1000)]
    private int playerInitSize;
    [SerializeField, Range (100, 1000)]
    int colorChanger;
    private bool rightFacing;


    void Start () 
    {
        setSize(playerInitSize);
        init();
        rightFacing = true;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        Vector3 pos = gameObject.transform.position;
        Vector3 vel = rb.velocity;

        constrainPosition(pos, vel);
        updateAnim(vel);
        validateDirection();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fish"))
            eat(other.gameObject.GetComponent<Fish>());
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
        if (pos.x > 7f)
        {
            pos.x = -7f;
            gameObject.transform.position = pos;
        }
        else if (pos.x < -7f)
        {
            pos.x = 7f;
            gameObject.transform.position = pos;
        }

        /*
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
        */
    }

    public override void eat(Fish other)
    {
        Debug.Log("Player size: " + size + "\nOther size: " + other.size);
        other.eat(this);
        if (_size <= other.size)
        {
//            playerDeathEvent(this, new InfoEventArgs<int>(_size));
//            GameObject.Destroy(this.gameObject);
        } else
        {
            _size += 5;
            setSize(_size);
            if (size < 500)
                mat.material.color = smallColor * (size * .003f + .25f);
            else
                mat.material.color = mediumColor * (size * .0024f - .2f);
        }
    }
}
