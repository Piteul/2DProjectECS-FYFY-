using UnityEngine;
using FYFY;

public class VirusFactory : FSystem {
    // Use this to update member variables when system pause. 
    // Advice: avoid to update your families inside this function.
    //Le composant Factory (dans notre exemple un seul GO)
    private Family factory_F = FamilyManager.getFamily(new AllOfComponents(typeof(Factory)));

	protected override void onPause(int currentFrame) {
	}

	// Use this to update member variables when system resume.
	// Advice: avoid to update your families inside this function.
	protected override void onResume(int currentFrame){
	}

	// Use to process your families.
	protected override void onProcess(int familiesUpdateCount) {
        //Dans cette exemple, une seule usine à virus est disponible
        GameObject virusFactory = factory_F.First();

        if(virusFactory != null) {
            //Recuperation du composant Factory
            Factory factory = virusFactory.GetComponent<Factory>();
            if(factory != null) {
                factory.reloadProgress += Time.deltaTime;

                if(factory.reloadProgress >= factory.reloadTime) {
                    //Instanciation d'un nouveau virus
                    GameObject go = GameObject.Instantiate<GameObject>(factory.prefab);
                    //Abonnement de ce nouveau Gameobject à FYFY
                    GameObjectManager.bind(go);
                    //Positionnement aléatoire du virus
                    go.transform.position = new Vector3((Random.value - 0.5f) * 7, (Random.value - 0.5f) * 5.2f);
                    factory.reloadProgress = 0;
                }
            }
        }

    }
}