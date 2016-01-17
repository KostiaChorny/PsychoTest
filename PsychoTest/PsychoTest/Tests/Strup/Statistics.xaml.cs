﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PsychoTest.Tests.Strup
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        public Statistics()
        {
            InitializeComponent();

            using (var context = new Model.DB())
            {
                var querry = from r in context.StrupTestResults
                             join p in context.StrupPartResults
                             on r.ResultId equals p.StrupResult_ResultId
                             select new
                             {
                                 Name = r.Name,
                                 Date = r.Date,
                                 Part = p.Part,
                                 QuestionCount = p.QuestionsCount,
                                 ErrorsCount = p.ErrorsCount,
                                 Time = p.Time
                             };
                dataGrid.ItemsSource = querry.ToList();
                dataGrid.ColumnWidth = DataGridLength.Auto;


            }
        }

        private void dataGrid_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dataGrid.Columns[0].Header = "Ім'я";
            dataGrid.Columns[1].Header = "Дата і час";
            dataGrid.Columns[2].Header = "Номер тесту";
            dataGrid.Columns[3].Header = "Кількість запитань";
            dataGrid.Columns[4].Header = "Кількість помилок";
            dataGrid.Columns[5].Header = "Витрачений час";
        }
    }
}