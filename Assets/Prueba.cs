using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba : MonoBehaviour
{
    public Vector2 casilla;
        private void OnMouseDown()
    {
        casilla = this.gameObject.transform.position;
        Debug.Log(message:$"Clic en el objeto: {this.gameObject.transform.position}");
    }
}
