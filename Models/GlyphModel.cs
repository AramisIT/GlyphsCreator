namespace GlyphsCreator.Models
    {
    using System.Collections.Generic;
    using System.ComponentModel;

    public class GlyphModel : INotifyPropertyChanged
        {
        private long glyphData;

        public long GlyphData
            {
            get { return glyphData; }
            set
                {
                setPropertyValue(ref glyphData, value, nameof(this.GlyphData));
                }
            }

        private int glyphCodeType;
        public int GlyphCodeType
            {
            get { return glyphCodeType; }
            set
                {
                setPropertyValue(ref glyphCodeType, value, nameof(this.GlyphCodeType));
                }
            }

        private void setPropertyValue<T>(ref T propertyValueHolder, T value, string propertyName)
            {
            if (EqualityComparer<T>.Default.Equals(propertyValueHolder, value)) return;

            propertyValueHolder = value;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        }
    }
