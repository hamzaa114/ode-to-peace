using SweetSugar.Scripts.GUI.BonusSpin;
using SweetSugar.Scripts.GUI.Boost;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Reward icon for the Reward popup
    /// </summary>
    public class RewardIcon : MonoBehaviour
    {
        public GameObject coinimage;
        public Sprite[] sprites;
        public Image icon;
        public Transform iconHolder;
        public TextMeshProUGUI text;
        public TextMeshProUGUI rewardName;


        /// <summary>
        /// Sets Wheel reward
        /// </summary>
        /// <param name="reward">reward object</param>
        public void SetWheelReward(RewardWheel reward)
        {
            foreach (Transform item in iconHolder)
            {
                Destroy(item.gameObject);
            }
            var g = Instantiate(reward.gameObject, Vector2.zero, Quaternion.identity, iconHolder);
            g.transform.localPosition = Vector3.zero;
            //g.transform.localScale = Vector3.one * 0.3f;
            icon = g.GetComponent<Image>();
            if (reward.type == BoostType.None)
            {
                coinimage.SetActive(true);
               
                text.text = "You got " + "50" + " " + " " + " " +" " + "  " + " " + " Coins";
                rewardName.text = "Coins";
            }
            else if (reward.type == BoostType.Bomb)
            {
                text.text = "Free Wand";
                rewardName.text = "wand";
            }
            else if (reward.type == BoostType.Stripes)
            {
                text.text = "Free Stripes Item";
                rewardName.text = "Stripes Item";
            }
            else if (reward.type == BoostType.Marmalade)
            {
                text.text = "Free Atom Booster";
                rewardName.text = "Atom";
            }
            else if (reward.type == BoostType.ExplodeArea)
            {
                text.text = "Free Bomb  Booster";
                rewardName.text = "Bomb";
            }
            else if (reward.type == BoostType.MulticolorCandy)
            {
                text.text = "Free GGG Gem";
                rewardName.text = "GGG Gem";
            }
            else if (reward.type == BoostType.FreeMove)
            {
                text.text = "Free +5 Swaps";
                rewardName.text = "Swaps";
            }

            else if (reward.type == BoostType.ExtraMoves)
            {
                text.text = "Free +5 Moves";
                rewardName.text = "Moves";
            }
            //else if(reward.type == BoostType.None)
            //{
            //    text.text = "You got booster";
            //    rewardName.text = reward.description;
            //}

        }

        /// <summary>
        /// Set icon
        /// </summary>
        /// <param name="i"></param>
        public void SetIconSprite(int i)
        {
            icon.sprite = sprites[i];
            if (i == 0)
            {
                text.text = "You got 5 coins";
                rewardName.text = "Coins";
            }
            else if (i == 1)
            {
                text.text = "You got +1 life";
                rewardName.text = "Life Awarded";
            }
        }
    }
}
