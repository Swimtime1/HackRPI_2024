using UnityEngine;

public class Intersection : MonoBehaviour {

    public GameObject playerCar;

    public GameObject npcCar;
    private bool npcCarGoesFirst;

    // Start is called before the first frame update
    void Start() {

        npcCarGoesFirst = (Random.Range(0, 1) == 0) ? true : false;
        if(npcCarGoesFirst) {
        }
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.gameActive) {
            npcCar.transform.Translate(10, 0, 0);
        }
    }
}
