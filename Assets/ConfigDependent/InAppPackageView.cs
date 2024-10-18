using System.Globalization;
using TMPro;
using UnityEngine;

public class InAppPackageView : MonoBehaviour
{
    private InAppPackageConfig _config;
    [SerializeField] private TMP_Text text;

    public void Initialize(InAppPackageConfig config)
    {
        _config = config;
        text.text = _config.Price.ToString(CultureInfo.CurrentCulture);
    }
}