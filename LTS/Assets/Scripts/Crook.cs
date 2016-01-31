using UnityEngine;
using System.Collections;

public class Crook : MonoBehaviour {

    public Animator m_Anim;            // Reference to the player's animator component.
    public GameObject sheep;

    public int frames = 0;
    public int frames2 = 0;

    void Update() {
        frames++;
        frames2++;
        if (frames > 100 && Input.GetKey(KeyCode.RightControl))
        {
            m_Anim.SetBool("Crook", true);
            frames = 0;
        }
        
        //Debug.Log(getDistance(this.gameObject, sheep));

        if (getDistance(this.gameObject, sheep) < 6 && m_Anim.GetBool("Crook")) {

            Vector2 force = new Vector2();
            force.x = 15;
            force.y = 1;

            if (GetComponent<SpriteRenderer>().flipX) { force.x *= -1; }


            StartCoroutine(waitThenFling(force));
        }

    }

    IEnumerator waitThenFling(Vector2 force)
    {
        yield return new WaitForSeconds(1.5f);
        if (frames2 > 100) {
            AudioManager.instance.PlaySound2D("Sheep Hurt");
            frames2 = 0;
            AudioManager.instance.PlaySound2D("Shepherd Attack");
        }
        sheep.GetComponent<Rigidbody2D>().velocity = force;
        m_Anim.SetBool("Crook", false);
    }

    float getDistance(GameObject go1, GameObject go2)
    {
        float x = go2.transform.position.x - go1.transform.position.x;
        float y = go2.transform.position.x - go1.transform.position.x;

        return Mathf.Sqrt((x * x) + (y * y));
    }
}
