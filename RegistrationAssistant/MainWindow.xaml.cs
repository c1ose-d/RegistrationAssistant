using System;
using System.Windows;
using System.Windows.Controls;

namespace RegistrationAssistant
{
    public partial class MainWindow : Window
    {
        const int fontSize = 24;
        const int minWidth = 500;

        int TLevel { get; set; }

        readonly Transliteration transliteration = new Transliteration();
        readonly PasswordGenerator passwordGenerator = new PasswordGenerator();

        StackPanel originalNameCommands = new StackPanel
        {
            Orientation = Orientation.Horizontal
        };
        TextBox originalName = new TextBox
        {
            FontSize = fontSize,
            MinWidth = minWidth
        };
        Button oSurnameCopy = new Button
        {
            Content = "Ф",
            FontSize = fontSize
        };
        Button oNameCopy = new Button
        {
            Content = "И",
            FontSize = fontSize
        };
        Button oPatronymicCopy = new Button
        {
            Content = "О",
            FontSize = fontSize
        };
        Button oNamePatronymicCopy = new Button
        {
            Content = "ИО",
            FontSize = fontSize
        };

        StackPanel transliteratedNameCommands = new StackPanel
        {
            Orientation = Orientation.Horizontal
        };
        TextBox transliteratedName = new TextBox
        {
            FontSize = fontSize,
            MinWidth = minWidth
        };
        Button tMore = new Button
        {
            Content = ">",
            FontSize = fontSize
        };
        Button tCopy = new Button
        {
            Content = "C",
            FontSize = fontSize
        };


        StackPanel passwordCommands = new StackPanel
        {
            Orientation = Orientation.Horizontal
        };
        TextBox password = new TextBox
        {
            FontSize = fontSize,
            MinWidth = minWidth
        };
        Button pCopy = new Button
        {
            Content = "C",
            FontSize = fontSize
        };

        StackPanel executeCommand = new StackPanel();
        Button execute = new Button
        {
            Content = "EXECUTE",
            FontSize = fontSize
        };
        Button copyAll = new Button
        {
            Content = "COPY ALL",
            FontSize = fontSize
        };

        public MainWindow()
        {
            InitializeComponent();

            Content = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            (Content as StackPanel).Children.Add(originalNameCommands);
            originalNameCommands.Children.Add(originalName);
            originalNameCommands.Children.Add(oSurnameCopy);
            oSurnameCopy.Click += OSurnameCopy_Click;
            originalNameCommands.Children.Add(oNameCopy);
            oNameCopy.Click += ONameCopy_Click; ;
            originalNameCommands.Children.Add(oPatronymicCopy);
            oPatronymicCopy.Click += OPatronymicCopy_Click; ;
            originalNameCommands.Children.Add(oNamePatronymicCopy);
            oNamePatronymicCopy.Click += ONamePatronymicCopy_Click; ;

            (Content as StackPanel).Children.Add(transliteratedNameCommands);
            transliteratedNameCommands.Children.Add(transliteratedName);
            transliteratedNameCommands.Children.Add(tMore);
            tMore.Click += TMore_Click; ;
            transliteratedNameCommands.Children.Add(tCopy);
            tCopy.Click += TCopy_Click;

            (Content as StackPanel).Children.Add(passwordCommands);
            passwordCommands.Children.Add(password);
            passwordCommands.Children.Add(pCopy);
            pCopy.Click += PCopy_Click;

            (Content as StackPanel).Children.Add(executeCommand);
            executeCommand.Children.Add(execute);
            execute.Click += Execute_Click;
            executeCommand.Children.Add(copyAll);
            copyAll.Click += CopyAll_Click;
        }

        private void CopyAll_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText($"{originalName.Text}\n{transliteratedName.Text}\n{password.Text}");
        }

        private void Execute_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = originalName.Text.Split(' ');
                transliteratedName.Text = transliteration.Execute($"{parts[0]}.{parts[1][0]}{parts[2][0]}");
                password.Text = passwordGenerator.Execute();
            }
            catch (Exception) { }
        }

        private void OSurnameCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = originalName.Text.Split(' ');
                Clipboard.SetText(parts[0]);
            }
            catch (Exception) { }
        }

        private void ONameCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = originalName.Text.Split(' ');
                Clipboard.SetText(parts[1]);
                TLevel = 1;
            }
            catch (Exception) { }
        }

        private void OPatronymicCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = originalName.Text.Split(' ');
                Clipboard.SetText(parts[2]);
            }
            catch (Exception) { }
        }

        private void ONamePatronymicCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = originalName.Text.Split(' ');
                Clipboard.SetText(parts[1] + " " + parts[2]);
            }
            catch (Exception) { }
        }

        private void TMore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] parts = originalName.Text.Split(' ');
                string newTransliteration = transliteration.Execute(parts[0]) + ".";
                if (TLevel % 2 == 0)
                {
                    for (int i = 0; i < TLevel + 2; i++)
                        newTransliteration += transliteration.Execute(parts[1][i].ToString());
                    for (int i = 0; i < TLevel + 1; i++)
                        newTransliteration += transliteration.Execute(parts[2][i].ToString());
                }
                else
                {
                    for (int i = 0; i < TLevel + 1; i++)
                        newTransliteration += transliteration.Execute(parts[1][i].ToString());
                    for (int i = 0; i < TLevel + 1; i++)
                        newTransliteration += transliteration.Execute(parts[2][i].ToString());
                }
                transliteratedName.Text = newTransliteration;
                TLevel++;
            }
            catch (Exception) { }
        }

        private void TCopy_Click(object sender, RoutedEventArgs e) =>
            Clipboard.SetText(transliteratedName.Text);

        private void PCopy_Click(object sender, RoutedEventArgs e) =>
            Clipboard.SetText(password.Text);
    }
}
