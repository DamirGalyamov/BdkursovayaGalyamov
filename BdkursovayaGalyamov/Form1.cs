using DB.Logic.Repositories;
using DB.Logic.Services;
using DB.Storage.Database;
using DB.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace BdkursovayaGalyamov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private Guid UploadingEnterData(DataContext context, Enter_value enterv)
        //{
        //    var enterR = new Enter_valueRepository();
        //    enterR.Create(context, enterv);
        //    context.SaveChanges();
        //    Guid Enterid = enterv.Id;
        //    if (enterv.belt_type != "Клиновый нормальный")
        //    {
        //        var phiR = new Phi0Repository();
        //        var phienter = new Phi0()
        //        {
        //            EnterId = Enterid,
        //            enter_phi0 = double.Parse(comboBox1.SelectedItem.ToString())
        //        };
        //        phiR.Create(context, phienter);
        //        context.SaveChanges();
        //    }
        //    else
        //    {
        //        var sigR = new Sig0Repository();
        //        var sigenter = new Sig0()
        //        {
        //            EnterId = Enterid,
        //            enter_sig0 = double.Parse(textBox7.Text.ToString())
        //        };
        //        sigR.Create(context, sigenter);
        //        context.SaveChanges();
        //    }
        //    return Enterid;
        //}
        private void UploadingOutData(DataContext context, Out_value outv)
        {
            var outR = new Out_valueRepository();
            outR.Create(context, outv);
            context.SaveChanges();
        }

        private void LoadSandq(DataContext context, ref double S, ref double q)
        {
            var belR = new Belt_characteristicService();
            var belch = belR.GetBelt_characteristicQueryable(context, null, true).Where(x => x.profile_type == comboBox4.SelectedItem.ToString())
    .Select(x => new Belt_characteristic
    {
        Id = x.Id,
        profile_type = x.profile_type,
        sectional_area = x.sectional_area,
        Loginlinear_density = x.Loginlinear_density
    })
    .SingleOrDefault();
            S = belch.sectional_area;
            q = belch.Loginlinear_density;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(new string[] { "Клиновый нормальный", "Клиновый узкий", "Поликлиновые" });
            for (double i = 0.1; i <= 0.26; i += 0.01)
            {
                comboBox3.Items.Add(i.ToString());
            }
            comboBox9.Items.AddRange(new string[] { "0,1", "0,9", "0,8", "0,7" });
            for (int i = 110; i <= 180; i += 10)
            {
                comboBox6.Items.Add(i.ToString());
            }
            if (comboBox6.Items.Count > 0)
                comboBox6.SelectedIndex = 0;
            if (comboBox9.Items.Count > 0)
                comboBox9.SelectedIndex = 0;
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0;
            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0;
        }

        private double calculation_Sig0(int Z, double F)
        {


            if (comboBox2.SelectedItem.ToString() == "Клиновый узкий")
            {
                double psi0 = double.Parse(comboBox1.SelectedItem.ToString());
                double C1 = 1;
                double C3 = double.Parse(comboBox9.SelectedItem.ToString());
                double S = 1;
                return F / (2 * psi0 * C1 * C3 * S * Z);
            }
            else if (comboBox2.SelectedItem.ToString() == "Поликлиновые")
            {
                double psi0 = double.Parse(comboBox1.SelectedItem.ToString());
                double C1 = 1;
                double C3 = double.Parse(comboBox9.SelectedItem.ToString());
                double S = 1;
                return 5 * F / (psi0 * C1 * C3 * S * Z);
            }
            else return double.Parse(textBox7.Text.ToString());
        }
        private double calculation_Q0(int Z, double S, double q)
        {
            double sig0 = double.Parse(textBox1.Text.ToString());
            double xi = double.Parse(comboBox3.SelectedItem.ToString());
            if (comboBox2.SelectedItem.ToString() == "Поликлиновые")
                return (sig0 * S + (1 - xi) * q * 10) * Z / 10;
            else return (sig0 * S + (1 - xi) * q * 10) * Z / 10;
        }
        private double calculation_R(int Z, double S)
        {
            double sig0 = double.Parse(textBox1.Text.ToString());
            double xi = double.Parse(comboBox3.SelectedItem.ToString());
            int alpha1 = int.Parse(comboBox6.SelectedItem.ToString());
            if (comboBox2.SelectedItem.ToString() == "Поликлиновые")
                return 2 * sig0 * (S / 10) * Z * Math.Sin(alpha1 * Math.PI / 360);
            else return 2 * sig0 * S * Z * Math.Sin(alpha1 * Math.PI / 360);
        }
        private double calculation_Teta(int Z, double F, double S)
        {
            double sig0 = double.Parse(textBox1.Text.ToString());
            int alpha1 = int.Parse(comboBox6.SelectedItem.ToString());
            int y1 = 180 - alpha1;
            if (comboBox2.SelectedItem.ToString() == "Поликлиновые")
                return Math.Atan((5 * F / (2 * sig0 * S * Z)) * Math.Tan(y1 * Math.PI / 360)) / Math.PI * 180;
            else return Math.Atan((F / (2 * sig0 * S * Z)) * Math.Tan(y1 * Math.PI / 360)) / Math.PI * 180;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool all_text_box_correct = true;
            if (int.TryParse(textBox5.Text, out int Z))
            {
                label8.Visible = false;
            }
            else { all_text_box_correct = false; label8.Visible = true; }
            if (double.TryParse(textBox6.Text, out double F))
            {
                label14.Visible = false;
            }
            else { all_text_box_correct = false; label14.Visible = true; }

            if (comboBox2.SelectedItem.ToString() == "Клиновый нормальный")
            {
                if (double.TryParse(textBox7.Text, out double sig0))
                {
                    label16.Visible = false;
                }
                else { all_text_box_correct = false; label16.Visible = true; }
            }

            if (all_text_box_correct)
            {
                const string DbConnectionString = "Server=localhost,1433;Database= Kursovaya;User ID=sa;Password=<YourStrong@Passw0rd>;MultipleActiveResultSets=true;TrustServerCertificate=True";
                var optionBuilder = new DbContextOptionsBuilder<DataContext>();
                optionBuilder.UseSqlServer(DbConnectionString);
                var context = new DataContext(optionBuilder.Options);

                var enterv = new Enter_value
                {
                    belt_type = comboBox2.SelectedItem.ToString(),
                    profile_type = comboBox4.SelectedItem.ToString(),
                    Z = Z,
                    C3 = double.Parse(comboBox9.SelectedItem.ToString()),
                    F = F,
                    xi = double.Parse(comboBox3.SelectedItem.ToString()),
                    alpha1 = double.Parse(comboBox6.SelectedItem.ToString())

                };
                var enterR = new Enter_valueRepository();
                enterR.Create(context, enterv);
                context.SaveChanges();
                Guid Enterid = enterv.Id;
                if (enterv.belt_type != "Клиновый нормальный")
                {
                    //var phiR = new Phi0Repository();
                    //var phienter = new Phi0()
                    //{
                    //    EnterId = Enterid,
                    //    enter_phi0 = double.Parse(comboBox1.SelectedItem.ToString())
                    //};
                    //phiR.Create(context1, phienter);
                    //context1.SaveChanges();
                }
                else
                {
                    var sigR = new Sig0Repository();
                    var sigenter = new Sig0()
                    {
                        Enter_ValueId = Enterid,
                        enter_sig0 = double.Parse(textBox7.Text.ToString())
                    };
                    sigR.Create(context, sigenter);
                    context.SaveChanges();
                }
                double s = 0;
                double q = 0;
                LoadSandq(context, ref s, ref q);
                double sig0 = calculation_Sig0(Z, F);
                textBox1.Text = sig0.ToString();
                double Q0 = calculation_Q0(Z, s, q);
                textBox2.Text = Q0.ToString();
                double R = calculation_R(Z, s);
                textBox3.Text = R.ToString();
                double Teta = calculation_Teta(Z, F, s);
                textBox4.Text = Teta.ToString();
                var outv = new Out_value
                {
                    Enter_valuesId = Enterid,
                    sigma0 = sig0,
                    Q0 = Q0,
                    R = R,
                    teta = Teta
                };
                //UploadingOutData(contex1, outv);
                context.Dispose();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Поликлиновые")
            {
                comboBox1.Items.Clear();
                switch (comboBox4.SelectedItem.ToString())
                {
                    case "К":
                        for (double i = 0.65; i <= 0.76; i += 0.01)
                        {
                            comboBox1.Items.Add(i.ToString());
                        }
                        break;
                    case "Л":
                        for (double i = 0.75; i <= 0.86; i += 0.01)
                        {
                            comboBox1.Items.Add(i.ToString());
                        }
                        break;
                }
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();

            // Проверяем, что выбрано в первом ComboBox
            switch (comboBox2.SelectedItem.ToString())
            {
                case "Клиновый нормальный":
                    comboBox4.Items.AddRange(new string[] { "О", "А", "Б", "В" });
                    label1.Visible = false;
                    comboBox1.Visible = false;
                    textBox7.Clear();
                    label15.Visible = true;
                    textBox7.Visible = true;
                    break;
                case "Клиновый узкий":
                    comboBox4.Items.AddRange(new string[] { "УО", "УА", "УБ", "УВ" });
                    label1.Visible = true;
                    comboBox1.Visible = true;
                    comboBox1.Items.Clear();
                    label15.Visible = false;
                    textBox7.Visible = false;
                    for (double i = 0.65; i <= 0.86; i += 0.01)
                    {
                        comboBox1.Items.Add(i.ToString());
                    }
                    break;
                case "Поликлиновые":
                    comboBox4.Items.AddRange(new string[] { "К", "Л" });
                    label1.Visible = true;
                    comboBox1.Visible = true;
                    label15.Visible = false;
                    textBox7.Visible = false;
                    comboBox1.Items.Clear();
                    for (double i = 0.65; i <= 0.76; i += 0.01)
                    {
                        comboBox1.Items.Add(i.ToString());
                    }
                    break;
            }

            // Выбрать первый элемент в comboBox2 (опционально)
            if (comboBox4.Items.Count > 0)
                comboBox4.SelectedIndex = 0;
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            comboBox3.Enabled = !checkBox1.Checked;
            if (comboBox3.Enabled == false) { comboBox3.Items.AddRange(new string[] { "1" }); }
            else
            {
                for (double i = 0.1; i <= 0.26; i += 0.01)
                {
                    comboBox3.Items.Add(i.ToString());
                }
            }

            if (comboBox3.Items.Count > 0)
                comboBox3.SelectedIndex = 0;

        }


    }
}
