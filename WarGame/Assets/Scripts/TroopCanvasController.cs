using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TroopCanvasController : MonoBehaviour
{

    [SerializeField]
    private Image soldierImage;

    [SerializeField]
    private Image tankImage;

    [SerializeField]
    private Image planeImage;

    [SerializeField]
    private Image antiAerialImage;

    [SerializeField]
    private TMP_Text soldierText;

    [SerializeField]
    private TMP_Text tankText;

    [SerializeField]
    private TMP_Text planeText;

    [SerializeField]
    private TMP_Text antiAerialText;

    [SerializeField]
    private GameObject backgroundCanvas;


    private void Update()
    {
        CheckMouseOverCountries();
    }

    private void CheckMouseOverCountries()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
           
            Countries country = hit.collider.GetComponent<Countries>();
            if (country != null)
            {

               
                soldierImage.color = country.GetPlayerColor();
                tankImage.color = country.GetPlayerColor();
                planeImage.color = country.GetPlayerColor();
                antiAerialImage.color = country.GetPlayerColor();
                soldierText.text = country.SoldiersNum.ToString();
                tankText.text = country.TankNum.ToString();
                planeText.text = 0.ToString();
                antiAerialText.text = country.AANum.ToString();
                backgroundCanvas.SetActive(true);
                

                

            }
            else
            {
                backgroundCanvas.SetActive(false);
            }
        }
    }
}
