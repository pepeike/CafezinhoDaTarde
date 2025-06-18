using UnityEngine;
using UnityEngine.Events; // Para usar UnityEvent

public class AceleracaoCafe : MonoBehaviour
{
    [Header("Configurações de rotação")]
    public float limRotacao = 1.0f;
    public float minRotacaoTime = 0.2f;
    public float rotationSpeedMult = 0.8f;
    public float maxRotationSpeed = 5f;
    public float idleStopTime = 2f;
    public float lerpSpeed = 3f;

    [Header("Redução de velocidade")]
    public float requiredRotationAngle = 270f;
    public float minAngleChange = 10f;

    [Header("Eventos")]
    // Ativa eventos ao atingir velocidade maxima;
    public UnityEvent onMaxSpeedReached; 

    private Vector3 lastAcceleration;
    private float lastStirTime;
    private Animator coffeeAnimator;
    private float targetRotationSpeed = 0f;
    private float currentRotationSpeed = 0f;
    private float lastInputTime;
    private float rotationProgress = 0f;
    private bool MaxSpeedReached = false; // Controller

    void Start()
    {
        lastAcceleration = Input.acceleration;
        coffeeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentAcceleration = Input.acceleration;
        float accelerationChange = (currentAcceleration - lastAcceleration).magnitude;

        if (accelerationChange > limRotacao)
        {
            lastInputTime = Time.time;

            if (Time.time > lastStirTime + minRotacaoTime)
            {
                lastStirTime = Time.time;
                UpdateRotationProgress(currentAcceleration);
            }
        }

        targetRotationSpeed = (Time.time > lastInputTime + idleStopTime)
            ? 0f
            : Mathf.Min(targetRotationSpeed, maxRotationSpeed);

        // Verifica se atingiu a velocidade máxima
        if (targetRotationSpeed >= maxRotationSpeed && !MaxSpeedReached)
        {
            OnMaxSpeedReached();
            MaxSpeedReached = true;
        }
        else if (targetRotationSpeed < maxRotationSpeed)
        {
            MaxSpeedReached = false;
        }

        currentRotationSpeed = Mathf.Lerp(
            currentRotationSpeed,
            targetRotationSpeed,
            lerpSpeed * Time.deltaTime
        );

        transform.Rotate(0, 0, currentRotationSpeed * Time.deltaTime);
        lastAcceleration = currentAcceleration;
    }

    void UpdateRotationProgress(Vector3 currentAccel)
    {
        Vector2 dir = new Vector2(currentAccel.x, currentAccel.y).normalized;
        Vector2 lastDir = new Vector2(lastAcceleration.x, lastAcceleration.y).normalized;

        float angleChange = Vector2.SignedAngle(lastDir, dir);

        if (Mathf.Abs(angleChange) > minAngleChange)
        {
            rotationProgress += Mathf.Abs(angleChange);

            if (rotationProgress >= requiredRotationAngle)
            {
                rotationProgress = 0f;
                targetRotationSpeed += rotationSpeedMult;
                if (coffeeAnimator != null)
                {
                    coffeeAnimator.SetTrigger("Stir");
                }
            }
        }
    }

    void OnMaxSpeedReached()
    {
        // Chama o evento UnityEvent
        onMaxSpeedReached.Invoke();

        // Exemplo de outras ações que podem ser feitas:
        Debug.Log("Velocidade máxima atingida!");

        // Você pode adicionar aqui:
        // - Efeitos sonoros
        // - Partículas
        // - Mudanças visuais
        // - Desbloqueio de conquistas
    }

    public void ResetRotation()
    {
        rotationProgress = 0f;
        targetRotationSpeed = 0f;
        currentRotationSpeed = 0f;
        MaxSpeedReached = false;
    }
}