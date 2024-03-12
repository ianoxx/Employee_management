using System.Reflection.Emit;
using System.Windows.Forms;
using System.Linq;

namespace z1
{
    public class Employee
    {
        public int uid;
        public string name;
        private double salary;

        // Конструкторы
        public Employee(int uid)
        {
            this.uid = uid;
            name = "Unnamed";
            salary = 0.0;
        }

        public Employee(int uid, string name)
        {
            this.uid = uid;
            this.name = name;
            salary = 0.0;

        }

        public Employee(int uid, string name, double salary)
        {
            this.uid = uid;
            this.name = name;
            this.salary = salary;
        }

        // Методы доступа к полям класса
        public double GetId()
        {
            return uid;
        }
        public string GetName()
        {
            return name;
        }
        public double GetSalary()
        {
            return salary;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetSalary(double salary)
        {
            this.salary = salary;
        }


        public void IncreaseSalary(double percent)
        {
            salary += salary * percent / 100;
        }

    }
    partial class Form1
    {




        #region Windows Form Designer generated code

        private TextBox textBox1;
        private TextBox textBox2;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox3;
        private Button Button1;
        private Button Button2;
        private Button Button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label5;
        public void Button1_Click(object sender, EventArgs e)
        {
            int[] list_id = make_list_emp();
            int new_id = list_id.Max() + 1;
            if ((richTextBox1.TextLength == 0) && (richTextBox2.TextLength == 0))
                emp_list.Add(new Employee(new_id));
            if ((richTextBox1.TextLength != 0) && (richTextBox2.TextLength == 0))
                emp_list.Add(new Employee(new_id, richTextBox1.Text));
            if ((richTextBox1.TextLength != 0) && (richTextBox2.TextLength != 0))
                {
                try
                {
                    emp_list.Add(new Employee(new_id, richTextBox1.Text, int.Parse(richTextBox2.Text)));
                }
                catch (Exception)
                {
                    richTextBox2.Text = "Введите корректный процент повышения зарплаты!";
                }
            }    
                

            this.comboBox1.DataSource = make_list_emp();
            this.comboBox2.DataSource = make_list_emp();
            show_emp();
        }
        private void richTextBox3_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "Введите корректный процент повышения зарплаты!")
            {
                richTextBox3.Clear();
                richTextBox3.Focus();
            }
        }
        private void richTextBox2_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Text == "Введите корректный процент повышения зарплаты!")
            {
                richTextBox2.Clear();
                richTextBox2.Focus();
            }
        }
        public int[] make_list_emp()
        {
            int[] empNames = emp_list.Select(e => e.uid).ToArray();
            return empNames;
        }

        public void show_emp()
        {
            string st = "";
            int i;
            for (i = 0; i < emp_list.Count; i++)
            {
                st += "ID: " + emp_list[i].GetId() + "; Работник: " + emp_list[i].GetName() + "; Зарплата: " + +emp_list[i].GetSalary() + "\r\n";
            }
            textBox2.Text = st;
        }
        public void Button2_Click(object sender, EventArgs e)
        {
            Employee eploeeToRemove = emp_list.FirstOrDefault(e => e.uid == int.Parse(comboBox1.Text));
            if (eploeeToRemove != null)
            {
                emp_list.Remove(eploeeToRemove);
                this.comboBox1.DataSource = make_list_emp();
                this.comboBox2.DataSource = make_list_emp();
                show_emp();
            }
        }
        public void Button3_Click(object sender, EventArgs e)
        {
            Employee eploeeToRemove = emp_list.FirstOrDefault(e => e.uid == int.Parse(comboBox2.Text));
            if (eploeeToRemove != null)
            {
                try
                {
                    eploeeToRemove.IncreaseSalary(int.Parse(richTextBox3.Text));
                    show_emp();
                }
                catch (Exception)
                {
                    richTextBox3.Text = "Введите корректный процент повышения зарплаты!";
                }
            }
        }
        public void InitializeComponent()
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "Form1";

            this.Label1 = new System.Windows.Forms.Label();
            Label1.Location = new Point(10, 30);
            Label1.Text = "Введите имя сотрудника:";
            Label1.AutoSize = true;
            this.Controls.Add(Label1);

            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1.Location = new System.Drawing.Point(10, 50);
            this.richTextBox1.Size = new System.Drawing.Size(300, 20);
            this.Controls.Add(this.richTextBox1);

            this.Label2 = new System.Windows.Forms.Label();
            Label2.Location = new Point(10, 80);
            Label2.Text = "Введите зарплату сотрудника:";
            Label2.AutoSize = true;
            this.Controls.Add(Label2);

            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2.Location = new System.Drawing.Point(10, 100);
            this.richTextBox2.Size = new System.Drawing.Size(300, 20);
            this.richTextBox2.Click += new System.EventHandler(this.richTextBox2_Click);
            this.Controls.Add(this.richTextBox2);


            this.Button1 = new System.Windows.Forms.Button();
            this.Button1.Location = new System.Drawing.Point(10, 150);
            this.Button1.Size = new System.Drawing.Size(300, 30);
            this.Button1.Text = "Добавить сотрудника";
            this.Controls.Add(this.Button1);
            this.Button1.Click += new System.EventHandler(this.Button1_Click);

            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox2.Location = new System.Drawing.Point(400, 50);
            this.textBox2.AutoSize = false;
            this.textBox2.Size = new System.Drawing.Size(300, 20);
            this.textBox2.Height = 480;
            this.textBox2.Multiline = true;
            this.textBox2.ReadOnly = true;
            this.Controls.Add(this.textBox2);
            show_emp();

            this.Label3 = new System.Windows.Forms.Label();
            Label3.Location = new Point(10, 230);
            Label3.Text = "Выберете ID сотрудника для увольнения:";
            Label3.AutoSize = true;
            this.Controls.Add(Label3);

            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox1.DropDownWidth = 280;
            this.comboBox1.DataSource = make_list_emp();
            this.comboBox1.Location = new System.Drawing.Point(10, 250);
            this.comboBox1.Size = new System.Drawing.Size(300, 20);
            this.comboBox1.TabIndex = 7;
            this.Controls.Add(this.comboBox1);

            this.Button2 = new System.Windows.Forms.Button();
            this.Button2.Location = new System.Drawing.Point(10, 300);
            this.Button2.Size = new System.Drawing.Size(300, 30);
            this.Button2.Text = "Удалить сотрудника:";
            this.Controls.Add(this.Button2);
            this.Button2.Click += new System.EventHandler(this.Button2_Click);





            this.Label4 = new System.Windows.Forms.Label();
            Label4.Location = new Point(10, 380);
            Label4.Text = "Выберете ID сотрудника для повышения зарплаты:";
            Label4.AutoSize = true;
            this.Controls.Add(Label4);

            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox2.DropDownWidth = 280;
            this.comboBox2.DataSource = make_list_emp();
            this.comboBox2.Location = new System.Drawing.Point(10, 400);
            this.comboBox2.Size = new System.Drawing.Size(300, 20);
            this.comboBox2.TabIndex = 7;
            this.Controls.Add(this.comboBox2);

            this.Label5 = new System.Windows.Forms.Label();
            Label5.Location = new Point(10, 430);
            Label5.Text = "Укажите процент повышения зарплаты:";
            Label5.AutoSize = true;
            this.Controls.Add(Label5);

            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3.Location = new System.Drawing.Point(10, 450);
            this.richTextBox3.Size = new System.Drawing.Size(300, 20);
            this.richTextBox3.Click += new System.EventHandler(this.richTextBox3_Click);
            this.Controls.Add(this.richTextBox3);

            this.Button3 = new System.Windows.Forms.Button();
            this.Button3.Location = new System.Drawing.Point(10, 500);
            this.Button3.Size = new System.Drawing.Size(300, 30);
            this.Button3.Text = "Повысить зарплату сотрудника:";
            this.Controls.Add(this.Button3);
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
        }

        #endregion
        List<Employee> emp_list = new List<Employee> { new Employee(1, "Ivan", 50000), new Employee(2, "John", 45000) };

    }
}
