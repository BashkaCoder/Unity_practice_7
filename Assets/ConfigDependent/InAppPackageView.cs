using TMPro;
using UnityEngine;

public class InAppPackageView : MonoBehaviour
{
    private InAppPackageConfig _config;
    [SerializeField] private TextMeshProUGUI textMesh;

    public void Initialize(InAppPackageConfig config)
    {
        _config = config;
    }
    
    private void Start()
    {
        textMesh.text = _config.Price.ToString();
    }
}