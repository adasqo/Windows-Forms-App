using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Xml;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Input;
using System.Windows.Controls;
using System.Linq;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public enum GenderTypes { Male, Female };
    public partial class Window1 : Window
    {
        public ObservableCollection<Contact> listOfContacts;
        bool canAccept;
        public Window1()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = Enum.GetValues(typeof(GenderTypes));
            GenderComboBox.SelectedIndex = 0;
            listOfContacts = new ObservableCollection<Contact>();
            canAccept = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            canAccept = true;
            string name ="", surname ="", email ="", phone = "";
            if (NameTextBox.Visibility == Visibility.Visible)
                name = NameTextBox.Text;
            if (NameTextBox1.Visibility == Visibility.Visible)
            {
                name = NameTextBox1.Text;
                if (name.Length < 5)
                    canAccept = false;
            }
            if (NameTextBox2.Visibility == Visibility.Visible)
            {
                name = NameTextBox2.Text;
                var re = new Regex(@".{1,}@.{1,}\..{2,}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(name))
                    canAccept = false;
            }
            if (NameTextBox3.Visibility == Visibility.Visible)
            {
                name = NameTextBox3.Text;
                var re = new Regex(@"[1-9]{3}-[1-9]{3}-[1-9]{3}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(name))
                    canAccept = false;
            }
            if (SurnameTextBox.Visibility == Visibility.Visible)
                surname = SurnameTextBox.Text;
            if (SurnameTextBox1.Visibility == Visibility.Visible)
            {
                surname = SurnameTextBox1.Text;
                if(surname.Length < 5)
                    canAccept = false;
            }
            if (SurnameTextBox2.Visibility == Visibility.Visible)
            {
                surname = SurnameTextBox2.Text;
                var re = new Regex(@".{1,}@.{1,}\..{2,}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(surname))
                    canAccept = false;
            }
            if (SurnameTextBox3.Visibility == Visibility.Visible)
            {
                surname = SurnameTextBox3.Text;
                var re = new Regex(@"[1-9]{3}-[1-9]{3}-[1-9]{3}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(surname))
                    canAccept = false;
            }
            if (EmailTextBox.Visibility == Visibility.Visible)
                email = EmailTextBox.Text;
            if (EmailTextBox1.Visibility == Visibility.Visible)
            {
                email = EmailTextBox1.Text;
                if (email.Length < 5)
                    canAccept = false;
            }
            if (EmailTextBox2.Visibility == Visibility.Visible)
            {
                email = EmailTextBox2.Text;
                var re = new Regex(@".{1,}@.{1,}\..{2,}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(email))
                    canAccept = false;
            }
            if (EmailTextBox3.Visibility == Visibility.Visible)
            {
                email = EmailTextBox3.Text;
                var re = new Regex(@"[1-9]{3}-[1-9]{3}-[1-9]{3}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(email))
                    canAccept = false;
            }
            if (PhoneTextBox.Visibility == Visibility.Visible)
                phone = PhoneTextBox.Text;
            if (PhoneTextBox1.Visibility == Visibility.Visible)
            {
                phone = PhoneTextBox1.Text;
                if (phone.Length < 5)
                    canAccept = false;
            }
            if (PhoneTextBox2.Visibility == Visibility.Visible)
            {
                phone = PhoneTextBox2.Text;
                var re = new Regex(@".{1,}@.{1,}\..{2,}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(phone))
                    canAccept = false;
            }
            if (PhoneTextBox3.Visibility == Visibility.Visible)
            {
                phone = PhoneTextBox3.Text;
                var re = new Regex(@"[1-9]{3}-[1-9]{3}-[1-9]{3}", RegexOptions.IgnoreCase);
                if (!re.IsMatch(phone))
                    canAccept = false;
            }
            if (!canAccept)
                return;
            listOfContacts.Add(new Contact(name, surname, email, phone, GenderComboBox.Text));
            Close();
        }
    }
    public partial class MainWindow : Window
    {
        [XmlElement("Contacts")]
        ObservableCollection<Contact> listOfContacts;
        Window1 window1;
        int indexOfActive;
        int nameVisibilityIndex, surnameVisibilityIndex, emailVisibilityIndex, phoneVisibilityIndex;
        int nameVisibilityIndexPrev, surnameVisibilityIndexPrev, emailVisibilityIndexPrev, phoneVisibilityIndexPrev;
        public MainWindow()
        {
            InitializeComponent();
            listOfContacts = new ObservableCollection<Contact>();
            MyDataGrid.DataContext = listOfContacts;
            MyContactList.ItemsSource = listOfContacts;
            DataGridComboBox.ItemsSource = Enum.GetValues(typeof(GenderTypes));
            indexOfActive = -1;
            nameVisibilityIndex = surnameVisibilityIndex = emailVisibilityIndex = phoneVisibilityIndex = 0;
            nameVisibilityIndexPrev = surnameVisibilityIndexPrev = emailVisibilityIndexPrev = phoneVisibilityIndexPrev = 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is simple contact manager.");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Opacity = 0.5;
            window1 = new Window1();

            if(nameVisibilityIndex > 0)
            {
                window1.NameTextBox.Visibility = Visibility.Collapsed;
                if(nameVisibilityIndex == 1)
                    window1.NameTextBox1.Visibility = Visibility.Visible;
                if (nameVisibilityIndex == 2)
                    window1.NameTextBox2.Visibility = Visibility.Visible;
                if (nameVisibilityIndex == 3)
                    window1.NameTextBox3.Visibility = Visibility.Visible;
            }
            if (surnameVisibilityIndex > 0)
            {
                window1.SurnameTextBox.Visibility = Visibility.Collapsed;
                if (surnameVisibilityIndex == 1)
                    window1.SurnameTextBox1.Visibility = Visibility.Visible;
                if (surnameVisibilityIndex == 2)
                    window1.SurnameTextBox2.Visibility = Visibility.Visible;
                if (surnameVisibilityIndex == 3)
                    window1.SurnameTextBox3.Visibility = Visibility.Visible;
            }
            if (emailVisibilityIndex > 0)
            {
                window1.EmailTextBox.Visibility = Visibility.Collapsed;
                if (emailVisibilityIndex == 1)
                    window1.EmailTextBox1.Visibility = Visibility.Visible;
                if (emailVisibilityIndex == 2)
                    window1.EmailTextBox2.Visibility = Visibility.Visible;
                if (emailVisibilityIndex == 3)
                    window1.EmailTextBox3.Visibility = Visibility.Visible;
            }
            if (phoneVisibilityIndex > 0)
            {
                window1.PhoneTextBox.Visibility = Visibility.Collapsed;
                if (phoneVisibilityIndex == 1)
                    window1.PhoneTextBox1.Visibility = Visibility.Visible;
                if (phoneVisibilityIndex == 2)
                    window1.PhoneTextBox2.Visibility = Visibility.Visible;
                if (phoneVisibilityIndex == 3)
                    window1.PhoneTextBox3.Visibility = Visibility.Visible;
            }
            window1.Closed += new EventHandler(SecondWindow_Closing);
            window1.ShowDialog();
        }
        void SecondWindow_Closing(object sender, EventArgs e)
        {
            foreach (Contact c in window1.listOfContacts)
                listOfContacts.Add(c);
            listOfContacts.Reverse<Contact>();
            MyContactList.ItemsSource = listOfContacts;
            MyDataGrid.DataContext = listOfContacts;
            CreateColorPattern();
            RemoveLastElement();
            Opacity = 1;
            ListBoxItem item = null;
            if (indexOfActive > -1)
                item = (ListBoxItem)MyContactList.ItemContainerGenerator.ContainerFromIndex(indexOfActive);
            if (item == null)
                return;
            item.Template = (ControlTemplate)FindResource("ContactTemplateMore");
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            listOfContacts.Clear();
            MyContactList.Items.Refresh();
            MyDataGrid.Items.Refresh();
            RemoveLastElement();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML documents (.xml)|*.xml";
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            if (fileName == null || fileName == "")
                return;
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };
            var emptyNs = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(ObservableCollection<Contact>));
            System.IO.FileStream file = System.IO.File.Create(fileName);
            file.SetLength(0);
            writer.Serialize(file, listOfContacts, emptyNs);
            file.Close();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = "xml";
            openFileDialog.Filter = "XML documents (.xml)|*.xml";
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            if (fileName == null || fileName == "")
                return;
            listOfContacts.Clear();
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "ArrayOfContact";
                xRoot.IsNullable = true;
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Contact>));

                listOfContacts = (ObservableCollection<Contact>)(serializer.Deserialize(fileStream));
            }
            MyContactList.ItemsSource = listOfContacts;
            MyDataGrid.DataContext = listOfContacts;
            CreateColorPattern();
            RemoveLastElement();
        }
        private void PlaceholdersListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(sender as ListBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item == null)
                return;

            CreateColorPattern();
            item.Template = (ControlTemplate)FindResource("ContactTemplateMore");
            indexOfActive = MyContactList.ItemContainerGenerator.IndexFromContainer(item);
            RemoveLastElement();
        }
        private void RowEditEnding_Event(object sender, DataGridRowEditEndingEventArgs e)
        {
            MyContactList.ItemTemplate = (DataTemplate)FindResource("ContactTemplateLess");
            RemoveLastElement();
        }
        private void DeleteEvent(object sender, RoutedEventArgs e)
        {
            listOfContacts.RemoveAt(indexOfActive);
            MyDataGrid.Items.Refresh();
            MyContactList.Items.Refresh();
            CreateColorPattern();
            RemoveLastElement();
        }
        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Visibility = Visibility.Collapsed;
            ValidationTextBlock.Visibility = Visibility.Visible;
            ValidationGrid.Visibility = Visibility.Visible;
            emptyTextBlock.Text = "1";
            nameVisibilityIndex = nameVisibilityIndexPrev;
            surnameVisibilityIndex = surnameVisibilityIndexPrev;
            emailVisibilityIndex = emailVisibilityIndexPrev;
            phoneVisibilityIndex = phoneVisibilityIndexPrev;
        }
        private void LockValidationButton_Event(object sender, RoutedEventArgs e)
        {
            ValidationGrid.Visibility = Visibility.Collapsed;
            ValidationTextBlock.Visibility = Visibility.Collapsed;
            ValidationButton.Visibility = Visibility.Visible;
            emptyTextBlock.Text = "0";
            nameVisibilityIndexPrev = nameVisibilityIndex;
            surnameVisibilityIndexPrev = surnameVisibilityIndex;
            emailVisibilityIndexPrev = emailVisibilityIndex;
            phoneVisibilityIndexPrev = phoneVisibilityIndex;
            nameVisibilityIndex = surnameVisibilityIndex = emailVisibilityIndex = phoneVisibilityIndex = 0;
        }
        private void CreateColorPattern()
        {
            for (int i = 0; i < MyContactList.Items.Count; i++)
            {
                ListBoxItem item2 = (ListBoxItem)MyContactList.ItemContainerGenerator.ContainerFromIndex(i);
                if (item2 == null)
                {
                    MyContactList.UpdateLayout();
                    MyContactList.ScrollIntoView(MyContactList.Items[i]);
                    item2 = (ListBoxItem)MyContactList.ItemContainerGenerator.ContainerFromIndex(i);
                }
                if (i % 2 == 0)
                    item2.Template = (ControlTemplate)FindResource("ContactTemplateLessControl1");
                else
                    item2.Template = (ControlTemplate)FindResource("ContactTemplateLessControl2");
            }
        }
        private void RemoveLastElement()
        {
            int index = MyContactList.Items.Count - 1;
            ListBoxItem item3 = (ListBoxItem)MyContactList.ItemContainerGenerator.ContainerFromIndex(index);
            if (item3 == null)
            {
                MyContactList.UpdateLayout();
                MyContactList.ScrollIntoView(MyContactList.Items[index]);
                item3 = (ListBoxItem)MyContactList.ItemContainerGenerator.ContainerFromIndex(index);
            }
            item3.Visibility = Visibility.Hidden;
        }
        private void ValidationComboBoxName_Event(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            switch (text)
            {
                case "Content length rule":
                    nameVisibilityIndex = 1;
                    break;
                case "Email rule":
                    nameVisibilityIndex = 2;
                    break;
                case "Phone rule":
                    nameVisibilityIndex = 3;
                    break;
            }
        }
        private void ValidationComboBoxSurname_Event(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            switch (text)
            {
                case "Content length rule":
                    surnameVisibilityIndex = 1;
                    break;
                case "Email rule":
                    surnameVisibilityIndex = 2;
                    break;
                case "Phone rule":
                    surnameVisibilityIndex = 3;
                    break;
            }
        }
        private void ValidationComboBoxEmail_Event(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            switch (text)
            {
                case "Content length rule":
                    emailVisibilityIndex = 1;
                    break;
                case "Email rule":
                    emailVisibilityIndex = 2;
                    break;
                case "Phone rule":
                    emailVisibilityIndex = 3;
                    break;
            }
        }
        private void ValidationComboBoxPhone_Event(object sender, SelectionChangedEventArgs e)
        {
            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            switch (text)
            {
                case "Content length rule":
                    phoneVisibilityIndex = 1;
                    break;
                case "Email rule":
                    phoneVisibilityIndex = 2;
                    break;
                case "Phone rule":
                    phoneVisibilityIndex = 3;
                    break;
            }
        }
    }
    public class Contact
    {
        [XmlElement]
        public string Name { get; set; }
        [XmlElement]
        public string Surname { get; set; }
        [XmlElement]
        public string Email { get; set; }
        [XmlElement]
        public string PhoneNumber { get; set; }
        [XmlElement]
        public string Gender { get; set; }
        public Contact()
        {
        }
        public Contact(string name, string lastName, string email, string phoneNumber, string gender)
        {
            Name = name;
            Surname = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Gender = gender;
        }
    }
    class GenderToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "" || (string)value == null)
                return $@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\man.png";
            if ((string)value == "Male")
                return $@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\man.png";
            if ((string)value == "Female")
                return $@"{AppDomain.CurrentDomain.BaseDirectory}\Resources\woman.jpg";
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    class ValidationBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string number)
            {
                if (number == "0")
                    return "#FFDCDCDC";
                if (number == "1")
                    return "#00FFFFFF";
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string)value.ToString();
        }
    }
}
