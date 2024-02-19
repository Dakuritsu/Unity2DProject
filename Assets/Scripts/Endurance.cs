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

    public float GetMaxEndurance
    {
        get { return maxEndurance; }
    }


    private void Start()
    {
        currentEndurance = maxEndurance;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ConsumeEndurance(enduranceConsumptionRate);
        }
        else if (currentEndurance < maxEndurance)
        {
            currentEndurance += enduranceRecoveryRate * Time.deltaTime;
            currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);//pour que currentEndurance reste entre 0 et maxEndurance
        }
        Debug.Log("quantité d'endurance :" + currentEndurance + "\n");
    }
    
    internal void ConsumeEndurance(float amount)
    {
        currentEndurance -= amount * Time.deltaTime;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);
        Debug.Log("quantité d'endurance :" + currentEndurance + " consommation : " + amount + "\n");
    }

        internal void ConsumeEnduranceForDash(float amount)
    {
        currentEndurance -= amount;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);
        Debug.Log("quantité d'endurance :" + currentEndurance + " consommation : " + amount + "\n");
    }
}
