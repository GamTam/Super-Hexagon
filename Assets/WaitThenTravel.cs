using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitThenTravel : MonoBehaviour
{
    [SerializeField] private Vector3 _destination;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        
        float movementDuration = 3;
        float timeElapsed = 0;
            
        while (timeElapsed < movementDuration)
        {
            timeElapsed += Time.deltaTime;
            gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, _destination, Time.deltaTime * 5);
                    
            yield return null;
        }
        
        gameObject.transform.localPosition = _destination;
    }
}
