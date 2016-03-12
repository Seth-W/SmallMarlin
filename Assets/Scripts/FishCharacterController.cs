using UnityEngine;
using System.Collections;

public class FishCharacterController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField, Range(1,20)]
    private float scalar;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(scalar * checkInput());
    }

    Vector3 checkInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        return new Vector3(x, y, 0);
    }

}