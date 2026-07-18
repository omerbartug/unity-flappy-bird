 using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float hiz = 4f;
    

    void Update()
    {
        transform.Translate(Vector3.left * hiz * Time.deltaTime);
         
    }

    
}

    
