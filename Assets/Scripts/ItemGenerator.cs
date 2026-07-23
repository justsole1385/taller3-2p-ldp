using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    [Header("Prefabs de los Items")]
    public GameObject[] itemPrefab; // Aquí arrastraremos el prefab del enemigo y de la moneda
    
    [Header("Configuración del Temporizador")]
    public float minTime = 1f;
    public float maxTime = 3f;
    
    [Header("Configuración de Distancia")]
    public float distanciaEntreItems = 15f; // Mantén esto igual al del PlatformGenerator para que coincidan

    private float posicionActualX = 0f;

    void Start()
    {
        posicionActualX = transform.position.x;
        StartCoroutine(SpawnCoroutine(0));
    }

    IEnumerator SpawnCoroutine(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Evita errores si no hay prefabs asignados
        if (itemPrefab == null || itemPrefab.Length == 0) yield break;

        // Calculamos la nueva posición de spawn en X
        Vector3 nuevaPosicion = new Vector3(posicionActualX, transform.position.y, transform.position.z);
        
        // Clonamos uno de los ítems al azar (enemigo o moneda)
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], nuevaPosicion, Quaternion.identity);

        // Avanzamos la posición X para el siguiente ítem
        posicionActualX += distanciaEntreItems;

        // Volvemos a iniciar la rutina con un tiempo aleatorio
        StartCoroutine(SpawnCoroutine(Random.Range(minTime, maxTime)));
    }
}
