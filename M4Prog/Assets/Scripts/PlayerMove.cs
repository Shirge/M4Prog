using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Maak een aanpasbare snelheid variabele voor de besturing van de speler
    private float speed = 3;
    //Maak een variabele waarmee je een referentie naar het score-script kunt opslaan door deze in de inspector toe te voegen.
    public ScoreManager scoreManager;

    void Start()
    {
        // Controleer of je scoreManager is meegegeven in de inspector
        if (scoreManager == null)
        {
            //Geef een error als dat niet zo is
            Debug.Log("ScoreManager ontbreekt!");
        }

        Debug.Log("speed is: 3");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Verander de player snelheid wanneer je 1 drukt
            speed = 3;
            Debug.Log("speed is: 3");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Verander de player snelheid wanneer je 2 drukt
            speed = 8;
            Debug.Log("speed is: 8");
        }

        // Movement
        transform.position += Input.GetAxisRaw("Vertical") * transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check of je een gameobject raakt met de tag "Coin"
        if (collider.tag == "Coin")
        {
            //Stuur 10 punten naar de scoreManager
            scoreManager.AddScore(10);
            //stuur bericht naar de console "Munt gepakt!"
            Debug.Log("Munt gepakt");
            //Vernietig de munt
            Destroy(collider.gameObject);
        }
    }
}