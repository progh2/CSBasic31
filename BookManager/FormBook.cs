﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManager
{
    public partial class FormBook : Form
    {
        public FormBook()
        {
            InitializeComponent();
            dataGridView1.DataSource = DataManager.Books;
           
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                Book book = dataGridView1.CurrentRow.DataBoundItem as Book;
                tbISBN.Text = book.Isbn;
                tbBookName.Text = book.Name;
                tbPublisher.Text = book.Publisher;
                tbPage.Text = book.Page.ToString();

            }catch(Exception exception)
            {

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(DataManager.Books.Exists((x)=> x.Isbn == tbISBN.Text))
                {
                    MessageBox.Show("이미 존재하는 도서입니다");
                }
                else
                {
                    Book book = new Book()
                    {
                        Isbn = tbISBN.Text,
                        Name = tbBookName.Text,
                        Publisher = tbPublisher.Text,
                        Page = int.Parse(tbPage.Text)
                    };
                    DataManager.Books.Add(book);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DataManager.Books;
                    DataManager.Save();
                }
            }
            catch (Exception exception)
            {

            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = DataManager.Books.Single((x) => x.Isbn == tbISBN.Text);
                book.Name = tbBookName.Text;
                book.Publisher = tbPublisher.Text;
                book.Page = int.Parse(tbPage.Text);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DataManager.Books;
                DataManager.Save();
            }catch(Exception exception)
            {
                MessageBox.Show("존재하지 않는 도서입니다");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
