    using UnityEngine;
    using System.Collections;
    
    public class Dragon_Head_statue: MonoBehaviour {
    	public GameObject openFire;
    	public bool IsActive = false;
    	
    	void Start()
    	{
    		//Start the coroutine
    		//5 seconds flame burst, then wait 3 secs
    		StartCoroutine(OpenFire(5.0f, 3.0f)); 
    	}
    
    	/* function for making this thing stop */
    	void StopFlames()
    	{
    		//Stop the first running coroutine with the function name "OpenFire".
    		StopCoroutine("OpenFire");
    		IsActive = false; //propage this metadata outside
    	}
    
    	IEnumerator OpenFire(float fireTime, float waitTime )
    	{
    		IsActive = true; //For outside checking if this is spitting fire
    		while(true)
    		{
    			//Activate the flames
    			openFire.SetActive(true);
    			//Wait *fireTime* seconds
    			yield return new WaitForSeconds(fireTime);
    			//Deactivate the flames 
    			openFire.SetActive(false);		
    			//Now wait the specified time
    			yield return new WaitForSeconds(waitTime);
    			//After this, go back to the beginning of the loop
    		}
    	}
    
    }
