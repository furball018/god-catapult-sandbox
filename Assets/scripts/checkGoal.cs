using UnityEngine;
using System.Collections;

public class checkGoal : MonoBehaviour {

    private CircleCollider2D[] cols;
    private int triggers = 0;
    private bool triggered = false;
    public GameObject part;
    public GameObject fill;
    public string pieceWanted;
    private GameObject piece;
    private GameObject lm;

    // Use this for initialization
    void Start ()
    {
        cols = GetComponents<CircleCollider2D>();
        lm = GameObject.FindWithTag("LevelManager");
        Debug.Log(lm);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(triggers == cols.Length && !triggered && pieceWanted == piece.GetComponent<ProjectileDragging>().pieceForm)
        {
            triggered = true;
            Instantiate(part, transform.position, transform.rotation);
            Destroy(piece);
            fill.SetActive(true);
            lm.GetComponent<LevelManagerScript>().nextPieceDelayed();
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
