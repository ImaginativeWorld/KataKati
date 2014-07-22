/// <aboutDev>
/// 
/// Project:
///     KataKati (Tic-tac-toe)
/// 
/// AI design, Graphics and Coding:
///     Md. Mahmudul Hasan Shohag
///     Founder, CEO of Imaginative World
///     http://shohag.imaginativeworld.org
///     
/// Lisence:
///     Opensource project lisense under MPL 2.0.
///     Copyright © Imaginative World. All rights researved.
///     http://imaginativeworld.org
/// 
/// **************************************************
///     This Source Code Form is subject to the
///     terms of the Mozilla Public License, v.
///     2.0. If a copy of the MPL was not
///     distributed with this file, You can obtain
///     one at http://mozilla.org/MPL/2.0/.
/// **************************************************
/// 
/// </aboutDev>

using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KataKuti
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        int step = 0;
        int option = 1;
        int WhatPlayer = 1;
        bool IsNormalMood = false;
        bool IsXtremeMood = false;

        public MainWindow()
        {
            InitializeComponent();
            ClearWindow();

            {
                lblStatus.Visibility = System.Windows.Visibility.Hidden;
                gOK.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            DragMove();
        }

        private void lblBox01_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            lblBoxProcedure(sender);

        }

        private void lblBoxProcedure(object sender)
        {
            if (step == 0)
            {
                btnPCfrist.IsEnabled = false;
                rBtnHvsCPU.IsEnabled = false;
                rBtnHvsH.IsEnabled = false;
                gMode.IsEnabled = false;
            }

            if (((sender as Label).Content != "〤") && ((sender as Label).Content != "〇"))
            {
                step = step + 1;

                if (option == 1)
                {
                    (sender as Label).Content = "〤"; // 〇〤
                    CheckPattern("〤");
                }
                else
                {
                    if (WhatPlayer == 1)
                    {
                        WhatPlayer = 2;

                        (sender as Label).Content = "〤"; // 〇〤
                        CheckPattern("〤");

                    }
                    else
                    {
                        WhatPlayer = 1;

                        (sender as Label).Content = "〇"; // 〇〤
                        CheckPattern("〇");

                    }
                }
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowMessageWinLoose(string str)
        {

            rBtnHvsCPU.Visibility = System.Windows.Visibility.Hidden;
            rBtnHvsH.Visibility = System.Windows.Visibility.Hidden;

            lblBox01.IsEnabled = false;
            lblBox02.IsEnabled = false;
            lblBox03.IsEnabled = false;
            lblBox04.IsEnabled = false;
            lblBox05.IsEnabled = false;
            lblBox06.IsEnabled = false;
            lblBox07.IsEnabled = false;
            lblBox08.IsEnabled = false;
            lblBox09.IsEnabled = false;


            if (str == "〤")
            {

                gInfoBar.Background = new SolidColorBrush(Color.FromRgb(132, 183, 0));
                if (option == 1)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 6);
                    string strText = "";

                    switch (rndNbr)
                    {
                        case 1:
                            strText = "ক্যামনে ক্যামনে জিততা গেছছ্‌..! :/";
                            break;
                        case 2:
                            strText = "গাঘারাও আজকাল খেলা পারে..! O.o";
                            break;
                        case 3:
                            strText = "আপনি জিতছেন..! :(";
                            break;
                        case 4:
                            strText = "আপনি বিজয়ী..! :(";
                            break;
                        case 5:
                            strText = "যা, তালগাছ তোর..! :/";
                            break;
                    }

                    lblStatus.Content = strText;
                }
                else
                {
                    lblStatus.Content = "১ম খেলোয়ার (〤) বিজয়ী.. :)";
                }

                lblStatus.Visibility = System.Windows.Visibility.Visible;
                gOK.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
               
                if (option == 1)
                {
                    gInfoBar.Background = new SolidColorBrush(Color.FromRgb(218, 41, 41));

                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 7);
                    string strText = "";

                    switch (rndNbr)
                    {
                        case 1:
                            strText = "তুই তো খ্যালাই পারস না! যা দ্যায়ালে বাড়ি খা.. :p";
                            break;
                        case 2:
                            strText = "ব্রেন হাটুতে নিয়া ঘুরলে পারবাইন কেমনে! :p";
                            break;
                        case 3:
                            strText = "পারসনা ক্যারে! রাতে ভাত খাসনাই? :p";
                            break;
                        case 4:
                            strText = "যা টয়লেটে গিয়া স্পেশাল পানি খায়া আয়.. :p";
                            break;
                        case 5:
                            strText = "হারপিক দিয়া মুরি খায়া আয়.. :p";
                            break;
                        case 6:
                            strText = "যান ললিপপ খান.. বুদ্ধি বাড়ান.. :p";
                            break;
                    }

                    lblStatus.Content = strText;
                }
                else
                {
                    gInfoBar.Background = new SolidColorBrush(Color.FromRgb(132, 183, 0));
                    lblStatus.Content = "২য় খেলোয়ার (〇) বিজয়ী.. :)";
                }
                lblStatus.Visibility = System.Windows.Visibility.Visible;
                gOK.Visibility = System.Windows.Visibility.Visible;
            }

        }



        private void CheckPattern(string str)
        {

            if ((lblBox01.Content == str) && (lblBox02.Content == str) && (lblBox03.Content == str))
            {
                lblBox01.Foreground = new SolidColorBrush(Colors.Red);
                lblBox02.Foreground = new SolidColorBrush(Colors.Red);
                lblBox03.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox04.Content == str) && (lblBox05.Content == str) && (lblBox06.Content == str))
            {
                lblBox04.Foreground = new SolidColorBrush(Colors.Red);
                lblBox05.Foreground = new SolidColorBrush(Colors.Red);
                lblBox06.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox07.Content == str) && (lblBox08.Content == str) && (lblBox09.Content == str))
            {
                lblBox07.Foreground = new SolidColorBrush(Colors.Red);
                lblBox08.Foreground = new SolidColorBrush(Colors.Red);
                lblBox09.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox01.Content == str) && (lblBox04.Content == str) && (lblBox07.Content == str))
            {
                lblBox01.Foreground = new SolidColorBrush(Colors.Red);
                lblBox04.Foreground = new SolidColorBrush(Colors.Red);
                lblBox07.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox02.Content == str) && (lblBox05.Content == str) && (lblBox08.Content == str))
            {
                lblBox02.Foreground = new SolidColorBrush(Colors.Red);
                lblBox05.Foreground = new SolidColorBrush(Colors.Red);
                lblBox08.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox03.Content == str) && (lblBox06.Content == str) && (lblBox09.Content == str))
            {
                lblBox03.Foreground = new SolidColorBrush(Colors.Red);
                lblBox06.Foreground = new SolidColorBrush(Colors.Red);
                lblBox09.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox01.Content == str) && (lblBox05.Content == str) && (lblBox09.Content == str))
            {
                lblBox01.Foreground = new SolidColorBrush(Colors.Red);
                lblBox05.Foreground = new SolidColorBrush(Colors.Red);
                lblBox09.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else if ((lblBox07.Content == str) && (lblBox05.Content == str) && (lblBox03.Content == str))
            {
                lblBox07.Foreground = new SolidColorBrush(Colors.Red);
                lblBox05.Foreground = new SolidColorBrush(Colors.Red);
                lblBox03.Foreground = new SolidColorBrush(Colors.Red);
                ShowMessageWinLoose(str);
            }
            else
            {
                if ((lblBox01.Content == "") || (lblBox02.Content == "") || (lblBox03.Content == "")
                    || (lblBox04.Content == "") || (lblBox05.Content == "") || (lblBox06.Content == "")
                    || (lblBox07.Content == "") || (lblBox08.Content == "") || (lblBox09.Content == ""))
                {
                    if (option == 1) //Human vs CPU
                    {
                        if (str == "〤")
                        {
                            CheckPatternAI_User();
                        }
                    }
                    else //Human vs Human
                    {
                        rBtnHvsCPU.Visibility = System.Windows.Visibility.Hidden;
                        rBtnHvsH.Visibility = System.Windows.Visibility.Hidden;
                        gInfoBar.Background = new SolidColorBrush(Color.FromRgb(51, 153, 255));

                        if (WhatPlayer == 1)
                        {
                            lblStatus.Content = "১ম খেলোয়ার (〤)";
                        }
                        else
                        {
                            lblStatus.Content = "২য় খেলোয়ার (〇)";
                        }

                        lblStatus.Visibility = System.Windows.Visibility.Visible;
                    }

                }
                else
                {
                    rBtnHvsCPU.Visibility = System.Windows.Visibility.Hidden;
                    rBtnHvsH.Visibility = System.Windows.Visibility.Hidden;

                    lblBox01.IsEnabled = false;
                    lblBox02.IsEnabled = false;
                    lblBox03.IsEnabled = false;
                    lblBox04.IsEnabled = false;
                    lblBox05.IsEnabled = false;
                    lblBox06.IsEnabled = false;
                    lblBox07.IsEnabled = false;
                    lblBox08.IsEnabled = false;
                    lblBox09.IsEnabled = false;

                    gInfoBar.Background = new SolidColorBrush(Color.FromRgb(64, 64, 64));
                    lblStatus.Content = "খ্যালা খতম! টেরাই পরের টাইম..";
                    lblStatus.Visibility = System.Windows.Visibility.Visible;
                    gOK.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void CheckPatternAI_User()
        {
            string strUser = "〤";
            string strCPU = "〇";
            // 1st group
            if ((lblBox01.Content == strUser) && (lblBox02.Content == strUser) && (lblBox03.Content != strCPU)
                && (lblBox03.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox03);
            }
            else if ((lblBox04.Content == strUser) && (lblBox05.Content == strUser) && (lblBox06.Content != strCPU)
                && (lblBox06.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox06);
            }
            else if ((lblBox07.Content == strUser) && (lblBox08.Content == strUser) && (lblBox09.Content != strCPU)
                && (lblBox09.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox09);
            }
            else if ((lblBox01.Content == strUser) && (lblBox04.Content == strUser) && (lblBox07.Content != strCPU)
                && (lblBox07.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox07);
            }
            else if ((lblBox02.Content == strUser) && (lblBox05.Content == strUser) && (lblBox08.Content != strCPU)
                && (lblBox08.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox08);
            }
            else if ((lblBox03.Content == strUser) && (lblBox06.Content == strUser) && (lblBox09.Content != strCPU)
                && (lblBox09.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox09);
            }
            else if ((lblBox01.Content == strUser) && (lblBox05.Content == strUser) && (lblBox09.Content != strCPU)
                && (lblBox09.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox09);
            }
            else if ((lblBox07.Content == strUser) && (lblBox05.Content == strUser) && (lblBox03.Content != strCPU)
                && (lblBox03.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox03);
            }
            // 2nd group
            else if ((lblBox02.Content == strUser) && (lblBox03.Content == strUser) && (lblBox01.Content != strCPU)
                && (lblBox01.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox01);
            }
            else if ((lblBox05.Content == strUser) && (lblBox06.Content == strUser) && (lblBox04.Content != strCPU)
                && (lblBox04.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox04);
            }
            else if ((lblBox08.Content == strUser) && (lblBox09.Content == strUser) && (lblBox07.Content != strCPU)
                && (lblBox07.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox07);
            }
            else if ((lblBox04.Content == strUser) && (lblBox07.Content == strUser) && (lblBox01.Content != strCPU)
                && (lblBox01.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox01);
            }
            else if ((lblBox05.Content == strUser) && (lblBox08.Content == strUser) && (lblBox02.Content != strCPU)
                && (lblBox02.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox02);
            }
            else if ((lblBox06.Content == strUser) && (lblBox09.Content == strUser) && (lblBox03.Content != strCPU)
                && (lblBox03.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox03);
            }
            else if ((lblBox05.Content == strUser) && (lblBox09.Content == strUser) && (lblBox01.Content != strCPU)
                && (lblBox01.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox01);
            }
            else if ((lblBox05.Content == strUser) && (lblBox03.Content == strUser) && (lblBox07.Content != strCPU)
                && (lblBox07.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox07);
            }
            // 3rd Group
            else if ((lblBox01.Content == strUser) && (lblBox03.Content == strUser) && (lblBox02.Content != strCPU)
                 && (lblBox02.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox02);
            }
            else if ((lblBox04.Content == strUser) && (lblBox06.Content == strUser) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox05);
            }
            else if ((lblBox07.Content == strUser) && (lblBox09.Content == strUser) && (lblBox08.Content != strCPU)
                && (lblBox08.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox08);
            }
            else if ((lblBox01.Content == strUser) && (lblBox07.Content == strUser) && (lblBox04.Content != strCPU)
                && (lblBox04.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox04);
            }
            else if ((lblBox02.Content == strUser) && (lblBox08.Content == strUser) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox05);
            }
            else if ((lblBox03.Content == strUser) && (lblBox09.Content == strUser) && (lblBox06.Content != strCPU)
                && (lblBox06.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox06);
            }
            else if ((lblBox01.Content == strUser) && (lblBox09.Content == strUser) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox05);
            }
            else if ((lblBox07.Content == strUser) && (lblBox03.Content == strUser) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                CheckPatternAI_CPU(lblBox05);
            }
            // 4th Group Extreme
            else if (IsNormalMood == true)
            {
                if
                (
                ((lblBox01.Content == strUser) || (lblBox03.Content == strUser)
                || (lblBox07.Content == strUser) || (lblBox09.Content == strUser))
                && ((lblBox05.Content != strUser) && (lblBox05.Content != strCPU))
                )
                {
                    CheckPatternAI_CPU(lblBox05);
                }
                else if ((lblBox05.Content == strUser) &&
                    (lblBox01.Content != strCPU) && (lblBox03.Content != strCPU)
                    && (lblBox07.Content != strCPU) && (lblBox09.Content != strCPU) &&
                    (lblBox01.Content != strUser) && (lblBox03.Content != strUser)
                    && (lblBox07.Content != strUser) && (lblBox09.Content != strUser))
                {

                    CheckPatternAI_CPU(null, 1); 
                }
                else if (IsXtremeMood == true)
                {
                    if (
                        (
                        ((lblBox01.Content == strUser) && (lblBox09.Content == strUser))
                        ||
                        ((lblBox03.Content == strUser) && (lblBox07.Content == strUser))
                        ) && (
                        (lblBox02.Content != strUser) && (lblBox02.Content != strCPU) &&
                        (lblBox04.Content != strUser) && (lblBox04.Content != strCPU) &&
                        (lblBox06.Content != strUser) && (lblBox06.Content != strCPU) &&
                        (lblBox08.Content != strUser) && (lblBox08.Content != strCPU)
                        )
                       )
                    {
                        ///  1(2)    2       3(3)
                        ///  4       5       6
                        ///  7       8       9(1)

                        CheckPatternAI_CPU(null, 2); 
                    }
                        ///  1(2)    2       3
                        ///  4(4)    5       6
                        ///  7(3)    8(1)    9
                        ///  
                        /// OR
                        /// 
                        ///  1(3)    2(4)    3(1)
                        ///  4(2)    5       6
                        ///  7       8       9
                    else if (
                        ((lblBox01.Content == strUser) && (lblBox08.Content == strUser) &&
                        (lblBox04.Content != strUser) && (lblBox04.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox04, 0); 
                    }
                    else if (
                        ((lblBox03.Content == strUser) && (lblBox04.Content == strUser) &&
                        (lblBox02.Content != strUser) && (lblBox02.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox02, 0); 
                    }
                    else if (
                        ((lblBox02.Content == strUser) && (lblBox09.Content == strUser) &&
                        (lblBox06.Content != strUser) && (lblBox06.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox06, 0); 
                    }
                    else if (
                        ((lblBox06.Content == strUser) && (lblBox07.Content == strUser) &&
                        (lblBox08.Content != strUser) && (lblBox08.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox08, 0); 
                    }
                        //another trick; Conflict with Pattern 5 so dismissed :)
                    //else if (
                    //    (((lblBox02.Content == strUser) || (lblBox08.Content == strUser)) &&
                    //    (lblBox04.Content != strUser) && (lblBox04.Content != strCPU) &&
                    //    (lblBox06.Content != strUser) && (lblBox06.Content != strCPU))
                    //    )
                    //{
                    //    CheckPatternAI_CPU(null, 3);
                    //}
                    //else if (
                    //    (((lblBox04.Content == strUser) || (lblBox06.Content == strUser)) &&
                    //    (lblBox02.Content != strUser) && (lblBox02.Content != strCPU) &&
                    //    (lblBox08.Content != strUser) && (lblBox08.Content != strCPU))
                    //    )
                    //{
                    //    CheckPatternAI_CPU(null, 4);
                    //}

                        /// 1       2       3(1)
                        /// 4(3)    5       6
                        /// 7(4)    8(2)    9

                    else if (
                        ((lblBox04.Content == strUser) && (lblBox08.Content == strUser) &&
                        (lblBox07.Content != strUser) && (lblBox07.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox07, 0); 
                    }
                    else if (
                        ((lblBox04.Content == strUser) && (lblBox02.Content == strUser) &&
                        (lblBox01.Content != strUser) && (lblBox01.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox01, 0);
                    }
                    else if (
                        ((lblBox06.Content == strUser) && (lblBox02.Content == strUser) &&
                        (lblBox03.Content != strUser) && (lblBox03.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox03, 0);
                    }
                    else if (
                        ((lblBox06.Content == strUser) && (lblBox08.Content == strUser) &&
                        (lblBox09.Content != strUser) && (lblBox09.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox09, 0);
                    }
                        /// New Tricks!
                        /// 
                        /// 1       2       3[3]
                        /// 4 [1]   5(3)    6
                        /// 7(2)    8(1)    9[2]
                        /// 
                        /// Pattern:
                        /// 2, 4, 6, 8 => 1, 3, 7, 9
                    else if
                        (
                        ((lblBox02.Content == strUser) || (lblBox04.Content == strUser)
                        || (lblBox06.Content == strUser) || (lblBox08.Content == strUser))
                        && ((lblBox05.Content != strUser) && (lblBox05.Content != strCPU))
                        )
                    {
                        CheckPatternAI_CPU(lblBox05);
                    }
                        /// 1       2       3[1]
                        /// 4       5(1)    6[2]
                        /// 7(2)    8       9(3)
                        /// 
                        /// Pattern:
                        /// 1, 5, 9[CPU] => 7, 3
                        /// 9, 5, 1[CPU] => 7, 3
                        /// 3, 5, 7[CPU] => 1, 9
                        /// 7, 5, 3[CPU] => 1, 9
                    else if
                        (
                        (lblBox01.Content == strUser) && (lblBox05.Content == strUser)
                        && (lblBox09.Content == strCPU)
                        && (lblBox07.Content != strUser) && (lblBox07.Content != strCPU)
                        && (lblBox03.Content != strUser) && (lblBox03.Content != strCPU)
                        )
                    {
                        CheckPatternAI_CPU(null, 5); // 3, 7
                    }
                    else if
                        (
                        (lblBox09.Content == strUser) && (lblBox05.Content == strUser)
                        && (lblBox01.Content == strCPU)
                        && (lblBox07.Content != strUser) && (lblBox07.Content != strCPU)
                        && (lblBox03.Content != strUser) && (lblBox03.Content != strCPU)
                        )
                    {
                        CheckPatternAI_CPU(null, 5); // 3, 7
                    }
                    else if
                        (
                        (lblBox03.Content == strUser) && (lblBox05.Content == strUser)
                        && (lblBox07.Content == strCPU)
                        && (lblBox01.Content != strUser) && (lblBox01.Content != strCPU)
                        && (lblBox09.Content != strUser) && (lblBox09.Content != strCPU)
                        )
                    {
                        CheckPatternAI_CPU(null, 6); // 1, 9
                    }
                    else if
                        (
                        (lblBox07.Content == strUser) && (lblBox05.Content == strUser)
                        && (lblBox03.Content == strCPU)
                        && (lblBox01.Content != strUser) && (lblBox01.Content != strCPU)
                        && (lblBox09.Content != strUser) && (lblBox09.Content != strCPU)
                        )
                    {
                        CheckPatternAI_CPU(null, 6); // 1, 9
                    }
                    else
                    {

                        CheckPatternAI_CPU();

                    }

                }
                else
                {

                    CheckPatternAI_CPU();

                }
            }
            else
            {

                RandomPattern_AI();

            }
        }

        private void CheckPatternAI_CPU(object sender = null, int WhickPattern = 0)
        {  
            string strCPU = "〇";
            string strUser = "〤";

            // 1st group
            if ((lblBox01.Content == strCPU) && (lblBox02.Content == strCPU) && (lblBox03.Content != strCPU)
                && (lblBox03.Content != strUser))
            {
                lblBox03.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox04.Content == strCPU) && (lblBox05.Content == strCPU) && (lblBox06.Content != strCPU)
                && (lblBox06.Content != strUser))
            {
                lblBox06.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox07.Content == strCPU) && (lblBox08.Content == strCPU) && (lblBox09.Content != strCPU)
                && (lblBox09.Content != strUser))
            {
                lblBox09.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox01.Content == strCPU) && (lblBox04.Content == strCPU) && (lblBox07.Content != strCPU)
                && (lblBox07.Content != strUser))
            {
                lblBox07.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox02.Content == strCPU) && (lblBox05.Content == strCPU) && (lblBox08.Content != strCPU)
                && (lblBox08.Content != strUser))
            {
                lblBox08.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox03.Content == strCPU) && (lblBox06.Content == strCPU) && (lblBox09.Content != strCPU)
                && (lblBox09.Content != strUser))
            {
                lblBox09.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox01.Content == strCPU) && (lblBox05.Content == strCPU) && (lblBox09.Content != strCPU)
                && (lblBox09.Content != strUser))
            {
                lblBox09.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox07.Content == strCPU) && (lblBox05.Content == strCPU) && (lblBox03.Content != strCPU)
                && (lblBox03.Content != strUser))
            {
                lblBox03.Content = strCPU;
                CheckPattern(strCPU);
            }
            // 2nd group
            else if ((lblBox02.Content == strCPU) && (lblBox03.Content == strCPU) && (lblBox01.Content != strCPU)
                && (lblBox01.Content != strUser))
            {
                lblBox01.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox05.Content == strCPU) && (lblBox06.Content == strCPU) && (lblBox04.Content != strCPU)
                && (lblBox04.Content != strUser))
            {
                lblBox04.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox08.Content == strCPU) && (lblBox09.Content == strCPU) && (lblBox07.Content != strCPU)
                && (lblBox07.Content != strUser))
            {
                lblBox07.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox04.Content == strCPU) && (lblBox07.Content == strCPU) && (lblBox01.Content != strCPU)
                && (lblBox01.Content != strUser))
            {
                lblBox01.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox05.Content == strCPU) && (lblBox08.Content == strCPU) && (lblBox02.Content != strCPU)
                && (lblBox02.Content != strUser))
            {
                lblBox02.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox06.Content == strCPU) && (lblBox09.Content == strCPU) && (lblBox03.Content != strCPU)
                && (lblBox03.Content != strUser))
            {
                lblBox03.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox05.Content == strCPU) && (lblBox09.Content == strCPU) && (lblBox01.Content != strCPU)
                && (lblBox01.Content != strUser))
            {
                lblBox01.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox05.Content == strCPU) && (lblBox03.Content == strCPU) && (lblBox07.Content != strCPU)
                && (lblBox07.Content != strUser))
            {
                lblBox07.Content = strCPU;
                CheckPattern(strCPU);
            }
            // 3rd Group
            else if ((lblBox01.Content == strCPU) && (lblBox03.Content == strCPU) && (lblBox02.Content != strCPU)
                           && (lblBox02.Content != strUser))
            {
                lblBox02.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox04.Content == strCPU) && (lblBox06.Content == strCPU) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                lblBox05.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox07.Content == strCPU) && (lblBox09.Content == strCPU) && (lblBox08.Content != strCPU)
                && (lblBox08.Content != strUser))
            {
                lblBox08.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox01.Content == strCPU) && (lblBox07.Content == strCPU) && (lblBox04.Content != strCPU)
                && (lblBox04.Content != strUser))
            {
                lblBox04.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox02.Content == strCPU) && (lblBox08.Content == strCPU) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                lblBox05.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox03.Content == strCPU) && (lblBox09.Content == strCPU) && (lblBox06.Content != strCPU)
                && (lblBox06.Content != strUser))
            {
                lblBox06.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox01.Content == strCPU) && (lblBox09.Content == strCPU) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                lblBox05.Content = strCPU;
                CheckPattern(strCPU);
            }
            else if ((lblBox07.Content == strCPU) && (lblBox03.Content == strCPU) && (lblBox05.Content != strCPU)
                && (lblBox05.Content != strUser))
            {
                lblBox05.Content = strCPU;
                CheckPattern(strCPU);
            }
            // 4th Group Extreme (Work done part)
            else
            {
                if (WhickPattern == 1)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1,5);

                    switch (rndNbr)
                    {
                        case 1:
                            lblBox01.Content = strCPU;

                            break;

                        case 2:
                            lblBox03.Content = strCPU;

                            break;

                        case 3:
                            lblBox07.Content = strCPU;

                            break;

                        case 4:
                            lblBox09.Content = strCPU;

                            break;
                    }


                }
                else if (WhickPattern == 2)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 5);

                    switch (rndNbr)
                    {
                        case 1:
                            lblBox02.Content = strCPU;

                            break;

                        case 2:
                            lblBox04.Content = strCPU;

                            break;

                        case 3:
                            lblBox06.Content = strCPU;

                            break;

                        case 4:
                            lblBox08.Content = strCPU;

                            break;
                    }
                }
                else if (WhickPattern == 3)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 3);

                    switch (rndNbr)
                    {
                        case 1:
                            lblBox04.Content = strCPU;

                            break;

                        case 2:
                            lblBox06.Content = strCPU;

                            break;

                    }
                }
                else if (WhickPattern == 4)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 3);

                    switch (rndNbr)
                    {
                        case 1:
                            lblBox02.Content = strCPU;

                            break;

                        case 2:
                            lblBox08.Content = strCPU;

                            break;

                    }
                }
                else if (WhickPattern == 5)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 3);

                    switch (rndNbr)
                    {
                        case 1:
                            lblBox03.Content = strCPU;

                            break;

                        case 2:
                            lblBox07.Content = strCPU;

                            break;

                    }
                }
                else if (WhickPattern == 6)
                {
                    Random rnd = new Random();
                    int rndNbr = rnd.Next(1, 3);

                    switch (rndNbr)
                    {
                        case 1:
                            lblBox01.Content = strCPU;

                            break;

                        case 2:
                            lblBox09.Content = strCPU;

                            break;

                    }
                }
                else
                {
                    if (sender is Label)
                    {
                        (sender as Label).Content = strCPU;
                        CheckPattern(strCPU);
                    }
                    else
                    {

                        RandomPattern_AI();

                    }
                }

            }
        }

        private void ClearWindow()
        {
            lblBox01.IsEnabled = true;
            lblBox02.IsEnabled = true;
            lblBox03.IsEnabled = true;
            lblBox04.IsEnabled = true;
            lblBox05.IsEnabled = true;
            lblBox06.IsEnabled = true;
            lblBox07.IsEnabled = true;
            lblBox08.IsEnabled = true;
            lblBox09.IsEnabled = true;

            lblBox01.Content = "";
            lblBox02.Content = "";
            lblBox03.Content = "";
            lblBox04.Content = "";
            lblBox05.Content = "";
            lblBox06.Content = "";
            lblBox07.Content = "";
            lblBox08.Content = "";
            lblBox09.Content = "";

            lblBox01.Foreground = new SolidColorBrush(Colors.Black);
            lblBox02.Foreground = new SolidColorBrush(Colors.Black);
            lblBox03.Foreground = new SolidColorBrush(Colors.Black);
            lblBox04.Foreground = new SolidColorBrush(Colors.Black);
            lblBox05.Foreground = new SolidColorBrush(Colors.Black);
            lblBox06.Foreground = new SolidColorBrush(Colors.Black);
            lblBox07.Foreground = new SolidColorBrush(Colors.Black);
            lblBox08.Foreground = new SolidColorBrush(Colors.Black);
            lblBox09.Foreground = new SolidColorBrush(Colors.Black);

            step = 0;
            WhatPlayer = 1;

            gInfoBar.Background = new SolidColorBrush(Color.FromRgb(51, 153, 255));
            lblStatus.Visibility = System.Windows.Visibility.Hidden;
            gOK.Visibility = System.Windows.Visibility.Hidden;
            lblStatus.Content = "";

            btnPCfrist.IsEnabled = true;
            rBtnHvsCPU.Visibility = System.Windows.Visibility.Visible;
            rBtnHvsH.Visibility = System.Windows.Visibility.Visible;

            rBtnHvsCPU.IsEnabled = true;
            rBtnHvsH.IsEnabled = true;

            if (option == 1)
            {
                gMode.IsEnabled = true;
            }
            else
            {
                gMode.IsEnabled = false;
            }
        }

        private void RandomPattern_AI()
        {
            Random rnd = new Random();
            int rndBoxNbr = rnd.Next(1, 10);

            boxCheck(rndBoxNbr);

        }

        private void boxCheck(int integer)
        {
            switch (integer)
            {
                case 1:
                    if ((lblBox01.Content == "〤") || (lblBox01.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox01.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 2:
                    if ((lblBox02.Content == "〤") || (lblBox02.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox02.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 3:
                    if ((lblBox03.Content == "〤") || (lblBox03.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox03.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 4:
                    if ((lblBox04.Content == "〤") || (lblBox04.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox04.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 5:
                    if ((lblBox05.Content == "〤") || (lblBox05.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox05.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 6:
                    if ((lblBox06.Content == "〤") || (lblBox06.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox06.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 7:
                    if ((lblBox07.Content == "〤") || (lblBox07.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox07.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 8:
                    if ((lblBox08.Content == "〤") || (lblBox08.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox08.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
                case 9:
                    if ((lblBox09.Content == "〤") || (lblBox09.Content == "〇"))
                    {
                        INorDEcreaseInt(integer);
                    }
                    else
                    {
                        lblBox09.Content = "〇";
                        CheckPattern("〇");
                    }
                    break;
            }
        }


        private void INorDEcreaseInt(int integer)
        {
            integer = integer + 1;
            if (integer > 9)
            {
                boxCheck(1);
            }
            else
            {
                boxCheck(integer);
            }
        }

        private void btnPCfrist_Click(object sender, RoutedEventArgs e)
        {
            RandomPattern_AI();
            btnPCfrist.IsEnabled = false;
        }

        private void gOK_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ClearWindow();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ClearWindow();
        }


        private void winMain_KeyUp(object sender, KeyEventArgs e)
        { 
            if (lblBox01.IsEnabled == true)
            {
                if (e.Key == Key.NumPad7)
                {
                    lblBoxProcedure(lblBox01);
                }
                else if (e.Key == Key.NumPad8)
                {
                    lblBoxProcedure(lblBox02);
                }
                else if (e.Key == Key.NumPad9)
                {
                    lblBoxProcedure(lblBox03);
                }
                else if (e.Key == Key.NumPad4)
                {
                    lblBoxProcedure(lblBox04);
                }
                else if (e.Key == Key.NumPad5)
                {
                    lblBoxProcedure(lblBox05);
                }
                else if (e.Key == Key.NumPad6)
                {
                    lblBoxProcedure(lblBox06);
                }
                else if (e.Key == Key.NumPad1)
                {
                    lblBoxProcedure(lblBox07);
                }
                else if (e.Key == Key.NumPad2)
                {
                    lblBoxProcedure(lblBox08);
                }
                else if (e.Key == Key.NumPad3)
                {
                    lblBoxProcedure(lblBox09);
                }
            }
            if ((e.Key == Key.Enter) || (e.Key == Key.Escape))
            {
                ClearWindow();
            }

        }

        private void gHelp_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("KataKati (Tic-tac-toe)"
                + Environment.NewLine + "v1.0"
                + Environment.NewLine
                + Environment.NewLine + "AI design, Graphics and Coding:"
                + Environment.NewLine + "    Md. Mahmudul Hasan Shohag"
                + Environment.NewLine + "    Founder, CEO of Imaginative World"
                + Environment.NewLine + "    shohag.imaginativeworld.org"
                + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine + "KataKati is an Open Source imagination of Imaginative World"
                + Environment.NewLine + "under MPL 2.0."
                + Environment.NewLine + "Copyright © Imaginative World. All rights reserved."
                + Environment.NewLine + "imaginativeworld.org"
                + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine + "Help:"
                + Environment.NewLine + "    * Use <Mouse> and/or <Num Pad> Keys (1 to 9) for playing."
                + Environment.NewLine + "    * Use <Enter> or <Escape> for restart the game."
                + Environment.NewLine + @"    * Click top-right Green ""E"" button to change the game difficulty (Easy, Normal, eXtreme)."
                + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine + "Credits:"
                + Environment.NewLine + "Used fonts: Kalpurush (omicronlab.com), Arial Unicode MS"
                + Environment.NewLine
                + Environment.NewLine
                + Environment.NewLine + "Share with your friend if you like this game :)"
                + Environment.NewLine
                + Environment.NewLine + "Like us on facebook:"
                + Environment.NewLine + "    fb.com/Imaginative.World.BD",
                "KataKati | Info", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void gMode_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            /// Change Difficulty
        {
            if ((IsNormalMood == true) && (IsXtremeMood == false))
            {
                gMode.Background = new SolidColorBrush(Color.FromRgb(218, 41, 41)); //Red
                lblMood.Content = "X";
                gMode.ToolTip = "eXtreme Mode";
                IsXtremeMood = true;
            }
            else if (IsXtremeMood == true)
            {
                gMode.Background = new SolidColorBrush(Color.FromRgb(132, 183, 0)); //Green
                lblMood.Content = "E";
                gMode.ToolTip = "Easy Mode";
                IsNormalMood = false;
                IsXtremeMood = false;
            }
            else
            {
                gMode.Background = new SolidColorBrush(Color.FromRgb(254, 153, 0)); //Yellow
                lblMood.Content = "N";
                gMode.ToolTip = "Normal Mode";
                IsNormalMood = true;
            }

        }

        private void rBtnHvs_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as RadioButton).Name == "rBtnHvsCPU")
            {
                option = 1;
                gMode.IsEnabled = true;
            }
            else if ((sender as RadioButton).Name == "rBtnHvsH")
            {
                option = 2;
                gMode.IsEnabled = false;
            }
        }


    }
}
