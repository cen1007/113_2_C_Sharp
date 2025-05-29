using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    /// <summary>
    /// 這個類別代表一枚硬幣，提供與硬幣相關的功能，例如擲硬幣。
    /// </summary>
    internal class Coin
    {
      private string sideUp; // 硬幣的正面或反面
        Random rand = new Random(); //隨機數生成器

        public Coin()
        {
            sideUp = "正面"; // 預設為正面
        }
        public void Toss()
        {
           
            // 隨機生成一個數字，如果是0則為正面，否則為反面
            if (rand.Next(2) == 0)
            {
                sideUp = "正面";
            }
            else
            {
                sideUp = "反面";
            }
        }

        public string GetSideUp()
        {
            // 返回當前硬幣的正面或反面
            return sideUp;
        }
    }
}
