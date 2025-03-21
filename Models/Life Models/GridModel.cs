namespace PersonalWebsite.Models.Life_Models
{
    public class GridModel
    {
        public int XCoord { get; set; } = 0;
        public int YCoord { get; set; } = 0;
        public bool Active { get; set; } = false;
        public int Count { get; set; } = 0;
        public string Style { get; set; } = "background-color: gray;";

        public GridModel(int xCoord, int yCoord, bool active, int count)
        {
            XCoord = xCoord;
            YCoord = yCoord;
            Active = active;
            Count = count;
        }

        public void UpdateStyles()
        {
            switch (Active)
            {
                case true:
                    Style = "height: 20px; width: 20px; background-color: yellow;";
                    break;
                case false:
                    Style = "height: 20px; width: 20px; background-color: gray;";
                    break;
            }
        }
    }
}
