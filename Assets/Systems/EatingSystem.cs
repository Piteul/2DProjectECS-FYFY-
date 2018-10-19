using UnityEngine;
using FYFY;
using FYFY_plugins.TriggerManager;
public class EatingSystem : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    //Construction d'une famille incluant tous les GO contenant le composant Triggered2D (en collision) 

    private Family _triggeredGO = FamilyManager.getFamily(new AllOfComponents(typeof(Triggered2D)));

    protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        //Parcours des GO dans la famille
        foreach (GameObject go in _triggeredGO) {
            //Récupération des composants du GO courant
            Triggered2D t2d = go.GetComponent<Triggered2D>();
            //Parcours des GO actuellement en collision
            foreach (GameObject target in t2d.Targets) {
                //Désabonnement de la cible pour qu'elle ne soit plus gérée par FYFY
                GameObjectManager.unbind(target);
                //Destruction du GO
                Object.Destroy(target);
            }

        }
	}
}