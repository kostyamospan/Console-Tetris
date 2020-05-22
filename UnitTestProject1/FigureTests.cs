using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace UnitTestProject1
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void ToString_figure_I()
        {
            // arrange
            Figure figure = new Figure(FigureType.I_block);

            string expected = "#\n#\n#\n#\n";

            // act

            string actual = figure.ToString();

            // assert 

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void ToString_figure_J()
        {
            // arrange
            Figure figure = new Figure(FigureType.J_block);

            string expected = " #\n #\n##\n";

            // act

            string actual = figure.ToString();

            // assert 

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_figure_L()
        {
            // arrange
            Figure figure = new Figure(FigureType.L_block);

            string expected = "# \n# \n##\n";
            // act
            string actual = figure.ToString();
            // assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_figure_O()
        {
            // arrange
            Figure figure = new Figure(FigureType.O_block);

            string expected = "##\n##\n";
            // act
            string actual = figure.ToString();
            // assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_figure_S()
        {
            // arrange
            Figure figure = new Figure(FigureType.S_block);

            string expected =  " ##\n" +
                               "## \n";
            // act
            string actual = figure.ToString();
            // assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_figure_T()
        {
            // arrange
            Figure figure = new Figure(FigureType.T_block);

            string expected = "###\n" +
                              " # \n";
            // act
            string actual = figure.ToString();
            // assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ToString_figure_Z()
        {
            // arrange
            Figure figure = new Figure(FigureType.Z_block);

            string expected = "## \n" +
                              " ##\n";
            // act
            string actual = figure.ToString();
            // assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
