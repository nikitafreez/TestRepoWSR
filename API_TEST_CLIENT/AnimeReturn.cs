using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_TEST_CLIENT
{
    public class AnimeReturn
    {
        public int ID_Anime { get; set; }
        public string TitleName { get; set; }
        public string TitleGenre { get; set; }
        public int TitleYear { get; set; }
        public float TitleCritic { get; set; }
        public string imgPath { get; set; }

        public AnimeReturn(string titleName, string titleGenre, int titleYear, float titleCritic, string imgPath)
        {
            TitleName = titleName;
            TitleGenre = titleGenre;
            TitleYear = titleYear;
            TitleCritic = titleCritic;
            this.imgPath = imgPath;
        }

        public AnimeReturn()
        {
        }
    }
}
