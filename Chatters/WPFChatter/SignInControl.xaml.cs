using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Common;

namespace WPFChatter
{
    #region ChatControl class
    /// <summary>
    /// This class represents a signin control, which is used to create a new
    /// chatter. The user is expected to pick a name and an image. When they
    /// have done this a new <see cref="Common.Person">chatter </see>
    /// is created
    /// 
    /// This provides the logic for the user control, whilst the SignInControl.xaml
    /// provides the WPF UI design.
    /// </summary>
    public partial class SignInControl : System.Windows.Controls.UserControl
    {
        #region Instance Fields
        string photoPath;
        Person currentPerson;
        #endregion
        #region Routed Events

        /// <summary>
        /// AddButtonClickEvent event, occurs when the user clicks the add button
        /// </summary>
        public static readonly RoutedEvent AddButtonClickEvent = EventManager.RegisterRoutedEvent(
            "AddButtonClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SignInControl));

        /// <summary>
        /// Expose the AddButtonClick to external sources
        /// </summary>
        public event RoutedEventHandler AddButtonClick
        {
            add { AddHandler(AddButtonClickEvent, value); }
            remove { RemoveHandler(AddButtonClickEvent, value); }
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Blank constructor
        /// </summary>
        public SignInControl()
        {
            InitializeComponent();
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// The current <see cref="Common.Person">chatter</see>
        /// </summary>
        public Person CurrentPerson
        {
            get { return currentPerson; }
            set { currentPerson = value; }
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// If there is a chatter name and image provided
        /// the currentPerson property is set to be a new
        /// <see cref="Common.Person">chatter</see> and the
        /// AddButtonClickEvent is raised which is used by the
        /// parent <see cref="Window1">window</see>
        /// </summary>
        /// <param name="sender">AddButton</param>
        /// <param name="e">The event args</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) &&
               !string.IsNullOrEmpty(photoPath))
            {
                currentPerson = new Person(photoPath, txtName.Text);
                RaiseEvent(new RoutedEventArgs(AddButtonClickEvent));
            }
            else
            {
                MessageBox.Show("You need to pick a screen name and image", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(0);
        }

        /// <summary>
        /// Handles Drop Event for Avatar photo.
        /// </summary>
        private void Photo_Drop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            if (fileNames.Length > 0)
            {
                photoPath = fileNames[0];
                photoSrc.Source = new BitmapImage(new Uri(photoPath));
            }

            // Mark the event as handled, so the control's native Drop handler is not called.
            e.Handled = true;
        }

        #endregion
    }
    #endregion
}