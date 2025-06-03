using UnityEngine;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsToSpawn; // Lista de prefabs no Inspector
    [SerializeField] private float spawnInterval = 20f; // Tempo entre spawns (20 segundos)
    [SerializeField] private Transform spawnTransform;

    private GameObject lastSpawnedObject; // Referência ao último objeto instanciado
    private float timer; // Contador de tempo

    private void Start()
    {
        timer = spawnInterval; // Inicia o timer para o primeiro spawn
    }

    private void Update()
    {
        // Se não há um objeto instanciado OU o último foi destruído
        if (lastSpawnedObject == null)
        {
            timer -= Time.deltaTime; // Decrementa o timer

            // Se o timer chegou a zero, spawna um novo objeto
            if (timer <= 0f)
            {
                SpawnRandomPrefab();
                timer = spawnInterval; // Reseta o timer
            }
        }
    }

    private void SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Count == 0)
        {
            Debug.LogWarning("Nenhum prefab na lista para spawnar!");
            return;
        }

        // Escolhe um prefab aleatório da lista
        int randomIndex = Random.Range(0, prefabsToSpawn.Count);
        GameObject prefab = prefabsToSpawn[randomIndex];

        // Instancia o objeto na posição do Spawner (ou personalize)
        lastSpawnedObject = Instantiate(prefab, spawnTransform.position, Quaternion.identity);

        Debug.Log("Novo objeto spawnado: " + lastSpawnedObject.name);
    }
}