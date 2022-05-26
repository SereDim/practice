using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace try4
{
	public partial class Form1 : Form
	{
		int start = 0;
		int rs1 = 0;
		int rs2 = 0;
		Button[] mas = new Button[40];
		Button[] mas2 = new Button[40];
		Button[] masday = new Button[5];
		Button[] masday2 = new Button[5];
		String rememberText = "";
		int start2 = 0;
		String rememberText2 = "";
		public Form1()
		{
			InitializeComponent();
			textBox1.AutoSize = false;
			textBox2.AutoSize = false;
			textBox3.AutoSize = false;
			textBox4.AutoSize = false;
			textBox5.AutoSize = false;
			panel1.AutoScroll = true;
			panel1.AutoScrollPosition = new Point(panel1.AutoScrollPosition.X, 0);
			panel1.VerticalScroll.Value = 1;
		}
		private void textBox1_KeyDown(object sender, KeyEventArgs e)//добавить факультет
		{
			if (e.KeyCode == Keys.Enter)
			{
				comboBox1.Items.Add(textBox1.Text);
				comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
				XML xml = new XML();
				xml.SaveIntoXml(textBox1.Text, "Faculties");
				textBox1.Clear();
			}
		}
		private void Form1_Load(object sender, EventArgs e)//Запуск
		{
			XML xml = new XML();         
			if (xml.FileExit("Faculties.xml") == false)
			{
				xml.LoadXmlIntoDocument("Faculties");
			}
			else
			{
				comboBox1 = xml.LoadFromXml(comboBox1,"Faculties");
			}
			if (xml.FileExit("Spec.xml") == false)
			{
				xml.LoadXmlIntoDocument("Spec");
			}
			else
			{
				comboBox2 = xml.LoadFromXml(comboBox2, "Spec");
			}
			if (xml.FileExit("Course.xml") == false)
			{
				xml.LoadXmlIntoDocument("Course");
			}
			else
			{
				comboBox3 = xml.LoadFromXml(comboBox3, "Course");
			}
			if (xml.FileExit("Teacher.xml") == false)
			{
				xml.LoadXmlIntoDocument("Teacher");
			}
			else
			{
				comboBox4 = xml.LoadFromXml(comboBox4, "Teacher");
			}
			for(int i = 0; i < 5; i++)
			{
				
				masday[i] = new Button();
				masday2[i] = new Button();
			}
			ButtonsForDays("Понеділок", 12, masday[0], panel1);
			ButtonsForDays("Вівторок", 509, masday[1], panel1);
			ButtonsForDays("Середа", 1000, masday[2], panel1);
			ButtonsForDays("Четвер", 1495, masday[3], panel1);
			ButtonsForDays("П'ятниця", 1990, masday[4], panel1);
			ButtonsForDays("Понеділок", 12, masday2[0], panel2);
			ButtonsForDays("Вівторок", 509, masday2[1], panel2);
			ButtonsForDays("Середа", 1000, masday2[2], panel2);
			ButtonsForDays("Четвер", 1495, masday2[3], panel2);
			ButtonsForDays("П'ятниця", 1990, masday2[4], panel2);
		}
		private void button2_Click(object sender, EventArgs e)//Кнопка удалить факультет
		{
			XML xml = new XML();
			try
			{				
				xml.RemoveFromXml(Convert.ToString(comboBox1.SelectedItem), "Faculties");
				comboBox1.Items.Remove(comboBox1.SelectedItem);
				for (int i = 0; i < 40; i++)
				{
					if (mas2[i] is not null)
						mas2[i].Dispose();
				}
			}
			catch { }
		}
		private void textBox2_KeyDown(object sender, KeyEventArgs e)//Добавить специальность
		{
			if (e.KeyCode == Keys.Enter)
			{
				comboBox2.Items.Add(textBox2.Text);
				comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
				XML xml = new XML();
				xml.SaveIntoXml(textBox2.Text, "Spec");
				textBox2.Clear();
			}
		}
		private void textBox3_KeyDown(object sender, KeyEventArgs e)//Добавить курс
		{
			if (e.KeyCode == Keys.Enter)
			{
				comboBox3.Items.Add(textBox3.Text);
				comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
				XML xml = new XML();
				xml.SaveIntoXml(textBox3.Text, "Course");
				textBox3.Clear();
			}
		}
		private void textBox4_KeyDown(object sender, KeyEventArgs e) // Добавить учителя
		{
			if (e.KeyCode == Keys.Enter)
			{
				comboBox4.Items.Add(textBox4.Text);
				comboBox4.SelectedIndex = comboBox4.Items.Count - 1;
				XML xml = new XML();
				xml.SaveIntoXml(textBox4.Text, "Teacher");
				textBox4.Clear();
			} 
		}
		private void button1_Click(object sender, EventArgs e)//Кнопка удалить специальность
		{
			XML xml = new XML();
			try
			{
				
					
					xml.RemoveFromXml(Convert.ToString(comboBox2.SelectedItem), "Spec");
					comboBox2.Items.Remove(comboBox2.SelectedItem);
					for (int i = 0; i < 40; i++)
					{
						if (mas2[i] is not null)
							mas2[i].Dispose();
					}
				
			}
			catch { }
		}
		private void button3_Click(object sender, EventArgs e)//Кнопка удалить курс
		{
			XML xml = new XML();
			try
			{
					xml.RemoveFromXml(Convert.ToString(comboBox3.SelectedItem), "Course");
				comboBox3.Items.Remove(comboBox3.SelectedItem);
				for (int i = 0; i < 40; i++)
				{
					if (mas2[i] is not null)
						mas2[i].Dispose();
				}
			}
			catch { }
		}
		private void button4_Click(object sender, EventArgs e)//Кнопка удалить учителя
		{
			XML xml = new XML();
			try
			{
				xml.RemoveFromXml(Convert.ToString(comboBox4.SelectedItem), "Teacher");
				comboBox4.Items.Remove(comboBox4.SelectedItem);
				for (int i = 0; i < 40; i++)
				{
					if (mas[i] is not null)
						mas[i].Dispose();
				}
			}
			catch { }
		}
		private Button InitializeMyButton(string namer, int locationY, Button button11)//Уроки для учителя
		{
			button11.DialogResult = DialogResult.OK;
			Controls.Add(button11);
			button11.AllowDrop = true;
			button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(170)))));
			button11.FlatAppearance.BorderSize = 0;
			button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button11.Location = new System.Drawing.Point(52, locationY - panel1.VerticalScroll.Value);
			button11.Size = new System.Drawing.Size(150, 35);
			button11.TabIndex = 2;
			button11.Text = namer;
			button11.Name = locationY.ToString();
			button11.UseVisualStyleBackColor = false;
			panel1.Controls.Add(button11);
			return button11;
		}
		private Button InitializeMyButton2(string namer, int locationY, Button button11)//Уроки для учеников
		{
			button11.DialogResult = DialogResult.OK;
			Controls.Add(button11);
			button11.AllowDrop = true;
			button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(211)))), ((int)(((byte)(170)))));
			button11.FlatAppearance.BorderSize = 0;
			button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button11.Location = new System.Drawing.Point(52, locationY - panel2.VerticalScroll.Value);
			button11.Size = new System.Drawing.Size(150, 35);
			button11.TabIndex = 2;
			button11.Text = namer;
			button11.Name = locationY.ToString();
			button11.UseVisualStyleBackColor = false;
			panel2.Controls.Add(button11);
			return button11;
		}
		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)//Выбор учителя
		{
			//panel2.VerticalScroll.Value = 0;
			//panel1.VerticalScroll.Value = 0;
			XML xml = new XML();
				if (xml.FileExit($"{comboBox4.SelectedItem.ToString()}.xml") == true)//Если для выбранного объекта сущ файл
				{
				if (start > 0)//Если второй выбранный объект
				{
					if (xml.FileExit($"{rememberText}.xml") == false)//Если предыдущий файла не существует
					{
						xml.LoadXmlIntoDocumentForButton(rememberText);//Создать файл для предыдущего объекта

						for (int i = 0; i < 40; i++)
						{
							xml.saveForButton(i, rememberText, 1, mas[i].Text);// Сохранить данные в этот файл
						}
					}
				}
				if (start > 0)//Удалить предыдущие кнопки
				{
					for (int i = 0; i < 40; i++)
					{
						mas[i].Dispose();
					}
				}//Если выбранный объект первый, инициализация новых кнопок
				int[] indexArray = xml.LoadFromXmlForButton(comboBox4.SelectedItem.ToString()); //массив индексов
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas[i] = new Button();
					int k = 10;
					if (i%8 == 0)
					{
						k = k + 30;
					}
						if (k % 5 == 0)
						{
							if (indexArray[i] == 1)
							{
								InitializeMyButton(comboBox4.SelectedItem.ToString(), 18 + p + k, mas[i]);
								mas[i].Click += new System.EventHandler(this.AllButtonEv_Click);
							}
							p = p + 48 + k;
						}
					} 
			}
			else//Если для выбранного объекта не существует файла
			{
				if (start > 0)//Если второй выбранный объект
				{
					if (xml.FileExit($"{rememberText}.xml") == false)//Если предыдущий файла не существует
					{
						xml.LoadXmlIntoDocumentForButton(rememberText);//Создать файл для предыдущего объекта

						for (int i = 0; i < 40; i++)
						{
							xml.saveForButton(i, rememberText, 1, mas[i].Text);// Сохранить данные в этот файл
						}
					}
				}
				if (start > 0)//Удалить предыдущие кнопки
				{
					for (int i = 0; i < 40; i++)
					{
						mas[i].Dispose();
					}
				}//Если выбранный объект первый, инициализация новых кнопок
				int p = 0;
				for (int i = 0; i < 40; i++)
				{
					mas[i] = new Button();

					int k = 10;
					if (i % 8 == 0)
					{
						k = k + 30;
					}
					if (k % 5 == 0)
					{
						InitializeMyButton(comboBox4.Text, 18 + p + k, mas[i]);
						mas[i].Click += new System.EventHandler(this.AllButtonEv_Click);
						p = p + 48 + k;
					}
				}
			}
			start++;
			rememberText = comboBox4.Text;//запомнить название предыдущего объекта
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
		}
		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//Выбор факультета
		{
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
			XML xml = new XML();
			if (comboBox1.SelectedItem is not null && comboBox2.SelectedItem is not null && comboBox3.SelectedItem is not null)
			{
				String slitno = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
				if (xml.FileExit($"{slitno}.xml") == true)
				{
					if (start2 > 0)//Если второй выбранный объект
					{
						if (xml.FileExit($"{rememberText2}.xml") == false)//Если предыдущий файл уже существует
						{
							xml.LoadXmlIntoDocumentForButton(rememberText2);//Создать новый файл

							for (int i = 0; i < 40; i++)
							{
								xml.saveForButton(i, rememberText2, 1, mas2[i].Text);// Сохранить данные в этот файл
							}
						}
						if (start2 > 0)//Удалить предыдущие кнопки
						{
							for (int i = 0; i < 40; i++)
							{
								mas2[i].Dispose();
							}
						}//Если выбранный объект первый, инициализация новых кнопок
					}
					int[] indexArray = xml.LoadFromXmlForButton(slitno); //array
					string[] textArray = xml.SaveTextForButton(slitno);
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();
						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						if (k % 5 == 0)
						{
							if (textArray[i] == "")
							{
								InitializeMyButton2("", 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							else
							{
								InitializeMyButton2(textArray[i], 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							p = p + 48 + k;
						}
					}
				}
				else
				{
					if (start2 > 0)
					{
						xml.LoadXmlIntoDocumentForButton(rememberText2);

						for (int i = 0; i < 40; i++)
						{
							// ВСТАВИТЬ НАЛИЧИЕ КНОПКИ ДЛЯ ИНДЕКСА
							xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
						}
						for (int i = 0; i < 40; i++)
						{
							mas2[i].Dispose();
						}
					}
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();

						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						InitializeMyButton2("", 18 + p + k, mas2[i]);
						mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
						p = p + 48 + k;
					}
				}
				start2++;
				rememberText2 = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
			}
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
		}
		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)//Выбор специальности
		{
			//panel2.VerticalScroll.Value = 0;
			//panel1.VerticalScroll.Value = 0;
			XML xml = new XML();
			if (comboBox1.SelectedItem is not null && comboBox2.SelectedItem is not null && comboBox3.SelectedItem is not null)
			{
				String slitno = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
				if (xml.FileExit($"{slitno}.xml") == true)
				{
					if (start2 > 0)//Если второй выбранный объект
					{
						if (xml.FileExit($"{rememberText2}.xml") == false)//Если предыдущий файл уже существует
						{
							xml.LoadXmlIntoDocumentForButton(rememberText2);//Создать новый файл

							for (int i = 0; i < 40; i++)
							{
								xml.saveForButton(i, rememberText2, 1, mas2[i].Text);// Сохранить данные в этот файл
							}
						}
						if (start2 > 0)//Удалить предыдущие кнопки
						{
							for (int i = 0; i < 40; i++)
							{
								mas2[i].Dispose();
							}
						}//Если выбранный объект первый, инициализация новых кнопок
					}
					int[] indexArray = xml.LoadFromXmlForButton(slitno); //array
					string[] textArray = xml.SaveTextForButton(slitno);
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();
						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						if (k % 5 == 0)
						{
							if (textArray[i] == "")
							{
								InitializeMyButton2("", 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							else
							{
								InitializeMyButton2(textArray[i], 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							p = p + 48 + k;
						}
					}
				}
				else
				{
					if (start2 > 0)
					{
						xml.LoadXmlIntoDocumentForButton(rememberText2);

						for (int i = 0; i < 40; i++)
						{
							// ВСТАВИТЬ НАЛИЧИЕ КНОПКИ ДЛЯ ИНДЕКСА
							xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
						}
						for (int i = 0; i < 40; i++)
						{
							mas2[i].Dispose();
						}
					}
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();

						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						InitializeMyButton2("", 18 + p + k, mas2[i]);
						p = p + 48 + k;
					}
				}
				start2++;
				rememberText2 = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
			}
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
		}
		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)//Выбор специальности
		{
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
			XML xml = new XML();
			if (comboBox1.SelectedItem is not null && comboBox2.SelectedItem is not null && comboBox3.SelectedItem is not null)
			{
				String slitno = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
				if (xml.FileExit($"{slitno}.xml") == true)
				{
					if (start2 > 0)//Если второй выбранный объект
					{
						if (xml.FileExit($"{rememberText2}.xml") == false)//Если предыдущий файл уже существует
						{
							xml.LoadXmlIntoDocumentForButton(rememberText2);//Создать новый файл

							for (int i = 0; i < 40; i++)
							{
								xml.saveForButton(i, rememberText2, 1, mas2[i].Text);// Сохранить данные в этот файл
							}
						}
						if (start2 > 0)//Удалить предыдущие кнопки
						{
							for (int i = 0; i < 40; i++)
							{
								mas2[i].Dispose();
							}
						}//Если выбранный объект первый, инициализация новых кнопок
					}
					int[] indexArray = xml.LoadFromXmlForButton(slitno); //array
					string[] textArray = xml.SaveTextForButton(slitno);
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();
						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						if (k % 5 == 0)
						{
							if (textArray[i] == "")
							{
								InitializeMyButton2("", 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							else
							{
								InitializeMyButton2(textArray[i], 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							p = p + 48 + k;
						}
					}
				}
				else
				{
					if (start2 > 0)
					{
						xml.LoadXmlIntoDocumentForButton(rememberText2);

						for (int i = 0; i < 40; i++)
						{
							// ВСТАВИТЬ НАЛИЧИЕ КНОПКИ ДЛЯ ИНДЕКСА
							xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
						}
						for (int i = 0; i < 40; i++)
						{
							mas2[i].Dispose();
						}
					}
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();

						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						InitializeMyButton2("", 18 + p + k, mas2[i]);
						mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
						p = p + 48 + k;
					}
				}
				start2++;
				rememberText2 = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
			}
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)//При закрытии
		{
			XML xml = new XML();
			if (start > 0)
			{
				if (xml.FileExit($"{rememberText}.xml") == false)
				{
					xml.LoadXmlIntoDocumentForButton(rememberText);

					for (int i = 0; i < 40; i++)
					{
						// ВСТАВИТЬ НАЛИЧИЕ КНОПКИ ДЛЯ ИНДЕКСА
						xml.saveForButton(i, rememberText, 1, mas[i].Text);
					}
				}
			}
			if (start2 > 0)
			{
				if (xml.FileExit($"{rememberText2}.xml") == false)
				{
					xml.LoadXmlIntoDocumentForButton(rememberText2);

					for (int i = 0; i < 40; i++)
					{
						// ВСТАВИТЬ НАЛИЧИЕ КНОПКИ ДЛЯ ИНДЕКСА
						xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
					}
				}
			}
		}
		private void AllButtonEv_Click(object sender, EventArgs e)//Нажатие на урок учителя
		{
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
			Button btn = (Button)sender;
			XML xml = new XML();//Если нажать на кнопку справа, то происходит инициализация кнопок слева, если выбраны элементы в комбобокс
			if (comboBox1.SelectedItem is not null && comboBox2.SelectedItem is not null && comboBox3.SelectedItem is not null)//ниже код скопирован с комбобокс
			{
				String slitno = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
				if (xml.FileExit($"{slitno}.xml") == true)
				{
					if (start2 > 0)//Если второй выбранный объект
					{
						if (xml.FileExit($"{rememberText2}.xml") == false)//Если предыдущего файла не сущ
						{
							xml.LoadXmlIntoDocumentForButton(rememberText2);//Создать новый файл

							for (int i = 0; i < 40; i++)
							{
								xml.saveForButton(i, rememberText2, 1, mas2[i].Text);// Сохранить данные в этот файл
							}
						}
						if (start2 > 0)//Удалить предыдущие кнопки
						{
							for (int i = 0; i < 40; i++)
							{
								mas2[i].Dispose();
							}
						}//Если выбранный объект первый, инициализация новых кнопок
					}
					int[] indexArray = xml.LoadFromXmlForButton(slitno); //array
					string[] textArray = xml.SaveTextForButton(slitno);
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();
						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						if (k % 5 == 0)
						{
							if (textArray[i] == "")
							{
								InitializeMyButton2("", 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							else
							{
								InitializeMyButton2(textArray[i], 18 + p + k, mas2[i]);
								mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
							}
							p = p + 48 + k;
						}
						if (mas2[i].Name == btn.Name)
						{
							mas2[i].Text = btn.Text;
						}
					}
				}
				else
				{
					if (start2 > 0)
					{
						xml.LoadXmlIntoDocumentForButton(rememberText2);

						for (int i = 0; i < 40; i++)
						{
							// ВСТАВИТЬ НАЛИЧИЕ КНОПКИ ДЛЯ ИНДЕКСА
							xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
						}
						for (int i = 0; i < 40; i++)
						{
							mas2[i].Dispose();
							
						}
					}
					int p = 0;
					for (int i = 0; i < 40; i++)
					{
						mas2[i] = new Button();

						int k = 10;
						if (i % 8 == 0)
						{
							k = k + 30;
						}
						InitializeMyButton2("", 18 + p + k, mas2[i]); ;
						mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
						p = p + 48 + k;
						if (mas2[i].Name == btn.Name)
						{
							mas2[i].Text = btn.Text;
						}
					}
				}
				//конец скопированного с комбобокс
				if (xml.FileExit($"{rememberText}.xml") == false)//Если файла не существует
				{
					xml.LoadXmlIntoDocumentForButton(rememberText);//Создать файл для объекта

					for (int i = 0; i < 40; i++)
					{
						xml.saveForButton(i, rememberText, 1, mas[i].Text);// Сохранить данные в этот файл
					}
				}
				for (int i = 0; i < 40; i++)
				{
					if (mas[i].Name == btn.Name)
					{
						xml.SaveDataForIndex(i,rememberText,0);
						xml.SaveDataForText(i, slitno, btn.Text);
					}
				}
				start2++;
				rememberText2 = $"{comboBox1.Text}{comboBox2.Text}{comboBox3.Text}";
				//сюда вставить новый метод запоминания с какого учителя удалён текст, запоминать за массивом расписания, при удалении такого расписания, все данные
				//востанавливаются на своих места. Для кнопок удаления сделать это
				if (xml.FileExit($"new\\{slitno}.xml") == false)
                {
					xml.LoadXmlIntoDocumentForButton($"new\\{slitno}");//создаём файл
				}
				for (int i = 0; i < 40; i++)//находим место нужной кнопки
				{
					if (mas2[i].Name == btn.Name)
					{
						xml.saveForButton(i, $"new\\{slitno}", 1, btn.Text);//загружаем данные
					}
				}
				btn.Dispose();
			}
			//panel1.VerticalScroll.Value = 0;
			//panel2.VerticalScroll.Value = 0;
		}
		private Button ButtonsForDays(string namer, int locationY, Button button11, Panel panel)//Уроки для учителя
		{
			button11.DialogResult = DialogResult.OK;
			Controls.Add(button11);
			button11.AllowDrop = true;
			button11.FlatAppearance.BorderSize = 0;
			button11.Font = new System.Drawing.Font("Calibri", 14.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button11.Location = new System.Drawing.Point(52, locationY);
			button11.Size = new System.Drawing.Size(150, 35);
			button11.TabIndex = 2;
			button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
			button11.Text = namer;
			button11.Name = locationY.ToString();
			button11.UseVisualStyleBackColor = false;
			panel.Controls.Add(button11);
			return button11;
		}
        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
			panel2.VerticalScroll.Value = panel1.VerticalScroll.Value;
			panel1.VerticalScroll.Value = panel2.VerticalScroll.Value;
		}
		private void LeftButtons_MouseDown(object sender, MouseEventArgs e)//mas2[i].MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButtons_MouseDown);
		{
				XML xml = new XML();
				Button btn = (Button)sender;
				if (e.Button == MouseButtons.Right)
				{

				//panel1.VerticalScroll.Value = 1;
				//panel2.VerticalScroll.Value = 1;
				xml.LoadXmlIntoDocumentForButton(rememberText2);//сохраниени мас2
					for (int i = 0; i < 40; i++)
					{
						xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
					}//окончание сохранения мас2
					btn.Text = textBox5.Text;
						for (int i = 0; i < 40; i++)
						{
							if (mas2[i].Name == btn.Name)
							{
								xml.SaveDataForText(i, rememberText2, btn.Text);
							}
					}
			}
			if (e.Button == MouseButtons.Left)
			{//Когда мы нажимаем на кнопку справа, то это запоминается для дальнейшего востановления

				//panel1.VerticalScroll.Value = 1;
				//panel2.VerticalScroll.Value = 1;
				xml.LoadXmlIntoDocumentForButton(rememberText2);//сохраниени мас2
				for (int i = 0; i < 40; i++)
				{
					xml.saveForButton(i, rememberText2, 1, mas2[i].Text);
				}//окончание сохранения мас2
				btn.Text = "";
				for (int j = 0; j < 40; j++)
				{
					if (mas2[j].Name == btn.Name)
					{
						xml.SaveDataForText(j, rememberText2, btn.Text);
						if (xml.FileExit($"new\\{rememberText2}.xml") == true) 
							{ 
							xml.SaveDataToRecover(rememberText2, j);//сюда лишь вставить инициализацию новых мас1 кнопок и метод востанавления кнопки
							}	
						if (start > 0) { 
							if (xml.FileExit($"{rememberText}.xml") == false)//Если предыдущий файла не существует
							{
								xml.LoadXmlIntoDocumentForButton(rememberText);//Создать файл для предыдущего объекта

								for (int i = 0; i < 40; i++)
								{
									xml.saveForButton(i, rememberText, 1, mas[i].Text);// Сохранить данные в этот файл
								}
							}
							for (int i = 0; i < 40; i++)
							{
								mas[i].Dispose();
							}
						//Если выбранный объект первый, инициализация новых кнопок
						int[] indexArray = xml.LoadFromXmlForButton(comboBox4.SelectedItem.ToString()); //массив индексов
						int p = 0;
							for (int i = 0; i < 40; i++)
							{
								mas[i] = new Button();
								int k = 10;
								if (i % 8 == 0)
								{
									k = k + 30;
								}
								if (k % 5 == 0)
								{
									if (indexArray[i] == 1)
									{
										InitializeMyButton(comboBox4.SelectedItem.ToString(), 18 + p + k, mas[i]);
										mas[i].Click += new System.EventHandler(this.AllButtonEv_Click);
									}
									p = p + 48 + k;
								}
							}
						}

					}
				}
			}
		}
        private void button5_Click(object sender, EventArgs e)
        {
			XML xml = new XML();
			if (comboBox1.SelectedItem is not null && comboBox2.SelectedItem is not null && comboBox3.SelectedItem is not null)
			{
				if (xml.FileExit($"{rememberText2}.xml") == true)
				{
					FileInfo fileInf2 = new FileInfo($"{rememberText2}.xml");
					fileInf2.Delete();
				}
				if (xml.FileExit($"new\\{rememberText2}.xml") == true)
				{
					for (int i = 0; i < 40; i++)
					{
						xml.SaveDataToRecover(rememberText2, i);
					}
					FileInfo fileInf = new FileInfo($"new\\{rememberText2}.xml");
					fileInf.Delete();
					if (comboBox4.SelectedItem is not null)
					{
						if (xml.FileExit($"{comboBox4.SelectedItem.ToString()}.xml") == true)//Если для выбранного объекта сущ файл
						{
							if (start > 0)//Если второй выбранный объект
							{
								if (xml.FileExit($"{rememberText}.xml") == false)//Если предыдущий файла не существует
								{
									xml.LoadXmlIntoDocumentForButton(rememberText);//Создать файл для предыдущего объекта

									for (int i = 0; i < 40; i++)
									{
										xml.saveForButton(i, rememberText, 1, mas[i].Text);// Сохранить данные в этот файл
									}
								}
							}

							if (start > 0)//Удалить предыдущие кнопки
							{
								for (int i = 0; i < 40; i++)
								{
									mas[i].Dispose();
								}
							}//Если выбранный объект первый, инициализация новых кнопок
							int[] indexArray = xml.LoadFromXmlForButton(comboBox4.SelectedItem.ToString()); //массив индексов
							int p = 0;
							for (int i = 0; i < 40; i++)
							{
								mas[i] = new Button();
								int k = 10;
								if (i % 8 == 0)
								{
									k = k + 30;
								}
								if (k % 5 == 0)
								{
									if (indexArray[i] == 1)
									{
										InitializeMyButton(comboBox4.SelectedItem.ToString(), 18 + p + k, mas[i]);
										mas[i].Click += new System.EventHandler(this.AllButtonEv_Click);
									}
									p = p + 48 + k;
								}
							}
						}
						else//Если для выбранного объекта не существует файла
						{
							if (start > 0)//Если второй выбранный объект
							{
								if (xml.FileExit($"{rememberText}.xml") == false)//Если предыдущий файла не существует
								{
									xml.LoadXmlIntoDocumentForButton(rememberText);//Создать файл для предыдущего объекта

									for (int i = 0; i < 40; i++)
									{
										xml.saveForButton(i, rememberText, 1, mas[i].Text);// Сохранить данные в этот файл
									}
								}
							}

							if (start > 0)//Удалить предыдущие кнопки
							{
								for (int i = 0; i < 40; i++)
								{
									mas[i].Dispose();
								}
							}//Если выбранный объект первый, инициализация новых кнопок
							int p = 0;
							for (int i = 0; i < 40; i++)
							{
								mas[i] = new Button();

								int k = 10;
								if (i % 8 == 0)
								{
									k = k + 30;
								}
								if (k % 5 == 0)
								{
									InitializeMyButton(comboBox4.Text, 18 + p + k, mas[i]);
									mas[i].Click += new System.EventHandler(this.AllButtonEv_Click);
									p = p + 48 + k;
								}
							}
						}
						start++;
						rememberText = comboBox4.Text;//запомнить название предыдущего
					}//инициализация кнопок


				}
				for (int i = 0; i < 40; i++)
				{
					if (mas2[i] is not null)
						mas2[i].Dispose();
				}
			}

		}
    }
}
