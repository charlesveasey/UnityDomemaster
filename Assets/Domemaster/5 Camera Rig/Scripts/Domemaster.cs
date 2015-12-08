using UnityEngine;
using System.Collections;

/***************************************************************
* Domemaster
* This class moves the domemaster prefab (most likely) offscreen
* to avoid seeing itself. Alternatively you can set it on it's 
* own rendering layer.
/***************************************************************/
public class Domemaster : MonoBehaviour {

    private int position = 25000;

    void Start () {
        transform.position = new Vector3(position, -position, position);
    }

}
