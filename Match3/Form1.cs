using Match3.components;

namespace Match3
{
    public partial class Form1 : Form
    {
        private GameGrid gameGrid;
        private Size sizeEntities;
        private FigureFabric figureFabric;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            figureFabric = new FigureFabric(AddEntity,RemoveEntity);
            gameGrid = new GameGrid(new Size(8, 8),figureFabric);

            Start();
        }
        private void Start()
        {
            gameGrid.Fill();
        }

        internal void AddEntity(Control item) => gridPanel.Controls.Add(item);
        internal void RemoveEntity(Control item) => gridPanel.Controls.Remove(item);


    }
}
