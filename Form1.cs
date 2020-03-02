using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_App
{
    public partial class Form1 : Form
    {
        // global  veriable for the quiz
        private readonly SortedList<string, bool> Questions = new SortedList<string, bool>()
        {
            {"SSD are faster than HDd", true},
            {"Microsoft owns GitHub", true},
            {"100 is the ASCII code for 'A'", false},

        };
        private int QuestionNumber = -1;
        private int SCore = 0; // User's score

        public Form1()
        {
            InitializeComponent();
            ShowNextQuestion();
        }
        private void ShowNextQuestion()
        {
            QuestionNumber++;
            
            if (QuestionNumber < Questions.Count)
            {
                KeyValuePair<String, bool> question = Questions.ElementAt(QuestionNumber);
                string questionText = question.Key;
                txtQuestion.Text = questionText;

                // Uncheck both RadioButtons
                rdoTrue.Checked = false;
                rdoFalse.Checked = false;
            }
            else
            {
                btnCheckAnswer.Enabled = false;
                btnCheckAnswer.Text = "Quiz over!";
                MessageBox.Show($"Your score is {SCore}", "Quiz Over!");
            }
        }
        private void ChechAnswer()
        {
            // Compare to answerstoredin Question SortedList

            if (QuestionNumber < Questions.Count)
            {
                KeyValuePair<String, bool> Question = Questions.ElementAt(QuestionNumber);
                bool correctAnswer = Question.Value;

                if (correctAnswer == true && rdoTrue.Checked == true)
                {
                    SCore++;
                }
                
                if (correctAnswer == false && rdoFalse.Checked == true)
                {
                    SCore++;
                }
                lblScore.Text = $"Score: {SCore}";
            }
        }
        private void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            // Make sure at least one checkbox is checked
            if(rdoTrue.Checked || rdoFalse.Checked)
            {
                ChechAnswer();
                ShowNextQuestion();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
