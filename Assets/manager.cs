using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject objetoPrefab; // Es el objeto que intanciaremos
    private GameObject instantiatedObject; // y este sera el objeto que igualaremos para poder hacer que se mueva por el tablero
    private int posX = 8; //limites para el tablero
    private int posY = 8;
    
    Vector2 randomPosition;//para la primera y unica instanciacion 

    private Vector2 actuallyPosition;//para guarda la posicion del instantiatedObject
    private float objX, objY, colX, colY; //mapeado de los vectores actuallyPosition y de hit.collider.transform.position.x



    private void Start()
    {
        randomPosition.x = Random.Range(0, posX);
        randomPosition.y = Random.Range(0, posY);
        instantiatedObject = Instantiate(objetoPrefab, randomPosition, Quaternion.identity); //objeto instanciado se iguala al objeto prefab para poder hacer cosas con el
        actuallyPosition = randomPosition;//igualamos la posicion actual del obejeto a la posicion aleatoria que hemos utilizado para instanciar el prefab

    }
    private void Update()
    {
        MoveQueen();
    }
    private void MoveQueen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Obtén la posición del ratón en el mundo
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ScreenToWorldPoint se utiliza para convertir las coordenadas de la pantalla
                                                                                        //Si no el input no funcionava
            //  un raycast que va a colisionar con los collider del tablero
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up);// el vector.up establece una direccion pero no se exactamente que pass si se cambia, porque lo he cambiado y no ha cambiado el funcionamiento
            // Comprueba si se ha hecho clic en un collider
            objX = actuallyPosition.x;//pasar los coordenadas de vectores a float para poder implementarlos en los metodos if
            objY = actuallyPosition.y;//tanto la posicion de la reina actualizada como la casilla selecionada
            colX = hit.collider.transform.position.x;// con esto y los limites del tablero lo tenemos todo para hace nuestras condiciones
            colY = hit.collider.transform.position.y;
            if (hit.collider != null)
            {
                if (objX == colX && objY < posY)//Arriva abajo la X siempre igual y la Y se mueve
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;//mueve el objeto a la casilla seleccionada
                    actuallyPosition = instantiatedObject.transform.position;//y actualiza la posicion del objeto
                }
                else if (objY == colY && objX < posX)//Derecha iquierda la Y siempre igual y la X se mueve
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                    actuallyPosition = instantiatedObject.transform.position;
                }
                else if (objX - colX == objY - colY)//diagonal 1 verifica que no haya diferencia entre las X e Y si esta en el vector(1, 2) puede moverse al (3, 4)
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                    actuallyPosition = instantiatedObject.transform.position;
                }
                else if (objX - colX ==  colY - objY)//diagonal 2
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                    actuallyPosition = instantiatedObject.transform.position;
                }
                else
                {
                    Debug.Log("Aprende a jugar al ajedrez"); //el resto de casillas
                }
            }
        }
    }
}