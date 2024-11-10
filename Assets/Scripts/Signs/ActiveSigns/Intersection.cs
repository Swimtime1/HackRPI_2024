using UnityEngine;

public class Intersection : MonoBehaviour {

    public GameObject playerCar;

    public GameObject npcCar;
    private bool npcCarGoesFirst;
    private bool playerCanPass = false;

    // Start is called before the first frame update
    void Start() {

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
