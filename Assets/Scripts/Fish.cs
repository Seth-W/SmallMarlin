using UnityEngine;
using System;
using UnityEngine.UI;

public class Fish : MonoBehaviour {

    public static event EventHandler<InfoEventArgs<int>> fishDeathEvent;
    [SerializeField]
    protected SkinnedMeshRenderer mat;
    protected Rigidbody rb;

    [SerializeField]
    protected Color smallColor;
    [SerializeField]
    protected Color mediumColor;
    [SerializeField]
    private Color bigColor;
    [SerializeField]
    protected int _size;
    public int size
    { get {return _size; } }

    [SerializeField]
    private float speedValue;
    [SerializeField, Range(0,1)]
    private float _speedWeight;


    private Vector3 SCALE = new Vector3(3, 3, 3);
    private float OUT_OF_BOUNDS = 9;

	void Start ()
    {
        float multiple = UnityEngine.Random.value < .75 ? 300f : 500f;
        setSize( (int)(UnityEngine.Random.value * multiple) );
        init();
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            Debug.Log("Rigidbody not found");
    }

    void Update ()
    {
	
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector3(1, 0, 0) * speedValue * _speedWeight;
        if (Mathf.Abs(transform.position.x) > OUT_OF_BOUNDS)
            GameObject.Destroy(this.gameObject);
    }



    protected void setSize(int i)
    {
        _size = i;
        transform.localScale = SCALE * _size * .01f;
    }
    protected void init()
    {
        float input = UnityEngine.Random.value;
//        Debug.Log("The random value is " + input + ". And the speed weight is " + input * .6f + .4f);
        if (size < 50)
        {
            mat.material.color = smallColor * (size * .0012f + .4f);
            _speedWeight *= (input * .6f) + .4f;      //Returns a range from .4 - 1 for small fish
        } else if (size < 250)
        {
            mat.material.color = mediumColor * (size * .003f + .25f);
            _speedWeight *= (input);                  //Returns a range from 0-1 for medium fish
        } else
        {
            mat.material.color = bigColor * (size * .0024f - .2f);
            _speedWeight *= (input * .5f);          //Returns a range from 0-.5 for large fish
        }
        if (_speedWeight < .1 && _speedWeight >= 0)
        {
            _speedWeight = .1f;
        }
        if (_speedWeight > -.1 && _speedWeight < 0)
        {
            _speedWeight = -.1f;
        }
        Vector3 pos = transform.position;
        pos.z = Mathf.Abs(_speedWeight) * 5;
        transform.position = pos;
    }

    public virtual void eat(Fish other)
    {
        if (_size <= other.size)
        {
            fishDeathEvent(this, new InfoEventArgs<int>(_size));
            GameObject.Destroy(this.gameObject);
        }
    }

    public void spawnedOnLeft(bool left)
    {
        if (left)
        {
            _speedWeight *= 1;
            //            transform.rotation = new Quaternion(0, 1, 0, 0.52532198881f);
            transform.rotation = new Quaternion(0, 1, 0, 1f);
        }
        else
        {
            _speedWeight *= -1;
            //            transform.rotation = new Quaternion(0, 1, 0, -0.99608783514f);
            transform.rotation = new Quaternion(0, 1, 0, -1f);
        }
    }

}
