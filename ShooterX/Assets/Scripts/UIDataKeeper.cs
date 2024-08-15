using TMPro;
using UnityEngine;

public class UIDataKeeper : MonoBehaviour
{
    M4A1 rifle;
    public string currentAmmo, ammoCapacity, spareAmmoCapacity;
    public TextMeshProUGUI ammoText, warningText;

    private void Awake()
    {
        rifle = FindObjectOfType<M4A1>();
    }

    private void Update()
    {
        currentAmmo = rifle.currentAmmo.ToString();
        spareAmmoCapacity = rifle.spareAmmoCapacity.ToString();

        ammoText.text = currentAmmo + "/" + spareAmmoCapacity;
        Warn();
    }

    private void Warn()
    {
        if (rifle.isReloading)
        {
            warningText.text = "Reloading!";
            warningText.gameObject.SetActive(true);

        }
        else
        {
            warningText.gameObject.SetActive(false);
        }
    }
}
