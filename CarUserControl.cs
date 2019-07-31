using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
        private Rigidbody rb;
        public Text countText;
        public Text scoreText;
        public Text winText;
        public Text coinText;
        public Text loseText;
        public Text GUIMessage;
        public Text GUIMessage2;
        public Text GUIMessage3;
        private int count = 0;
        private int coins = 0;
        private int score = 0;
        public int fuel = 5;
        public Text Fuel;
        public Transform Spawnpoint2;
        Button Ctnbtn;
        


        void start()
        {
            rb = GetComponent<Rigidbody>();
            coins = 0;
            count = 0;
            countText.text = "Coins: " + count.ToString();
            coinText.text = "Coins: " + coins.ToString();
            scoreText.text = "Coins: " + score.ToString();
            SetCountText();
            SetCoinText();
            SetScoreText();
            GUIMessage.text = "Racism";
            winText.text = "";
            loseText.text = "";
            fuel = 5;
            Fuel.text = "Fuel: " + fuel.ToString();
            SetFuel();
            SetTeleporter();
            
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

      

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f); 
#endif
        }

        void SetFuel()
        {
            Fuel.text = "Fuel: " + fuel.ToString();
            if (fuel <= 0)
            {
                loseText.text = "Game Over!!!";
                SetTeleporter();
            }
        }
      


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("pickup"))
            {

                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();

            }
            if (other.gameObject.CompareTag("pickup2"))
            {
                other.gameObject.SetActive(false);
                coins = coins + 1;
                SetCoinText();
            }
            if (other.gameObject.CompareTag("pickup3"))
            {
                other.gameObject.SetActive(false);
                score = score + 1;
                SetScoreText();
            }
            else if (other.gameObject.CompareTag("powerdowns"))
            {
                other.gameObject.SetActive(false);
                fuel = fuel - 1;
                SetFuel();
            }

            else if (other.gameObject.CompareTag("Issue"))
            {
                GUIMessage.text = "What is Racism? " + "\r\n" +"\r\n" +
                    "Racism takes many forms and can happen in many places. It includes prejudice, discrimination or hatred directed at someone because of their colour, ethnicity or national origin. People often associate racism with acts of abuse or harassment. However, it doesn’t need to involve violent or intimidating behaviour. Take racial name - calling and jokes. Or consider situations when people may be excluded from groups or activities because of where they come from. Racism can be revealed through people’s actions as well as their attitudes.It can also be reflected in systems and institutions.But sometimes it may not be revealed at all.Not all racism is obvious.For example, someone may look through a list of job applicants and decide not to interview people with certain surnames. Racism is more than just words, beliefs and actions. It includes all the barriers that prevent people from enjoying dignity and equality because of their race.";
                Instantiate(GUIMessage, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
                
                Time.timeScale = 0;
                
                
                other.gameObject.SetActive(false);
                fuel = fuel + 1;
                SetFuel();

            }
            else if (other.gameObject.CompareTag("Solution1"))
            {
                GUIMessage2.text = "Here are some of the steps those can be taken to eliminate racism" + "\r\n" + "\r\n"  + " 1.Don't laugh at racist, sexist, ageist, homophobic and other stereotypical jokes or assumptions." +"\r\n" +
                                    "2.Make an effort to get to know people different than you." + "\r\n" + "3.Learn about other people and their culture." + " \r\n" + "4.Think before you speak." + "\r\n" + "5.Don't make assumptions on others.";
                Instantiate(GUIMessage2, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
                Time.timeScale = 0;
                other.gameObject.SetActive(false);
                fuel = fuel + 1;
                SetFuel();

            }
            else if (other.gameObject.CompareTag("Solution2"))
            {
                GUIMessage3.text = "Here are some more steps to eliminate racism" + "\r\n" + "\r\n" + "Support anti-prejudice and anti-racist organizations: " + "\r\n" + "Whether your efforts are in volunteering, financial donation or being an advocate, working with other groups toward the same goal can be beneficial to you and the community. You'll meet great people and find real support for your efforts. By getting involved, your voice can make a big difference at the local level." + "\r\n" + "\r\n" +"Explore the unfamiliar:" + "\r\n" + "Attend an organization meeting, religious service or travel to a new region where you are in the minority. For example, if you are Christian attend a Jewish service at a synagogue.If you attend an all white suburban school visit an inner - city multi - cultural school. This first-hand experience can be enlightening and give you perspective. ";
                Instantiate(GUIMessage3, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
                Time.timeScale = 0;
                other.gameObject.SetActive(false);
                fuel = fuel + 1;
                SetFuel();

            }
            else if (other.gameObject.CompareTag("powerups"))
           {
              other.gameObject.SetActive(false);
             fuel = fuel + 1;
             SetFuel();

           }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.SetActive(false);
                fuel = fuel - 2;
                SetFuel();
            }

        }

        public void resume_OnClick()
        {
            Time.timeScale = 1;
            Destroy(GUIMessage);
            Destroy(GUIMessage2);
            Destroy(GUIMessage3);
        }


        void SetCountText()
        {
            countText.text = "Coins: " + count.ToString();
            if (count == 11)
            {
                Application.LoadLevel("Lvl 1 Message");
                countText.text = "Coins: " + count.ToString();
                Fuel.text = "Fuel: " + fuel.ToString();
            }
        }

        void SetCoinText()
        {
            coinText.text = "Coins: " + coins.ToString();
            if (coins >= 18)
            {
                Application.LoadLevel("Lvl 2 Message");
            }
        }
        void SetScoreText()
        {
            scoreText.text = "Coins: " + score.ToString();
            if (score >= 20)
            {
                Application.LoadLevel("GameWinScene");
            }
        }


        void SetTeleporter()
        {
            if (fuel <= 0)
            {
                Application.LoadLevel("GameOver");  
            }
          
        }
    }
}
