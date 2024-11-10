using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour {

    public GameObject playerCar;

    public GameObject npcCar;
    private bool npcCarGoesFirst;
    private bool playerCanPass = false;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        npcCarGoesFirst = Random.Range(0, 1) == 0;
        if(npcCarGoesFirst) {
            npcCar.GetComponent<Animation>().Play("topDownNpcCar");
        } else {
            SpriteRenderer npcCarSprite = npcCar.GetComponent<SpriteRenderer>();
            npcCarSprite.sprite = null;
            playerCanPass = true;
        }
    }

    // Update is called once per frame
    void Update() {
        if(boxCollider.OverlapCollider(new ContactFilter2D().NoFilter(), new List<Collider2D>()) == 1) {
            Debug.Log("TRIGGER");
        }
        if(GameManager.gameActive) {
            playerCar.transform.Translate(1 * Time.deltaTime, 0, 0);
        }
    }

    void allowPlayerToPass() {
        playerCanPass = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(true) { Debug.Log("TRIGGER"); }
    }
}
