using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
namespace JORP {
	public class GraphicsWindow : Form {
		public Graphics Context;
		public Paddle[] Paddles = new Paddle[4];
		public Point Character = new Point(0, 0);
		public Panel GameOverScreen = new Panel();
		public static LinearGradientBrush GameBackground = new LinearGradientBrush(new PointF(0.0f, 0.0f), new PointF(0.0f, 600.0f), Color.Aqua, Color.White);
		public GraphicsWindow() {
			this.Context = this.CreateGraphics();
			this.Controls.Add(GameOverScreen);
			this.GameOverScreen.Size = new Size(800, 600);
			this.GameOverScreen.Visible = true;
			this.GameOverScreen.BackColor = Color.Yellow;
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Size = new Size(800, 600);
		}
		protected override void OnPaint(PaintEventArgs e) {
			e.Graphics.FillRectangle(GameBackground, new Rectangle(0, 0, 800, 600));
		}
	}
	public class Paddle {
		public static Random Randomizer = new Random();
		public Point Position = new Point(0, 0);
		public enum Items {None = 0, Coin5, Coin10, Coin20, Spring, Jetpack, Sand};
        public static int[] Chances = new int[7] {40, 10, 10, 10, 10, 5, 20};
		public Items Item = Items.None;
		public bool Fading = false;
        public int HorizontalVelocity = 0;
		public int DirectionFlag = 0;
        public Paddle(int height)
        {
			Position = new Point(Randomizer.Next(0, 800), height);
			if (Randomizer.Next(0, 2) == 0) {
				HorizontalVelocity = Randomizer.Next(1, 10);
				DirectionFlag = new int[]{-1, 1}[Randomizer.Next(0,1)];
			}
        }
	}
	public static class Anaaaa {
		public static GraphicsWindow Tencere = new GraphicsWindow();
		public static void Main() {
			Application.Run(Tencere);
		}
	}
}