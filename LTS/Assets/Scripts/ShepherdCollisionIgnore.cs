using UnityEngine;
using System.Collections;

public class ShepherdCollisionIgnore : MonoBehaviour {

    public int ignoreLayerShepherd;
    public int ignoreLayerRocks;

    // Use this for initialization
    void Start () {
        Physics2D.IgnoreLayerCollision(ignoreLayerRocks, ignoreLayerShepherd);
	}
}
