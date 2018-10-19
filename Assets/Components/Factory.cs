using UnityEngine;

public class Factory : MonoBehaviour {
    // Advice: FYFY component aims to contain only public members (according to Entity-Component-System paradigm).

    public float reloadTime = 2f;
    public float reloadProgress = 0f;

    public GameObject prefab;
}