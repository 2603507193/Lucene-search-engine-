using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syn.WordNet;


namespace LuceneAdvancedSearchApplication
{
    public partial class GUIForm : Form
    {
        LuceneAdvancedSearchApplication myLucene;
        public static WordNetEngine wordNet;
        public static bool expandState;
        public static bool Weight;
        Button dynamicButton;
        public int button = 0;
        public int currentPage = 1;
     
        public int getButton() {
            if (Standard_button.Checked)
            {
                button = 1;

            }
            else if (Snowball.Checked)
            {
                button = 2;
            }
            else if (Both.Checked)
            {
                button = 3;
            }
            else if(keyword.Checked)
            {
                button = 4;
            }
            return button;
        }

        public GUIForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Create_button()
        {

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
               
            List<List<string>> myResult = new List<List<string>>();
            button = getButton();
         
            myLucene = new LuceneAdvancedSearchApplication(button);
     
            myResult = myLucene.OutPut(TextEnter.Text, currentPage, Source.Text, Index.Text);
            //if (buttonPanel.Contains(dynamicButton))
            //{
            //    buttonPanel.Controls.Clear();                
            //}
            Console.WriteLine(myResult[0].Count);
            CreateButton(myResult[0], myResult[1]);
                 
            //int j = 0;
            //int k = 0;
            //int length = 0;
            for (int i = 0; i < myResult[0].Count; i++)
            {
               
                richTextBox1.Text += myResult[0][i];
              
                
                //if (i % 2 == 0)
                //{
                //    label1.Text = result[i];
                //    richTextBox1.Select(length, result[i].Length);
                //    //richTextBox1.SelectionFont = new Font("Tahoma", 12, FontStyle.Bold);
                //    richTextBox1.SelectionColor = System.Drawing.Color.Red;
                //    length += result[i].Length;
                //}
                //else
                //{
                //    label2.Text = result[i];
                //    //j += j;
                //    richTextBox1.Select(length, result[i].Length);
                //    //richTextBox1.SelectionFont = new Font("Tahoma", 10, FontStyle.Regular);
                //    richTextBox1.SelectionColor = Color.Black;
                //    length += result[i].Length;
                //}


            }
            NumberOfresults.Text =  myResult[3][0];
            querylabel.Text = myResult[4][0];
            //label1.Text = k.ToString();
            //label2.Text = j.ToString();
            //Console.WriteLine(result);
            //richTextBox1.Text = myLucene.OutPut(TextEnter.Text, 1);
        }
  
        private void CreateButton(List<string> result, List<string> text)
        {
            string abstractText = "";
            if (buttonPanel.Contains(dynamicButton))
            {
                buttonPanel.Controls.Clear();
            }
            foreach (var item in text)
            {
                abstractText += item;
            }
            string[] final = new string[1000];
            string[] removetoken = new string[] { "Abstract:" };
            final = abstractText.Split(removetoken, StringSplitOptions.RemoveEmptyEntries);
            //Console.WriteLine(final.Length);

    
            for (int i = 0; i < result.Count ; i++)
            {
                dynamicButton = new Button();
                dynamicButton.Location = new Point(3, 3 + (i+1) * 40);
                dynamicButton.Height = 50;
                dynamicButton.Width = 320;
                dynamicButton.Text = Display_title(result, i);
                //if (final[i] != null)
                //{
                switch (i)
                {
                    case 0:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[0],"Abstract");
                        };
                        break;
                    case 1:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[1], "Abstract");
                        };
                        break;
                    case 2:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[2], "Abstract");
                        };
                        break;
                    case 3:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[3], "Abstract");
                        };
                        break;
                    case 4:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[4], "Abstract");
                        };
                        break;
                    case 5:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[5], "Abstract");
                        };
                        break;
                    case 6:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[6], "Abstract");
                        };
                        break;
                    case 7:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[7], "Abstract");
                        };
                        break;
                    case 8:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[8], "Abstract");
                        };
                        break;
                    case 9:
                        this.dynamicButton.Click += delegate (object sender2, EventArgs e2)
                        {
                            MessageBox.Show(final[9], "Abstract");
                        };
                        break;                   

                } 
                    
                    buttonPanel.Controls.Add(dynamicButton);
                //}
                //else {
                //    break;
                //}
            }
         
        }

        private string Display_title(List<string> result, int i)
        {
            string text = result[i];
            string[] removeToken = new string[] { "Rank:", "Title:", "Author:", "Bibliographic information:", "frist Sentence: " };
            string title = text.Split(removeToken, StringSplitOptions.RemoveEmptyEntries)[1];
           // Console.WriteLine(title);
            return title;
        }
        private void QueryBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //richTextBox1.Text = myLucene.OutPut(TextEnter.Text, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            Source.Text = folderBrowserDialog1.SelectedPath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            Index.Text = saveFileDialog1.FileName;
        }
        public void SaveCountToFile(string filename, List<string> result)
        {
            if (System.IO.File.Exists(filename))
            {
                using (System.IO.StreamWriter writer = System.IO.File.AppendText(filename))
                {
                    foreach (var value in result)
                    {
                        writer.WriteLine(value);
                    }
                }
            }else
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filename))
                {
                    foreach (var value in result)
                    {
                        writer.WriteLine(value);
                    }
                
                }
            }

           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.OverwritePrompt = false;
            saveFileDialog1.ShowDialog();
            label3.Text = saveFileDialog1.FileName;
            button = getButton();
            List<List<string>> myResult = new List<List<string>>();
            myResult = myLucene.OutPut(TextEnter.Text, 1, Source.Text, Index.Text);
            for (int i = 0; i < int.Parse(myResult[2][0]); i++)
            {
                myResult = myLucene.OutPut(TextEnter.Text, (i+1), Source.Text, Index.Text);
                List<string> result = myResult[5];
                SaveCountToFile(label3.Text, result);
            }
            //List<string> result = myResult[5];
            //SaveCountToFile(label3.Text, result);
            //myLucene.SaveCountToFile(label3.Text, myLucene.OutPut(TextEnter.Text, 0, Source.Text, Index.Text));

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LastButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
          
            List<List<string>> myResult = new List<List<string>>();
            button = getButton();
            myLucene = new LuceneAdvancedSearchApplication(button);
            if(currentPage > 1)
            {
                myResult = myLucene.OutPut2(TextEnter.Text, currentPage - 1, Source.Text, Index.Text);
                currentPage -= 1;
                CreateButton(myResult[0], myResult[1]);
                
            }
            else
            {
                myResult = myLucene.OutPut2(TextEnter.Text, 1, Source.Text, Index.Text);
                CreateButton(myResult[0], myResult[1]);
            }     
            for (int i = 0; i < myResult[0].Count; i++)
            {
                richTextBox1.Text += myResult[0][i];
              
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            List<string> result = new List<string>();
            List<List<string>> myResult = new List<List<string>>();
            myResult = myLucene.OutPut2(TextEnter.Text, currentPage, Source.Text, Index.Text);
            button = getButton();
            myLucene = new LuceneAdvancedSearchApplication(button);
            if (currentPage < int.Parse(myResult[2][0]))
            {
                myResult = myLucene.OutPut2(TextEnter.Text, currentPage + 1, Source.Text, Index.Text);
                currentPage += 1;
                CreateButton(myResult[0], myResult[1]);
            }
            else
            {
                myResult = myLucene.OutPut2(TextEnter.Text, int.Parse(myResult[2][0]), Source.Text, Index.Text);
                CreateButton(myResult[0], myResult[1]);
            }
            
            for (int i = 0; i < myResult[0].Count; i++)
            {
                richTextBox1.Text += myResult[0][i];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //var directory = System.IO.Directory.GetCurrentDirectory();
            string directory = @"H:\semester 4\IFN 647\project\LuceneAdvancedSearchApplicationSolutions\LuceneAdvancedSearchApplication\bin\Debug\Wordnet";
            wordNet = new WordNetEngine();

            //MessageBox.Show("Loading database...");
            wordNet.LoadFromDirectory(directory);
            MessageBox.Show("Load completed.");
        }

        private void queryExpansion_CheckedChanged(object sender, EventArgs e)
        {
            if (queryExpansion.Checked)
                expandState = true;
            else
                expandState = false;

        }

        private void WeightTerm_CheckedChanged(object sender, EventArgs e)
        {
            if (WeightTerm.Checked)
                Weight = true;
            else
                Weight = false;
        }
    }
}
