using UnityEngine;

public class TransformController : MonoBehaviour
{ 
        private void Update()
    {
        var x = Mathf.PingPong(Time.time, 3);
        var y = Mathf.PingPong(Time.time, 3);
        var p = new Vector3(x, y, 0);
        transform.position = p;

        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(30, 0, 0) * Time.deltaTime);
    }
}