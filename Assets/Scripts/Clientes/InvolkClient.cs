using UnityEngine;
using System.Collections.Generic;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabsToSpawn; // Lista de prefabs
    //[SerializeField] private float spawnInterval = 20f; // Tempo entre spawns
    [SerializeField] private AudioClip spawnSound; // Som a ser tocado ao spawnar (arraste um AudioClip aqui no Inspector)

    private GameObject lastSpawnedObject;
    //private float timer;
    private AudioSource audioSource; // Referência para o AudioSource

    private void Start()
    {
        //timer = spawnInterval;
        //audioSource = GetComponent<AudioSource>(); // Pega o AudioSource do GameObject

        // Se não houver AudioSource, adiciona um automaticamente
        //if (audioSource == null)
        //{
            //audioSource = gameObject.AddComponent<AudioSource>();
        //}
    }
    /*
    private void Update()
    {
        if (lastSpawnedObject == null)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnRandomPrefab();
                timer = spawnInterval;
            }
        }
    }
    */
    private void SpawnRandomPrefab()
    {
        if (prefabsToSpawn.Count == 0)
        {
            Debug.LogWarning("Nenhum prefab na lista para spawnar!");
            return;
        }

        int randomIndex = Random.Range(0, prefabsToSpawn.Count);
        GameObject prefab = prefabsToSpawn[randomIndex];
        lastSpawnedObject = Instantiate(prefab, transform.position, Quaternion.identity);

        // Toca o som de spawn (se existir)
        if (spawnSound != null)
        {
            audioSource.PlayOneShot(spawnSound); // Toca o som sem interromper outros áudios
        }

        Debug.Log("Novo objeto spawnado: " + lastSpawnedObject.name);
    }

    //RLH107////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private GameObject CurrentSpawnedCliant, SpawnedCliant2;
    public void SpawnCliant(Cliant CliantToSpawn)
    {
        if (CliantToSpawn.CliantPrefab == null) { Debug.LogError(CliantToSpawn.debugCliantName + " / Cliente Sem PREFAB"); return; }
        CurrentSpawnedCliant = Instantiate(CliantToSpawn.CliantPrefab, transform.position, Quaternion.identity);
        if (spawnSound != null)
        {
            //audioSource.PlayOneShot(spawnSound); // Toca o som sem interromper outros áudios
        }
    }
    public void DuoSpawnCliant(Cliant CliantToSpawn1)
    {
        if (CliantToSpawn1.CliantPrefab == null) { Debug.LogError(CliantToSpawn1.debugCliantName + " / Cliente Sem PREFAB"); return; }
        if (CliantToSpawn1.CliantPrefab2 == null) { Debug.LogError(CliantToSpawn1 + " / Cliente Não Existente"); return; }
        CurrentSpawnedCliant = Instantiate(CliantToSpawn1.CliantPrefab, transform.position, Quaternion.identity);
        SpawnedCliant2 = Instantiate(CliantToSpawn1.CliantPrefab2, transform.position + new Vector3(8,0,0), Quaternion.identity);
    }
    public void DeSpawnCliant() 
    {
        if(CurrentSpawnedCliant == null) { Debug.LogWarning("There is no spawned Cliant"); return; }
        Destroy(CurrentSpawnedCliant);
        if(SpawnedCliant2 != null)
        {
            Destroy(SpawnedCliant2); SpawnedCliant2 = null;
        }
    }
    public void TutorialSpawn(GameObject tospawn)
    {
        if(tospawn == null) { Debug.LogError("TutorialSpriteGameObjectMissing"); }
        CurrentSpawnedCliant = Instantiate(tospawn, transform.position, Quaternion.identity);
    }
}