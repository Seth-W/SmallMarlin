using UnityEngine;
using System.Collections;

public class FishAnimController : MonoBehaviour
{

    private Animator _anim;
    public Animator anim { get { return _anim; } }

	void Start ()
    {
        _anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
	
	}
}
