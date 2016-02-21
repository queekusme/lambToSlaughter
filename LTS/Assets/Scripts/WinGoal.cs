using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinGoal : MonoBehaviour {

    public enum Winner { Sheep, Shepherd };

    public GameObject target;

    public GameObject other;

    public GameObject targetRespawn;
    public GameObject otherRespawn;

    public Winner winner;

    public ScoreManager scoreManager;

    public Fence fence1;
    public Fence fence2;
    public Fence fence3;
    public Fence fence4;
    public Fence fence5;

    void OnTriggerEnter2D(Collider2D c) {
        if (c.gameObject.name.Equals(target.name)) {
            target.transform.position = targetRespawn.transform.position;
            other.transform.position = otherRespawn.transform.position;
            switch (winner) {
                case Winner.Sheep: scoreManager.sheep++; break;
                case Winner.Shepherd: scoreManager.shepherd++; break;
            }

            fence1.fenceOpen = false;
            fence2.fenceOpen = false;
            fence3.fenceOpen = false;
            fence4.fenceOpen = false;
            fence5.fenceOpen = false;
        }
    }

}
