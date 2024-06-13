using Match3.components;

namespace Match3
{
    public partial class Form1 : Form
    {
        private GameGrid gameGrid;
        private Size sizeEntities;
        public Form1()
        {
            InitializeComponent();
            gameGrid = new GameGrid(new Size(8, 8));

            Start();
        }
        private void Start()
        {
            gameGrid.Fill();
        }
    }
}
