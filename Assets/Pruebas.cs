using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pruebas : MonoBehaviour
{
    public GameObject objetoPrefab; // Es el objeto que intanciaremos
    [SerializeField] private GameObject instantiatedObject; // y este sera el objeto que igualaremos para poder hacer que se mueva por el tablero
    private int posX = 8; //limites para el tablero
    private int posY = 8;
    Vector2 randomPosition;



    private List<Vector3> positionsNoRepeat = new List<Vector3>();

    private int index;

    private void Start()
    {
        randomPosition.x = Random.Range(0, posX);
        randomPosition.y = Random.Range(0, posY);
        instantiatedObject = Instantiate(objetoPrefab, randomPosition, Quaternion.identity); //objeto instanciado se iguala al objeto prefab para poder hacer cosas con el

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
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Realiza un raycast para detectar colisiones con los colliders 2D
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up);

            // Comprueba si se ha hecho clic en un collider
            if (hit.collider != null)
            {
                if (hit.collider.transform.position == instantiatedObject.transform.position + Vector3.up)
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + Vector3.down)
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + Vector3.right)
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + Vector3.left)
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + new Vector3(1, 1))//der arriva
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + new Vector3(-1, 1))//izq arriva
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + new Vector3(1, -1))//der abajo
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else if (hit.collider.transform.position == instantiatedObject.transform.position + new Vector3(-1, -1))// izq abajo
                {
                    instantiatedObject.transform.position = hit.collider.transform.position;
                }
                else
                {
                    Debug.Log("Dirección no válida");
                }
            }
        }
    }
}
