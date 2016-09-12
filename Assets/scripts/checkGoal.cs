using UnityEngine;
using System.Collections;

public class checkGoal : MonoBehaviour {

    private CircleCollider2D[] cols;
    private int triggers = 0;
    private bool triggered = false;
    public GameObject part;
    public GameObject fill;
    private GameObject piece;

    // Use this for initialization
    void Start ()
    {
        cols = GetComponents<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(triggers == cols.Length && !triggered)
        {
            triggered = true;
            Instantiate(part, transform.position, transform.rotation);
            Destroy(piece);
            fill.SetActive(true);
        }
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        triggers++;
        piece = other.gameObject;
    }

    void OnTriggerExit2D ()
    {
        triggers--;
    }
}
