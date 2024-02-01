using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public Slider healthSlider;
    public Image healthSliderFill;
    public float damageValue;
    public TextMeshPro enemyCountText;  // Reference to the TextMeshPro component to display the enemy count

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("The starting health of the player is:" + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currentHealth;
        //healthText.text = "Health:" + playerCurrentHealth;
        if (currentHealth >= (maxHealth / 100) * 50) // more than 50%
        {
            //healthText.color = Color.green;
            healthSliderFill.color = Color.green;

        }
        else if (currentHealth >= (maxHealth / 100) * 30 && currentHealth <= (maxHealth / 100) * 50) // between 30-50%
        {
            // healthText.color = Color.yellow;
            healthSliderFill.color = Color.yellow;
        }
        else if (currentHealth >= (maxHealth / 100) * 0 && currentHealth <= (maxHealth / 100) * 30) // 0-30%
        {
            // healthText.color = Color.red;
            healthSliderFill.color = Color.red;
        }
        // if (ForestFireCell.State == ForestFireCell.State.Alight) // reducing health
        // currentHealth -= 10; 
        if (currentHealth <= 0) 
        {
            Debug.Log("The player is dead");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene("Hub");
            //Application.Quit();
        }



    }
    public void OnTriggerEnter(Collider other) // detecting when player goes through fire-effects' collider
    {
        if (other.tag == "enemy" && currentHealth > 0)
        {
            InsectDamage(damageValue);
        }
    }


    public void InsectDamage(float damageValue) // fire decrease health and showing a red effect on the screen
    {
        currentHealth -= damageValue;
    }
}

