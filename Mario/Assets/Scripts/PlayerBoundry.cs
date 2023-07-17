using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundry : MonoBehaviour
{
   
    float xMove;

    // Update is called once per frame
    void Update()
    {
        xMove = Mathf.Clamp(transform.position.x, 0, 210);// playerýn x ekseni boyunca + ve- deðerleri arasýnda kalmasý için..
        transform.position = new Vector2(xMove,transform.position.y);// y ekseninde yukarý çýkma sýnýrý.
        
    }

}
