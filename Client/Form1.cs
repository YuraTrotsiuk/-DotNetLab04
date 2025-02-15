﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
           
        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxChat.Items.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = ChatServerConnector.Connect(textBox1.Text);
           
            if (msg != "OK")
            {
                MessageBox.Show(msg);
                return;
            }
            textBox1.ReadOnly = true;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            ChatServerConnector.GetInstance().SendMessageToServer(textBox2.Text, ChatServerConnector.GetInstance().SelectedUser());
            textBox2.Text = " ";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChatServerConnector.Disconnect();
            Application.Exit();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                textBox2.Text = " ";

            }
        }
    }
}
