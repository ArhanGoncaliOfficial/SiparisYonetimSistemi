using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedTextBox : UserControl
{
    private TextBox textBox;

    public int BorderRadius { get; set; } = 15;
    public Color BorderColor { get; set; } = Color.Gray;
    public int BorderSize { get; set; } = 2;

    public RoundedTextBox()
    {
        textBox = new TextBox();
        textBox.BorderStyle = BorderStyle.None;
        textBox.Location = new Point(10, 5);
        textBox.Width = this.Width - 20;
        this.Controls.Add(textBox);
        this.Padding = new Padding(BorderSize);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        textBox.Width = this.Width - 20;
        textBox.Height = this.Height - 10;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Yuvarlatılmış kenarları çiz
        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle rectBorder = this.ClientRectangle;
        rectBorder.Width -= 1;
        rectBorder.Height -= 1;

        GraphicsPath pathBorder = GetRoundedRectanglePath(rectBorder, BorderRadius);
        using (Pen penBorder = new Pen(BorderColor, BorderSize))
        {
            graphics.DrawPath(penBorder, pathBorder);
        }
    }

    private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }

    public string Text
    {
        get { return textBox.Text; }
        set { textBox.Text = value; }
    }
}
