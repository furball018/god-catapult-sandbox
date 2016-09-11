using UnityEngine;
using System.Collections;

public class rotateInAir : MonoBehaviour {

    public float rotationAmount;
    private float rotation;

	// Use this for initialization
	void Start () {
	    rotationAmount = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {
        rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward * rotation * rotationAmount * -1);
	}
}
