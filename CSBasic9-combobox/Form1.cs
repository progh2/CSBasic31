﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSBasic9_combobox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 콤보박스용 데이터 추가
            foodBindingSource.Add(
                new Food() { Name= "삼선해물볶음짬뽕",Price = 8500 });
            foodBindingSource.Add(
                new Food() { Name = "삼선불짜장", Price = 8500 });
            foodBindingSource.Add(
                new Food() { Name = "굴짬뽕", Price = 8000 });
            foodBindingSource.Add(
                new Food() { Name = "육개장", Price = 6500 });
            foodBindingSource.Add(
                new Food() { Name = "짬짜면", Price = 7000 });
            foodBindingSource.Add(
                new Food() { Name = "탕짜면", Price = 8000 });

            comboBox1.SelectedIndexChanged += DataSelect;


            // 리스트박스용 데이터 추가
            foodBindingSource1.Add(
                new Food() { Name = "카페 아메리카노", Price = 4100 });
            foodBindingSource1.Add(
                new Food() { Name = "카페 라떼", Price = 4600 });
            foodBindingSource1.Add(
                new Food() { Name = "카푸치노", Price = 4600 });
            foodBindingSource1.Add(
                new Food() { Name = "오트밀 라떼", Price = 6500 });
            foodBindingSource1.Add(
                new Food() { Name = "카페 모카", Price = 5100 });
            foodBindingSource1.Add(
                new Food() { Name = "리스트레토 비안코", Price = 5200 });
            
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
        }

        private void DataSelect(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            Food food = cb.SelectedItem as Food;
            if(food != null)
            {
                MessageBox.Show(cb.SelectedValue.ToString());
                MessageBox.Show(food.Name + " : " + food.Price);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;
            Food food = lb.SelectedItem as Food;
            if (food != null)
            {
                MessageBox.Show(lb.SelectedValue.ToString());
                MessageBox.Show(food.Name + " : " + food.Price);
            }
        }
    }
}
