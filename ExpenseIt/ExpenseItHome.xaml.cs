﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get
            {
                return lastChecked;
            }
            set
            {
                lastChecked = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }
            }
        }

        public ObservableCollection<string> PersonsChecked { get; set; }

        public string MainCaptionText { get; set; }

        public List<Person> ExpenseDataSource { get; set; }

        public ExpenseItHome()
        {
            InitializeComponent();

            PersonsChecked = new ObservableCollection<string>();

            ExpenseDataSource = new List<Person>(){
                new Person(){
                    Name = "Mike",
                    Department = "Legal",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Lunch",
                            ExpenseAmount = 50
                        },
                        new Expense() {
                            ExpenseType = "Transportation",
                            ExpenseAmount = 50
                        }
                    }
                },
                new Person(){
                    Name = "Lisa",
                    Department = "Marketing",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Document printing",
                            ExpenseAmount = 50
                        },
                        new Expense() {
                            ExpenseType = "Gift",
                            ExpenseAmount = 125
                        }
                    }
                },
                new Person(){
                    Name = "John",
                    Department = "Engineering",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Magazine subscription",
                            ExpenseAmount = 50
                        },
                        new Expense() {
                            ExpenseType = "New machine",
                            ExpenseAmount = 600
                        },
                        new Expense() {
                            ExpenseType = "Software",
                            ExpenseAmount = 500
                        }
                    }
                },
                new Person(){
                    Name = "Mary",
                    Department ="Finance",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Dinner",
                            ExpenseAmount = 100
                        }
                    }
                },
                new Person(){
                    Name = "Theo",
                    Department = "Marketing",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Dinner",
                            ExpenseAmount = 100
                        }
                    }
                },
                new Person(){
                    Name = "James",
                    Department = "Engineering",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Coffee machine",
                            ExpenseAmount = 3000
                        },
                        new Expense() {
                            ExpenseType = "New printer",
                            ExpenseAmount = 300
                        },
                        new Expense() {
                            ExpenseType = "License",
                            ExpenseAmount = 1000
                        }
                    }
                },
                new Person(){
                    Name = "David",
                    Department = "Engineering",
                    Expenses = new List<Expense>(){
                        new Expense() {
                            ExpenseType = "Magazine subscription",
                            ExpenseAmount = 50
                        },
                        new Expense() {
                            ExpenseType = "New machine",
                            ExpenseAmount = 600
                        },
                        new Expense() {
                            ExpenseType = "Software",
                            ExpenseAmount = 500
                        }
                    }
                }
            };

            this.DataContext = this;
            LastChecked = DateTime.Now;
            MainCaptionText = "View Expense Report :";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReport reportWindow = new ExpenseReport(peopleListBox.SelectedItem);
            reportWindow.Height = this.Height;
            reportWindow.Width = this.Width;
            reportWindow.ShowDialog();
            this.Close();
        }

        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            LastChecked = DateTime.Now;
            PersonsChecked.Add((peopleListBox.SelectedItem as Person).Name);
        }
    }
}
