using UnityEngine;

public class Intersection : MonoBehaviour {

    public GameObject playerCar;

    public GameObject npcCar;
    private bool npcCarGoesFirst;

    // Start is called before the first frame update
    void Start() {

        npcCarGoesFirst = true;
        //(Random.Range(0, 1) == 0) ? true : false;
        if(npcCarGoesFirst) {

            npcCar.GetComponent<Animation>().Play("topDownNpcCar");
        }
    }

    // Update is called once per frame
    void Update() {
        if(GameManager.gameActive) {
            playerCar.transform.Translate(1 * Time.deltaTime, 0, 0);
        }
    }
}
