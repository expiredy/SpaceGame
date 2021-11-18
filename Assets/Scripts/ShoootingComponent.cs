using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoootingComponent : MonoBehaviour
{

	public Transform muzzleLeft, muzzleRight;

    public bool isAutoShootingMode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {		
		if (this.isAutoShootingMode ? this.GetInput() : this.GetAutomaticEvent()){
			this.FireWeapons();
		}	
    }
    
    private bool GetInput(){
		return Input.GetKeyDown("space");
	}

	private bool GetAutomaticEvent(){
		return true;
	}

	private void FireWeapons(){
		
	}
}
