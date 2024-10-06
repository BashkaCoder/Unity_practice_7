using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerConfig _config;

    public void Initialize(PlayerConfig config)
    {
        _config = config;
    }
    
    private void Update()
    {
        if (_config != null)
        {
            transform.position += transform.forward * (_config.Speed * Time.deltaTime);
        }
    }
}