using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Common
{
    #region Person class
    /// <summary>
    /// This class represnts a single chat user that can participate in this chat application
    /// This class implements INotifyPropertyChanged to support one-way and two-way
    /// WPF bindings (such that the UI element updates when the source has been changed
    /// dynamically)
    /// [DataContract] specifies that the type defines or implements a data contract
    /// and is serializable by a serializer, such as the DataContractSerializer
    /// </summary>
    [DataContract]
    public class Person : INotifyPropertyChanged
    {
        #region Instance Fields
        private string imageURL;
        private string name;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Ctors
        /// <summary>
        /// Blank constructor
        /// </summary>
        public Person()
        {
        }
        
        /// <summary>
        /// Assign constructor
        /// </summary>
        /// <param name="imageURL">Image url to allow a picture to be created for this chatter</param>
        /// <param name="name">The name to use for this chatter</param>
        public Person(string imageURL, string name)
        {
            this.imageURL = imageURL;
            this.name = name;
        }
        #endregion
        #region Public Properties
        /// <summary>
        /// The chatters image url
        /// </summary>
        [DataMember]
        public string ImageURL
        {
            get { return imageURL; }
            set
            {
                imageURL = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("ImageURL");
            }
        }

        /// <summary>
        /// The chatters Name
        /// </summary>
        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("Name");
            }
        }
        #endregion
        #region OnPropertyChanged (for correct well behaved databinding)
        /// <summary>
        /// Notifies the parent bindings (if any) that a property
        /// value changed and that the binding needs updating
        /// </summary>
        /// <param name="propValue">The property which changed</param>
        protected void OnPropertyChanged(string propValue)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propValue));
            }
        }
        #endregion
    }
    #endregion
}
