namespace Tetris
{
    class Figure
    {
        public FigureType Type { get; private set; }
        public Position Position { get; set; }

        private Pixel[,] pixels;

        public Figure(FigureType type)
        {
            Type = type;
            InitFigureBody(type);
        }


        private void InitFigureBody(FigureType type)
        {
            Pixel[,] figureBody = null;

            switch (type)
            {
                case FigureType.I_block:
                    {
                        figureBody = new Pixel[4, 1]
                        {
                                { new Pixel() },
                                { new Pixel() },
                                { new Pixel() },
                                { new Pixel() },
                        };
                    }
                    break;
                case FigureType.J_block:
                    {
                        figureBody = new Pixel[3, 2]
                        {
                                { null, new Pixel() },
                                { null, new Pixel() },
                                { new Pixel(),new Pixel() },
                       };
                    }
                    break;
                case FigureType.L_block:
                    {
                        figureBody = new Pixel[3, 2]
                        {
                                { new Pixel(), null },
                                { new Pixel(), null },
                                { new Pixel(), new Pixel() },
                       };
                    }
                    break;
                case FigureType.O_block:
                    figureBody = new Pixel[2, 2]
                       {
                                { new Pixel(), new Pixel() },
                                { new Pixel(), new Pixel() },

                       };
                    break;
                case FigureType.S_block:
                    figureBody = new Pixel[2, 3]
                      {
                                { null, new Pixel(), new Pixel() },
                                { new Pixel(), new Pixel(), null },

                      };
                    break;
                case FigureType.T_block:
                    figureBody = new Pixel[2, 3]
                      {
                                { new Pixel(), new Pixel(), new Pixel() },
                                { null, new Pixel(), null },

                      };
                    break;
                case FigureType.Z_block:
                    figureBody = new Pixel[2, 3]
                      {
                                { new Pixel(), new Pixel(), null },
                                { null, new Pixel(), new Pixel() },

                      };
                    break;
            }

            pixels = figureBody;
        }
    }

}