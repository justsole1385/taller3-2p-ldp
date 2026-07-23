using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Prefabs de las Plataformas (Chunks)")]
    public GameObject[] itemPrefab; // Aquí van los Chunk_1, Chunk_2, Chunk_3
    
    [Header("Configuración del Temporizador")]
    public float minTime = 1f;
    public float maxTime = 3f;
    
    [Header("Configuración de Distancia")]
    public float distanciaEntreChunks = 15f;

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

        // Creamos la nueva posición avanzando hacia la derecha
        Vector3 nuevaPosicion = new Vector3(posicionActualX, transform.position.y, transform.position.z);

        // Clonamos un chunk al azar (Chunk_1, Chunk_2 o Chunk_3)
        Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], nuevaPosicion, Quaternion.identity);

        // Avanzamos la posición X para el siguiente chunk
        posicionActualX += distanciaEntreChunks;

        StartCoroutine(SpawnCoroutine(Random.Range(minTime, maxTime)));
    }
}
