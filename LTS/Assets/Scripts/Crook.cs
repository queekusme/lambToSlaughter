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

        if (frames > 100) { m_Anim.SetBool("Crook", false); }
        if (frames > 100 && Input.GetKey(KeyCode.RightControl))
        {
            m_Anim.SetBool("Crook", true);
            frames = 0;
        }
        
        //Debug.Log(getDistance(this.gameObject, sheep));

        if (getDistance(this.gameObject, sheep) < 6 && m_Anim.GetBool("Crook")) {

            Vector2 force = new Vector2();
            force.x = 5;
            force.y = 2.5f;

            if (GetComponent<SpriteRenderer>().flipX) { force.x *= -1; }
            
            StartCoroutine(waitThenFling(force));
        }

    }

    IEnumerator setACTrue() {
        while (!sheep.GetComponent<PlatformerCharacter2D>().m_Anim.GetBool("Ground")) { yield return new WaitForEndOfFrame(); }
        sheep.GetComponent<PlatformerCharacter2D>().m_AirControl = true;
    }

    IEnumerator waitThenFling(Vector2 force)
    {
        yield return new WaitForSeconds(1.5f);
        if (frames2 > 100) {
            AudioManager.instance.PlaySound2D("Sheep Hurt");
            frames2 = 0;
            AudioManager.instance.PlaySound2D("Shepherd Attack");
        }
        bool ac = sheep.GetComponent<PlatformerCharacter2D>().m_AirControl;

        sheep.GetComponent<PlatformerCharacter2D>().m_AirControl = false;
        sheep.GetComponent<Rigidbody2D>().velocity = force;
        if (ac)  {
            StartCoroutine(setACTrue());
        }

        m_Anim.SetBool("Crook", false);
    }

    float getDistance(GameObject go1, GameObject go2)
    {
        float x = go2.transform.position.x - go1.transform.position.x;
        float y = go2.transform.position.x - go1.transform.position.x;

        return Mathf.Sqrt((x * x) + (y * y));
    }
}
