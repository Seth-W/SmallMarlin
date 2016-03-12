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
    [SerializeField]
    public int RandomSeed = 42;

    private Vector3 SCALE = new Vector3(3, 3, 3);

	void Start ()
    {
        UnityEngine.Random.seed = RandomSeed;
//        setSize( (int)(UnityEngine.Random.value * 500f) );
        Debug.Log("Size initiated to " + _size);
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
    }

    protected void setSize(int i)
    {
        _size = i;
    }
    protected void init()
    {
        transform.localScale = SCALE * _size * .01f;
        float input = UnityEngine.Random.value;
        Debug.Log("The random value is " + input + ". And the speed weight is " + input * .6f + .4f);
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
            Debug.Log(_speedWeight);
            _speedWeight = .1f;
            Debug.Log(this + "Case 1");
        }
        if (_speedWeight > -.1 && _speedWeight < 0)
        {
            _speedWeight = .1f;
            Debug.Log(this + "Case 2");
        }
    }

    protected virtual void eat(Fish other)
    {
        if (_size <= other.size)
        {
            fishDeathEvent(this, new InfoEventArgs<int>(_size));
            GameObject.Destroy(this);
        }
    }

    public void spawnedOnLeft(bool left)
    { }

}
