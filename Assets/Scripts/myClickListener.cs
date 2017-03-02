using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myClickListener : MonoBehaviour {

    
	void Start () {
        gameObject.AddComponent<Button>().onClick.AddListener(evokeGivenMethod);
	}
	
	void evokeGivenMethod () {
		
	}
}
