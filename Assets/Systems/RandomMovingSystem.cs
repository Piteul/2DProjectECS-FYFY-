using UnityEngine;
using FYFY;

public class RandomMovingSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    //Construction d'une famille incluant tous les GO contenant le composant Move et RandomTarget
    private Family _randomMovingeGO = FamilyManager.getFamily(new AllOfComponents(typeof(Move), typeof(RandomTarget)));

    //Constructeur

    public RandomMovingSystem() {
        //Initialisation des GO inclut dans la famille, au démarrage système

        foreach (GameObject go in _randomMovingeGO) {
            onGOEnter(go);
        }

        //Def d'une callback sur l'entrée d'un GO, dans la famille pour l'initialiser en conséquence
        _randomMovingeGO.addEntryCallback(onGOEnter);
    }

    private void onGOEnter(GameObject go) {
        //Récupération des composants du GO courant
        Transform tr = go.GetComponent<Transform>();
        RandomTarget rt = go.GetComponent<RandomTarget>();
        //Init de sa cible à sa position
        rt.target = tr.position;
    }


    protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        //Parcours des GO inclus dans la famille 
        foreach (GameObject go in _randomMovingeGO) {
            //récupération des composants du GO courant
            Transform tr = go.GetComponent<Transform>();
            Move mv = go.GetComponent<Move>();
            RandomTarget rt = go.GetComponent<RandomTarget>();

            //Vérification si le GO est arrivé à destination
            if (rt.target.Equals(tr.position)) {

                //random vers une nouvelle destination
                rt.target = new Vector3((Random.value - 0.5f) * 7, (Random.value - 0.5f) * 5.2f);
            }
            else {
                //progression vers la destination
                tr.position = Vector3.MoveTowards(tr.position, rt.target, mv.speed * Time.deltaTime);
            }

        }
    }
}