using UnityEngine;

public class Endurance : MonoBehaviour
{
    private float maxEndurance = 100f;
    private float currentEndurance;

    [SerializeField] private float enduranceConsumptionRate = 10f;
    [SerializeField] private float enduranceRecoveryRate = 20f; 


    public float GetCurrentEndurance
    {
        get { return currentEndurance; }
    }

    public float GetEnduranceConsumptionRate
    {
        get { return enduranceConsumptionRate; }
    }

    public float GetMaxEndurance
    {
        get { return maxEndurance; }
    }


    public void SetCurrentEndurance(float amount)
    {
        currentEndurance = amount;
    }
    private void Start()
    {
        currentEndurance = maxEndurance;
    }

    private void Update()
    {
    }
    
    internal void ConsumeEndurance()
    {
        currentEndurance -= enduranceConsumptionRate * Time.deltaTime;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);
        Debug.Log("quantité d'endurance :" + currentEndurance + " consommation : " + enduranceConsumptionRate + "\n");
    }

    internal void ConsumeEnduranceForDash(float amount)
    {
        currentEndurance -= amount;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);
        Debug.Log("quantité d'endurance :" + currentEndurance + " consommation : " + amount + "\n");
    }

    public void recoveryEndurance(){
        currentEndurance += enduranceRecoveryRate * Time.deltaTime;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);
    }
}
