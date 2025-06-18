using UnityEngine;

public class StirDetection : MonoBehaviour
{
    [Header("Configurações")]
    public float stirThreshold = 1.5f;
    public float minStirTime = 0.3f;
    public float rotationSpeedMultiplier = 0.5f;
    public float maxRotationSpeed = 5f;
    public float idleStopTime = 2f;
    public float lerpSpeed = 2f; // Velocidade da suavização

    private Vector3 _lastAcceleration;
    private float _lastStirTime;
    private Animator _coffeeAnimator;
    private float _targetRotationSpeed = 0f; // Velocidade alvo (para Lerp)
    private float _currentRotationSpeed = 0f;
    private float _lastInputTime;
    private float _rotationProgress = 0f;

    void Start()
    {
        _lastAcceleration = Input.acceleration;
        _coffeeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentAcceleration = Input.acceleration;
        float accelerationChange = (currentAcceleration - _lastAcceleration).magnitude;

        // Detecção de movimento
        if (accelerationChange > stirThreshold)
        {
            _lastInputTime = Time.time;

            if (Time.time > _lastStirTime + minStirTime)
            {
                _lastStirTime = Time.time;
                UpdateRotationProgress(currentAcceleration);
            }
        }

        // Define a velocidade alvo (0 se inativo)
        _targetRotationSpeed = (Time.time > _lastInputTime + idleStopTime) ? 0f : Mathf.Min(_targetRotationSpeed, maxRotationSpeed);

        // Suaviza a velocidade atual em direção ao alvo
        _currentRotationSpeed = Mathf.Lerp(
            _currentRotationSpeed,
            _targetRotationSpeed,
            lerpSpeed * Time.deltaTime
        );

        // Aplica rotação
        transform.Rotate(0, 0, _currentRotationSpeed * Time.deltaTime);
        _lastAcceleration = currentAcceleration;
    }

    void UpdateRotationProgress(Vector3 currentAccel)
    {
        Vector2 dir = new Vector2(currentAccel.x, currentAccel.y).normalized;
        Vector2 lastDir = new Vector2(_lastAcceleration.x, _lastAcceleration.y).normalized;

        float angleChange = Vector2.SignedAngle(lastDir, dir);
        _rotationProgress += Mathf.Abs(angleChange);

        if (_rotationProgress >= 360f)
        {
            _rotationProgress = 0f;
            _targetRotationSpeed += rotationSpeedMultiplier; // Acelera o alvo
            _coffeeAnimator.SetTrigger("Stir");
        }
    }
}