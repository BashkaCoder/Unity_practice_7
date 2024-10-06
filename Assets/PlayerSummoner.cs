using UnityEngine;

public class PlayerSummoner : MonoBehaviour
{
    [SerializeField] private Player prefab;
    private PlayerConfig _config;

    public void SetConfig(PlayerConfig config) => _config = config;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            var player = Instantiate(prefab);
            player.Initialize(_config);
        }
    }
}
