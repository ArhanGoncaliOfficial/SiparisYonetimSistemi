using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace SiparisYonetimSistemi
{
    public partial class AboutUs : Form
    {
        // Proje kök dizinini bulmak için helper method
        private string GetProjectRootPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            // bin\Debug veya bin\Release klasöründen iki seviye yukarı çık
            return Directory.GetParent(Directory.GetParent(currentDirectory).FullName).FullName;
        }

        public AboutUs()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Form ayarları aynı
            this.Text = "Hakkımızda";
            this.Size = new Size(840, 800);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 240, 240);

            TableLayoutPanel mainContainer = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                ColumnCount = 1,
                RowCount = 4
            };

            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 580));
            mainContainer.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            this.Controls.Add(mainContainer);

            // Başlık ve açıklama labelları aynı...
            Label titleLabel = new Label
            {
                Text = "Hakkımızda",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(45, 45, 45),
                Padding = new Padding(0, 20, 0, 0)
            };
            mainContainer.Controls.Add(titleLabel, 0, 0);

            Label descriptionLabel = new Label
            {
                Text = "Bizler, Manisa Celal Bayar Üniversitesi Bilgisayar Programcılığı bölümünde öğrenim gören 2. sınıf öğrencileri olarak teknolojiye ve yazılıma tutku duyan bir ekibiz.",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(70, 70, 70),
                Padding = new Padding(10)
            };
            mainContainer.Controls.Add(descriptionLabel, 0, 1);

            FlowLayoutPanel teamPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10),
                AutoScroll = false,
                WrapContents = true,
                FlowDirection = FlowDirection.LeftToRight
            };
            mainContainer.Controls.Add(teamPanel, 0, 2);

            // Proje kök dizinini al
            string projectRoot = GetProjectRootPath();

            var teamMembers = new[]
            {
                new { Name = "Ömer İlhan", Description = "Projenin Windows Forms uygulamasında form tasarımları üzerine çalıştı. Kullanıcı dostu ve işlevsel bir arayüz oluşturmak için tasarım detaylarına odaklandı.", ImagePath = "omer.jpg" },
                new { Name = "Arda İlktuğ", Description = "Veritabanı tasarımı ve genel kodlama süreçlerinde aktif rol aldı. Projenin işlevselliğini artırmak ve sistemin kararlı bir şekilde çalışmasını sağlamak için çeşitli çözümler geliştirdi.", ImagePath = "arda.jpg" },
                new { Name = "Arhan Goncalı", Description = "Projenin genel koordinasyonunu üstlendi. PHP ve JavaScript kullanarak web tarafını geliştirdi, sistemler arası haberleşmeyi sağladı ve veritabanı yönetimi üzerine çalıştı.", ImagePath = "arhan.png" }
            };

            foreach (var member in teamMembers)
            {
                Panel memberCard = new Panel
                {
                    Width = 230,
                    Height = 500,
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(245, 245, 245),
                    Padding = new Padding(15),
                };

                PictureBox pictureBox = new PictureBox
                {
                    Width = 200,
                    Height = 200,
                    Location = new Point(15, 15),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BorderStyle = BorderStyle.None,
                    BackColor = Color.White
                };

                try
                {
                    // Proje kök dizininden görseli yükle
                    string imagePath = Path.Combine(projectRoot, "assets", "members", member.ImagePath);
                    if (File.Exists(imagePath))
                    {
                        using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            pictureBox.Image = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        pictureBox.BackColor = Color.LightGray;
                        MessageBox.Show($"Görsel bulunamadı: {imagePath}");
                    }
                }
                catch (Exception ex)
                {
                    pictureBox.BackColor = Color.LightGray;
                    MessageBox.Show($"Görsel yüklenirken hata oluştu: {ex.Message}");
                }

                Label nameLabel = new Label
                {
                    Text = member.Name,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(15, 225),
                    AutoSize = true,
                    ForeColor = Color.FromArgb(45, 45, 45)
                };

                Label descLabel = new Label
                {
                    Text = member.Description,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    Location = new Point(15, 255),
                    Width = 200,
                    Height = 200,
                    ForeColor = Color.FromArgb(70, 70, 70)
                };

                memberCard.Controls.Add(pictureBox);
                memberCard.Controls.Add(nameLabel);
                memberCard.Controls.Add(descLabel);
                teamPanel.Controls.Add(memberCard);
            }

            Label footerLabel = new Label
            {
                Text = "Feasto Projesi © 2024",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.FromArgb(100, 100, 100)
            };
            mainContainer.Controls.Add(footerLabel, 0, 3);
        }
    }
}