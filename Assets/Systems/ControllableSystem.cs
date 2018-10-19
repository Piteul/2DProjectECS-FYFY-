using UnityEngine;
using FYFY;

public class ControllableSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.

    //Construction d'une famille incluant tous les GO contenant le composant Move
    private Family _controllableGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move)), new NoneOfComponents(typeof(RandomTarget)));
    protected override void onPause(int currentFrame) {

    }

    // Use this to update member variables when system resume.
    // Advice: avoid to update your families inside this function.
    protected override void onResume(int currentFrame) {


    }

    // Use to process your families.
    protected override void onProcess(int familiesUpdateCount) {
        foreach (GameObject go in _controllableGO) {
            Transform tr = go.GetComponent<Transform>();
            Move mv = go.GetComponent<Move>();

            Vector3 movement = Vector3.zero;


            if (Input.GetKey(KeyCode.LeftArrow) == true) {
                movement += Vector3.left;
            }
            if (Input.GetKey(KeyCode.RightArrow) == true) {
                movement += Vector3.right;
            }
            if (Input.GetKey(KeyCode.UpArrow) == true) {
                movement += Vector3.up;
            }
            if (Input.GetKey(KeyCode.DownArrow) == true) {
                movement += Vector3.down;
            }

            //transform.position += movement * speed * Time.deltaTime;


            go.GetComponent<Rigidbody2D>().MovePosition(go.transform.position + movement * mv.speed * Time.deltaTime);
        }

    }
}