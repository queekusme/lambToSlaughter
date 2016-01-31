using UnityEngine;
using System.Collections;

public class WinGoal : MonoBehaviour {

    public enum Winner { Sheep, Shepherd };

    public GameObject target;

    public GameObject other;

    public GameObject targetRespawn;
    public GameObject otherRespawn;

    public Winner winner;

    public ScoreManager scoreManager;

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.name.Equals(target.name)) {
            target.transform.position = targetRespawn.transform.position;
            other.transform.position = otherRespawn.transform.position;
            switch (winner) {
                case Winner.Sheep: scoreManager.sheep++; break;
                case Winner.Shepherd: scoreManager.shepherd++; break;
            }
        }
    }

}
