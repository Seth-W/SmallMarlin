using UnityEngine;
using System;

public class Fish_Player : Fish {

    public static event EventHandler<InfoEventArgs<int>> playerDeathEvent;

	// Use this for initialization
	void Start ()
    {
        setSize(100);
        init();
	}
	
	// Update is called once per frame
	void Update () {
	
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
