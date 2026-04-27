using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public Light luz;

    public void Switch(){
        luz.enabled = !luz.enabled;
    }
}
