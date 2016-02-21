using UnityEngine;
using System.Collections;

public class Fence : MonoBehaviour {

    public GameObject open;
    public GameObject closed;
    public GameObject shepherd;

    public bool fenceOpen = false;

    void Update() {
        if (fenceOpen) {
            open.SetActive(true);
            closed.SetActive(false);
            GetComponent<BoxCollider2D>().isTrigger = true;
        } else {
            open.SetActive(false);
            closed.SetActive(true);
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }

	void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.name == "Shepherd") { StartCoroutine(openFence()); }
    }

    float getDistance(GameObject go1, GameObject go2)
    {
        float x = go2.transform.position.x - go1.transform.position.x;
        float y = go2.transform.position.x - go1.transform.position.x;

        return Mathf.Sqrt((x * x) + (y * y));
    }

    IEnumerator openFence()  {
        yield return new WaitForSeconds(0.5f);

        if (getDistance(this.gameObject, shepherd) < 9) {
            fenceOpen = true;
            AudioManager.instance.PlaySound2D("Fence");
        }
    }
}
