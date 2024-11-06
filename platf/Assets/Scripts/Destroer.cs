using UnityEngine;

public class Destroer : MonoBehaviour
{
    public float lifetime;
    private void Start()  
    {
        Destroy(gameObject, lifetime);
    }
        
}
