using UnityEngine;
using System;

public class Fish : MonoBehaviour {

    public static event EventHandler<InfoEventArgs<int>> fishDeathEvent;

    protected int _size;
    public int size
    { get {return _size; } }

    private Vector3 SCALE = new Vector3(1, 1, 1);

	void Start ()
    {
        setSize(Mathf.CeilToInt(UnityEngine.Random.Range(0, 1) * 300));
    }
	
	void Update ()
    {
	
	}

    protected void setSize(int i)
    {
        _size = i;
    }
    protected void init()
    {
        transform.localScale = SCALE * _size * .01f;
    }

    protected virtual void eat(Fish other)
    {
        if (_size <= other.size)
        {
            fishDeathEvent(this, new InfoEventArgs<int>(_size));
            GameObject.Destroy(this);
        }
    }

}
