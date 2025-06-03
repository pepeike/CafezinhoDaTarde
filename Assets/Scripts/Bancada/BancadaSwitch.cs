using UnityEngine;

public class AtivarPainelPorTag : MonoBehaviour
{
    [SerializeField] private GameObject painel; // Arraste o painel do Canvas aqui
    [SerializeField] private string tagDesejada; // Tag que ativará o painel

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Se o objeto que entrou tem a tag desejada, ativa o painel
        if (other.CompareTag(tagDesejada))
        {
            painel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Se o objeto com a tag sair, desativa o painel (opcional)
        if (other.CompareTag(tagDesejada))
        {
            painel.SetActive(false);
        }
    }
}