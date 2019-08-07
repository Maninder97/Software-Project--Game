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
                    "Racism has become a big issue today. It basically highlights the race of a person proving him/her better over the other. In other words, it can be said that someone trying to show his or her power among others because of being wealthier or belonging to some higher caste or something like this.It may also include prejudice, discrimination, or antagonism directed against other people because they are of a different race or ethnicity, or the belief that members of different races or ethnicities should be treated differently.It is too much raised because of the hate in people among others which rises due to some weird reasons like the hated people have different colour, they belong to different nation or sometimes, they have different language too.These small reasons have, many times, turned into big fights or wars even. Which further influenced slavery forced by the stronger people to the poor ones.This issue has affected mostly the Africans and many parts of Asian countries.In this modern era, it can be seen in society as people making others feel lower by showing them weak and proving their abilities over others.";
                Instantiate(GUIMessage, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
                
                Time.timeScale = 0;
                
                
                other.gameObject.SetActive(false);
                fuel = fuel + 1;
                SetFuel();

            }
            else if (other.gameObject.CompareTag("Solution1"))
            {
                GUIMessage2.text = "Here are some of the steps those can be taken to eliminate racism" + "\r\n" + "\r\n"  + "Never pay for the fault or some cause, which is not caused by you or your are not involved in that. If someone is still trying to put you in trouble without any reason, or teasing you for their own comfort, never let them go ahead. Complaint that as soon as possible to any authority according to the condition. For example, if you are in school, if someone is bullying you without any reason, tell your teacher immediately. It cannot stop everyone, but you can get your right and take first step to stop racism." +"\r\n" +
                                    "Following the above information about knowing your rights, it is also your responsibility that if you don't want to be a victim of racism, then it is your responsibility that no one else should be treated badly or negatively by you. Apart from that, helping others by saving them from bullies and people who promote racism is also your responsibility. Let others feel confident and it is only possible, if you will be a good citizen and before that, a good member of the society you are living in. Always treat everyone equally whether they belong to your society or from any other. ";
                Instantiate(GUIMessage2, Camera.main.WorldToViewportPoint(gameObject.transform.position), Quaternion.identity);
                Time.timeScale = 0;
                other.gameObject.SetActive(false);
                fuel = fuel + 1;
                SetFuel();

            }
            else if (other.gameObject.CompareTag("Solution2"))
            {
                GUIMessage3.text = "Here are some more steps to eliminate racism" + "\r\n" + "\r\n" + "Another step to eliminate racial discrimination is promoting equality among people. As we all know, in many parts of the world, the political and powerful authorities control people and for their own benefits, they convince people to support them and cleverly rise hate between people. What is our step then? The best thing we can do is not to support them if they want our support in this manner.  " + "\r\n" + "There are still some people present in our society who raise their voices for their rights, but, due to lack of support and power, they are always ignored and never heard by anyone. Some people want to stand by their side but afraid of the majority which is against them. We should never be afraid of those who promote racism. The only way to lower their strength is, supporting the right person, even if it is one or two, if we are supporting them, we can encourage more people and the majority will be in our side. " + "\r\n" + "\r\n" + "If you belong to higher caste or religion or you are wealthier among your group or society, or anything that makes you better than others, never let it make you over confident. Always engage with others in a manner that they should feel comfortable. Never let them realize that they are lower than you or never show that you are above them. " + "\r\n" + "Take a stand with your wallet. Know the practices of companies that you invest in and the charities that you donate to. Make an effort to shop at small, local businesses and give your money back to the people living in the community. Your state or territory may have a directory of local, minority-owned businesses in your area. ";
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
