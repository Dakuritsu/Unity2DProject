using UnityEngine;

public class Endurance : MonoBehaviour
{
    public float maxEndurance = 100f;
    public float currentEndurance;
    public float enduranceConsumptionRate = 10f;
    public float enduranceRecoveryRate = 20f; 

    private void Start()
    {
        currentEndurance = maxEndurance;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ConsumeEndurance();
        }
        else if (currentEndurance < maxEndurance)
        {
            currentEndurance += enduranceRecoveryRate * Time.deltaTime;
            currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);//pour que currentEndurance reste entre 0 et maxEndurance
        }
    }
    
    private void ConsumeEndurance()
    {
        currentEndurance -= enduranceConsumptionRate * Time.deltaTime;
        currentEndurance = Mathf.Clamp(currentEndurance, 0f, maxEndurance);
    }
}
